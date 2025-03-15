using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using DatacomTestProject.Models;
using DatacomTestProject.Data.Repositories;


namespace DatacomTestProject.Data.Repositories
{
    public class ApplicationRepository : IApplicationRepository
    {
        private readonly ApplicationDbContext _context;

        public ApplicationRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Application>> GetAll()
        {
            return await _context.Applications.ToListAsync();
        }

        public async Task<Application?> GetById(int id)
        {
            return await _context.Applications.FindAsync(id);
        }

        public async Task<Application?> Add(Application application)
        {
            await _context.Applications.AddAsync(application);
            await _context.SaveChangesAsync();
            return application;
        }

        public async Task<Application?> UpdateStatus(Application application, ApplicationStatus status)
        {
            application.Status = status;
            await _context.SaveChangesAsync();
            return application;
        }
    }
}