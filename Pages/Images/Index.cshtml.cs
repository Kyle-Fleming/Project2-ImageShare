﻿using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Project2_Images.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project2_Images.Pages.Images
{
    public class IndexModel : PageModel
    {
        private readonly Project2_Images.Data.Project2_ImagesContext _context;

        public IndexModel(Project2_Images.Data.Project2_ImagesContext context)
        {
            _context = context;
        }

        public IList<Image> Image { get; set; }

        public async Task OnGetAsync()
        {
            Image = await _context.Image.ToListAsync();
        }
    }
}
