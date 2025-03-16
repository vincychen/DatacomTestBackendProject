using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DatacomTestProject.Models;
using DatacomTestProject.Data.Repositories;

namespace DatacomTestProject.Data.Repositories
{
    /// <summary>
    /// Repository class for managing application data.
    /// </summary>
    public class ApplicationRepository : IApplicationRepository
    {
        private readonly ApplicationDbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationRepository"/> class.
        /// </summary>
        /// <param name="context">The database context.</param>
        public ApplicationRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Gets all applications.
        /// </summary>
        /// <returns>A list of all applications.</returns>
        public async Task<IEnumerable<Application>> GetAll()
        {
            return await _context.Applications.ToListAsync();
        }

        /// <summary>
        /// Gets an application by its ID.
        /// </summary>
        /// <param name="id">The ID of the application.</param>
        /// <returns>The application with the specified ID, or null if not found.</returns>
        public async Task<Application?> GetById(int id)
        {
            return await _context.Applications.FindAsync(id);
        }

        /// <summary>
        /// Adds a new application.
        /// </summary>
        /// <param name="application">The application to add.</param>
        /// <returns>The added application.</returns>
        public async Task<Application?> Add(Application application)
        {
            await _context.Applications.AddAsync(application);
            await _context.SaveChangesAsync();
            return application;
        }

        /// <summary>
        /// Updates the status of an application.
        /// </summary>
        /// <param name="application">The application to update.</param>
        /// <param name="status">The new status of the application.</param>
        /// <returns>The updated application.</returns>
        public async Task<Application?> UpdateStatus(Application application, ApplicationStatus status)
        {
            application.Status = status;
            await _context.SaveChangesAsync();
            return application;
        }
    }
}