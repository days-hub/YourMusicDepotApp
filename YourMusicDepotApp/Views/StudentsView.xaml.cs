// Import necessary namespaces.
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
   
    /// Interaction logic for StudentsView.xaml
    /// This class represents the user interface for managing student records in the YourMusicDepot application.
  
    public partial class StudentsView : UserControl
    {
       
        /// Constructor for the StudentsView class.
        /// Initializes the user interface components and sets up data binding for student records.
       
        public StudentsView()
        {
            // Initialize the UI components defined in XAML.
            InitializeComponent();

            // Initialize a new instance of the database context for YourMusicDepot.
            var context = new YourMusicDepotContext();

            // Initialize the repository responsible for handling operations on student data.
            var studentRepository = new StudentRepository(context);

            // Set the DataContext for data binding.
            // The DataContext is set to a new instance of StudentsViewModel with the student repository.
            // StudentsViewModel handles the presentation logic and data manipulation for student records.
            DataContext = new StudentsViewModel(studentRepository);
        }
    }
}
