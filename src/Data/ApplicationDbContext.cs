using Microsoft.EntityFrameworkCore;
using DatacomTestProject.Models;

namespace DatacomTestProject.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {
            this.Applications = this.Set<Application>();
         }

        public DbSet<Application> Applications { get; set; }
    }
}