#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Meeting_Minutes.Data;
using Meeting_Minutes.Models;
using Microsoft.AspNetCore.Authorization;

namespace Meeting_Minutes.Controllers
{
    [Authorize]
    public class UpcomingController : Controller
    {
        private readonly ApplicationDbContext _context;
        public UpcomingController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var upcomings = _context.Meetings.Where(u => u.MeetingDate > DateTime.Now).ToList();
            return View(upcomings);
        }

        // POST: Meetings/ShowSearchResults
        [HttpPost]
        public async Task<IActionResult> ShowSearchResults(string SearchPhrase, DateTime? dateFrom, DateTime? dateTo)
        {
            if (!String.IsNullOrEmpty(SearchPhrase) && dateFrom.HasValue && dateTo.HasValue)
            {
                var meetings = await _context.Meetings.Where(j => j.MeetingDate >= dateFrom && j.MeetingDate <= dateTo).ToListAsync();
                meetings = meetings.Where(m => m.Title.Contains(SearchPhrase)).ToList();
                return View("Index", meetings);// await _context.Meetings.Where(j => j.MeetingDate >= dateFrom && j.MeetingDate <= dateTo && j.Title == SearchPhrase).ToListAsync());

            }
            else if (String.IsNullOrEmpty(SearchPhrase) && dateFrom.HasValue && dateTo.HasValue)
            {
                var meetings = await _context.Meetings.Where(j => j.MeetingDate >= dateFrom && j.MeetingDate <= dateTo).ToListAsync();
                return View("Index", meetings);
            }
            else if (!String.IsNullOrEmpty(SearchPhrase) && (dateFrom.HasValue || dateTo.HasValue))
            {
                if (dateFrom.HasValue)
                {
                    var meetings = await _context.Meetings.Where(j => j.MeetingDate >= dateFrom).ToListAsync();
                    meetings = meetings.Where(m => m.Title.Contains(SearchPhrase)).ToList();
                    return View("Index", meetings);

                }
                else
                {
                    var meetings = await _context.Meetings.Where(j => j.MeetingDate <= dateTo).ToListAsync();
                    meetings = meetings.Where(m => m.Title.Contains(SearchPhrase)).ToList();
                    return View("Index", meetings);

                }
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
                var meetings = _context.Meetings.Where(m => m.Title.Contains(SearchPhrase)).ToList();
                return View("Index", meetings);
            }
        }

        // GET: Meetings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meeting = await _context.Meetings
                .FirstOrDefaultAsync(m => m.Id == id);
            if (meeting == null)
            {
                return NotFound();
            }
            //var meetingItems = await _context.MeetingItems
            //.Where(i => i.MeetingId == id).ToListAsync();
            //var model = new Meeting
            //{
            //    Meeting = meeting,
            //    meetingItems = meetingItems
            //};
            return View(meeting);
        }

    }


}