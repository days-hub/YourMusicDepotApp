// Importing necessary namespaces for functionality
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using YourMusicDepotApp.Models;
using YourMusicDepotApp.ViewModels;
using YourMusicDepotApp.Repositories.Interfaces;
using System.Linq;
using YourMusicDepotApp.Views;
using System;
using System.Windows;
using System.CodeDom.Compiler;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

// Defining the ViewModel namespace of the application
namespace YourMusicDepotApp.ViewModels
{
    // ViewModel for scheduling-related functionalities
    public class SchedulingViewModel : INotifyPropertyChanged
    {
        // Repositories for accessing data related to music lessons, students, instructors, and rooms
        private readonly IMusicLessonRepository _musicLessonRepository;
        private readonly IStudentRepository _studentRepository;
        private readonly IInstructorRepository _instructorRepository;
        private readonly IRoomRepository _roomRepository;

        // Collection of MusicLessons for data binding
        public ObservableCollection<MusicLesson> MusicLessons { get; set; }

        // Collection of students for data binding
        public ObservableCollection<Student> Students { get; private set; }

        // MusicLesson object for adding new lessons
        public MusicLesson NewLesson { get; set; }

        public MusicLesson EditLesson { get; set; }

        // Event to notify when a new lesson is added
        public event Action OnNewLessonAdded;

        // ICommand properties for handling UI commands
        public ICommand EditLessonCommand { get; private set; }
        public ICommand DeleteLessonCommand { get; private set; }
        public ICommand AddLessonCommand { get; private set; }
        public ICommand SaveNewLessonCommand { get; private set; }
        public ICommand SaveLessonChangesCommand { get; private set; }
        public ICommand SearchDateCommand { get; private set; }

        // Properties for selected start and end times
        private TimeSpan _selectedStartTime;
        public TimeSpan SelectedStartTime
        {
            get => _selectedStartTime;
            set
            {
                _selectedStartTime = value;
                OnPropertyChanged(nameof(SelectedStartTime));
            }
        }

        private TimeSpan _selectedEndTime;
        public TimeSpan SelectedEndTime
        {
            get => _selectedEndTime;
            set
            {
                _selectedEndTime = value;
                OnPropertyChanged(nameof(SelectedEndTime));
            }
        }

        // Property for search query
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

        // Property for selected date
        private DateTime? _selectedDate;
        public DateTime? SelectedDate
        {
            get => _selectedDate;
            set
            {
                _selectedDate = value;
                OnPropertyChanged(nameof(SelectedDate));
                FilterLessonsOnSelectedDate(); // Filtering lessons based on the selected date
                UpdateRoomCapacities(); // Updating room capacities based on the selected date
            }
        }

        // Method to calculate the room capacity count
        public int GetRoomCapacityCount(int roomId, DateTime selectedDate)
        {
            // Check if there are any lessons
            if (MusicLessons == null)
                return 0;

            // Filtering lessons based on room and date
            var lessonsInRoom = MusicLessons.Where(m => m.RoomID == roomId && m.MusicLessonStartDateTime.Date == selectedDate.Date);
            var instructorCount = lessonsInRoom.Select(lesson => lesson.InstructorID).Distinct().Count();
            var studentCount = lessonsInRoom.Select(lesson => lesson.StudentID).Distinct().Count();

            // Returning the total count of instructors and students
            return instructorCount + studentCount;
        }

        // Event to handle when the calendar date changes
        public event Action<DateTime> OnCalendarDateChanged;

        // Method to filter lessons based on the selected date
        private async void FilterLessonsOnSelectedDate()
        {
            try
            {
                if (SelectedDate.HasValue)
                {
                    var filteredLessons = await _musicLessonRepository
                        .GetAllAsync()
                        .ConfigureAwait(false);

                    filteredLessons = filteredLessons
                        .Where(lesson => lesson.MusicLessonStartDateTime.Date == SelectedDate.Value.Date)
                        .OrderBy(lesson => lesson.MusicLessonStartDateTime)
                        .ToList();

                    // Assigning lesson numbers
                    int lessonNumber = 1;
                    foreach (var lesson in filteredLessons)
                    {
                        lesson.LessonNumber = lessonNumber++;
                    }

                    // Updating the MusicLessons collection
                    MusicLessons = new ObservableCollection<MusicLesson>(filteredLessons);
                    UpdateRoomCapacities(); // Update room capacities after updating lessons
                    OnPropertyChanged(nameof(MusicLessons));
                }
            }
            catch (Exception ex)
            {
                // Handling exceptions (could be logging or user notification)
            }
        }

