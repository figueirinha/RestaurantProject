using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
    public class ClientRecordController : ControllerBase
    {
        private ClientRecordBusinessObject _bo = new ClientRecordBusinessObject();

        [HttpPost]
        public ActionResult Create([FromBody] ClientRecordViewModel vm)
        {
            var cr = new ClientRecord(vm.RegisterDate, vm.PersonId, vm.RestaurantId);

            var res = _bo.Create(cr);
            var code = res.Success ? HttpStatusCode.OK : HttpStatusCode.InternalServerError;
            return new ObjectResult(code);
        }

        [HttpGet("{id}")]
        public ActionResult<ClientRecordViewModel> Get(Guid id)
        {
            var res = _bo.Read(id);
            if (res.Success)
            {
                if (res.Result == null) return NotFound();
                var crvm = ClientRecordViewModel.Parse(res.Result);
                return crvm;
            }
            else return new ObjectResult(HttpStatusCode.InternalServerError);
        }

        [Authorize]
        [HttpGet]
        public ActionResult<List<ClientRecordViewModel>> List()
        {
            var res = _bo.List();
            if (!res.Success) return new ObjectResult(HttpStatusCode.InternalServerError);
            var list = new List<ClientRecordViewModel>();
            foreach (var item in res.Result)
            {
                list.Add(ClientRecordViewModel.Parse(item));
            }
            return (list);
        }

        [HttpPut]
        public ActionResult Update([FromBody] ClientRecordViewModel cr)
        {
            var currentResult = _bo.Read(cr.Id); 
            if (!currentResult.Success) return new ObjectResult(HttpStatusCode.InternalServerError);
            var current = currentResult.Result; 
            if (current == null) return NotFound();

            if (current.RegisterDate == cr.RegisterDate && current.PersonId == cr.PersonId &&
                current.RestaurantId == cr.RestaurantId) 
                return new ObjectResult(HttpStatusCode.NotModified);

            if (current.RegisterDate != cr.RegisterDate) current.RegisterDate = cr.RegisterDate;
            if (current.PersonId != cr.PersonId) current.PersonId = cr.PersonId;
            if (current.RestaurantId != cr.RestaurantId) current.RestaurantId = cr.RestaurantId;
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

