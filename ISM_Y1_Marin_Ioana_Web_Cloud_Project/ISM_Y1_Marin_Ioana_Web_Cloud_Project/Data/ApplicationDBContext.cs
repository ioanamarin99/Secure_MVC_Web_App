using ISM_Y1_Marin_Ioana_Web_Cloud_Project.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ISM_Y1_Marin_Ioana_Web_Cloud_Project.Data
{
    public class ApplicationDBContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options) {}
        public DbSet<Employee> employees { get; set; }
        public DbSet<Job> jobs { get; set; }
    }
}