        // Constructor for SchedulingViewModel
        public SchedulingViewModel(IMusicLessonRepository musicLessonRepository, IStudentRepository studentRepository, IInstructorRepository instructorRepository, IRoomRepository roomRepository)
        {
            _musicLessonRepository = musicLessonRepository;
            _studentRepository = studentRepository;
            _instructorRepository = instructorRepository;
            _roomRepository = roomRepository;

            MusicLessons = new ObservableCollection<MusicLesson>(); // Initializing the MusicLessons collection
            LoadMusicLessons(); // Loading music lessons

            InitializeCommands(); // Initializing commands
            LoadInstructors(); // Loading instructors
            LoadStudents(); // Loading students
            LoadRooms(); // Loading rooms
            InitializeStatusChoices(); // Initializing lesson status choices
            InitializeTimeOptions(); // Initializing time options

            SaveLessonChangesCommand = new RelayCommand(SaveLessonChangesExecute, CanSaveLessonChangesExecute);
            SelectedDate = DateTime.Today; // Setting the selected date to today
            FilterLessonsOnSelectedDate(); // Filtering lessons based on the selected date

            AddLessonCommand = new RelayCommand(AddLessonExecute);
            SaveNewLessonCommand = new RelayCommand(SaveNewLessonExecute, CanSaveNewLessonExecute);
            DeleteLessonCommand = new RelayCommand(DeleteLessonExecute, CanExecuteDeleteLesson);
            SearchDateCommand = new RelayCommand(SearchDateExecute);
        }

        // Executes the SearchDate command to filter lessons by a specific date
        private void SearchDateExecute(object parameter)
        {
            if (DateTime.TryParse(SearchQuery, out DateTime parsedDate))
            {
                SelectedDate = parsedDate;
                FilterLessonsOnSelectedDate();
                OnCalendarDateChanged?.Invoke(parsedDate); // Notify about the date change
            }
            else
            {
                MessageBox.Show("Invalid date format. Please enter a valid date.");
            }
        }

        // Checks if the SaveNewLesson command can be executed
        private bool CanSaveNewLessonExecute(object parameter)
        {
            // Ensure NewLesson is not null and all required fields are valid
            return NewLesson != null &&
                NewLesson.Instructor != null &&
                NewLesson.Student != null &&
                NewLesson.Room != null &&
                !string.IsNullOrWhiteSpace(NewLesson.MusicLessonStatus) &&
                NewLesson.MusicLessonStartDateTime != DateTime.MinValue &&
                NewLesson.MusicLessonEndDateTime != DateTime.MinValue &&
                NewLesson.MusicLessonStartDateTime < NewLesson.MusicLessonEndDateTime; // Start time should be before end time
        }

        // Executes the SaveNewLesson command to add a new lesson
        private async void SaveNewLessonExecute(object parameter)
        {
            if (NewLesson != null)
            {
                try
                {
                    // Combine the date and time for start and end
                    // Create a new instance of MusicLesson with ID properties
                    var lessonToAdd = new MusicLesson
                    {
                        InstructorID = NewLesson.Instructor?.InstructorID ?? 0,
                        StudentID = NewLesson.Student?.StudentID ?? 0,
                        RoomID = NewLesson.Room?.RoomID ?? 0,
                        MusicLessonStartDateTime = NewLesson.MusicLessonStartDateTime = NewLesson.MusicLessonStartDateTime.Date + SelectedStartTime,
                        MusicLessonEndDateTime = NewLesson.MusicLessonEndDateTime = NewLesson.MusicLessonEndDateTime.Date + SelectedEndTime,
                        MusicLessonStatus = NewLesson.MusicLessonStatus
                        // Set other properties of MusicLesson as necessary
                    };

                    await _musicLessonRepository.AddAsync(lessonToAdd);
                    MusicLessons.Add(lessonToAdd);
                    UpdateRoomCapacities();
                    OnPropertyChanged(nameof(MusicLessons));
                    MessageBox.Show("New lesson added successfully.");
                    // Refresh the lessons for the selected date
                    FilterLessonsOnSelectedDate();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error adding new lesson: {ex.Message}");
                }
            }
            // Raise the event after saving the lesson
            OnNewLessonAdded?.Invoke();
        }

