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
using Microsoft.AspNetCore.Session;
using Newtonsoft.Json;

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
                List<Meeting> meetings = await _context.Meetings.Where(j => j.MeetingDate >= dateFrom && j.MeetingDate <= dateTo).ToListAsync();
                meetings = meetings.Where(m => m.Title.Contains(SearchPhrase)).ToList();
                HttpContext.Session.SetString("CurrentMeetings", JsonConvert.SerializeObject(meetings));
                return View("Index", meetings);// await _context.Meetings.Where(j => j.MeetingDate >= dateFrom && j.MeetingDate <= dateTo && j.Title == SearchPhrase).ToListAsync());

            }
            else if (String.IsNullOrEmpty(SearchPhrase) && dateFrom.HasValue && dateTo.HasValue)
            {
                List<Meeting> meetings = _context.Meetings.Where(j => j.MeetingDate >= dateFrom && j.MeetingDate <= dateTo).ToList();
                HttpContext.Session.SetString("CurrentMeetings", JsonConvert.SerializeObject(meetings));
                return View("Index", meetings);
                
            }
            else if (!String.IsNullOrEmpty(SearchPhrase) && (dateFrom.HasValue || dateTo.HasValue))
            {
                if (dateFrom.HasValue)
                {
                    List<Meeting> meetings = await _context.Meetings.Where(j => j.MeetingDate >= dateFrom).ToListAsync();
                    HttpContext.Session.SetString("CurrentMeetings", JsonConvert.SerializeObject(meetings));
                    meetings = meetings.Where(m => m.Title.Contains(SearchPhrase)).ToList();
                    return View("Index", meetings);

                }
                else
                {
                    List<Meeting> meetings = await _context.Meetings.Where(j => j.MeetingDate <= dateTo).ToListAsync();
                    HttpContext.Session.SetString("CurrentMeetings", JsonConvert.SerializeObject(meetings));
                    meetings = meetings.Where(m => m.Title.Contains(SearchPhrase)).ToList();
                    return View("Index", meetings);

                }
            }
            else if (dateFrom.HasValue)
            {
                List<Meeting> meetings = await _context.Meetings.Where(j => j.MeetingDate >= dateTo).ToListAsync();
                HttpContext.Session.SetString("CurrentMeetings", JsonConvert.SerializeObject(meetings));
                return View("Index", meetings);

            }
            else if (dateTo.HasValue)
            {
                List<Meeting> meetings = await _context.Meetings.Where(j => j.MeetingDate <= dateTo).ToListAsync();
                HttpContext.Session.SetString("CurrentMeetings", JsonConvert.SerializeObject(meetings));
                return View("Index", meetings);

            }
            else
            {
                List<Meeting> meetings = _context.Meetings.Where(m => m.Title.Contains(SearchPhrase)).ToList();
                HttpContext.Session.SetString("CurrentMeetings", JsonConvert.SerializeObject(meetings));
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
        public FileContentResult DownloadCSVUpcoming()
        {
            var value = HttpContext.Session.GetString("CurrentMeetings"); 
            List<Meeting> meetingsList = JsonConvert.DeserializeObject<List<Meeting>>(value);

            string csv = "MeetingDate,Title,Status,CreatedBy,CreatedDate,Participants,DateUpdated\n";

            var temp = String.Empty;

         
            //var meetingItemList = _context.MeetingItems.Where(m => m.MeetingId == id).ToList();

            foreach (var element in meetingsList)
            {

                temp = element.MeetingDate.ToString();
                csv = csv + temp;
                temp = element.Title;
                csv = csv + "," + temp;
                temp = element.Status.ToString();
                csv = csv + "," + temp;
                temp = element.CreatedBy;
                csv = csv + temp;
                temp = element.CreatedDate.ToString();
                csv = csv + "," + temp;
                temp = element.Participants;
                csv = csv + "," + temp;
                temp = element.DateUpdated.ToString();
                csv = csv + "," + temp;
                csv = csv + "\n";

            }


            return File(new System.Text.UTF8Encoding().GetBytes(csv), "text/csv", "UpcomingMeetingsReport.csv");
        }
        
    }


}