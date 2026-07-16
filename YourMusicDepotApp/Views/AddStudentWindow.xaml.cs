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
using System.Windows.Shapes;
using YourMusicDepotApp.ViewModels;

namespace YourMusicDepotApp.Views
{
    
    /// Interaction logic for AddStudentWindow.xaml.
    /// This class represents the window used for adding new students in the YourMusicDepot application.
   
    public partial class AddStudentWindow : Window
    {
     
        /// Constructor for the AddStudentWindow class.
        /// Initializes the user interface components and sets up the data context for adding new students.
        
        public AddStudentWindow()
        {
            // Initialize the UI components defined in XAML for this window.
            InitializeComponent();

            // Check if the DataContext is set to an instance of StudentsViewModel.
            if (this.DataContext is StudentsViewModel viewModel)
            {
                // Provide a reference of this window to the ViewModel.
                // This enables the ViewModel to interact with this window, e.g., for closing it after adding a student.
                viewModel.SetAddStudentWindowReference(this);
            }
        }

        /// Event handler for when the password in the PasswordBox changes.
        /// Updates the new student account password in the StudentsViewModel.
      
        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            // Check if the DataContext is set to an instance of StudentsViewModel.
            if (this.DataContext is StudentsViewModel viewModel)
            {
                // Update the NewStudentAccountPassword property in the ViewModel with the new password.
                viewModel.NewStudentAccountPassword = PasswordBox.Password;
            }
        }
    }
}
