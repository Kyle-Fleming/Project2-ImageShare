using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Project2_Images.Models;

namespace Project2_Images.Pages.Utilities
{
    public class SignInModel : PageModel
    {
        [BindProperty]
        public new User User { get; set; }

        public void OnGet()
        {
        }
    }
}
