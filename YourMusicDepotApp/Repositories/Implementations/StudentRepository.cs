using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using YourMusicDepotApp.Data;
using YourMusicDepotApp.Models;
using YourMusicDepotApp.Repositories.Interfaces;

namespace YourMusicDepotApp.Repositories.Implementations
{
    public class StudentRepository : IStudentRepository
    {
        private readonly YourMusicDepotContext _context;

        public StudentRepository(YourMusicDepotContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Student>> GetAllAsync()
        {
            return await _context.Students.AsNoTracking().ToListAsync();
        }
        public async Task<IEnumerable<Student>> GetAllWithDetailsAsync()
        {
            var students = await _context.Students
                                         .Include(s => s.StudentMusicProgresses)
                                         .Include(s => s.MusicLessons)
                                         .ToListAsync();

            foreach (var student in students)
            {
                // Fetch the last music lesson for each student
                var lastLesson = await _context.MusicLessons
                                               .Where(ml => ml.StudentID == student.StudentID)
                                               .OrderByDescending(ml => ml.MusicLessonEndDateTime)
                                               .Include(ml => ml.Instructor)
                                               .FirstOrDefaultAsync();

                if (lastLesson != null)
                {
                    student.LastInstructorName = $"{lastLesson.Instructor.InstructorFirstName} {lastLesson.Instructor.InstructorLastName}";
                }

                var progress = student.StudentMusicProgresses.FirstOrDefault();
                if (progress != null)
                {
                    student.StudentInstrument = progress.StudentInstrument;
                    student.StudentSkillLevel = progress.StudentSkillLevel;
                }
            }

            return students;
        }
        public async Task<Student> GetByIdAsync(int id)
        {
            return await _context.Students.FindAsync(id);
        }

        public async Task AddAsync(Student student)
        {
            await _context.Students.AddAsync(student);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Student student)
        {
            _context.Students.Update(student);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student != null)
            {
                _context.Students.Remove(student);
                await _context.SaveChangesAsync();
            }
        }
    }
}
