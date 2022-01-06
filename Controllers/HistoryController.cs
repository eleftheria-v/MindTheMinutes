using Meeting_Minutes.Data;
using Microsoft.AspNetCore.Mvc;

namespace Meeting_Minutes.Controllers
{
    public class HistoryController : Controller
    {
        private readonly ApplicationDbContext _context;
        public HistoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var history = _context.Meetings.Where(u => u.MeetingDate<DateTime.Now).ToList();
            return View(history);
        }

    }
}
