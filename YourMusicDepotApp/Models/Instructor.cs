using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YourMusicDepotApp.Models
{
    public class Instructor
    {
        [Key]
        public int InstructorID { get; set; }

        [Required]
        [MaxLength(15)]
        public string InstructorFirstName { get; set; }

        [Required]
        [MaxLength(15)]
        public string InstructorLastName { get; set; }

        [Required]
        [MaxLength(100)]
        public string InstructorCredential { get; set; }

        [Required]
        [MaxLength(20)]
        public string InstructorPhoneNumber { get; set; }

        [Required]
        [MaxLength(50)]
        public string InstructorEmail { get; set; }

        public virtual ICollection<InstructorAvailability> InstructorAvailabilities { get; set; }
        public virtual ICollection<MusicLesson> MusicLessons { get; set; }

        // New property to hold the last taught student's name
        [NotMapped]
        public string LastTaughtStudentName { get; set; }

        public string? ProfilePicturePath { get; set; }

        [NotMapped]
        public string FullName
        {
            get => $"{InstructorFirstName} {InstructorLastName}";
            set
            {
                var names = value.Split(' ');
                if (names.Length >= 2)
                {
                    InstructorFirstName = names[0];
                    InstructorLastName = string.Join(" ", names[1..]);
                }
            }
        }
    }
}
