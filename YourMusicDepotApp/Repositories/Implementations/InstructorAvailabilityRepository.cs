using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using YourMusicDepotApp.Data;
using YourMusicDepotApp.Models;
using YourMusicDepotApp.Repositories.Interfaces;

public class InstructorAvailabilityRepository : IInstructorAvailabilityRepository
{
    // Context for the database, providing access to the application's data.
    private readonly YourMusicDepotContext _context;

 
    /// Constructor that initializes the repository with the database context.

    public InstructorAvailabilityRepository(YourMusicDepotContext context)
    {
        _context = context;
    }

   
    /// Retrieves all instructor availability records from the database.

    public async Task<IEnumerable<InstructorAvailability>> GetAllAsync()
    {
        return await _context.InstructorAvailabilities.ToListAsync();
    }

    
    /// Retrieves a specific instructor availability record by its ID.
 
    public async Task<InstructorAvailability> GetByIdAsync(int id)
    {
        return await _context.InstructorAvailabilities.FindAsync(id);
    }

   
    /// Adds a new instructor availability record to the database.
 
 
    public async Task AddAsync(InstructorAvailability instructorAvailability)
    {
        await _context.InstructorAvailabilities.AddAsync(instructorAvailability);
        await _context.SaveChangesAsync();
    }


    /// Updates an existing instructor availability record in the database.

    public async Task UpdateAsync(InstructorAvailability instructorAvailability)
    {
        _context.InstructorAvailabilities.Update(instructorAvailability);
        await _context.SaveChangesAsync();
    }

    /// Deletes an instructor availability record from the database by its ID.


    public async Task DeleteAsync(int id)
    {
        var instructorAvailability = await _context.InstructorAvailabilities.FindAsync(id);
        if (instructorAvailability != null)
        {
            _context.InstructorAvailabilities.Remove(instructorAvailability);
            await _context.SaveChangesAsync();
        }
    }
}
