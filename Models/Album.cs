using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project2_Images.Models
{
    public class Album
    {
        public int ID { get; set; }
        [Display(Name = "Album name")]
        public string AlbumName { get; set; }

        public string Uploader { get; set; }

        public DbSet<Image> AlbumContents { get; set; }
        public DbSet<User> GrantedAccess { get; set; }

    }
}
