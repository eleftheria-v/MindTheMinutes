using Meeting_Minutes.Data;
using Microsoft.AspNetCore.Mvc;

namespace Meeting_Minutes.Controllers
{
    public class UpcomingController : Controller
    {
        private readonly ApplicationDbContext _context;
        public UpcomingController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var upcomings = _context.Meetings.Where(u => u.MeetingDate>DateTime.Now).ToList();
            return View(upcomings);
        }

    }
}
