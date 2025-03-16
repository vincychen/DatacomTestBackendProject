using DatacomTestProject.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DatacomTestProject.Data.Repositories
{
    /// <summary>
    /// Interface for managing application data.
    /// </summary>
    public interface IApplicationRepository
    {
        /// <summary>
        /// Gets all applications.
        /// </summary>
        /// <returns>A list of all applications.</returns>
        Task<IEnumerable<Application>> GetAll();

        /// <summary>
        /// Gets an application by its ID.
        /// </summary>
        /// <param name="id">The ID of the application.</param>
        /// <returns>The application with the specified ID, or null if not found.</returns>
        Task<Application?> GetById(int id);

        /// <summary>
        /// Adds a new application.
        /// </summary>
        /// <param name="application">The application to add.</param>
        /// <returns>The added application.</returns>
        Task<Application?> Add(Application application);

        /// <summary>
        /// Updates the status of an application.
        /// </summary>
        /// <param name="application">The application to update.</param>
        /// <param name="status">The new status of the application.</param>
        /// <returns>The updated application.</returns>
        Task<Application?> UpdateStatus(Application application, ApplicationStatus status);
    }
}