using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourMusicDepotApp.Models;

namespace YourMusicDepotApp.Repositories.Interfaces
{
    public interface IMartialArtsLessonRepository
    {
        Task<IEnumerable<MartialArtsLesson>> GetAllAsync();
        Task<MartialArtsLesson> GetByIdAsync(int id);
        Task AddAsync(MartialArtsLesson martialArtsLesson);
        Task UpdateAsync(MartialArtsLesson martialArtsLesson);
        Task DeleteAsync(int id);
    }

}
