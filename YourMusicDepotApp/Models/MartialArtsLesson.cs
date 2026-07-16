using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YourMusicDepotApp.Models
{
    public class MartialArtsLesson
    {
        [Key]
        public int MartialArtsLessonID { get; set; }

        [ForeignKey("Room")]
        public int RoomID { get; set; }

        [Required]
        public DateTime MartialArtsLessonStartDateTime { get; set; }

        [Required]
        public DateTime MartialArtsLessonEndDateTime { get; set; }

        [Required]
        [MaxLength(100)]
        public string MartialArtsLessonStatus { get; set; }

        public virtual Room Room { get; set; }
    }
}
