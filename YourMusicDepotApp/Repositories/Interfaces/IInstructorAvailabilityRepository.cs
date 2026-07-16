using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourMusicDepotApp.Models;
using YourMusicDepotApp.Data;

namespace YourMusicDepotApp.Repositories.Interfaces
{
    public interface IInstructorAvailabilityRepository
    {
        Task<IEnumerable<InstructorAvailability>> GetAllAsync();
        Task<InstructorAvailability> GetByIdAsync(int id);
        Task AddAsync(InstructorAvailability instructorAvailability);
        Task UpdateAsync(InstructorAvailability instructorAvailability);
        Task DeleteAsync(int id);
    }

}
