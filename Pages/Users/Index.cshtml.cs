using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Project2_Images.Data;
using Project2_Images.Models;

namespace Project2_Images.Pages.Users
{
    public class IndexModel : PageModel
    {
        private readonly Project2_Images.Data.Project2_ImagesContext _context;

        public IndexModel(Project2_Images.Data.Project2_ImagesContext context)
        {
            _context = context;
        }

        public IList<User> User { get;set; }

        public async Task OnGetAsync()
        {
            User = await _context.User.ToListAsync();
        }
    }
}
