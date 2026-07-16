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

    /// Interaction logic for EditLessonWindow.xaml

    public partial class EditLessonWindow : Window
    {
        public EditLessonWindow(SchedulingViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;

            // Subscribe to the OnLessonSave event
            viewModel.OnLessonSave += CloseWindow;
        }

        private void CloseWindow()
        {
            this.Close(); // Close the window
        }
        // This method is called when the window is closed
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            // Unsubscribe from the event when the window closes
            if (DataContext is SchedulingViewModel viewModel)
            {
                viewModel.OnLessonSave -= CloseWindow;
            }
        }

    }
}
