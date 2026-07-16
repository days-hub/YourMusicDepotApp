using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YourMusicDepotApp.Models
{
    public class StudentMusicProgress
    {
        [Key]
        public int StudentMusicProgressID { get; set; }

        [ForeignKey("Student")]
        public int StudentID { get; set; }

        [Required]
        [MaxLength(50)]
        public string StudentInstrument { get; set; }

        [Required]
        [MaxLength(100)]
        public string StudentSkillLevel { get; set; }

        public virtual Student Student { get; set; }
    }
}
