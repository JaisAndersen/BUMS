using BUMS.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BUMS.Pages{
    public class IndexModel : PageModel{
        public bool IsAdmin => HttpContext.User.HasClaim("IsAdmin", bool.TrueString);

        private readonly ILogger<IndexModel> _logger;
        private readonly BUMSDbContext _context;

        public IndexModel(ILogger<IndexModel> logger, BUMSDbContext context){
            _logger = logger;
            _context = context;
        }
       
        public CounterViewModel? Counter { get; set;}

        public async Task OnGetAsync(){
            if(this._context.Groups == null){
                throw new ArgumentNullException("Unable to process");
            }

            Counter = new CounterViewModel {
                UserCount = await _context.Users.CountAsync(),
                GroupCount = await _context.Groups.CountAsync(),
            };
        }
    }
}
