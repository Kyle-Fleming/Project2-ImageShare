using Microsoft.EntityFrameworkCore;

namespace Project2_Images.Data
{
    public class Project2_ImagesContext : DbContext
    {
        public Project2_ImagesContext(DbContextOptions<Project2_ImagesContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Project2_Images.Models.Image> Image { get; set; }

        public DbSet<Project2_Images.Models.User> User { get; set; }
    }
}
