using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using YourMusicDepotApp.Models;

namespace YourMusicDepotApp.Repositories.Interfaces
{
    /// <summary>
    /// Interface defining the contract for a repository managing student data.
    /// </summary>
    public interface IStudentRepository
    {
       
        /// Retrieves all students without related data.
      
        Task<IEnumerable<Student>> GetAllAsync();

      
        /// Retrieves all students along with their related details like music progress, etc.
     
        Task<IEnumerable<Student>> GetAllWithDetailsAsync();

       
        /// Retrieves a single student by their ID.
       
        Task<Student> GetByIdAsync(int id);

       
        /// Adds a new student to the repository.
       
        Task AddAsync(Student student);

       
        /// Updates an existing student in the repository.
      
        Task UpdateAsync(Student student);

        
        /// Deletes a student from the repository by their ID.
        
       
        Task DeleteAsync(int id);
    }
}
