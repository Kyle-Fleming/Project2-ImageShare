using System;
using System.Collections.Generic;
using System.IO;
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
    public class EditModel : PageModel
    {
        private readonly Project2_Images.Data.Project2_ImagesContext _context;

        public EditModel(Project2_Images.Data.Project2_ImagesContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Image Image { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Image = await _context.Image.FirstOrDefaultAsync(m => m.ID == id);

            if (Image == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Image).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ImageExists(Image.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }
        public async Task<IActionResult> UploadImage()
        {
            foreach (var file in Request.Form.Files)
            {
                Image img = new Image();
                img.FileName = file.FileName;

                MemoryStream ms = new MemoryStream();
                file.CopyTo(ms);
                img.AdvertisementAsset = ms.ToArray();

                ms.Close();
                ms.Dispose();

                _context.Image.Add(img);
                await _context.SaveChangesAsync();
            }
            return Page();
        }

        public ActionResult RetrieveImage()
        {
            Image img = _context.Image.OrderByDescending(i => i.ID).SingleOrDefault();
            string imageBase64Data = Convert.ToBase64String(img.AdvertisementAsset);
            string imageDataURL = string.Format("data:image/jpg;base64,{0}", imageBase64Data);
            return Page();
        }
        private bool ImageExists(int id)
        {
            return _context.Image.Any(e => e.ID == id);
        }
    }
}
