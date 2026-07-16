// Import necessary namespaces.
using Syncfusion.Windows.Edit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace YourMusicDepotApp.Views
{
    /// <summary>
    /// Interaction logic for EditPaymentWindow.xaml.
    /// This class represents the window used for editing payment information in the YourMusicDepot application.
    /// </summary>
    public partial class EditPaymentWindow : Window, INotifyPropertyChanged
    {
        // Property representing the updated payment information.
        public MusicLessonPayment UpdatedPayment { get; private set; }

        private decimal _paymentAmount;

        // Command property for the Save action.
        public ICommand SaveCommand { get; private set; }

        // Property for payment amount, with notification for changes.
        public decimal PaymentAmount
        {
            get => _paymentAmount;
            set
            {
                if (_paymentAmount != value)
                {
                    _paymentAmount = value;
                    OnPropertyChanged(nameof(PaymentAmount));
                }
            }
        }

      
        /// Constructor for the EditPaymentWindow class.
        /// 
        /// Initializes the window and sets up data binding for the payment to be edited.
      
        public EditPaymentWindow(MusicLessonPayment payment)
        {
            // Initialize the UI components.
            InitializeComponent();
            UpdatedPayment = payment;
            DataContext = UpdatedPayment;

            // Initialize the SaveCommand with a delegate to SaveAction method.
            SaveCommand = new RelayCommand(SaveAction);
        }

        
        /// Action for SaveCommand. Closes the window and sets the dialog result to true.
       
        private void SaveAction(object parameter)
        {
            this.DialogResult = true; // Set the dialog result to indicate success.
            this.Close(); // Close the window.
        }

        // INotifyPropertyChanged implementation to notify UI of property changes.
        public event PropertyChangedEventHandler PropertyChanged;

     
        /// Method to invoke the PropertyChanged event.
        /// Notifies the UI when a property value changes.
       
       
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

     
    }
}
