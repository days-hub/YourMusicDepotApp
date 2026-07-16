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
using YourMusicDepotApp.Models;
using YourMusicDepotApp.ViewModels;

namespace YourMusicDepotApp.Views
{
    
    /// Interaction logic for AddLessonWindow.xaml
   
    public partial class AddLessonWindow : Window
    {
        public AddLessonWindow(MusicLesson newLesson, SchedulingViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;

           
            viewModel.NewLesson = newLesson;
        }
    }
}
