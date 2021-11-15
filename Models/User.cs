using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;

namespace Project2_Images.Models
{
    public class User
    {
        public int Id { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string UserPassword { get; set; }


        

    }
}
