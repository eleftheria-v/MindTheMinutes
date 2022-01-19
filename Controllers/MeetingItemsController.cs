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

namespace Meeting_Minutes.Controllers
{
    public class MeetingItemsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MeetingItemsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: MeetingItems
        public async Task<IActionResult> Index()
        {
            return View(await _context.MeetingItems.ToListAsync());
        }

        // GET: MeetingItems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meetingItem = await _context.MeetingItems
                .FirstOrDefaultAsync(m => m.Id == id);
            if (meetingItem == null)
            {
                return NotFound();
            }

            return View(meetingItem);
        }

        // GET:
        public IActionResult Create(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meeting = _context.Meetings
                .FirstOrDefault(m => m.Id == id);

            if (meeting == null)
            {
                return NotFound();
            }

            ViewBag.Message = $"{id}";

            return View();
        }

        // POST: 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MeetingId,Description,Deadline,AssignedTo,RiskLevel,RequestedBy,ChangeRequested,VisibleInMinutes,FileAttachment,FileName,FileType")] MeetingItem meetingItem, int id)
        {
            if (ModelState.IsValid)
            {
                meetingItem.MeetingId = id;

                _context.Add(meetingItem);
                await _context.SaveChangesAsync();
                return RedirectToAction("Details", "Meetings", new {id = id });
            }
            return View(meetingItem);
        }

        // GET: MeetingItems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meetingItem = await _context.MeetingItems.FindAsync(id);
            if (meetingItem == null)
            {
                return NotFound();
            }
            return View(meetingItem);
        }

        // POST: MeetingItems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,MeetingId,Description,Deadline,AssignedTo,RiskLevel,RequestedBy,ChangeRequested,VisibleInMinutes,FileAttachment,FileName,FileType")] MeetingItem meetingItem)
        {
            if (id != meetingItem.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(meetingItem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MeetingItemExists(meetingItem.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(meetingItem);
        }

        // GET: MeetingItems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meetingItem = await _context.MeetingItems
                .FirstOrDefaultAsync(m => m.Id == id);
            if (meetingItem == null)
            {
                return NotFound();
            }

            return View(meetingItem);
        }

        // POST: MeetingItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var meetingItem = await _context.MeetingItems.FindAsync(id);
            _context.MeetingItems.Remove(meetingItem);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MeetingItemExists(int id)
        {
            return _context.MeetingItems.Any(e => e.Id == id);
        }
    }
}
