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
    public class LennyouseUserTest
    {
        [TestMethod]
        public void TestCreateLennyouseUser()
        {
            ContextSeeders.Seed();
            var lubo = new LennyouseUserBusinessObject();

            var _lennyouseUser = new LennyouseUser(Guid.NewGuid());

            var resCreate = lubo.Create(_lennyouseUser);
            var resGet = lubo.Read(_lennyouseUser.Id);

            Assert.IsTrue(resCreate.Success && resGet.Success && resGet.Result != null);

        }

        [TestMethod]
        public void TestCreateLennyouseUserAsync()
        {
            ContextSeeders.Seed();
            var lubo = new LennyouseUserBusinessObject();

            var _lennyouseUser = new LennyouseUser(Guid.NewGuid());

            var resCreate = lubo.CreateAsync(_lennyouseUser).Result;
            var resGet = lubo.ReadAsync(_lennyouseUser.Id).Result;

            Assert.IsTrue(resCreate.Success && resGet.Success && resGet.Result != null);

        }

        [TestMethod]
        public void TestListLennyouseUser()
        {
            ContextSeeders.Seed();
            var bo = new LennyouseUserBusinessObject();
            var resList = bo.List();

            Assert.IsTrue(resList.Success && resList.Result.Count == 1);
        }

        [TestMethod]
        public void TestListLennyouseUserAsync()
        {
            ContextSeeders.Seed();
            var bo = new LennyouseUserBusinessObject();
            var resList = bo.ListAsync().Result;

            Assert.IsTrue(resList.Success && resList.Result.Count == 1);

        }

        [TestMethod]
        public void TestUpdateLennyouseUser()
        {
            ContextSeeders.Seed();
            var lubo = new LennyouseUserBusinessObject();
            var resList = lubo.List();
            var item = resList.Result.FirstOrDefault();

            var _newLennyouseUser = new LennyouseUser(Guid.NewGuid());
            item.PersonId = _newLennyouseUser.PersonId;

            var resUpdate = lubo.Update(item);
            resList = lubo.List();

            Assert.IsTrue(resList.Success && resUpdate.Success &&
                resList.Result.First().PersonId == _newLennyouseUser.PersonId);
        }

        [TestMethod]
        public void TestUpdateLennyouseUserAsync()
        {
            ContextSeeders.Seed();
            var lubo = new LennyouseUserBusinessObject();
            var resList = lubo.List();
            var item = resList.Result.FirstOrDefault();

            var _newLennyouseUser = new LennyouseUser(Guid.NewGuid());
            item.PersonId = _newLennyouseUser.PersonId;

            var resUpdate = lubo.UpdateAsync(item).Result;
            resList = lubo.ListAsync().Result;

            Assert.IsTrue(resList.Success && resUpdate.Success &&
                resList.Result.First().PersonId == _newLennyouseUser.PersonId);
        }
    
        [TestMethod]
        public void TestDeleteLennyouseUser()
        {
            ContextSeeders.Seed();
            var bo = new LennyouseUserBusinessObject();

            var resList = bo.List();
            var resDelete = bo.Delete(resList.Result.First().Id);
            resList = bo.List();

            Assert.IsTrue(resDelete.Success && resList.Success);

        }

        [TestMethod]
        public void TestDeleteLennyouseUserAsync()
        {
            ContextSeeders.Seed();
            var bo = new LennyouseUserBusinessObject();

            var resList = bo.List();
            var resDelete = bo.Delete(resList.Result.First().Id);
            resList = bo.ListAsync().Result;

            Assert.IsTrue(resDelete.Success && resList.Success);

        }
    }
}
