using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Recodme.RD.Lennyouse.BusinessLayer.BusinessObjects.RestaurantInfo;
using Recodme.RD.Lennyouse.BusinessLayer.BusinessObjects.UserInfo;
using Recodme.RD.Lennyouse.Data.UserInfo;
using Recodme.RD.Lennyouse.PresentationLayer.WebAPI.Models.UserInfo;
using System;
using System.Collections.Generic;
using System.Net;


namespace Recodme.RD.Lennyouse.PresentationLayer.WebAPI.Controllers.LennyouseControllers.Api.UserInfo
{
    [Route("api/[controller]")]
    [ApiController]
    public class LennyouseUserController : ControllerBase
    {
        private LennyouseUserBusinessObject _bo = new LennyouseUserBusinessObject();

        [HttpPost]
        public ActionResult Create([FromBody] LennyouseUserViewModel vm)
        {
            var cr = new LennyouseUser(vm.Id);

            var res = _bo.Create(cr);
            var code = res.Success ? HttpStatusCode.OK : HttpStatusCode.InternalServerError;
            return new ObjectResult(code);
        }

        [HttpGet("{id}")]
        public ActionResult<LennyouseUserViewModel> Get(Guid id)
        {
            var res = _bo.Read(id);
            if (res.Success)
            {
                if (res.Result == null) return NotFound();
                var crvm = LennyouseUserViewModel.Parse(res.Result);
                return crvm;
            }
            else return new ObjectResult(HttpStatusCode.InternalServerError);
        }

        [Authorize]
        [HttpGet]
        public ActionResult<List<LennyouseUserViewModel>> List()
        {
            var res = _bo.List();
            if (!res.Success) return new ObjectResult(HttpStatusCode.InternalServerError);
            var list = new List<LennyouseUserViewModel>();
            foreach (var item in res.Result)
            {
                list.Add(LennyouseUserViewModel.Parse(item));
            }
            return (list);
        }

        [HttpPut]
        public ActionResult Update([FromBody] LennyouseUserViewModel cr)
        {
            var currentResult = _bo.Read(cr.Id); 
            if (!currentResult.Success) return new ObjectResult(HttpStatusCode.InternalServerError);
            var current = currentResult.Result; 
            if (current == null) return NotFound();

            if (current.Id == cr.Id) return new ObjectResult(HttpStatusCode.NotModified);
        
            if (current.Id != cr.Id) current.Id = cr.Id;
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

