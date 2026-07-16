using System.Windows.Controls;
using YourMusicDepotApp.Data;
using YourMusicDepotApp.ViewModels;

namespace YourMusicDepotApp.Views
{
    /// Interaction logic for HomeView.xaml.
    /// Displays dashboard statistics and today's lesson schedule.
    public partial class HomeView : UserControl
    {
        public HomeView()
        {
            InitializeComponent();

            var context = new YourMusicDepotContext();
            DataContext = new HomeViewModel(context);
        }
    }
}
