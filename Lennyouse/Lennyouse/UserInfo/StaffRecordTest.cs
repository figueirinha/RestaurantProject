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
    public class StaffRecordTest
    {
        [TestMethod]
        public void TestCreateStaffRecord()
        {
            ContextSeeders.Seed();
            var srbo = new StaffRecordBusinessObject();
            var pbo = new PersonBusinessObject();
            var rbo = new RestaurantBusinessObject();
            var lubo = new LennyouseUserBusinessObject();

            var _lennyouseUser = new LennyouseUser(Guid.NewGuid());
            lubo.Create(_lennyouseUser);

            var _person = new Person(1234321, 23432456, "Marco", "Figueirnha", DateTime.UtcNow, _lennyouseUser.Id);
            pbo.Create(_person);

            var _restaurant = new Restaurant("Tasca do sol", "Bairro Alto 2", "12h", "00h", "Mondays", 3);
            rbo.Create(_restaurant);

            var _staffRecord = new StaffRecord(DateTime.UtcNow, DateTime.UtcNow, _person.Id, _restaurant.Id);

            var resCreate = srbo.Create(_staffRecord);
            var resGet = srbo.Read(_staffRecord.Id);

            Assert.IsTrue(resCreate.Success && resGet.Success && resGet.Result != null);

        }

        [TestMethod]
        public void TestCreateStaffRecordAsync()
        {
            ContextSeeders.Seed();
            var srbo = new StaffRecordBusinessObject();
            var pbo = new PersonBusinessObject();
            var rbo = new RestaurantBusinessObject();
            var lubo = new LennyouseUserBusinessObject();

            var _lennyouseUser = new LennyouseUser(Guid.NewGuid());
            lubo.Create(_lennyouseUser);

            var _person = new Person(1234321, 23432456, "Marco", "Figueirnha", DateTime.UtcNow, _lennyouseUser.Id);
            pbo.Create(_person);

            var _restaurant = new Restaurant("Tasca do sol", "Bairro Alto 2", "12h", "00h", "Mondays", 3);
            rbo.Create(_restaurant);

            var _staffRecord = new StaffRecord(DateTime.UtcNow, DateTime.UtcNow, _person.Id, _restaurant.Id);

            var resCreate = srbo.CreateAsync(_staffRecord).Result;
            var resGet = srbo.ReadAsync(_staffRecord.Id).Result;

            Assert.IsTrue(resCreate.Success && resGet.Success && resGet.Result != null);

        }

        [TestMethod]
        public void TestListStaffRecord()
        {
            ContextSeeders.Seed();
            var bo = new StaffRecordBusinessObject();
            var resList = bo.List();

            Assert.IsTrue(resList.Success && resList.Result.Count == 1);
        }

        [TestMethod]
        public void TestListStaffRecordAsync()
        {
            ContextSeeders.Seed();
            var bo = new StaffRecordBusinessObject();
            var resList = bo.ListAsync().Result;

            Assert.IsTrue(resList.Success && resList.Result.Count == 1);

        }

        [TestMethod]
        public void TestUpdateStaffRecord()
        {
            ContextSeeders.Seed();
            var srbo = new StaffRecordBusinessObject();
            var resList = srbo.List();
            var item = resList.Result.FirstOrDefault();

            var pbo = new PersonBusinessObject();
            var rbo = new RestaurantBusinessObject();
            var lubo = new LennyouseUserBusinessObject();

            var _lennyouseUser = new LennyouseUser(Guid.NewGuid());
            lubo.Create(_lennyouseUser);

            var _person = new Person(3654324444, 0000000, "Marco", "Figueirnha", DateTime.UtcNow, _lennyouseUser.Id);
            pbo.Create(_person);

            var _restaurant = new Restaurant("Tasca da Lua", "Bairro Alto 2", "12h", "00h", "Mondays", 7);
            rbo.Create(_restaurant);


            var _newStaffRecord = new StaffRecord(DateTime.UtcNow, DateTime.UtcNow, _person.Id, _restaurant.Id);
            item.BeginDate = _newStaffRecord.BeginDate;
            item.EndDate = _newStaffRecord.EndDate;
            item.PersonId = _newStaffRecord.PersonId;
            item.RestaurantId = _newStaffRecord.RestaurantId;

            var resUpdate = srbo.Update(item);
            resList = srbo.List();

            Assert.IsTrue(resList.Success && resUpdate.Success &&
                resList.Result.First().BeginDate == _newStaffRecord.BeginDate &&
                resList.Result.First().EndDate == _newStaffRecord.EndDate &&
                resList.Result.First().PersonId == _newStaffRecord.PersonId &&
                resList.Result.First().RestaurantId == _newStaffRecord.RestaurantId
                );

        }

        [TestMethod]
        public void TestUpdateStaffRecordAsync()
        {
            ContextSeeders.Seed();
            var srbo = new StaffRecordBusinessObject();
            var resList = srbo.List();
            var item = resList.Result.FirstOrDefault();

            var pbo = new PersonBusinessObject();
            var rbo = new RestaurantBusinessObject();
            var lubo = new LennyouseUserBusinessObject();

            var _lennyouseUser = new LennyouseUser(Guid.NewGuid());
            lubo.Create(_lennyouseUser);

            var _person = new Person(3654324444, 0000000, "Marco", "Figueirnha", DateTime.UtcNow, _lennyouseUser.Id);
            pbo.Create(_person);

            var _restaurant = new Restaurant("Tasca da Lua", "Bairro Alto 2", "12h", "00h", "Mondays", 7);
            rbo.Create(_restaurant);


            var _newStaffRecord = new StaffRecord(DateTime.UtcNow, DateTime.UtcNow, _person.Id, _restaurant.Id);
            item.BeginDate = _newStaffRecord.BeginDate;
            item.EndDate = _newStaffRecord.EndDate;
            item.PersonId = _newStaffRecord.PersonId;
            item.RestaurantId = _newStaffRecord.RestaurantId;

            var resUpdate = srbo.UpdateAsync(item).Result;
            resList = srbo.ListAsync().Result;

            Assert.IsTrue(resList.Success && resUpdate.Success &&
                resList.Result.First().BeginDate == _newStaffRecord.BeginDate &&
                resList.Result.First().EndDate == _newStaffRecord.EndDate &&
                resList.Result.First().PersonId == _newStaffRecord.PersonId &&
                resList.Result.First().RestaurantId == _newStaffRecord.RestaurantId
                );
        }
        
        [TestMethod]
        public void TestDeleteStaffRecord()
        {
            ContextSeeders.Seed();
            var bo = new StaffRecordBusinessObject();

            var resList = bo.List();
            var resDelete = bo.Delete(resList.Result.First().Id);
            resList = bo.List();

            Assert.IsTrue(resDelete.Success && resList.Success && resList.Result.First().IsDeleted);
        }


        [TestMethod]
        public void TestDeleteStaffRecordAsync()
        {
            ContextSeeders.Seed();
            var bo = new StaffRecordBusinessObject();

            var resList = bo.List();
            var resDelete = bo.DeleteAsync(resList.Result.First().Id).Result;
            resList = bo.ListAsync().Result;

            Assert.IsTrue(resDelete.Success && resList.Success && resList.Result.First().IsDeleted);

        }
    }
}
