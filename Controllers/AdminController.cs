using Meeting_Minutes.Data;
using Meeting_Minutes.Services;
using Microsoft.AspNetCore.Mvc;

namespace Meeting_Minutes.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;
        private IUserService _userService;

        public AdminController(ApplicationDbContext context, IUserService userService)
        {
            _context = context;
            _userService = userService;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
