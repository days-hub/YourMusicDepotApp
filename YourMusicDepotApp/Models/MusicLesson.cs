using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YourMusicDepotApp.Models
{
    public class MusicLesson : INotifyPropertyChanged
    {
        [Key]
        public int MusicLessonID { get; set; }

        [ForeignKey("Instructor")]
        public int InstructorID { get; set; }

        [ForeignKey("Student")]
        public int StudentID { get; set; }

        [ForeignKey("Room")]
        public int RoomID { get; set; }

        [Required]
        public DateTime MusicLessonStartDateTime { get; set; }

        [Required]
        public DateTime MusicLessonEndDateTime { get; set; }

        public virtual MusicLessonPayment MusicLessonPayment { get; set; }

        [Required]
        [MaxLength(100)]
        public string MusicLessonStatus { get; set; }

        public virtual Instructor Instructor { get; set; }
        public virtual Student Student { get; set; }
        public virtual Room Room { get; set; }

        // New property for lesson numbering
        [NotMapped]
        public int LessonNumber { get; set; }

        private int _currentRoomCapacityCount;

        [NotMapped]
        public int CurrentRoomCapacityCount
        {
            get => _currentRoomCapacityCount;
            set
            {
                if (_currentRoomCapacityCount != value)
                {
                    _currentRoomCapacityCount = value;
                    OnPropertyChanged(nameof(CurrentRoomCapacityCount));
                }
            }
        }

        // INotifyPropertyChanged implementation
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
