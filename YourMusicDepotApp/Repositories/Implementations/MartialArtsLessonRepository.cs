using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using YourMusicDepotApp.Data;
using YourMusicDepotApp.Models;
using YourMusicDepotApp.Repositories.Interfaces;

public class MartialArtsLessonRepository : IMartialArtsLessonRepository
{
    private readonly YourMusicDepotContext _context;

    public MartialArtsLessonRepository(YourMusicDepotContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<MartialArtsLesson>> GetAllAsync()
    {
        return await _context.MartialArtsLessons.ToListAsync();
    }

    public async Task<MartialArtsLesson> GetByIdAsync(int id)
    {
        return await _context.MartialArtsLessons.FindAsync(id);
    }

    public async Task AddAsync(MartialArtsLesson martialArtsLesson)
    {
        await _context.MartialArtsLessons.AddAsync(martialArtsLesson);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(MartialArtsLesson martialArtsLesson)
    {
        _context.MartialArtsLessons.Update(martialArtsLesson);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var martialArtsLesson = await _context.MartialArtsLessons.FindAsync(id);
        if (martialArtsLesson != null)
        {
            _context.MartialArtsLessons.Remove(martialArtsLesson);
            await _context.SaveChangesAsync();
        }
    }
}
