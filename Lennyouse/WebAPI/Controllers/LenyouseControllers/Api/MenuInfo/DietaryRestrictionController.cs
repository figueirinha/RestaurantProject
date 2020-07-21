using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Recodme.RD.Lennyouse.BusinessLayer.BusinessObjects.MenuInfo;
using Recodme.RD.Lennyouse.Data.MenuInfo;
using Recodme.RD.Lennyouse.PresentationLayer.WebAPI.Models.MenuInfo;
using WebAPI.Models;

namespace Recodme.RD.Lennyouse.PresentationLayer.WebAPI.Controllers.LennyouseControllers.Api.MenuInfo
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class DietaryRestrictionController : Controller
    {
        private DietaryRestrictionBusinessObject _bo = new DietaryRestrictionBusinessObject();

        public async Task<IActionResult> Index()
        {
            var listOperation = await _bo.ListAsync();
            if (!listOperation.Success) return View("Error", new ErrorViewModel() { RequestId = listOperation.Exception.Message });


            var list = new List<DietaryRestrictionViewModel>();
            foreach (var item in listOperation.Result)
            {
                if (!item.IsDeleted)
                {
                    list.Add(DietaryRestrictionViewModel.Parse(item));
                }
            }           
            return View(list);
        }


        [HttpPost]
        public ActionResult Create([FromBody] DietaryRestrictionViewModel vm)
        {
            var dr = new DietaryRestriction(vm.Name);

            var res = _bo.Create(dr);
            var code = res.Success ? HttpStatusCode.OK : HttpStatusCode.InternalServerError;
            return new ObjectResult(code);
        }

        [HttpGet("{id}")]
        public ActionResult<DietaryRestrictionViewModel> Get(Guid id)
        {
            var res = _bo.Read(id);
            if (res.Success)
            {
                if (res.Result == null) return NotFound();
                if (res.Result.UpdatedAt != DateTime.UtcNow) return new ObjectResult(HttpStatusCode.InternalServerError);
                var drvm = DietaryRestrictionViewModel.Parse(res.Result);
                return drvm;
            }
            else return new ObjectResult(HttpStatusCode.InternalServerError);
        }

        [HttpGet]
        public ActionResult<List<DietaryRestrictionViewModel>> List()
        {
            var res = _bo.List();
            if (!res.Success) return new ObjectResult(HttpStatusCode.InternalServerError);
            var list = new List<DietaryRestrictionViewModel>();
            foreach (var item in res.Result)
            {

                list.Add(DietaryRestrictionViewModel.Parse(item));
            }

            return (list);


        }

        [HttpPut]
        public ActionResult Update([FromBody] DietaryRestrictionViewModel dr)
        {
            var currentResult = _bo.Read(dr.Id);
            if (!currentResult.Success) return new ObjectResult(HttpStatusCode.InternalServerError);
            var current = currentResult.Result;
            if (current == null) return NotFound();
            if (current.Name == dr.Name) return new ObjectResult(HttpStatusCode.NotModified);

            if (current.Name != dr.Name) current.Name = dr.Name;
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