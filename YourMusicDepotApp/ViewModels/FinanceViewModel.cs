using LiveCharts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using YourMusicDepotApp.Models;
using YourMusicDepotApp.Repositories.Interfaces;
using YourMusicDepotApp.Views;

public class FinanceViewModel : INotifyPropertyChanged
{
    private readonly IMusicLessonPaymentRepository _paymentRepository;
    private readonly IMusicLessonRepository _lessonRepository;
    private ObservableCollection<MusicLessonPayment> _payments;
    private MusicLessonPayment _selectedPayment;
    //Payment commands
    public ICommand ShowRevenueCommand { get; private set; }
    public ICommand AddPaymentCommand { get; private set; }
    public ICommand EditPaymentCommand { get; private set; }
    public ICommand DeletePaymentCommand { get; private set; }
    public ICommand SearchDateOrStudentCommand { get; private set; }

    //Pass Payment repo and Lesson Repo
    public FinanceViewModel(IMusicLessonPaymentRepository paymentRepository, IMusicLessonRepository lessonRepository)
    {
        _paymentRepository = paymentRepository;
        _lessonRepository = lessonRepository;
        AddPaymentCommand = new RelayCommand(param => AddPaymentAsync());
        EditPaymentCommand = new RelayCommand(param => EditPayment(), param => SelectedPayment != null);
        DeletePaymentCommand = new RelayCommand(param => DeletePaymentAsync(), param => SelectedPayment != null);
        SearchDateOrStudentCommand = new RelayCommand(param => SearchDateOrStudent());
        ShowRevenueCommand = new RelayCommand(param => CalculateRevenue());
        LoadPayments();
    }
    // Public property for selected payment
    public bool IsEditEnabled => SelectedPayment != null;
    public MusicLessonPayment SelectedPayment
    {
        get => _selectedPayment;
        set
        {
            if (_selectedPayment != value)
            {
                _selectedPayment = value;
                OnPropertyChanged(nameof(SelectedPayment));
                OnPropertyChanged(nameof(IsEditEnabled)); 
            }
        }
    }
    //Chart values for line graph 
    private ChartValues<decimal> _revenueValues;
    public ChartValues<decimal> RevenueValues
    {
        get => _revenueValues;
        set
        {
            _revenueValues = value;
            OnPropertyChanged(nameof(RevenueValues));
        }
    }
    //Search functionality 
    private string _searchQuery;
    public string SearchQuery
    {
        get => _searchQuery;
        set
        {
            _searchQuery = value;
            OnPropertyChanged(nameof(SearchQuery));
        }
    }
    //Date range for revenue
    private DateTime? _startDate;
    public DateTime? StartDate
    {
        get => _startDate;
        set
        {
            _startDate = value;
            OnPropertyChanged(nameof(StartDate));
        }
    }

    private DateTime? _endDate;
    public DateTime? EndDate
    {
        get => _endDate;
        set
        {
            _endDate = value;
            OnPropertyChanged(nameof(EndDate));
        }
    }
    

    //Observable collection for payments
    public ObservableCollection<MusicLessonPayment> Payments
    {
        get => _payments;
        set
        {
            _payments = value;
            OnPropertyChanged(nameof(Payments));
        }
    }
    //Revenue labels for line graph
    private string[] _revenueDateLabels;
    public string[] RevenueDateLabels
    {
        get => _revenueDateLabels;
        set
        {
            _revenueDateLabels = value;
            OnPropertyChanged(nameof(RevenueDateLabels));
        }
    }

    //Calculate revenue based on start and end date
    private void CalculateRevenue()
    {
        if (StartDate == null || EndDate == null)
        {
            MessageBox.Show("Please select both start and end dates.");
            return;
        }

        var revenueData = _paymentRepository.GetAll()
            .Where(payment => payment.MusicLessonPaymentDate >= StartDate && payment.MusicLessonPaymentDate <= EndDate)
            .GroupBy(payment => payment.MusicLessonPaymentDate.Date)
            .Select(group => new { Date = group.Key, TotalRevenue = group.Sum(payment => payment.MusicLessonPaymentAmount) })
            .OrderBy(result => result.Date)
            .ToList();

        // Update RevenueValues for the graph
        RevenueValues = new ChartValues<decimal>(revenueData.Select(data => data.TotalRevenue));
        RevenueDateLabels = revenueData.Select(data => data.Date.ToString("MM/dd/yyyy")).ToArray();

        OnPropertyChanged(nameof(RevenueValues));
        OnPropertyChanged(nameof(RevenueDateLabels));
    }
    //Search by date or student name
    private void SearchDateOrStudent()
    {
        if (string.IsNullOrWhiteSpace(SearchQuery))
        {
            LoadPayments(); // Load all payments if search query is empty
            return;
        }

        var lowerQuery = SearchQuery.ToLower();

        // Fetch the data first
        var allPayments = _paymentRepository.GetAll()
            .Include(payment => payment.MusicLesson)
            .ThenInclude(lesson => lesson.Student)
            .ToList();

        // Perform the filtering in memory
        var filteredPayments = allPayments
            .Where(payment => payment.MusicLesson.Student.FullName.ToLower().Contains(lowerQuery) ||
                              payment.MusicLessonPaymentDate.ToString().Contains(lowerQuery))
            .ToList();

        Payments = new ObservableCollection<MusicLessonPayment>(filteredPayments);
    }
    //Add payment functionality
    private async void AddPaymentAsync()
    {
        // Fetch lessons without payments
        var lessonsWithoutPayments = await _lessonRepository.GetLessonsWithoutPaymentsAsync();

        
        var addPaymentWindow = new AddPaymentWindow(lessonsWithoutPayments);
        var result = addPaymentWindow.ShowDialog();

        if (result == true) // If the user clicked Save/Confirm
        {
            var newPayment = addPaymentWindow.NewPayment; // Assume this is the payment details entered by the user

            // Create and save the new payment
            await _paymentRepository.AddAsync(newPayment);
            LoadPayments(); // Refresh the payment list
        }
    }

    //Load payments
    private async void LoadPayments()
    {
        var query = _paymentRepository.GetAll(); // This gets the IQueryable
        var payments = await query.ToListAsync(); // Execute the query asynchronously
        Payments = new ObservableCollection<MusicLessonPayment>(payments);
    }
    //Delete payment
    private async Task DeletePaymentAsync()
    {
        if (SelectedPayment == null)
        {
            MessageBox.Show("No payment selected.", "Error");
            return;
        }

        MessageBoxResult confirmResult = MessageBox.Show("Are you sure to delete this payment?", "Confirm Delete", MessageBoxButton.YesNo);
        if (confirmResult == MessageBoxResult.Yes)
        {
            await _paymentRepository.DeleteAsync(SelectedPayment.MusicLessonPaymentID);
            LoadPayments(); // Refresh the list of payments
        }
    }
    //INotifyPropertyChanged implementation
    public event PropertyChangedEventHandler PropertyChanged;
    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    // Make the EditPayment method async and return Task
    private async Task EditPayment()
    {
        if (SelectedPayment == null) return;

        var editPaymentWindow = new EditPaymentWindow(SelectedPayment);
        var result = editPaymentWindow.ShowDialog();

        if (result == true)
        {
            // UpdatedPayment has the updated values
            await _paymentRepository.UpdateAsync(SelectedPayment);
            LoadPayments(); // Refresh the list
        }
    }



}
