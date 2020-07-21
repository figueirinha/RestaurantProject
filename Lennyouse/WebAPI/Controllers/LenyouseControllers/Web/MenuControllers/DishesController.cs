using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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

        public async Task<IActionResult> Create()
        {
            var drListOperation = await _drbo.ListAsync();
            if (!drListOperation.Success) return View("Error", new ErrorViewModel() { RequestId = "Error" });
            var drList = new List<DietaryRestrictionViewModel>();
            foreach (var dr in drListOperation.Result)
            {
                if (!dr.IsDeleted)
                {
                    var drvm = DietaryRestrictionViewModel.Parse(dr);
                    drList.Add(drvm);
                }
                ViewBag.DietaryRestrictions = drList.Select(dr => new SelectListItem() { Text = dr.Name, Value = dr.Id.ToString() });
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name", "DietaryRestrictionId")] DishViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var dish = vm.ToDish();
                var drOptions = await _drbo.ListAsync();
                var createOperation = await _bo.CreateAsync(dish);
                if (!createOperation.Success) return View("Error", new ErrorViewModel() { RequestId = createOperation.Exception.Message });
                return RedirectToAction(nameof(Index));
            }
            return View(vm);
        }

        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null) return NotFound();
            var getOperation = await _bo.ReadAsync((Guid)id);
            if (!getOperation.Success) return View("Error", new ErrorViewModel() { RequestId = getOperation.Exception.Message });
            if (getOperation.Result == null) return NotFound();
            var vm = DishViewModel.Parse(getOperation.Result);
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind ("Id, Name, DietaryRestrictionId")] DishViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var getOperation = await _bo.ReadAsync((Guid)id);
                if (!getOperation.Success) return View("Error", new ErrorViewModel() { RequestId = getOperation.Exception.Message });
                if (getOperation.Result == null) return NotFound();
                var result = getOperation.Result;
                result.Name = vm.Name;
                result.DietaryRestrictionId = vm.DietaryRestrictionId;
                var updateOperation = await _bo.UpdateAsync(result);
                if (!updateOperation.Success) return View("Error", new ErrorViewModel() { RequestId = updateOperation.Exception.Message });
            }
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null) return NotFound();
            var deleteOperation = await _bo.DeleteAsync((Guid)id);
            if (!deleteOperation.Success) return View("Error", new ErrorViewModel() { RequestId = deleteOperation.Exception.Message });
            return RedirectToAction(nameof(Index));
        }

    }
}