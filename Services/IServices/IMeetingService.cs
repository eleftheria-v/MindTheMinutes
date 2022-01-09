using Meeting_Minutes.Models;

namespace Meeting_Minutes.Services
{
    public interface IMeetingService
    {
        public List<Meeting> Search(string title);

        public Meeting Create();
        public void Delete();
        public IEnumerable<Meeting> GetAll();
        public Meeting GetById(int id);
        public bool Update();

    }
}