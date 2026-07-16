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
   
    /// Interaction logic for InstructorsView.xaml.
    /// This class represents the user interface for managing instructor-related data within the YourMusicDepot application.
    
    public partial class InstructorsView : UserControl
    {
        
        /// Constructor for the InstructorsView class.
        /// Initializes the user interface components and sets up data binding for instructor records.
       
        public InstructorsView()
        {
            // Initialize the UI components defined in XAML.
            InitializeComponent();

            // Create a new instance of YourMusicDepotContext, which handles database operations for the application.
            var context = new YourMusicDepotContext();

            // Initialize the repository responsible for handling operations on instructor data.
            var instructorRepository = new InstructorRepository(context);

            // Set the DataContext for this UserControl.
            // DataContext is set to a new instance of InstructorViewModel with the instructor repository.
            // InstructorViewModel manages the presentation logic and data manipulation for instructor records.
            DataContext = new InstructorViewModel(instructorRepository);
        }
    }
}
