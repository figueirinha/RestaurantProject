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
    public class PersonController : ControllerBase
    {
        private PersonBusinessObject _bo = new PersonBusinessObject();
        


        [HttpPost]
        public ActionResult Create([FromBody] PersonViewModel vm)
        {
            var p = new Person(vm.VatNumber, vm.PhoneNumber, vm.FirstName, vm.LastName, vm.BirthDate);            
            var res = _bo.Create(p);
            var code = res.Success ? HttpStatusCode.OK : HttpStatusCode.InternalServerError;
            return new ObjectResult(code);
        }

        [HttpGet("{id}")]
        public ActionResult<PersonViewModel> Get(Guid id)
        {
            var res = _bo.Read(id);
            if (res.Success)
            {
                if (res.Result == null) return NotFound();
                var pvm = PersonViewModel.Parse(res.Result);
                return pvm;
            }
            else return new ObjectResult(HttpStatusCode.InternalServerError);
        }

        [HttpGet]
        public ActionResult<List<PersonViewModel>> List()
        {
            var res = _bo.List();
            if (!res.Success) return new ObjectResult(HttpStatusCode.InternalServerError);
            var list = new List<PersonViewModel>();
            foreach (var item in res.Result)
            {
                list.Add(PersonViewModel.Parse(item));
            }
            return (list);
        }

        [HttpPut]
        public ActionResult Update([FromBody] PersonViewModel p)
        {
            var currentResult = _bo.Read(p.Id); // somente lê
            if (!currentResult.Success) return new ObjectResult(HttpStatusCode.InternalServerError);
            var current = currentResult.Result; // vai buscar o resultado
            if (current == null) return NotFound();

            if (current.VatNumber == p.VatNumber && current.PhoneNumber == p.PhoneNumber &&
                current.FirstName == p.FirstName && current.LastName == p.LastName &&
                current.BirthDate == p.BirthDate) return new ObjectResult(HttpStatusCode.NotModified);

            if (current.VatNumber != p.VatNumber) current.VatNumber = p.VatNumber;
            if (current.PhoneNumber != p.PhoneNumber) current.PhoneNumber = p.PhoneNumber;
            if (current.FirstName != p.FirstName) current.FirstName = p.FirstName;
            if (current.LastName != p.LastName) current.LastName = p.LastName;
            if (current.BirthDate != p.BirthDate) current.BirthDate = p.BirthDate;
      

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

