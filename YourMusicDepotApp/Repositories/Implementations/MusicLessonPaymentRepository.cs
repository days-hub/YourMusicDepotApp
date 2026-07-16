using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using YourMusicDepotApp.Data;
using YourMusicDepotApp.Models;
using YourMusicDepotApp.Repositories.Interfaces;

public class MusicLessonPaymentRepository : IMusicLessonPaymentRepository
{
    private readonly Func<YourMusicDepotContext> _contextFactory;

    public MusicLessonPaymentRepository(Func<YourMusicDepotContext> contextFactory)
    {
        _contextFactory = contextFactory;
    }

    public IQueryable<MusicLessonPayment> GetAll()
    {
        var context = _contextFactory.Invoke();
        return context.MusicLessonPayments
                      .Include(mlp => mlp.MusicLesson)
                      .ThenInclude(ml => ml.Student)
                      .AsNoTracking(); 
    }

    public async Task<MusicLessonPayment> GetByIdAsync(int id)
    {
        using var context = _contextFactory.Invoke();
        return await context.MusicLessonPayments.FindAsync(id);
    }

    public async Task AddAsync(MusicLessonPayment musicLessonPayment)
    {
        using var context = _contextFactory.Invoke();
        await context.MusicLessonPayments.AddAsync(musicLessonPayment);
        await context.SaveChangesAsync();
    }

    public async Task UpdateAsync(MusicLessonPayment musicLessonPayment)
    {
        using var context = _contextFactory.Invoke();
        context.MusicLessonPayments.Update(musicLessonPayment);
        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        using var context = _contextFactory.Invoke();
        var musicLessonPayment = await context.MusicLessonPayments.FindAsync(id);
        if (musicLessonPayment != null)
        {
            context.MusicLessonPayments.Remove(musicLessonPayment);
            await context.SaveChangesAsync();
        }
    }
}
