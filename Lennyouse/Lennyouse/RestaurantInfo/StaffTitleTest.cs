using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recodme.RD.Lennyouse.BusinessLayer.BusinessObjects.RestaurantInfo;
using Recodme.RD.Lennyouse.BusinessLayer.BusinessObjects.UserInfo;
using Recodme.RD.Lennyouse.Data.RestaurantInfo;
using Recodme.RD.Lennyouse.DataAccessLayer.Seeders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Recodme.RD.Lennyouse.LennyouseTest.RestaurantInfo
{
    [TestClass]
    public class StaffTitleTest
    {
        #region Create
        [TestMethod]
        public void TestCreateStaffTitle()
        {
            ContextSeeders.Seed();
            var boStaffRecord = new StaffRecordBusinessObject();
            var staffRecord = boStaffRecord.List().Result.First();

            var boTitle = new TitleBusinessObject();
            var title = boTitle.List().Result.First();

            var bo = new StaffTitleBusinessObject();
            var staffTitle = new StaffTitle(staffRecord.Id, title.Id, DateTime.Parse("13/07/2020"), DateTime.Parse("13/07/2021")); ;
            var resCreate = bo.Create(staffTitle);
            Assert.IsTrue(resCreate.Success);
        }
        #endregion

        #region Read
        [TestMethod]
        public void TestReadStaffTitle()
        {
            ContextSeeders.Seed();
            var bo = new StaffTitleBusinessObject();
            var resList = bo.List();
            Assert.IsTrue(resList.Success && resList.Result != null);
        }
        #endregion

        #region Update
        [TestMethod]
        public void TestUpdateStaffTitle()
        {
            ContextSeeders.Seed();
            var bo = new StaffTitleBusinessObject();
            var resList = bo.List();
            var item = resList.Result.FirstOrDefault();
            item.EndDate = DateTime.Parse("13/07/2022");
            var resUpdate = bo.Update(item);
            var resNotList = bo.List().Result.Where(x => !x.IsDeleted);

            Assert.IsTrue(resUpdate.Success && resNotList.First().EndDate == DateTime.Parse("13/07/2022"));
        }
        #endregion

        #region Delete
        [TestMethod]
        public void TestDeleteStaffTitle()
        {
            ContextSeeders.Seed();
            var bo = new StaffTitleBusinessObject();
            var resList = bo.List();
            var resDelete = bo.Delete(resList.Result.First().Id);
            resList = bo.List();
            Assert.IsTrue(resDelete.Success && resList.Success && resList.Result.First().IsDeleted);
        }
        #endregion

        #region List
        [TestMethod]
        public void TestListStaffTitle()
        {
            ContextSeeders.Seed();
            var bo = new StaffTitleBusinessObject();
            var resList = bo.List();
            Assert.IsTrue(resList.Success && resList.Result.Count == 1);
        }
        #endregion

        #region Assync 
        [TestMethod]
        public void TestDeleteStaffTitleAsync()
        {
            ContextSeeders.Seed();
            var bo = new StaffTitleBusinessObject();
            var resList = bo.List();
            var resDelete = bo.Delete(resList.Result.First().Id);
            resList = bo.List();
            Assert.IsTrue(resDelete.Success && resList.Success && resList.Result.First().IsDeleted);
        }
        #endregion
        #region Assync Update
        [TestMethod]
        public void TestUpdateStaffTitleAsync()
        {
            ContextSeeders.Seed();

            var boStaffRecord = new StaffRecordBusinessObject();
            var staffRecord = boStaffRecord.List().Result.First();

            var boTitle = new TitleBusinessObject();
            var title = boTitle.List().Result.First();

            var mbo = new StaffTitleBusinessObject();
            var resList = mbo.List();

            var item = resList.Result.FirstOrDefault();

            var newRestaurant = new StaffTitle(staffRecord.Id, title.Id, DateTime.Parse("14/07/2020"), DateTime.Parse("14/07/2021"));

            item.StartDate = newRestaurant.StartDate;
            item.EndDate = newRestaurant.EndDate;          

            var resUpdate = mbo.UpdateAsync(item).Result;
            resList = mbo.ListAsync().Result;

            Assert.IsTrue(resList.Success && resUpdate.Success &&
                resList.Result.First().StartDate == newRestaurant.StartDate &&
                resList.Result.First().EndDate == newRestaurant.EndDate);
        }
        #endregion
    }
}
