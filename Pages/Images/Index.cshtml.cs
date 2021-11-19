using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Project2_Images.Data;
using Project2_Images.Models;

namespace Project2_Images.Pages.Images
{
    public class IndexModel : PageModel
    {
        private readonly Project2_Images.Data.Project2_ImagesContext _context;

        public IndexModel(Project2_Images.Data.Project2_ImagesContext context)
        {
            _context = context;
        }

        public IList<Image> Image { get;set; }

        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        public SelectList Metadata { get; set; }
        [BindProperty(SupportsGet = true)]
        public string MetadataTags { get; set; }
        
        public async Task OnGetAsync()
        {
            var images = from i in _context.Image 
                         select i;

            if (!string.IsNullOrEmpty(SearchString))
            {
                images = images.Where(s => s.CapturedBy.Contains(SearchString));
            }
            if (!string.IsNullOrEmpty(SearchString))
            {
                images = images.Where(s => s.GeoTag.Contains(SearchString));
            }
            if (!string.IsNullOrEmpty(SearchString))
            {
                images = images.Where(s => s.Tags.Contains(SearchString));
            }

            Image = await _context.Image.ToListAsync();

        }
    }
}
