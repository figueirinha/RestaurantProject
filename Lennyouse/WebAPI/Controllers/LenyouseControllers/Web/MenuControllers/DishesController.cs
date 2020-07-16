using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Recodme.RD.Lennyouse.BusinessLayer.BusinessObjects.MenuInfo;
using Recodme.RD.Lennyouse.PresentationLayer.WebAPI.Models.MenuInfo;
using WebAPI.Models;

namespace Recodme.RD.Lennyouse.PresentationLayer.WebAPI.Controllers.LenyouseControllers.Web.MenuControllers
{

    [ApiExplorerSettings(IgnoreApi = true)]
    public class DishesController : Controller
    {
        private readonly DishBusinessObject _bo = new DishBusinessObject();
        private readonly DietaryRestrictionBusinessObject _drbo = new DietaryRestrictionBusinessObject();

        public async Task<IActionResult> Index()
        {
            var listOperation = await _bo.ListAsync();
            if (!listOperation.Success) return View("Error", new ErrorViewModel() { RequestId = listOperation.Exception.Message });
            var drListOperation = await _drbo.ListAsync();
            if (!drListOperation.Success) return View("Error", new ErrorViewModel() { RequestId = drListOperation.Exception.Message });

            var dishLst = new List<DishViewModel>();
            foreach(var item in listOperation.Result)
            {
                if (!item.IsDeleted)
                {
                    dishLst.Add(DishViewModel.Parse(item));
                }
            }

            var drLst = new List<DietaryRestrictionViewModel>();
            foreach (var item in drListOperation.Result)
            {
                if (!item.IsDeleted)
                {
                    drLst.Add(DietaryRestrictionViewModel.Parse(item));
                }
            }

            ViewBag.DietaryRestrictions = drLst;
            return View(dishLst);
        }

        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null) return NotFound();
            var getOperation = await _bo.ReadAsync((Guid)id);
            if (!getOperation.Success) return View("Error", new ErrorViewModel() { RequestId = getOperation.Exception.Message });
            if (getOperation.Result == null) return NotFound();
            var vm = DishViewModel.Parse(getOperation.Result);
            return View(vm);
        }
    }
}