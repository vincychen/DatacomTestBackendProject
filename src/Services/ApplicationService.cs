using DatacomTestProject.Data.Repositories;
using DatacomTestProject.Models;

namespace DatacomTestProject.Services
{
    public class ApplicationService
    {
        private readonly IApplicationRepository _applicationRepository;

        public ApplicationService(IApplicationRepository applicationRepository)
        {
            _applicationRepository = applicationRepository;
        }

        public async Task<IEnumerable<Application>> GetAllApplications()
        {
            return await _applicationRepository.GetAll();
        }

        public async Task<Application?> GetApplicationById(int id)
        {
            return await _applicationRepository.GetById(id);
        }

        public async Task<Application?> CreateApplication(Application application)
        {
            return await _applicationRepository.Add(application);
        }

        public async Task<Application?> UpdateApplication(Application application, ApplicationStatus status)
        {
            return await _applicationRepository.UpdateStatus(application, status);
        }
    }
}