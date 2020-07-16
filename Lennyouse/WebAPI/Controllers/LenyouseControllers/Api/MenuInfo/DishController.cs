using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Recodme.RD.Lennyouse.BusinessLayer.BusinessObjects.MenuInfo;
using Recodme.RD.Lennyouse.Data.MenuInfo;
using Recodme.RD.Lennyouse.PresentationLayer.WebAPI.Models.MenuInfo;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using WebAPI.Models;

namespace Recodme.RD.Lennyouse.PresentationLayer.WebAPI.Controllers.LennyouseControllers.Api.MenuInfo
{
    [Route("api/[controller]")]
    [ApiController]
    public class DishController : Controller
    {
        private DishBusinessObject _bo = new DishBusinessObject();
        private DietaryRestrictionBusinessObject _drbo = new DietaryRestrictionBusinessObject();

        public async Task<IActionResult> Index()
        {
            var listOperation = await _bo.ListAsync();
            if (!listOperation.Success) return View("Error", new ErrorViewModel() { RequestId = listOperation.Exception.Message });
            var drlistOperation = await _drbo.ListAsync();
            if (!drlistOperation.Success) return View("Error", new ErrorViewModel() { RequestId = listOperation.Exception.Message });

            var dishlist = new List<DishViewModel>();
            foreach (var item in listOperation.Result)
            {
                dishlist.Add(DishViewModel.Parse(item));
            }

            var drlist = new List<DietaryRestrictionViewModel>();
            foreach (var item in drlistOperation.Result)
            {
                drlist.Add(DietaryRestrictionViewModel.Parse(item));
            }
            ViewBag.DietaryRestrictins = drlist;
            return View(dishlist);
        }

        [HttpPost]
        public ActionResult Create([FromBody] DishViewModel vm)
        {
            var dr = new Dish(vm.Name, vm.DietaryRestrictionId);

            var res = _bo.Create(dr);
            var code = res.Success ? HttpStatusCode.OK : HttpStatusCode.InternalServerError;
            return new ObjectResult(code);
        }

        [HttpGet("{id}")]
        public ActionResult<DishViewModel> Get(Guid id)
        {
            var res = _bo.Read(id);
            if (res.Success)
            {
                if (res.Result == null) return NotFound();
                var drvm = DishViewModel.Parse(res.Result);
                return drvm;
            }
            else return new ObjectResult(HttpStatusCode.InternalServerError);
        }

        [Authorize]
        [HttpGet]
        public ActionResult<List<DishViewModel>> List()
        {
            var res = _bo.List();
            if (!res.Success) return new ObjectResult(HttpStatusCode.InternalServerError);
            var list = new List<DishViewModel>();
            foreach (var item in res.Result)
            {
                list.Add(DishViewModel.Parse(item));
            }
            return list;
        }

        [HttpPut]
        public ActionResult Update([FromBody] DishViewModel dr)
        {
            var currentResult = _bo.Read(dr.Id);
            if (!currentResult.Success) return new ObjectResult(HttpStatusCode.InternalServerError);
            var current = currentResult.Result;
            if (current == null) return NotFound();
            if (current.Name == dr.Name && current.DietaryRestrictionId == dr.DietaryRestrictionId) return new ObjectResult(HttpStatusCode.NotModified);

            if (current.Name != dr.Name) current.Name = dr.Name;
            if (current.DietaryRestrictionId != dr.DietaryRestrictionId) current.DietaryRestrictionId = dr.DietaryRestrictionId;
            var updateResult = _bo.Update(current);
            if (!updateResult.Success) return new ObjectResult(HttpStatusCode.InternalServerError);
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            var result = _bo.Delete(id);
            if (result.Success) return Ok();
            return new ObjectResult(HttpStatusCode.InternalServerError);
        }
    }
}
