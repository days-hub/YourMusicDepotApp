using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourMusicDepotApp.Models;

namespace YourMusicDepotApp.Repositories.Interfaces
{
    public interface IMusicLessonPaymentRepository
    {
        IQueryable<MusicLessonPayment> GetAll();
        Task<MusicLessonPayment> GetByIdAsync(int id);
        Task AddAsync(MusicLessonPayment musicLessonPayment);
        Task UpdateAsync(MusicLessonPayment musicLessonPayment);
        Task DeleteAsync(int id);
    }
}
