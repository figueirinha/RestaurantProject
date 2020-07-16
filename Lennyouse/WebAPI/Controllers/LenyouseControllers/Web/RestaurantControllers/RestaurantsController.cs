using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Recodme.RD.Lennyouse.BusinessLayer.BusinessObjects.RestaurantInfo;
using Recodme.RD.Lennyouse.PresentationLayer.WebAPI.Models.RestaurantInfo;
using WebAPI.Models;

namespace Recodme.RD.Lennyouse.PresentationLayer.WebAPI.Controllers.LenyouseControllers.Web.RestaurantControllers
{

    [ApiExplorerSettings(IgnoreApi = true)]
    public class RestaurantsController : Controller
    {
        private readonly RestaurantBusinessObject _bo = new RestaurantBusinessObject();

        public async Task<IActionResult> Index()
        {
            var listOperation = await _bo.ListAsync();
            if (!listOperation.Success) return View("Error", new ErrorViewModel() { RequestId = listOperation.Exception.Message });
            var lst = new List<RestaurantViewModel>();
            foreach (var item in listOperation.Result)
            {
                if (!item.IsDeleted)
                {
                    lst.Add(RestaurantViewModel.Parse(item));
                }
            }
            return View(lst);
        }

        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null) return NotFound();
            var getOperation = await _bo.ReadAsync((Guid)id);
            if (!getOperation.Success) return View("Error", new ErrorViewModel() { RequestId = getOperation.Exception.Message });
            if (getOperation.Result == null) return NotFound();
            var vm = RestaurantViewModel.Parse(getOperation.Result);
            return View(vm);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name", "Address", "OpenningHours", "ClosingHours", "ClosingDays", "TableCount")] RestaurantViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var Restaurant = vm.ToRestaurant();
                var createOperation = await _bo.CreateAsync(Restaurant);
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
            var vm = RestaurantViewModel.Parse(getOperation.Result);
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id, Name, Address, OpenningHours, ClosingHours, ClosingDays, TableCount")] RestaurantViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var getOperation = await _bo.ReadAsync((Guid)id);
                if (!getOperation.Success) return View("Error", new ErrorViewModel() { RequestId = getOperation.Exception.Message });
                if (getOperation.Result == null) return NotFound();
                var result = getOperation.Result;
                result.Name = vm.Name;
                result.Address = vm.Address;
                result.OpenningHours = vm.OpenningHours;
                result.ClosingHours = vm.ClosingHours;
                result.ClosingDays = vm.ClosingDays;
                result.TableCount = vm.TableCount;
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