using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace YourMusicDepotApp.Models
{
    public class Student
    {
        [Key]
        public int StudentID { get; set; }

        [Required]
        [MaxLength(15)]
        public string StudentFirstName { get; set; }

        [Required]
        [MaxLength(15)]
        public string StudentLastName { get; set; }

        [Required]
        public byte StudentAge { get; set; }

        [Required]
        [MaxLength(20)]
        public string StudentPhoneNumber { get; set; }

        [Required]
        [MaxLength(50)]
        public string StudentEmail { get; set; }

        [Required]
        [MaxLength(100)]
        public string StudentAccountPassword { get; set; }

        public string? ProfilePicturePath { get; set; }

        public virtual ICollection<StudentMusicProgress> StudentMusicProgresses { get; set; }
        public virtual ICollection<MusicLesson> MusicLessons { get; set; }

        [NotMapped]
        public string FullName
        {
            get => $"{StudentFirstName} {StudentLastName}";
            set
            {
                var names = value.Split(' ');
                if (names.Length >= 2)
                {
                    StudentFirstName = names[0];
                    StudentLastName = string.Join(" ", names[1..]);
                }
            }
        }
        [NotMapped]
        public string LastInstructorName { get; set; }

        [NotMapped]
        public string StudentInstrument { get; set; } // For the primary instrument from StudentMusicProgresses

        [NotMapped]
        public string StudentSkillLevel { get; set; } // For the skill level from StudentMusicProgresses

        [NotMapped]
        public StudentMusicProgress FirstMusicProgress => StudentMusicProgresses.FirstOrDefault();

    }
}
