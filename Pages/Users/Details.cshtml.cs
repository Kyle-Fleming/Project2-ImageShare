using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Project2_Images.Models;
using System.Threading.Tasks;

namespace Project2_Images.Pages.Users
{
    public class DetailsModel : PageModel
    {
        private readonly Project2_Images.Data.Project2_ImagesContext _context;

        public DetailsModel(Project2_Images.Data.Project2_ImagesContext context)
        {
            _context = context;
        }

        public User User { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            User = await _context.User.FirstOrDefaultAsync(m => m.Id == id);

            if (User == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
