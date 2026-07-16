// Import necessary namespaces for the application.
using Syncfusion.Licensing;
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

namespace YourMusicDepotApp
{
   
    /// Interaction logic for MainWindow.xaml.
    /// This class defines the behavior of the main window in the WPF application.
   
    public partial class MainWindow : Window
    {
       
        /// Constructor for MainWindow. This method is called when a new instance of MainWindow is created.
        
        public MainWindow()
        {
            // Initializes the components (controls) defined in XAML for this window.
            InitializeComponent();
        }

      
        /// Event handler for the 'Instructors' button click.
       
        /// Navigates the MainContentFrame to the InstructorsView.
      
       
        private void Instructors_Click(object sender, RoutedEventArgs e)
        {
            // Changes the displayed content of MainContentFrame to InstructorsView.
            MainContentFrame.Navigate(new Uri("Views/InstructorsView.xaml", UriKind.Relative));
        }

       
        /// Event handler for the 'Students' button click.
        /// Navigates the MainContentFrame to the StudentsView.
        
        private void Students_Click(object sender, RoutedEventArgs e)
        {
            // Changes the displayed content of MainContentFrame to StudentsView.
            MainContentFrame.Navigate(new Uri("Views/StudentsView.xaml", UriKind.Relative));
        }

       
        /// Event handler for the 'Scheduling' button click.
        /// Navigates the MainContentFrame to the SchedulingView.
      
        private void Scheduling_Click(object sender, RoutedEventArgs e)
        {
            // Changes the displayed content of MainContentFrame to SchedulingView.
            MainContentFrame.Navigate(new Uri("Views/SchedulingView.xaml", UriKind.Relative));
        }

       
        /// Event handler for the 'Finance' button click.
        /// Navigates the MainContentFrame to the FinanceView.
       
        private void Finance_Click(object sender, RoutedEventArgs e)
        {
            // Changes the displayed content of MainContentFrame to FinanceView.
            MainContentFrame.Navigate(new Uri("Views/FinanceView.xaml", UriKind.Relative));
        }

       
        /// Event handler called when the content of MainContentFrame is rendered.
        /// Hides the LogoStackPanel when any content is rendered in the MainContentFrame.
       
        private void MainContentFrame_ContentRendered(object sender, EventArgs e)
        {
            // Sets the visibility of the LogoStackPanel to Collapsed, hiding it from view.
            LogoStackPanel.Visibility = Visibility.Collapsed;
        }
    }
}
