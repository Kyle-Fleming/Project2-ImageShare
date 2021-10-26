using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project2_Images.Models
{
    public class ImageContext : DbContext

    {
        public ImageContext(DbContextOptions<ImageContext> options)
            :base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Image> Images { get; set; }
    }
}
