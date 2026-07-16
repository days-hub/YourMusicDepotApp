// Import necessary namespaces.
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using YourMusicDepotApp.Models;

namespace YourMusicDepotApp.Views
{
 
    /// Interaction logic for AddPaymentWindow.xaml.
    /// This class represents the window used for adding new payments in the YourMusicDepot application.
  
    public partial class AddPaymentWindow : Window, INotifyPropertyChanged
    {
        // Property to hold lessons that have not yet had payments made against them.
        private IEnumerable<MusicLesson> _lessonsWithoutPayments;

        // Command property for saving the payment information.
        public ICommand SavePaymentCommand { get; private set; }

        // Property representing the new payment to be added.
        public MusicLessonPayment NewPayment { get; private set; }

        private decimal _paymentAmount;
        private DateTime? _paymentDate;
        private string _paymentType;

        // Property for payment amount with notification on change.
        public decimal PaymentAmount
        {
            get => _paymentAmount;
            set
            {
                _paymentAmount = value;
                OnPropertyChanged(nameof(PaymentAmount));
            }
        }

        // Property for payment date with notification on change.
        public DateTime? PaymentDate
        {
            get => _paymentDate;
            set
            {
                _paymentDate = value;
                OnPropertyChanged(nameof(PaymentDate));
            }
        }

        // Property for payment type with notification on change.
        public string PaymentType
        {
            get => _paymentType;
            set
            {
                _paymentType = value;
                OnPropertyChanged(nameof(PaymentType));
            }
        }

        
        /// Constructor for AddPaymentWindow.
        /// Initializes the window and binds data for lessons without payments.
       
      
        public AddPaymentWindow(IEnumerable<MusicLesson> lessonsWithoutPayments)
        {
            // Initialize the UI components.
            InitializeComponent();
            _lessonsWithoutPayments = lessonsWithoutPayments;

            // Set the DataContext for the window to itself.
            DataContext = this;

            // Initialize SavePaymentCommand with a delegate to the SavePayment method.
            SavePaymentCommand = new RelayCommand(param => SavePayment());
        }

       
        /// Method to handle the logic for saving a new payment.
        /// Creates a new MusicLessonPayment instance and assigns values from the UI.
       
        private void SavePayment()
        {
            // Create and configure a new MusicLessonPayment object.
            NewPayment = new MusicLessonPayment
            {
                MusicLessonID = SelectedLesson.MusicLessonID,
                MusicLessonPaymentAmount = PaymentAmount,
                MusicLessonPaymentDate = PaymentDate ?? DateTime.Now,
                MusicLessonPaymentType = PaymentType
            };

            // Set the DialogResult to true and close the window.
            DialogResult = true;
            this.Close();
        }

        private MusicLesson _selectedLesson;

        // Property for the list of lessons without payments.
        public IEnumerable<MusicLesson> LessonsWithoutPayments
        {
            get => _lessonsWithoutPayments;
            set
            {
                _lessonsWithoutPayments = value;
                OnPropertyChanged(nameof(LessonsWithoutPayments));
            }
        }

        // Property for the selected lesson.
        public MusicLesson SelectedLesson
        {
            get => _selectedLesson;
            set
            {
                _selectedLesson = value;
                OnPropertyChanged(nameof(SelectedLesson));
            }
        }

        // Implement the INotifyPropertyChanged interface to notify the UI of property changes.
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
