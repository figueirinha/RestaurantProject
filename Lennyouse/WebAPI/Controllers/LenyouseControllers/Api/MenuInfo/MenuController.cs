using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Recodme.RD.Lennyouse.BusinessLayer.BusinessObjects.MenuInfo;
using Recodme.RD.Lennyouse.Data.MenuInfo;
using Recodme.RD.Lennyouse.PresentationLayer.WebAPI.Models.MenuInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Recodme.RD.Lennyouse.PresentationLayer.WebAPI.Controllers.LennyouseControllers.Api.MenuInfo
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private MenuBusinessObject _bo = new MenuBusinessObject();

        [HttpPost]
        public ActionResult Create([FromBody] MenuViewModel vm)
        {
            var dr = new Menu(vm.Date, vm.RestaurantId, vm.MealId);

            var res = _bo.Create(dr);
            var code = res.Success ? HttpStatusCode.OK : HttpStatusCode.InternalServerError;
            return new ObjectResult(code);
        }

        [HttpGet("{id}")]
        public ActionResult<MenuViewModel> Get(Guid id)
        {
            var res = _bo.Read(id);
            if (res.Success)
            {
                if (res.Result == null) return NotFound();
                var drvm = MenuViewModel.Parse(res.Result);
                return drvm;
            }
            else return new ObjectResult(HttpStatusCode.InternalServerError);
        }

        [Authorize]
        [HttpGet]
        public ActionResult<List<MenuViewModel>> List()
        {
            var res = _bo.List();
            if (!res.Success) return new ObjectResult(HttpStatusCode.InternalServerError);
            var list = new List<MenuViewModel>();
            foreach (var item in res.Result)
            {
                list.Add(MenuViewModel.Parse(item));
            }
            return list;
        }

        [HttpPut]
        public ActionResult Update([FromBody] MenuViewModel dr)
        {
            var currentResult = _bo.Read(dr.Id);
            if (!currentResult.Success) return new ObjectResult(HttpStatusCode.InternalServerError);
            var current = currentResult.Result;
            if (current == null) return NotFound();
            if (current.Date == dr.Date && current.RestaurantId == dr.RestaurantId 
                && current.MealId == dr.MealId) return new ObjectResult(HttpStatusCode.NotModified);

            if (current.Date != dr.Date) current.Date = dr.Date;
            if (current.RestaurantId != dr.RestaurantId) current.RestaurantId = dr.RestaurantId;
            if (current.MealId != dr.MealId) current.MealId = dr.MealId;
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

