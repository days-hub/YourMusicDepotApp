using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourMusicDepotApp.Models;

namespace YourMusicDepotApp.Repositories.Interfaces
{
    public interface IMusicLessonRepository
    {
        Task<IEnumerable<MusicLesson>> GetAllAsync();
        Task<IEnumerable<MusicLesson>> GetLessonsWithoutPaymentsAsync();
        Task<MusicLesson> GetByIdAsync(int id);
        Task AddAsync(MusicLesson musicLesson);
        Task UpdateAsync(MusicLesson musicLesson);
        Task DeleteAsync(int id);
    }
}
