using Meeting_Minutes.Data;
using Meeting_Minutes.Models;

namespace Meeting_Minutes.Services
{
    public class UserService : IUserService 
    {
        private readonly ApplicationDbContext _context;

        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }


        public User Create()
        {

            return null;
        }

        public IQueryable<User> Search()
        {
            return null;
        }

        public void Delete (int id)
        {
            
        }

        public IEnumerable<User> GetAll()
        {
            return null;
        }

        public User GetById(int id)
        {
            
            return null;
        }

        public bool Update()
        {
            return false;
        }


    }


}
