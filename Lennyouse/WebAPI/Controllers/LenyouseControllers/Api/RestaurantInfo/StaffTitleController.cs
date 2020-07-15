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
    public class StaffTitleController : ControllerBase
    {
        private StaffTitleBusinessObject _bo = new StaffTitleBusinessObject();

        [Authorize]
        [HttpPost]     
        public ActionResult Create([FromBody] StaffTitleViewModel vm)
        {
            var st = new StaffTitle(vm.StaffRecordId, vm.TitleId, vm.StartDate, vm.EndDate);

            var res = _bo.Create(st);
            var code = res.Success ? HttpStatusCode.OK : HttpStatusCode.InternalServerError;
            return new ObjectResult(code);
        }

        [HttpGet("{id}")]
        public ActionResult<StaffTitleViewModel> Get(Guid id)
        {
            var res = _bo.Read(id);
            if (res.Success)
            {
                if (res.Result == null) return NotFound();
                var stvm = StaffTitleViewModel.Parse(res.Result);
                return stvm;
            }
            else return new ObjectResult(HttpStatusCode.InternalServerError);
        }

        [Authorize]
        [HttpGet]
        public ActionResult<List<StaffTitleViewModel>> List()
        {
            var res = _bo.List();
            if (!res.Success) return new ObjectResult(HttpStatusCode.InternalServerError);
            var list = new List<StaffTitleViewModel>();
            foreach (var staffTitle in res.Result)
            {
                list.Add(StaffTitleViewModel.Parse(staffTitle));
            }
            return list;
        }

        [HttpPut]
        public ActionResult Update([FromBody] StaffTitleViewModel st)
        {
            var currentResult = _bo.Read(st.Id);
            if (!currentResult.Success) return new ObjectResult(HttpStatusCode.InternalServerError);
            var current = currentResult.Result;
            if (current == null) return NotFound();
            if (current.StartDate == st.StartDate && current.EndDate == st.EndDate && 
                current.TitleId == st.TitleId && current.StaffRecordId == st.StaffRecordId) return new ObjectResult(HttpStatusCode.NotModified);

            if (current.StartDate!= st.StartDate) current.StartDate = st.StartDate;
            if (current.EndDate != st.EndDate) current.EndDate = st.EndDate;
            if (current.TitleId != st.TitleId) current.TitleId = st.TitleId;
            if (current.StaffRecordId != st.StaffRecordId) current.StaffRecordId = st.StaffRecordId;

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
