using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project2_Images.Models
{
    public class UserContext : DbContext
    {

        public UserContext(DbContextOptions<UserContext> options)
               :base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<User> Users { get; set; }
    }
}
