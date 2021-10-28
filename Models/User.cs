using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project2_Images.Models
{
    public class User
    {
        public int Id { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        
        public string UserName { get; set; }

        [DataType(DataType.Password)]
        protected string UserPassword { get; set; }

    }
}
