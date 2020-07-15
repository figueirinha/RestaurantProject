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
    public class TitleController : ControllerBase
    {
        private TitleBusinessObject _bo = new TitleBusinessObject();

        [Authorize]
        [HttpPost]
        public ActionResult Create([FromBody] TitleViewModel vm)
        {
            var t = new Title(vm.Position, vm.Description, vm.Name);

            var res = _bo.Create(t);
            var code = res.Success ? HttpStatusCode.OK : HttpStatusCode.InternalServerError;
            return new ObjectResult(code);
        }

        [HttpGet("{id}")]
        public ActionResult<TitleViewModel> Get(Guid id)
        {
            var res = _bo.Read(id);
            if (res.Success)
            {
                if (res.Result == null) return NotFound();
                var tvm = TitleViewModel.Parse(res.Result);
                return tvm;
            }
            else return new ObjectResult(HttpStatusCode.InternalServerError);
        }

        [Authorize]
        [HttpGet]
        public ActionResult<List<TitleViewModel>> List()
        {
            var res = _bo.List();
            if (!res.Success) return new ObjectResult(HttpStatusCode.InternalServerError);
            var list = new List<TitleViewModel>();
            foreach (var title in res.Result)
            {
                list.Add(TitleViewModel.Parse(title));
            }
            return list;
        }

        [HttpPut]
        public ActionResult Update([FromBody] TitleViewModel t)
        {
            {
                var currentResult = _bo.Read(t.Id);
                if (!currentResult.Success) return new ObjectResult(HttpStatusCode.InternalServerError);
                var current = currentResult.Result;
                if (current == null) return NotFound();
                if (current.Position == current.Position && current.Description == current.Description &&
                    current.Name == t.Name)
                    return new ObjectResult(HttpStatusCode.NotModified);

                if (current.Description != t.Description) current.Description = t.Description;
                if (current.Position != t.Position) current.Position = t.Position;
                if (current.Name != t.Name) current.Name = t.Name;
                var updateResult = _bo.Update(current);
                if (!updateResult.Success) return new ObjectResult(HttpStatusCode.InternalServerError);
                return Ok();
            }
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
    

