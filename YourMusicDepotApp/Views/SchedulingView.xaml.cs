// Import the necessary namespaces.
using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using YourMusicDepotApp.Data;
using YourMusicDepotApp.Repositories.Implementations;
using YourMusicDepotApp.ViewModels;

namespace YourMusicDepotApp.Views
{
    
    /// Interaction logic for SchedulingView.xaml
    /// This class represents the user interface for scheduling features in the YourMusicDepot application.
   
    public partial class SchedulingView : UserControl
    {
        
        /// Constructor for SchedulingView.
        /// Initializes the user interface components and sets up the data context for scheduling features.
       
        public SchedulingView()
        {
            // Initialize the UI components defined in XAML.
            InitializeComponent();

            // Factory method for creating new instances of the YourMusicDepotContext.
            Func<YourMusicDepotContext> contextFactory = () => new YourMusicDepotContext();

            // Initialize repositories with the database context. These repositories handle data operations.
            var musicLessonRepository = new MusicLessonRepository(contextFactory);
            var studentRepository = new StudentRepository(new YourMusicDepotContext());
            var instructorRepository = new InstructorRepository(new YourMusicDepotContext());
            var roomRepository = new RoomRepository(new YourMusicDepotContext()); // Repository for managing room data.

            // Create a SchedulingViewModel with the necessary repositories.
            // This ViewModel handles the business logic and data manipulation for scheduling.
            var schedulingviewModel = new SchedulingViewModel(musicLessonRepository, studentRepository, instructorRepository, roomRepository);

            // Create a WeeklyScheduleViewModel, possibly for managing weekly schedules.
            var weeklyScheduleViewModel = new WeeklyScheduleViewModel(musicLessonRepository);

            // Set the DataContext for data binding. This enables UI elements to bind to properties in the ViewModel.
            this.DataContext = schedulingviewModel;
            this.WeeklyScheduleTab.DataContext = weeklyScheduleViewModel;

            // Register an event listener for calendar date changes in the ViewModel.
            schedulingviewModel.OnCalendarDateChanged += UpdateCalendarSelectedDate;

            // Reflect the ViewModel's initial date (today) in the calendar.
            if (schedulingviewModel.SelectedDate.HasValue)
            {
                MaterialCalendar.SelectedDate = schedulingviewModel.SelectedDate;
            }
        }

       
        /// Event handler for changes in the calendar selection.
        /// Updates the selected date in the SchedulingViewModel.
       
        private void Calendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            var calendar = sender as Calendar;
            if (DataContext is SchedulingViewModel viewModel && calendar.SelectedDate.HasValue)
            {
                // Update the selected date in the ViewModel when a new date is selected in the calendar.
                viewModel.SelectedDate = calendar.SelectedDate;
            }
        }

       
        /// Method to update the calendar's selected date based on changes in the ViewModel.
        /// This ensures the UI calendar reflects changes made programmatically in the ViewModel.
       
        private void UpdateCalendarSelectedDate(DateTime date)
        {
            // Update the MaterialCalendar's selected date.
            MaterialCalendar.SelectedDate = date;
        }
    }
}
