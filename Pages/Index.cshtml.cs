using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProgrammingFinal2024.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgrammingFinal2024
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;
    private readonly ILogger<IndexModel> _logger;

        public IndexModel(ApplicationDbContext context, ILogger<IndexModel> logger)
        {
            _context = context;
                    _logger = logger;        

        }

        public IList<Project> SavedProjects { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            SavedProjects = await _context.Projects
                .Where(p => p.Users.Any(u => u.UserID == 1)) 
                .ToListAsync();
            return Page();
        }
    }
}
