using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Project2_Images.Models;

namespace Project2_Images.Data
{
    public class Project2_UserContext : DbContext
    {
        public Project2_UserContext (DbContextOptions<Project2_UserContext> options)
            : base(options)
        {
        }

        public DbSet<Project2_Images.Models.User> User { get; set; }
    }
}
