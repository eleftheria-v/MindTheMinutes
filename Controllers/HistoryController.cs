using Meeting_Minutes.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        // POST: Meetings/ShowSearchResults
        public async Task<IActionResult> ShowSearchResults(string SearchPhrase)
        {
            if (String.IsNullOrEmpty(SearchPhrase))
            {
                return View("Index", await _context.Meetings.ToListAsync());

            }
            else
            {
                return View("Index", await _context.Meetings.Where(j => j.Title.Contains
               (SearchPhrase)).ToListAsync());
            }

        }


        public async Task<IActionResult> ShowDateSearchResults(DateTime? dateFrom, DateTime? dateTo)



        {
            if (dateFrom.HasValue && dateTo.HasValue)
            {
                return View("Index", await _context.Meetings.Where(j => j.MeetingDate >= dateFrom && j.MeetingDate <= dateTo).ToListAsync());

            }
            else if (dateFrom.HasValue)
            {
                return View("Index", await _context.Meetings.Where(j => j.MeetingDate >= dateFrom).ToListAsync());

            }
            else if (dateTo.HasValue)
            {
                return View("Index", await _context.Meetings.Where(j => j.MeetingDate <= dateTo).ToListAsync());

            }
            else
            {
                return View();
            }


        }

    }
}
