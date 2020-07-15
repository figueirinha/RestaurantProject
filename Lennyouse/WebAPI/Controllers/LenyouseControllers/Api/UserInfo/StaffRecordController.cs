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
    public class StaffRecordController : ControllerBase
    {
        private StaffRecordBusinessObject _bo = new StaffRecordBusinessObject();

        [HttpPost]
        public ActionResult Create([FromBody] StaffRecordViewModel vm)
        {
            var sr = new StaffRecord( vm.BeginDate, vm.EndDate, vm.PersonId, vm.RestaurantId);

            var res = _bo.Create(sr);
            var code = res.Success ? HttpStatusCode.OK : HttpStatusCode.InternalServerError;
            return new ObjectResult(code);
        }

        [HttpGet("{id}")]
        public ActionResult<StaffRecordViewModel> Get(Guid id)
        {
            var res = _bo.Read(id);
            if (res.Success)
            {
                if (res.Result == null) return NotFound();
                var srvm = StaffRecordViewModel.Parse(res.Result);
                return srvm;
            }
            else return new ObjectResult(HttpStatusCode.InternalServerError);
        }

        [Authorize]
        [HttpGet]
        public ActionResult<List<StaffRecordViewModel>> List()
        {
            var res = _bo.List();
            if (!res.Success) return new ObjectResult(HttpStatusCode.InternalServerError);
            var list = new List<StaffRecordViewModel>();
            foreach (var item in res.Result)
            {
                list.Add(StaffRecordViewModel.Parse(item));
            }
            return (list);
        }

        [HttpPut]
        public ActionResult Update([FromBody] StaffRecordViewModel sr)
        {
            var currentResult = _bo.Read(sr.Id); 
            if (!currentResult.Success) return new ObjectResult(HttpStatusCode.InternalServerError);
            var current = currentResult.Result; 
            if (current == null) return NotFound();

            if (current.BeginDate == sr.BeginDate && current.EndDate == sr.EndDate
                && current.RestaurantId == sr.RestaurantId && current.PersonId == sr.PersonId) 
                return new ObjectResult(HttpStatusCode.NotModified);
            
            if (current.BeginDate != sr.BeginDate) current.BeginDate = sr.BeginDate;
            if (current.EndDate != sr.EndDate) current.EndDate = sr.EndDate;
            if (current.PersonId != sr.PersonId) current.PersonId = sr.PersonId;
            if (current.RestaurantId != sr.RestaurantId) current.RestaurantId = sr.RestaurantId;
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
