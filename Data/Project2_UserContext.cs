using Microsoft.EntityFrameworkCore;

namespace Project2_Images.Data
{
    public class Project2_UserContext : DbContext
    {
        public Project2_UserContext(DbContextOptions<Project2_UserContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Project2_Images.Models.User> User { get; set; }
    }
}
