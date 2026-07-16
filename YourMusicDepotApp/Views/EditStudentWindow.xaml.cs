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
using System.Windows.Shapes;
using YourMusicDepotApp.ViewModels;

namespace YourMusicDepotApp.Views
{
    
    /// Interaction logic for EditStudentWindow.xaml.

    /// This class represents the window used for editing student account information in the YourMusicDepot application.

    public partial class EditStudentWindow : Window
    {
       
        /// Constructor for the EditStudentWindow class.
        /// Initializes the user interface components of the window.
      
        public EditStudentWindow()
        {
            // Initialize the UI components defined in XAML for this window.
            InitializeComponent();
        }

       
        /// Event handler for when the password in the PasswordBox changes.
        
        /// Updates the student account password in the StudentsViewModel.
       
        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            // Check if the DataContext is set to an instance of StudentsViewModel.
            if (this.DataContext is StudentsViewModel viewModel)
            {
                // Update the EditStudentAccountPassword property in the ViewModel with the new password.
                viewModel.EditStudentAccountPassword = passwordBox.Password;
            }
        }
    }
}
