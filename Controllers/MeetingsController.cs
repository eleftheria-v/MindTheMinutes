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
    public class MeetingsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MeetingsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Meetings
        public async Task<IActionResult> Index()
        {
            return View(await _context.Meetings.ToListAsync());
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
            var meetingItems = await _context.MeetingItems
            .Where(i => i.MeetingId == id).ToListAsync();
            var model = new MeetingItemsViewModel
            {
                Meeting = meeting,
                meetingItems = meetingItems
            };
            return View(model);
            }

            // GET: Meetings/Create
            public IActionResult Create()
            {
                return View();
            }

            // POST: Meetings/Create
            // To protect from overposting attacks, enable the specific properties you want to bind to.
            // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Create([Bind("Id,CreatedDate,CreatedBy,DateUpdated,MeetingDate,Title,ExternalParticipants")] Meeting meeting)
            {
                if (ModelState.IsValid)
                {
                    _context.Add(meeting);
                    await _context.SaveChangesAsync();
                    TempData["success"] = "Meeting created successfully";
                    return RedirectToAction(nameof(Index));

                }
                return View(meeting);
            }

            // GET: Meetings/Edit/5
            public async Task<IActionResult> Edit(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var meeting = await _context.Meetings.FindAsync(id);
                if (meeting == null)
                {
                    return NotFound();
                }
                return View(meeting);
            }

            // POST: Meetings/Edit/5
            // To protect from overposting attacks, enable the specific properties you want to bind to.
            // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Edit(int id, [Bind("Id,CreatedDate,CreatedBy,DateUpdated,MeetingDate,Status,Title,ExternalParticipants")] Meeting meeting)
            {
                if (id != meeting.Id)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(meeting);
                        await _context.SaveChangesAsync();

                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!MeetingExists(meeting.Id))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                    TempData["success"] = "Meeting updated successfully";

                    return RedirectToAction(nameof(Index));
                }
                return View(meeting);
            }

            // GET: Meetings/Delete/5
            public async Task<IActionResult> Delete(int? id)
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

                return View(meeting);
            }

            // POST: Meetings/Delete/5
            [HttpPost, ActionName("Delete")]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> DeleteConfirmed(int id)
            {
                var meeting = await _context.Meetings.FindAsync(id);
                _context.Meetings.Remove(meeting);
                await _context.SaveChangesAsync();
                TempData["success"] = "Meeting deleted successfully";

                return RedirectToAction(nameof(Index));
            }

            private bool MeetingExists(int id)
            {
                return _context.Meetings.Any(e => e.Id == id);
            }
        }
    }

