using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProgrammingFinal2024.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgrammingFinal2024.Pages
{
    public class SavedProjectsModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public SavedProjectsModel(ApplicationDbContext context)
    {
        _context = context;
    }

    public IList<Project> SavedProjects { get; set; }

    public async Task OnGetAsync()
    {
        var user = await _context.Users.Include(u => u.ParticipatingProjects).FirstOrDefaultAsync(u => u.UserID == 1); // Assuming user with ID 1 is logged in
        SavedProjects = user?.ParticipatingProjects.ToList() ?? new List<Project>();
    }
}
}