        // Method to update room capacities for each lesson
        private void UpdateRoomCapacities()
        {
            if (SelectedDate.HasValue)
            {
                foreach (var lesson in MusicLessons)
                {
                    lesson.CurrentRoomCapacityCount = GetRoomCapacityCount(lesson.RoomID, SelectedDate.Value);
                }
            }
        }

        // Loads music lessons from the repository
        private async void LoadMusicLessons()
        {
            var lessons = await _musicLessonRepository.GetAllAsync();
            var lessonsList = lessons.ToList(); // Fetching data from the database
            foreach (var lesson in lessonsList)
            {
                lesson.CurrentRoomCapacityCount = GetRoomCapacityCount(lesson.RoomID, DateTime.Today);
            }

            MusicLessons = new ObservableCollection<MusicLesson>(lessonsList);
            OnPropertyChanged(nameof(MusicLessons));
        }

        // INotifyPropertyChanged implementation to update the UI on property changes
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        // Selected music lesson property for data binding
        private MusicLesson _selectedMusicLesson;
        public MusicLesson SelectedMusicLesson
        {
            get => _selectedMusicLesson;
            set
            {
                if (_selectedMusicLesson != value)
                {
                    _selectedMusicLesson = value;
                    OnPropertyChanged(nameof(SelectedMusicLesson));
                    (EditLessonCommand as RelayCommand)?.NotifyCanExecuteChanged();
                }
            }
        }

        // Initialize the commands for UI interactions
        private void InitializeCommands()
        {
            EditLessonCommand = new RelayCommand(
                EditLessonExecute,
                parameter => SelectedMusicLesson != null); // Can execute if a lesson is selected

            DeleteLessonCommand = new RelayCommand(DeleteLessonExecute, CanExecuteLessonCommand);
            // ... Other command initializations
        }

        // Gets the current room capacity count
        public int CurrentRoomCapacityCount
        {
            get
            {
                if (SelectedDate.HasValue && SelectedRoomId.HasValue)
                {
                    return GetRoomCapacityCount(SelectedRoomId.Value, SelectedDate.Value);
                }
                return 0; // Default value if no date or room is selected
            }
        }



        // Property to store the selected room ID for lesson scheduling
        private int? _selectedRoomId;
        public int? SelectedRoomId
        {
            get => _selectedRoomId;
            set
            {
                if (_selectedRoomId != value)
                {
                    _selectedRoomId = value;
                    OnPropertyChanged(nameof(SelectedRoomId));
                    OnPropertyChanged(nameof(CurrentRoomCapacityCount)); // Update room capacity when room selection changes

                }
            }
        }

        // Collection of instructors for data binding
        public ObservableCollection<Instructor> Instructors { get; private set; }

        // Method to load instructors from the repository
        private async void LoadInstructors()
        {
            try
            {
                var instructorData = await _instructorRepository.GetAll().ToListAsync();
                Instructors = new ObservableCollection<Instructor>(instructorData);
                OnPropertyChanged(nameof(Instructors));
            }
            catch (Exception ex)
            {
                // Handle exceptions, e.g., logging or user notification
            }
        }

     

        // Method to load students from the repository
        private async void LoadStudents()
        {
            try
            {
                var studentData = await _studentRepository.GetAllAsync();
                Students = new ObservableCollection<Student>(studentData);
                OnPropertyChanged(nameof(Students));
            }
            catch (Exception ex)
            {
                // Handle exceptions
            }
        }

        // Collection of rooms for data binding
        public ObservableCollection<Room> Rooms { get; private set; }

        // Method to load rooms from the repository
        private async void LoadRooms()
        {
            try
            {
                var roomData = await _roomRepository.GetAllAsync();
                Rooms = new ObservableCollection<Room>(roomData);
                OnPropertyChanged(nameof(Rooms));
            }
            catch (Exception ex)
            {
                // Handle exceptions
            }
        }

        // Method to determine if lesson commands (edit, delete) can be executed
        private bool CanExecuteLessonCommand(object parameter)
        {
            // Implement logic to determine if the lesson commands can be executed
            return true; // For now, return true to enable the commands
        }

        // Method to execute the EditLesson command
        private void EditLessonExecute(object parameter)
        {
            var editLessonWindow = new EditLessonWindow(this); // Pass this ViewModel to the window
            editLessonWindow.DataContext = this;
            editLessonWindow.ShowDialog(); // Show the edit lesson window

            // Optionally, refresh lessons list after editing a lesson
        }

