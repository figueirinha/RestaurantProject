using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Recodme.RD.Lennyouse.BusinessLayer.BusinessObjects.MenuInfo;
using Recodme.RD.Lennyouse.PresentationLayer.WebAPI.Models.MenuInfo;
using System.Diagnostics;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class HomeController : Controller
    {

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
       

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
