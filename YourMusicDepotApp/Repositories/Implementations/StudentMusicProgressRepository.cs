using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using YourMusicDepotApp.Data;
using YourMusicDepotApp.Models;
using YourMusicDepotApp.Repositories.Interfaces;

public class StudentMusicProgressRepository : IStudentMusicProgressRepository
{
    private readonly YourMusicDepotContext _context;

    public StudentMusicProgressRepository(YourMusicDepotContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<StudentMusicProgress>> GetAllAsync()
    {
        return await _context.StudentMusicProgresses.ToListAsync();
    }

    public async Task<StudentMusicProgress> GetByIdAsync(int id)
    {
        return await _context.StudentMusicProgresses.FindAsync(id);
    }

    public async Task AddAsync(StudentMusicProgress studentMusicProgress)
    {
        await _context.StudentMusicProgresses.AddAsync(studentMusicProgress);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(StudentMusicProgress studentMusicProgress)
    {
        _context.StudentMusicProgresses.Update(studentMusicProgress);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var studentMusicProgress = await _context.StudentMusicProgresses.FindAsync(id);
        if (studentMusicProgress != null)
        {
            _context.StudentMusicProgresses.Remove(studentMusicProgress);
            await _context.SaveChangesAsync();
        }
    }
}
