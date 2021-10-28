using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Project2_Images.Models;
using System.Threading.Tasks;

namespace Project2_Images.Pages.Users
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
        public User User { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.User.Add(User);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