        // Method to execute the DeleteLesson command
        private async void DeleteLessonExecute(object parameter)
        {
            if (SelectedMusicLesson != null)
            {
                try
                {
                    await _musicLessonRepository.DeleteAsync(SelectedMusicLesson.MusicLessonID);
                    MusicLessons.Remove(SelectedMusicLesson); // Remove the lesson from the collection
                    UpdateRoomCapacities(); // Update room capacities after deletion
                    OnPropertyChanged(nameof(MusicLessons));
                    MessageBox.Show("Lesson deleted successfully.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting lesson: {ex.Message}");
                }
            }
        }

        // Method to determine if the SaveLessonChanges command can be executed
        private bool CanSaveLessonChangesExecute(object parameter)
        {
            // Add logic to determine if the lesson can be saved
            return true; // For now, return true to enable the command
        }

        // Event to signal when a lesson is saved
        public event Action OnLessonSave;

        // Method to execute the SaveLessonChanges command
        private async void SaveLessonChangesExecute(object parameter)
        {
            if (SelectedMusicLesson != null)
            {
                try
                {
                    await _musicLessonRepository.UpdateAsync(SelectedMusicLesson);
                    MessageBox.Show("Lesson updated successfully.");
                    OnLessonSave?.Invoke();
                }
                catch (DbUpdateException ex)
                {
                    // Access the inner exception
                    var innerException = ex.InnerException;

                    // Display the inner exception message in a MessageBox
                    MessageBox.Show($"Error updating lesson: {innerException?.Message}");

                }

                FilterLessonsOnSelectedDate(); // Reload lessons
            }
        }


        // Properties for start and end times of the selected lesson
        public TimeSpan StartTime
        {
            get => SelectedMusicLesson?.MusicLessonStartDateTime.TimeOfDay ?? TimeSpan.Zero;
            set
            {
                if (SelectedMusicLesson != null)
                {
                    SelectedMusicLesson.MusicLessonStartDateTime =
                        SelectedMusicLesson.MusicLessonStartDateTime.Date + value;
                    OnPropertyChanged(nameof(StartTime));
                }
            }
        }

        public TimeSpan EndTime
        {
            get => SelectedMusicLesson?.MusicLessonEndDateTime.TimeOfDay ?? TimeSpan.Zero;
            set
            {
                if (SelectedMusicLesson != null)
                {
                    SelectedMusicLesson.MusicLessonEndDateTime =
                        SelectedMusicLesson.MusicLessonEndDateTime.Date + value;
                    OnPropertyChanged(nameof(EndTime));
                }
            }
        }

        // Collection of time options for lesson scheduling
        public ObservableCollection<TimeSpan> TimeOptions { get; private set; }

        // Method to initialize time options
        private void InitializeTimeOptions()
        {
            TimeOptions = new ObservableCollection<TimeSpan>();
            for (int hour = 0; hour < 24; hour++)
            {
                for (int min = 0; min < 60; min += 30) // Adjust as needed
                {
                    TimeOptions.Add(new TimeSpan(hour, min, 0));
                }
            }
        }

        // Collection of status choices for lessons
        public ObservableCollection<string> StatusChoices { get; private set; }

        // Method to initialize status choices
        private void InitializeStatusChoices()
        {
            StatusChoices = new ObservableCollection<string>
            {
                "Scheduled", "Canceled", "Completed"
            };
        }

        // Method to execute the AddLesson command
        private void AddLessonExecute(object parameter)
        {
            MusicLesson newLesson = new MusicLesson
            {
                MusicLessonStartDateTime = SelectedDate ?? DateTime.Today,
                MusicLessonEndDateTime = (SelectedDate ?? DateTime.Today).AddHours(1)
            };

            var addLessonWindow = new AddLessonWindow(newLesson, this);
            if (addLessonWindow.ShowDialog() == true)
            {
                _musicLessonRepository.AddAsync(newLesson); // Add the new lesson to the repository
                MusicLessons.Add(newLesson); // Add to the collection
                UpdateRoomCapacities(); // Update room capacities
                OnPropertyChanged(nameof(MusicLessons));
            }
        }

        // Method to determine if the DeleteLesson command can be executed
        private bool CanExecuteDeleteLesson(object parameter)
        {
            return SelectedMusicLesson != null; // Can execute if a lesson is selected
        }
    }
}



