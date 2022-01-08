using Meeting_Minutes.Data;
using Meeting_Minutes.Models;

namespace Meeting_Minutes.Services
{
    public class MeetingService : IMeetingService
    {
        private readonly ApplicationDbContext _context;

        public MeetingService(ApplicationDbContext context)
        {
            _context = context; 
        }

        public List<Meeting> Search(string title)
        {
            if (title == null)
            {
                return null;
            }

            var meeting = _context.Meetings.Where(m => m.Title == title).ToList();

            return meeting;

        }

        public Meeting Create()
        {
            return new Meeting();
        }

        public void Delete()
        {

        }

        public IEnumerable<Meeting> GetAll()
        {
            return new List<Meeting>();
        }

        public Meeting GetById(int id)
        {
            var meeting = _context.Meetings.FirstOrDefault(m => m.Id == id);

            return meeting;
        }

        public bool Update()
        {
            return false;
        }
    }
}
