using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using YourMusicDepotApp.Data;
using YourMusicDepotApp.Models;
using YourMusicDepotApp.Repositories.Interfaces;

namespace YourMusicDepotApp.Repositories.Implementations
{
    public class InstructorRepository : IInstructorRepository
    {
        private readonly YourMusicDepotContext _context;

        public InstructorRepository(YourMusicDepotContext context)
        {
            _context = context;
        }

        public IQueryable<Instructor> GetAll()
        {
            return _context.Instructors.AsNoTracking();
        }

        public async Task<Instructor> GetByIdAsync(int id)
        {
            return await _context.Instructors.FindAsync(id);
        }

        public async Task AddAsync(Instructor instructor)
        {
            await _context.Instructors.AddAsync(instructor);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Instructor instructor)
        {
            _context.Instructors.Update(instructor);
            await _context.SaveChangesAsync();
        }
        public async Task<IEnumerable<Instructor>> GetAllWithLastLessonAsync()
        {
            var instructors = await _context.Instructors.Include(i => i.InstructorAvailabilities).ToListAsync();

            foreach (var instructor in instructors)
            {
                var lastLesson = await _context.MusicLessons
                                               .Where(ml => ml.InstructorID == instructor.InstructorID)
                                               .OrderByDescending(ml => ml.MusicLessonEndDateTime)
                                               .Include(ml => ml.Student)
                                               .FirstOrDefaultAsync();

                if (lastLesson != null)
                {
                    instructor.LastTaughtStudentName = $"{lastLesson.Student.StudentFirstName} {lastLesson.Student.StudentLastName}";
                }
            }

            return instructors;
        }
        public async Task<IEnumerable<Instructor>> GetFilteredInstructorsAsync(string searchText)
        {
            // Your existing query logic here
            var searchTextLower = searchText?.ToLower() ?? string.Empty;
            return await _context.Instructors
                .Include(i => i.InstructorAvailabilities)
                // Other necessary includes
                .Where(i => i.InstructorFirstName.ToLower().Contains(searchTextLower) ||
                            i.InstructorLastName.ToLower().Contains(searchTextLower) ||
                            i.InstructorCredential.ToLower().Contains(searchTextLower))
                .ToListAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var instructor = await _context.Instructors.FindAsync(id);
            if (instructor != null)
            {
                _context.Instructors.Remove(instructor);
                await _context.SaveChangesAsync();
            }
        }
    }
}
