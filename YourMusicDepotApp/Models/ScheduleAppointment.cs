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

        public string Status { get; set; }

        // Display fields for the weekly schedule cards.
        public string StudentName { get; set; }
        public string InstructorName { get; set; }
        public string RoomLabel { get; set; }

        // Status-derived brushes used by the week view (soft fill, colored
        // left accent bar, dark text — same palette as the legend chips).
        public Brush AccentBrush => LessonStatusPalette.AccentFor(Status);
        public Brush FillBrush => LessonStatusPalette.FillFor(Status);
        public Brush TextBrush => LessonStatusPalette.TextFor(Status);

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
