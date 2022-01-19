using Meeting_Minutes.Models;
using Meeting_Minutes.Models.ViewModels;
using Meeting_Minutes.Services.IServices;
using Microsoft.AspNetCore.Authorization;
//using Meeting_Minutes.ViewModels;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using System.Diagnostics;

namespace Meeting_Minutes.Controllers
{
    
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private IMailService _mailService;
        public HomeController(ILogger<HomeController> logger, IMailService mailService)
        {
            _logger = logger;
            _mailService = mailService;
        }

        public IActionResult Index()
        {   
            //MimeMessage message = new MimeMessage();
            //_mailService.sendMail(message);
            return View();
        }

        //public IActionResult Privacy()
        //{
        //    return View();
        //}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}