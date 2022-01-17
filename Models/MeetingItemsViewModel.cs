namespace Meeting_Minutes.Models
{
    public class MeetingItemsViewModel
    {
        public Meeting Meeting { get; set; }
        public IEnumerable<MeetingItem> meetingItems { get; set; }
    }
}


