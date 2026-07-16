using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourMusicDepotApp.Models;

namespace YourMusicDepotApp.Repositories.Interfaces
{
    public interface IInstructorRepository
    {
        IQueryable<Instructor> GetAll();
        Task<Instructor> GetByIdAsync(int id);
        Task AddAsync(Instructor instructor);
        Task UpdateAsync(Instructor instructor);
        Task<IEnumerable<Instructor>> GetFilteredInstructorsAsync(string searchText);
        Task DeleteAsync(int id);
        Task<IEnumerable<Instructor>> GetAllWithLastLessonAsync();
    }
}
