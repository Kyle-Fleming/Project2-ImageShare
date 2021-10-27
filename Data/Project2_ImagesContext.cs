using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Project2_Images.Models;

namespace Project2_Images.Data
{
    public class Project2_ImagesContext : DbContext
    {
        public Project2_ImagesContext (DbContextOptions<Project2_ImagesContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Project2_Images.Models.Image> Image { get; set; }
    }
}
