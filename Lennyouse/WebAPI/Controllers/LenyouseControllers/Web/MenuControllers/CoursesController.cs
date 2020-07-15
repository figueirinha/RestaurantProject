using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Recodme.RD.Lennyouse.PresentationLayer.WebAPI.Controllers.LenyouseControllers.Web.MenuControllers
{
    [Route("[Controller]")]
    [ApiExplorerSettings(IgnoreApi = true)]

    public class CoursesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}