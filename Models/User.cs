using System;
using System.ComponentModel.DataAnnotations;

namespace Project2_Images.Models
{
    public class User
    {
        public int Id { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public string UserName { get; set; }

        [DataType(DataType.Password)]
        public string UserPassword { get; set; }

        public Image[] Collection { get; set; }

        public Object[,] Album { get; set; }

    }
}
