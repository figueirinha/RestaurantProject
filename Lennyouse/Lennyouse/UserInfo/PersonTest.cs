using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recodme.RD.Lennyouse.BusinessLayer.BusinessObjects.UserInfo;
using Recodme.RD.Lennyouse.Data.UserInfo;
using Recodme.RD.Lennyouse.DataAccessLayer.Seeders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Recodme.RD.Lennyouse.LennyouseTest.UserInfo
{
    [TestClass]
    public class PersonTest
    {
        [TestMethod]
        public void TestCreatePerson()
        {
            ContextSeeders.Seed();
            var pbo = new PersonBusinessObject();
            var lubo = new LennyouseUserBusinessObject();

            var _lennyouseUser = new LennyouseUser(Guid.NewGuid());
            lubo.Create(_lennyouseUser);

            var _person = new Person(3654324444, 0000000, "Marco", "Figueirnha", DateTime.UtcNow, _lennyouseUser.Id);
            var resCreate = pbo.Create(_person);
            var resGet = pbo.Read(_person.Id);

            Assert.IsTrue(resCreate.Success && resGet.Success && resGet.Result != null);
        }

        [TestMethod]
        public void TestCreatePersonAsync()
        {
            ContextSeeders.Seed();
            var pbo = new PersonBusinessObject();
            var lubo = new LennyouseUserBusinessObject();

            var _lennyouseUser = new LennyouseUser(Guid.NewGuid());
            lubo.Create(_lennyouseUser);

            var _person = new Person(3654324444, 0000000, "Marco", "Figueirnha", DateTime.UtcNow, _lennyouseUser.Id);
            var resCreate = pbo.CreateAsync(_person).Result;
            var resGet = pbo.ReadAsync(_person.Id).Result;

            Assert.IsTrue(resCreate.Success && resGet.Success && resGet.Result != null);

        }
        [TestMethod]
        public void TestListPerson()
        {
            ContextSeeders.Seed();
            var bo = new PersonBusinessObject();
            var resList = bo.List();

            Assert.IsTrue(resList.Success && resList.Result.Count == 1);
        }

        [TestMethod]
        public void TestListPersonAsync()
        {
            ContextSeeders.Seed();
            ContextSeeders.Seed();
            var bo = new PersonBusinessObject();
            var resList = bo.ListAsync().Result;

            Assert.IsTrue(resList.Success && resList.Result.Count == 1);
        }

        [TestMethod]
        public void TestUpdatePerson()
        {
            ContextSeeders.Seed();
            var pbo = new PersonBusinessObject();
            var resList = pbo.List();
            var item = resList.Result.FirstOrDefault();

            var lubo = new LennyouseUserBusinessObject();

            var _lennyouseUser = new LennyouseUser(Guid.NewGuid());
            lubo.Create(_lennyouseUser);

            var _newPerson =  new Person(3654324444, 1111111, "Marco", "Figueirinha", DateTime.UtcNow, _lennyouseUser.Id);
            item.VatNumber = _newPerson.VatNumber;
            item.PhoneNumber = _newPerson.PhoneNumber;
            item.FirstName = _newPerson.FirstName;
            item.LastName = _newPerson.LastName;
            item.BirthDate = _newPerson.BirthDate;
            item.LennyouseUserId = _newPerson.LennyouseUserId;

            var resUpdate = pbo.Update(item);
            resList = pbo.List();

            Assert.IsTrue(resList.Success && resUpdate.Success &&
                resList.Result.First().VatNumber == _newPerson.VatNumber &&
                resList.Result.First().PhoneNumber == _newPerson.PhoneNumber &&
                resList.Result.First().FirstName == _newPerson.FirstName &&
                resList.Result.First().LastName == _newPerson.LastName &&
                resList.Result.First().BirthDate == _newPerson.BirthDate &&
                resList.Result.First().LennyouseUserId == _newPerson.LennyouseUserId 
                );
        }

        [TestMethod]
        public void TestUpdatePersonAsync()
        {
            ContextSeeders.Seed();
            var pbo = new PersonBusinessObject();
            var resList = pbo.List();
            var item = resList.Result.FirstOrDefault();

            var lubo = new LennyouseUserBusinessObject();

            var _lennyouseUser = new LennyouseUser(Guid.NewGuid());
            lubo.Create(_lennyouseUser);

            var _newPerson = new Person(3654324444, 1111111, "Marco", "Figueirinha", DateTime.UtcNow, _lennyouseUser.Id);
            item.VatNumber = _newPerson.VatNumber;
            item.PhoneNumber = _newPerson.PhoneNumber;
            item.FirstName = _newPerson.FirstName;
            item.LastName = _newPerson.LastName;
            item.BirthDate = _newPerson.BirthDate;
            item.LennyouseUserId = _newPerson.LennyouseUserId;

            var resUpdate = pbo.UpdateAsync(item).Result;
            resList = pbo.ListAsync().Result;

            Assert.IsTrue(resList.Success && resUpdate.Success &&
                resList.Result.First().VatNumber == _newPerson.VatNumber &&
                resList.Result.First().PhoneNumber == _newPerson.PhoneNumber &&
                resList.Result.First().FirstName == _newPerson.FirstName &&
                resList.Result.First().LastName == _newPerson.LastName &&
                resList.Result.First().BirthDate == _newPerson.BirthDate &&
                resList.Result.First().LennyouseUserId == _newPerson.LennyouseUserId
                );

        }

        [TestMethod]
        public void TestDeletePerson()
        {

            ContextSeeders.Seed();
            var bo = new PersonBusinessObject();

            var resList = bo.List();
            var resDelete = bo.Delete(resList.Result.First().Id);
            resList = bo.List();

            Assert.IsTrue(resDelete.Success && resList.Success && resList.Result.First().IsDeleted);

        }

        [TestMethod]
        public void TestDeletePersonAsync()
        {
            ContextSeeders.Seed();
            var bo = new PersonBusinessObject();

            var resList = bo.List();
            var resDelete = bo.DeleteAsync(resList.Result.First().Id).Result;
            resList = bo.ListAsync().Result;

            Assert.IsTrue(resDelete.Success && resList.Success && resList.Result.First().IsDeleted);

        }

    }
}
