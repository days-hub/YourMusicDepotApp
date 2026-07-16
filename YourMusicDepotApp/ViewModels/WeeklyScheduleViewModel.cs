using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using YourMusicDepotApp.Models;
using YourMusicDepotApp.Repositories.Interfaces;

namespace YourMusicDepotApp.ViewModels
{
  
    /// ViewModel for managing the weekly schedule of music lessons in the YourMusicDepot application.
    /// Implements INotifyPropertyChanged for data binding and UI updates.
 
    public class WeeklyScheduleViewModel : INotifyPropertyChanged
    {
        private readonly IMusicLessonRepository _musicLessonRepository;

        // Holds a collection of ScheduleAppointment objects for display in the UI.
        public ObservableCollection<ScheduleAppointment> ScheduleAppointments { get; private set; }

        // Backing field for the search query used in filtering the weekly schedule.
        private string _weeklyScheduleSearchQuery;
        public string WeeklyScheduleSearchQuery
        {
            get => _weeklyScheduleSearchQuery;
            set
            {
                _weeklyScheduleSearchQuery = value;
                OnPropertyChanged(nameof(WeeklyScheduleSearchQuery));
            }
        }

        // Backing field for the selected date, used to load lessons for a specific day.
        private DateTime _selectedDate;
        public DateTime SelectedDate
        {
            get => _selectedDate;
            set
            {
                if (_selectedDate != value)
                {
                    _selectedDate = value;
                    OnPropertyChanged(nameof(SelectedDate));
                    // Load music lessons for the newly selected date.
                }
            }
        }

      
        // Asynchronously loads and filters music lessons based on the provided search query.
       
        // <param name="searchQuery">The query used for filtering lessons.</param>
        private async void LoadMusicLessonsFiltered(string searchQuery)
        {
            var musicLessons = await _musicLessonRepository.GetAllAsync();
            var filteredLessons = string.IsNullOrEmpty(searchQuery)
                ? musicLessons
                : musicLessons.Where(lesson => lesson.Instructor.FullName.Contains(searchQuery, StringComparison.OrdinalIgnoreCase)
                                              || lesson.Student.FullName.Contains(searchQuery, StringComparison.OrdinalIgnoreCase));

            var scheduleAppointments = filteredLessons.Select(lesson => ConvertToScheduleAppointment(lesson)).ToList();
            ScheduleAppointments = new ObservableCollection<ScheduleAppointment>(scheduleAppointments);
            OnPropertyChanged(nameof(ScheduleAppointments));
        }

        // ICommand property for executing the search action.
        public ICommand SearchWeeklyScheduleCommand { get; private set; }

       
        // Constructor for WeeklyScheduleViewModel.
        // Initializes the ViewModel and loads the weekly music lessons.
    
        // <param name="musicLessonRepository">Repository for accessing music lesson data.</param>
        public WeeklyScheduleViewModel(IMusicLessonRepository musicLessonRepository)
        {
            _musicLessonRepository = musicLessonRepository;
            ScheduleAppointments = new ObservableCollection<ScheduleAppointment>();
            LoadMusicLessonsWeekly();
            InitializeCommands();
        }

       
        // Initializes the command used in the ViewModel.
       
        private void InitializeCommands()
        {
            SearchWeeklyScheduleCommand = new RelayCommand(SearchWeeklyScheduleExecute);
        }

      
        // Asynchronously loads music lessons for the current week.
      
        private async void LoadMusicLessonsWeekly()
        {
            var musicLessons = await _musicLessonRepository.GetAllAsync();
            var scheduleAppointments = musicLessons.Select(lesson => ConvertToScheduleAppointment(lesson)).ToList();

            ScheduleAppointments = new ObservableCollection<ScheduleAppointment>(scheduleAppointments);
            OnPropertyChanged(nameof(ScheduleAppointments));
        }

      
        // Converts a MusicLesson object to a ScheduleAppointment object for display.
       
       
        private ScheduleAppointment ConvertToScheduleAppointment(MusicLesson lesson)
        {
            return new ScheduleAppointment
            {
                StartTime = lesson.MusicLessonStartDateTime,
                EndTime = lesson.MusicLessonEndDateTime,
                Subject = $"Lesson with {lesson.Instructor.FullName} and {lesson.Student.FullName}",
                Status = lesson.MusicLessonStatus,
                ForegroundColor = new SolidColorBrush(Colors.White),

                // Other properties and mappings as per the ScheduleAppointment model.
            };
        }

        
        // Executes the search command to filter lessons based on the search query.
      
       
        private void SearchWeeklyScheduleExecute(object parameter)
        {
            try
            {
                System.Diagnostics.Debug.WriteLine("Search command initiated.");
                LoadMusicLessonsFiltered(WeeklyScheduleSearchQuery);
                System.Diagnostics.Debug.WriteLine("Search command completed successfully.");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception occurred: " + ex.Message);
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Event and method for INotifyPropertyChanged implementation.
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
