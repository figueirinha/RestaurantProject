using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recodme.RD.Lennyouse.BusinessLayer.BusinessObjects.MenuInfo;
using Recodme.RD.Lennyouse.Data.MenuInfo;
using Recodme.RD.Lennyouse.DataAccessLayer.Seeders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Recodme.RD.Lennyouse.LennyouseTest.MenuInfo
{
    [TestClass]
    public class DietaryRestrictionTest
    {
        [TestMethod]
        public void TestCreateDietaryRestriction()
        {
            ContextSeeders.Seed();
            var mbo = new DietaryRestrictionBusinessObject();

            var dietaryRestriction = new DietaryRestriction("Vegan");
            var resCreate = mbo.Create(dietaryRestriction);
            var resGet = mbo.Read(dietaryRestriction.Id);

            Assert.IsTrue(resCreate.Success && resGet.Success && resGet.Result != null);
        }

        [TestMethod]
        public void TestCreateDietaryRestrictionAsync()
        {
            ContextSeeders.Seed();
            var mbo = new DietaryRestrictionBusinessObject();

            var dietaryRestriction = new DietaryRestriction("Vegan");
            var resCreate = mbo.CreateAsync(dietaryRestriction).Result;
            var resGet = mbo.ReadAsync(dietaryRestriction.Id).Result;

            Assert.IsTrue(resCreate.Success && resGet.Success && resGet.Result != null);
        }

        [TestMethod]
        public void TestListDietaryRestriction()
        {
            ContextSeeders.Seed();
            var bo = new DietaryRestrictionBusinessObject();
            var resList = bo.List();

            Assert.IsTrue(resList.Success && resList.Result.Count == 1);
        }

        [TestMethod]
        public void TestListDietaryRestrictionAsync()
        {
            ContextSeeders.Seed();
            var bo = new DietaryRestrictionBusinessObject();
            var resList = bo.ListAsync().Result;

            Assert.IsTrue(resList.Success && resList.Result.Count == 1);
        }

        [TestMethod]
        public void TestUpdateDietaryRestriction()
        {
            ContextSeeders.Seed();
            var mbo = new DietaryRestrictionBusinessObject();
            var resList = mbo.List();
            var item = resList.Result.FirstOrDefault();

            var newDietaryRestriction = new DietaryRestriction("Vegan");

            item.Name = newDietaryRestriction.Name;


            var resUpdate = mbo.Update(item);
            resList = mbo.List();

            Assert.IsTrue(resList.Success && resUpdate.Success &&
                resList.Result.First().Name == newDietaryRestriction.Name);
        }

        [TestMethod]
        public void TestUpdateDietaryRestrictionAsync()
        {
            ContextSeeders.Seed();
            var mbo = new DietaryRestrictionBusinessObject();
            var resList = mbo.List();
            var item = resList.Result.FirstOrDefault();

            var newDietaryRestriction = new DietaryRestriction("Vegan");

            item.Name = newDietaryRestriction.Name;


            var resUpdate = mbo.UpdateAsync(item).Result;
            resList = mbo.ListAsync().Result;

            Assert.IsTrue(resList.Success && resUpdate.Success &&
                resList.Result.First().Name == newDietaryRestriction.Name);
        }

        [TestMethod]
        public void TestDeleteDietaryRestriction()
        {
            ContextSeeders.Seed();
            var bo = new DietaryRestrictionBusinessObject();

            var resList = bo.List();
            var resDelete = bo.Delete(resList.Result.First().Id);
            resList = bo.List();

            Assert.IsTrue(resDelete.Success && resList.Success && resList.Result.First().IsDeleted);
        }


        [TestMethod]
        public void TestDeleteDietaryRestrictionAsync()
        {
            ContextSeeders.Seed();
            var bo = new DietaryRestrictionBusinessObject();

            var resList = bo.List();
            var resDelete = bo.DeleteAsync(resList.Result.First().Id).Result;
            resList = bo.ListAsync().Result;

            Assert.IsTrue(resDelete.Success && resList.Success && resList.Result.First().IsDeleted);
        }
    }
}
