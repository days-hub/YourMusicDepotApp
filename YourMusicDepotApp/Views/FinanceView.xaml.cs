// Import the required namespaces.
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
    
    /// Interaction logic for FinanceView.xaml.
    /// This class represents the user interface for managing financial records, particularly for music lessons, within the YourMusicDepot application.
   
    public partial class FinanceView : UserControl
    {
        
        /// Constructor for the FinanceView class.
        /// Initializes the user interface components and sets up data binding for financial records.
      
        public FinanceView()
        {
            // Initialize the UI components defined in XAML.
            InitializeComponent();

            // Factory method for creating new instances of the YourMusicDepotContext.
            Func<YourMusicDepotContext> contextFactory = () => new YourMusicDepotContext();

            // Initialize the repository responsible for handling music lesson payment operations.
            var paymentRepository = new MusicLessonPaymentRepository(contextFactory);

            // Initialize the repository responsible for handling music lesson data operations.
            var lessonRepository = new MusicLessonRepository(contextFactory);

            // Set the DataContext for this UserControl.
            // DataContext is set to a new instance of FinanceViewModel with the necessary repositories.
            // FinanceViewModel manages the presentation logic and data manipulation for financial records related to music lessons.
            DataContext = new FinanceViewModel(paymentRepository, lessonRepository);
        }
    }
}
