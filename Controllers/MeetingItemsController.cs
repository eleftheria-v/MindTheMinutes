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
using Meeting_Minutes.Models.ViewModels;
using System.Diagnostics;

namespace Meeting_Minutes.Controllers
{
    public class MeetingItemsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _environment;
        public MeetingItemsController(ApplicationDbContext context,IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
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
            ViewBag.Risks = _context.ListValues.Where(x => x.ListTypeID == 1).Select(x => new SelectListItem{
                  Value = x.ID.ToString(),
                  Text = x.Value
              }).ToList();

            return View();
        }

        // POST: 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MeetingId,Description,Deadline,AssignedTo,RiskLevel,RequestedBy,ChangeRequested,VisibleInMinutes,FileList")] MeetingItem meetingItem, int id)
        { //,FileAttachment,FileName,FileType
            if (ModelState.IsValid)
            {
                try
                {
                    //Add Guid
                    var addGuid = Convert.ToString(Guid.NewGuid());

                    if (meetingItem.FileList != null)
                    {
                        foreach (var formfile in meetingItem.FileList)
                        {
                            //save it with Guid + random name
                            //nikos path string path = @$"{_environment.WebRootPath}\files\{string.Concat(addGuid, Path.GetRandomFileName())}.png";
                            string path = @$"{_environment.WebRootPath}\files\ {string.Concat(addGuid, formfile.FileName)}";

                            //The recommended way of saving the file is to save outside of the application folders. 
                            //Because of security issues, if we save the files in the outside directory we can scan those folders
                            //in background checks without affecting the application. 
                            //string path = $"{_config["AppSettings:FileRootPath"]}/{string.Concat(addGuid, Path.GetRandomFileName())}.png";


                            using var fileStream = new FileStream(path, FileMode.Create);
                            await formfile.CopyToAsync(fileStream);
                            meetingItem.FileName = formfile.FileName;
                            meetingItem.FileAttachment = path;
                            break;
                        }
                        
                    }
                    //return RedirectToAction(nameof(Index), "Meetings");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    throw;
                }

              
                meetingItem.MeetingId = id;
                _context.Add(meetingItem);
                await _context.SaveChangesAsync();
                TempData["success"] = "Meeting Item has been successfully Created";
                return RedirectToAction("Details", "Meetings", new { id = id });
            }


            //TempData["error"] = "Meeting Item has been successfully Created";
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
        public async Task<IActionResult> Edit(int id, [Bind("Id,MeetingId,Description,Deadline,AssignedTo,RiskLevel,RequestedBy,ChangeRequested,VisibleInMinutes,FileAttachment,FileName,FileType")] MeetingItem meetingItem )
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

        [HttpPost]
        public async Task<IActionResult> UploadFile([FromForm] FileUpd files, int id)
        {
            try
            {
                //Add Guid
                var addGuid = Convert.ToString(Guid.NewGuid());

                if (files.FileList != null)
                {
                    foreach (var formfile in files.FileList)
                    {
                        //save it with Guid + random name
                        //nikos path string path = @$"{_environment.WebRootPath}\files\{string.Concat(addGuid, Path.GetRandomFileName())}.png";
                        string path = @$"{_environment.WebRootPath}\files\ {string.Concat(addGuid,formfile.FileName)}";
                      
                        //The recommended way of saving the file is to save outside of the application folders. 
                        //Because of security issues, if we save the files in the outside directory we can scan those folders
                        //in background checks without affecting the application. 
                        //string path = $"{_config["AppSettings:FileRootPath"]}/{string.Concat(addGuid, Path.GetRandomFileName())}.png";


                        using var fileStream = new FileStream(path, FileMode.Create);
                        await formfile.CopyToAsync(fileStream);
                    }
                }
                return RedirectToAction(nameof(Index), "Meetings");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        
    }

}
