using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProgrammingFinal2024.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgrammingFinal2024
{
    public class MessageModel : PageModel
    {
        private readonly ApplicationDbContext _context;
    private readonly ILogger<MessageModel> _logger;

        public MessageModel(ApplicationDbContext context, ILogger<MessageModel> logger)
        {
            _context = context;
                    _logger = logger;        

        }

        public IList<Message> Messages { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            Messages = await _context.Messages
                .Include(m => m.Sender)
                .Include(m => m.Receiver)
                .ToListAsync();
            return Page();
        }
    }
}
