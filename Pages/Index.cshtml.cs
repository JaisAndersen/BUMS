using BUMS.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace BUMS.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly BUMSDbContext _context;
        public bool IsAdmin => HttpContext.User.HasClaim("IsAdmin", bool.TrueString);
        public IndexModel(ILogger<IndexModel> logger, BUMSDbContext context)
        {
            _logger = logger;
            _context = context;
        }
       
        public CounterViewModel Counter { get; set;}

        public async Task OnGetAsync()
        {
            Counter = new CounterViewModel
            {
                UserCount = await _context.Users.CountAsync(),
                GroupCount = await _context.Groups.CountAsync(),
            };
        }
    }
}
