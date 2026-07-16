using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YourMusicDepotApp.Models
{
    public class InstructorAvailability
    {
        [Key]
        public int AvailabilityID { get; set; }

        [ForeignKey("Instructor")]
        public int InstructorID { get; set; }

        [Required]
        [MaxLength(15)]
        public string DayOfWeek { get; set; }

        [Required]
        public TimeSpan StartTime { get; set; }

        [Required]
        public TimeSpan EndTime { get; set; }

        [Required]
        public bool IsRecurring { get; set; }

        public virtual Instructor Instructor { get; set; }
    }
}
