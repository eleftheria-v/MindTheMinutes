using Meeting_Minutes.Models;

namespace Meeting_Minutes.Services
{
    public interface IUserService
    {
        public User Create();
        public IQueryable<User> Search();
        public void Delete(int id);
        public IEnumerable<User> GetAll();
        public User GetById(int id);
        public bool Update();
    }
}