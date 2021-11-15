using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Project2_Images.Data;
using Project2_Images.Models;

namespace Project2_Images.Pages.Images
{
    public class CreateModel : PageModel
    {
        private readonly Project2_Images.Data.Project2_ImagesContext _context;

        public CreateModel(Project2_Images.Data.Project2_ImagesContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Image Image { get; set; }
        //method to save images to db
        public async Task<IActionResult> UploadImage()
        {
            foreach (var file in Request.Form.Files)
            {
                Image img = new()
                {
                    FileName = file.FileName
                };

                MemoryStream ms = new();
                file.CopyTo(ms);
                img.AdvertisementAsset = ms.ToArray();

                ms.Close();
                ms.Dispose();

                _context.Image.Add(img);
                await _context.SaveChangesAsync();
            }
            return RedirectToPage("./Index");
        }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Image.Add(Image);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
