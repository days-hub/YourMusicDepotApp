using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace YourMusicDepotApp.Models
{
    public class Room
    {
        [Key]
        public int RoomID { get; set; }

        [Required]
        public int RoomSize { get; set; } // Changed from boolean to int

        public virtual ICollection<MusicLesson> MusicLessons { get; set; }
        public virtual ICollection<MartialArtsLesson> MartialArtsLessons { get; set; }
    }

}
