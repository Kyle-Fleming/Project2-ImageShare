using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project2_Images.Models
{
    public class Album
    {
        public int ID { get; set; }

        public string AlbumName { get; set; }

        public string Uploader { get; set; }

        public User GrantedAcess { get; set; }

        public DbSet<Image> AlbumContents { get; set; }
        public DbSet<User> GrantedAccess { get; set; }

    }
}
