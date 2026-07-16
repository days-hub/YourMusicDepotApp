using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourMusicDepotApp.Models;

namespace YourMusicDepotApp.Repositories.Interfaces
{
    public interface IStudentMusicProgressRepository
    {
        Task<IEnumerable<StudentMusicProgress>> GetAllAsync();
        Task<StudentMusicProgress> GetByIdAsync(int id);
        Task AddAsync(StudentMusicProgress studentMusicProgress);
        Task UpdateAsync(StudentMusicProgress studentMusicProgress);
        Task DeleteAsync(int id);
    }

}
