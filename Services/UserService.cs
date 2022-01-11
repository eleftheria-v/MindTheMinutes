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


        public IQueryable<ApplicationUser> Search(string email)
        {
            if (email == null)
            {
                return null;
            }
            var users = _context.Users.Where(u => u.Email == email).AsQueryable();

            return users;
        }

        public ApplicationUser GetById(string id)
        {
            if (id == null)
            {
                return null;
            }
            var user = _context.Users.FirstOrDefault(u => u.Id == id);
            return user;
        }


        public void Delete (int id)
        {
            
        }

        public IEnumerable<ApplicationUser> GetAll()
        {
            return null;
        }

        public bool Update()
        {
            return false;
        }




    }


}
