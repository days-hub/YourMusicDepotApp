using System;
using System.Windows;

namespace YourMusicDepotApp
{
    /// Interaction logic for MainWindow.xaml.
    /// Hosts the navigation rail and the frame that displays each module's view.
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        /// Navigates the MainContentFrame to the HomeView dashboard.
        private void Home_Click(object sender, RoutedEventArgs e)
        {
            if (MainContentFrame == null) return;
            MainContentFrame.Navigate(new Uri("Views/HomeView.xaml", UriKind.Relative));
        }

        /// Navigates the MainContentFrame to the InstructorsView.
        private void Instructors_Click(object sender, RoutedEventArgs e)
        {
            if (MainContentFrame == null) return;
            MainContentFrame.Navigate(new Uri("Views/InstructorsView.xaml", UriKind.Relative));
        }

        /// Navigates the MainContentFrame to the StudentsView.
        private void Students_Click(object sender, RoutedEventArgs e)
        {
            if (MainContentFrame == null) return;
            MainContentFrame.Navigate(new Uri("Views/StudentsView.xaml", UriKind.Relative));
        }

        /// Navigates the MainContentFrame to the SchedulingView.
        private void Scheduling_Click(object sender, RoutedEventArgs e)
        {
            if (MainContentFrame == null) return;
            MainContentFrame.Navigate(new Uri("Views/SchedulingView.xaml", UriKind.Relative));
        }

        /// Navigates the MainContentFrame to the FinanceView.
        private void Finance_Click(object sender, RoutedEventArgs e)
        {
            if (MainContentFrame == null) return;
            MainContentFrame.Navigate(new Uri("Views/FinanceView.xaml", UriKind.Relative));
        }
    }
}
