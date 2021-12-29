using Meeting_Minutes.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Meeting_Minutes.ViewModel
{
    public class AddEventViewModel
    {
        public MeetingStatus Status { get; set; }
        public List<SelectListItem> MeetingStatuses { get; set; } = new List<SelectListItem>
{
   new SelectListItem(MeetingStatus.New.ToString(), ((int)MeetingStatus.New).ToString()),
   new SelectListItem(MeetingStatus.Started.ToString(), ((int)MeetingStatus.Started).ToString()),
   new SelectListItem(MeetingStatus.Finished.ToString(), ((int)MeetingStatus.Finished).ToString()),
   new SelectListItem(MeetingStatus.Cancelled.ToString(), ((int)MeetingStatus.Cancelled).ToString())
};
    }
}
