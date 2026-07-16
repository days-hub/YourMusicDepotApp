using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using YourMusicDepotApp.Data;
using YourMusicDepotApp.Models;
using YourMusicDepotApp.Repositories.Interfaces;

public class MusicLessonRepository : IMusicLessonRepository
{
    private readonly Func<YourMusicDepotContext> _contextFactory;

    public MusicLessonRepository(Func<YourMusicDepotContext> contextFactory)
    {
        _contextFactory = contextFactory;
    }

    public async Task<IEnumerable<MusicLesson>> GetAllAsync()
    {
        using var context = _contextFactory.Invoke();
        return await context.MusicLessons
            .Include(ml => ml.Instructor)
            .Include(ml => ml.Student)
            .Include(ml => ml.Room)
            .ToListAsync();
    }
    public async Task<IEnumerable<MusicLesson>> GetLessonsWithoutPaymentsAsync()
    {
        using var context = _contextFactory.Invoke();
        return await context.MusicLessons
                            .Where(ml => ml.MusicLessonPayment == null) // Filter first
                            .Include(ml => ml.Student) // Then include related data
                            .ToListAsync();
    }



    public async Task<MusicLesson> GetByIdAsync(int id)
    {
        using var context = _contextFactory.Invoke();
        // Use AsNoTracking to get the entity without tracking it
        return await context.MusicLessons
                            .AsNoTracking()
                            .Include(ml => ml.Instructor)
                            .Include(ml => ml.Student)
                            .Include(ml => ml.Room)
                            .FirstOrDefaultAsync(ml => ml.MusicLessonID == id);
    }


    public async Task AddAsync(MusicLesson musicLesson)
    {
        using var context = _contextFactory.Invoke();
        await context.MusicLessons.AddAsync(musicLesson);
        await context.SaveChangesAsync();
    }

    public async Task UpdateAsync(MusicLesson musicLesson)
    {
        using var context = _contextFactory.Invoke();
        context.Entry(musicLesson).State = EntityState.Modified;
        await context.SaveChangesAsync();
    }


    public async Task DeleteAsync(int id)
    {
        using var context = _contextFactory.Invoke();
        var musicLesson = await context.MusicLessons.FindAsync(id);
        if (musicLesson != null)
        {
            context.MusicLessons.Remove(musicLesson);
            await context.SaveChangesAsync();
        }
    }
}
