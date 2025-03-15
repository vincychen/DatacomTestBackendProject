using DatacomTestProject.Models;

namespace DatacomTestProject.Data.Repositories
{
    public interface IApplicationRepository
    {
        Task<IEnumerable<Application>> GetAll();
        Task<Application?> GetById(int id);
        Task<Application?> Add(Application application);
        Task<Application?> UpdateStatus(Application application, ApplicationStatus status);
    }
}