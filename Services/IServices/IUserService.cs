using Meeting_Minutes.Models;

namespace Meeting_Minutes.Services
{
    public interface IUserService
    {
        public IQueryable<ApplicationUser> Search(string email);
        public void Delete(int id);
        public IEnumerable<ApplicationUser> GetAll();
        public ApplicationUser GetById(string id);
        public bool Update();
    }
}