using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Recodme.RD.Lennyouse.BusinessLayer.BusinessObjects.RestaurantInfo;
using Recodme.RD.Lennyouse.Data.RestaurantInfo;
using Recodme.RD.Lennyouse.PresentationLayer.WebAPI.Models.RestaurantInfo;
using System;
using System.Collections.Generic;
using System.Net;

namespace Recodme.RD.Lennyouse.PresentationLayer.WebAPI.Controllers.LennyouseControllers.Api.RestaurantInfo
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        private RestaurantBusinessObject _bo = new RestaurantBusinessObject();

        [Authorize]
        [HttpPost]
        public ActionResult Create([FromBody] RestaurantViewModel vm)
        {            
            var r = new Restaurant(vm.Name, vm.Address, vm.OpenningHours, vm.ClosingHours, vm.ClosingDays, vm.TableCount);

            var res = _bo.Create(r);
            var code = res.Success ? HttpStatusCode.OK : HttpStatusCode.InternalServerError;
            return new ObjectResult(code);
        }

        [HttpGet("{id}")]
        public ActionResult<RestaurantViewModel> Get(Guid id)
        {
            var res = _bo.Read(id);
            if (res.Success)
            {
                if (res.Result == null) return NotFound();
                var rvm = RestaurantViewModel.Parse(res.Result);
                return rvm;
            }
            else return new ObjectResult(HttpStatusCode.InternalServerError);
        }

        [Authorize]
        [HttpGet]
        public ActionResult<List<RestaurantViewModel>> List()
        {
            var res = _bo.List();
            if (!res.Success) return new ObjectResult(HttpStatusCode.InternalServerError);
            var list = new List<RestaurantViewModel>();
            foreach (var restaurant in res.Result)
            {
                list.Add(RestaurantViewModel.Parse(restaurant));
            }
            return list;
        }

        [HttpPut]
        public ActionResult Update([FromBody] RestaurantViewModel r)
        {
            var currentResult = _bo.Read(r.Id);
            if (!currentResult.Success) return new ObjectResult(HttpStatusCode.InternalServerError);
            var current = currentResult.Result;
            if (current == null) return NotFound();         

            if (current.Address == r.Address && current.OpenningHours == r.OpenningHours &&
                current.ClosingHours == r.ClosingHours && current.ClosingDays == r.ClosingDays &&
                current.TableCount == r.TableCount && current.Name == r.Name)                   
                return new ObjectResult(HttpStatusCode.NotModified);

            if (current.Address != r.Address) current.Address = r.Address;
            if (current.OpenningHours != r.OpenningHours) current.OpenningHours = r.OpenningHours;
            if (current.ClosingHours != r.ClosingHours) current.ClosingHours = r.ClosingHours;
            if (current.ClosingDays != r.ClosingDays) current.ClosingDays = r.ClosingDays;
            if (current.TableCount != r.TableCount) current.TableCount = r.TableCount;            
            if (current.Name != r.Name) current.Name = r.Name;
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
