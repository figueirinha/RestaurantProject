using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recodme.RD.Lennyouse.BusinessLayer.BusinessObjects.RestaurantInfo;
using Recodme.RD.Lennyouse.BusinessLayer.BusinessObjects.UserInfo;
using Recodme.RD.Lennyouse.Data.RestaurantInfo;
using Recodme.RD.Lennyouse.Data.UserInfo;
using Recodme.RD.Lennyouse.DataAccessLayer.Seeders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Recodme.RD.Lennyouse.LennyouseTest.UserInfo
{

    [TestClass]
    public class ClientRecordTest
    {
        [TestMethod]
        public void TestCreateClientRecord()
        {
            ContextSeeders.Seed();
            var crbo = new ClientRecordBusinessObject();
            var lubo = new LennyouseUserBusinessObject();
            var pbo = new PersonBusinessObject();

            var _lennyouseUser = new LennyouseUser(Guid.NewGuid());
            lubo.Create(_lennyouseUser);

            var _person = new Person(123456789, 934657823, "Miguel", "Silva",DateTime.UtcNow, _lennyouseUser.Id);
            pbo.Create(_person);

            var rbo = new RestaurantBusinessObject();
            var _resturant = new Restaurant("Dom Pedro", "Rua das Flores 2", "2 p.m", "9 p.m", "Fridays", 2);
            rbo.Create(_resturant);

            var _clientRecord = new ClientRecord(DateTime.UtcNow, _person.Id, _resturant.Id);
         

            var resCreate = crbo.Create(_clientRecord);
            var resGet = crbo.Read(_clientRecord.Id);

            Assert.IsTrue(resCreate.Success && resGet.Success && resGet.Result != null);

        }
        [TestMethod]
        public void TestCreateClientRecordAsync()
        {
            ContextSeeders.Seed();
            var crbo = new ClientRecordBusinessObject();
            var lubo = new LennyouseUserBusinessObject();
            var pbo = new PersonBusinessObject();

            var _lennyouseUser = new LennyouseUser(Guid.NewGuid());
            lubo.Create(_lennyouseUser);

            var _person = new Person(123456789, 934657823, "Miguel", "Silva", DateTime.UtcNow, _lennyouseUser.Id);
            pbo.Create(_person);

            var rbo = new RestaurantBusinessObject();
            var _resturant = new Restaurant("Dom Pedro", "Rua das Flores 2", "2 p.m", "9 p.m", "Fridays", 2);
            rbo.Create(_resturant);

            var _clientRecord = new ClientRecord(DateTime.UtcNow, _person.Id, _resturant.Id);

            var resCreate = crbo.CreateAsync(_clientRecord).Result;
            var resGet = crbo.ReadAsync(_clientRecord.Id).Result;

            Assert.IsTrue(resCreate.Success && resGet.Success && resGet.Result != null);
        }
        [TestMethod]
        public void TestListClientRecord()
        {
            ContextSeeders.Seed();
            var bo = new ClientRecordBusinessObject();
            var resList = bo.List();

            Assert.IsTrue(resList.Success && resList.Result.Count == 1);
        }
        [TestMethod]
        public void TestListClientRecordAsync()
        {
            ContextSeeders.Seed();
            var bo = new ClientRecordBusinessObject();
            var resList = bo.ListAsync().Result;

            Assert.IsTrue(resList.Success && resList.Result.Count == 1);
        }
        [TestMethod]
        public void TestUpdateClientRecord()
        {
            ContextSeeders.Seed();
            var crbo = new ClientRecordBusinessObject();
            var resList = crbo.List();
            var item = resList.Result.FirstOrDefault();

            var lubo = new LennyouseUserBusinessObject();
            var pbo = new PersonBusinessObject();
            var rbo = new RestaurantBusinessObject();

            var _lennyouseUser = new LennyouseUser(Guid.NewGuid());
            lubo.Create(_lennyouseUser);

            var _person = new Person(98764321, 364857484, "Ana", "Pereira", DateTime.UtcNow, _lennyouseUser.Id);
            pbo.Create(_person);

            
            var _resturant = new Restaurant("Dona Ivone", "Rua dos Anjos 2", "2 p.m", "9 p.m", "Sundays", 2);
            rbo.Create(_resturant);

            var _newclientRecord = new ClientRecord(DateTime.UtcNow, _person.Id, _resturant.Id);
  
            item.RegisterDate = _newclientRecord.RegisterDate;
            item.PersonId = _newclientRecord.PersonId;
            item.RestaurantId = _newclientRecord.RestaurantId;

            var resUpdate = crbo.Update(item);
            resList = crbo.List();

            Assert.IsTrue(resList.Success && resUpdate.Success &&
               resList.Result.First().RegisterDate == _newclientRecord.RegisterDate && resList.Result.First().RestaurantId == _newclientRecord.RestaurantId
               && resList.Result.First().PersonId == _newclientRecord.PersonId);
        }

        [TestMethod]
        public void TestUpdateClientRecordAsync()
        {
            ContextSeeders.Seed();
            var crbo = new ClientRecordBusinessObject();
            var resList = crbo.List();
            var item = resList.Result.FirstOrDefault();

            var lubo = new LennyouseUserBusinessObject();
            var pbo = new PersonBusinessObject();
            var rbo = new RestaurantBusinessObject();

            var _lennyouseUser = new LennyouseUser(Guid.NewGuid());
            lubo.Create(_lennyouseUser);

            var _person = new Person(98764321, 364857484, "Ana", "Pereira", DateTime.UtcNow, _lennyouseUser.Id);
            pbo.Create(_person);


            var _resturant = new Restaurant("Dona Ivone", "Rua dos Anjos 2", "2 p.m", "9 p.m", "Sundays", 2);
            rbo.Create(_resturant);

            var _newclientRecord = new ClientRecord(DateTime.UtcNow, _person.Id, _resturant.Id);

            item.RegisterDate = _newclientRecord.RegisterDate;
            item.PersonId = _newclientRecord.PersonId;
            item.RestaurantId = _newclientRecord.RestaurantId;

            var resUpdate = crbo.UpdateAsync(item).Result;
            resList = crbo.ListAsync().Result;

            Assert.IsTrue(resList.Success && resUpdate.Success &&
               resList.Result.First().RegisterDate == _newclientRecord.RegisterDate && resList.Result.First().RestaurantId == _newclientRecord.RestaurantId
               && resList.Result.First().PersonId == _newclientRecord.PersonId);

        }
        [TestMethod]
        public void TestDeleteClientRecord()
        {
            ContextSeeders.Seed();
            var bo = new ClientRecordBusinessObject();

            var resList = bo.List();
            var resDelete = bo.Delete(resList.Result.First().Id);
            resList = bo.List();

            Assert.IsTrue(resDelete.Success && resList.Success && resList.Result.First().IsDeleted);

        }
        [TestMethod]
        public void TestDeleteClientRecordAsync()
        {
            ContextSeeders.Seed();
            var bo = new ClientRecordBusinessObject();

            var resList = bo.List();
            var resDelete = bo.DeleteAsync(resList.Result.First().Id).Result;
            resList = bo.ListAsync().Result;

            Assert.IsTrue(resDelete.Success && resList.Success && resList.Result.First().IsDeleted);
        }

    }
}
