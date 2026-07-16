using System;
using System.ComponentModel;
using System.Windows.Media;
namespace YourMusicDepotApp.Models
{
    public class ScheduleAppointment : INotifyPropertyChanged
    {
        private DateTime _startTime;
        private DateTime _endTime;
        private string _subject;

        public DateTime StartTime
        {
            get => _startTime;
            set
            {
                if (_startTime != value)
                {
                    _startTime = value;
                    OnPropertyChanged(nameof(StartTime));
                }
            }
        }

        public DateTime EndTime
        {
            get => _endTime;
            set
            {
                if (_endTime != value)
                {
                    _endTime = value;
                    OnPropertyChanged(nameof(EndTime));
                }
            }
        }

        public string Subject
        {
            get => _subject;
            set
            {
                if (_subject != value)
                {
                    _subject = value;
                    OnPropertyChanged(nameof(Subject));
                }
            }
        }
        // Add a property for the status
        public string Status { get; set; }

        public SolidColorBrush BackgroundColor
        {
            get
            {
                return Status switch
                {
                    "Scheduled" => new SolidColorBrush(Colors.Green),
                    "Completed" => new SolidColorBrush(Colors.Blue),
                    "Canceled" => new SolidColorBrush(Colors.Red),
                    _ => new SolidColorBrush(Colors.Gray), // Default color
                };
            }
        }
        public Brush ForegroundColor { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
