using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YourMusicDepotApp.Models
{
    public class MusicLessonPayment
    {
        [Key]
        public int MusicLessonPaymentID { get; set; }

        [ForeignKey("MusicLesson")]
        public int MusicLessonID { get; set; }

        [Required]
        [Column(TypeName = "money")]
        public decimal MusicLessonPaymentAmount { get; set; }

        [Required]
        public DateTime MusicLessonPaymentDate { get; set; }

        [Required]
        [MaxLength(100)]
        public string MusicLessonPaymentType { get; set; }

        public virtual MusicLesson MusicLesson { get; set; }
    }
}
