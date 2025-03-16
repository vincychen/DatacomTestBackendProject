using DatacomTestProject.Data.Repositories;
using DatacomTestProject.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DatacomTestProject.Services
{
    /// <summary>
    /// Service class for managing application operations.
    /// </summary>
    public class ApplicationService
    {
        private readonly IApplicationRepository _applicationRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationService"/> class.
        /// </summary>
        /// <param name="applicationRepository">The application repository.</param>
        public ApplicationService(IApplicationRepository applicationRepository)
        {
            _applicationRepository = applicationRepository;
        }

        /// <summary>
        /// Gets all applications.
        /// </summary>
        /// <returns>A list of all applications.</returns>
        public async Task<IEnumerable<Application>> GetAllApplications()
        {
            return await _applicationRepository.GetAll();
        }

        /// <summary>
        /// Gets an application by its ID.
        /// </summary>
        /// <param name="id">The ID of the application.</param>
        /// <returns>The application with the specified ID, or null if not found.</returns>
        public async Task<Application?> GetApplicationById(int id)
        {
            return await _applicationRepository.GetById(id);
        }

        /// <summary>
        /// Creates a new application.
        /// </summary>
        /// <param name="application">The application to create.</param>
        /// <returns>The created application.</returns>
        public async Task<Application?> CreateApplication(Application application)
        {
            return await _applicationRepository.Add(application);
        }

        /// <summary>
        /// Updates the status of an application.
        /// </summary>
        /// <param name="application">The application to update.</param>
        /// <param name="status">The new status of the application.</param>
        /// <returns>The updated application.</returns>
        public async Task<Application?> UpdateApplication(Application application, ApplicationStatus status)
        {
            return await _applicationRepository.UpdateStatus(application, status);
        }
    }
}