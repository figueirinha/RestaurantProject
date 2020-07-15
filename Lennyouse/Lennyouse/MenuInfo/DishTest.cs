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
    public class DishTest
    {
        [TestMethod]
        public void TestCreateDish()
        {
            ContextSeeders.Seed();
            var drbo = new DietaryRestrictionBusinessObject();
            var dbo = new DishBusinessObject();

            var dr = new DietaryRestriction("vegan");
            var dish = new Dish("ok", dr.Id);

            
            drbo.Create(dr);

            var resCreate = dbo.Create(dish);
            var resGet = dbo.Read(dish.Id);

            Assert.IsTrue(resCreate.Success && resGet.Success && resGet.Result != null);
        }

        [TestMethod]
        public void TestCreateDishAsync()
        {
            var drbo = new DietaryRestrictionBusinessObject();
            var dbo = new DishBusinessObject();

            var dr = new DietaryRestriction("vegan");
            var dish = new Dish("ok", dr.Id);


            drbo.Create(dr);

            var resCreate = dbo.CreateAsync(dish).Result;
            var resGet = dbo.ReadAsync(dish.Id).Result;

            Assert.IsTrue(resCreate.Success && resGet.Success && resGet.Result != null);
        }

        [TestMethod]
        public void TestListDish()
        {
            ContextSeeders.Seed();
            var bo = new DishBusinessObject();
            var resList = bo.List();

            Assert.IsTrue(resList.Success && resList.Result.Count == 1);
        }

        [TestMethod]
        public void TestListDishAsync()
        {
            ContextSeeders.Seed();
            var bo = new DishBusinessObject();
            var resList = bo.ListAsync().Result;

            Assert.IsTrue(resList.Success && resList.Result.Count == 1);
        }

        [TestMethod]
        public void TestUpdateDish()
        {
            ContextSeeders.Seed();
            var dbo = new DishBusinessObject();
            var resList = dbo.List();
            var item = resList.Result.FirstOrDefault();

            
            var drbo = new DietaryRestrictionBusinessObject();
            

            var dr = new DietaryRestriction("vegan");
            var newDish = new Dish("ok", dr.Id);

            
            drbo.Create(dr);


            item.Name = newDish.Name;
            item.DietaryRestrictionId = newDish.DietaryRestrictionId;

            var resUpdate = dbo.Update(item);
            resList = dbo.List();

            Assert.IsTrue(resList.Success && resUpdate.Success &&
                resList.Result.First().DietaryRestrictionId == newDish.DietaryRestrictionId 
                && resList.Result.First().Name == newDish.Name);
        }

        [TestMethod]
        public void TestUpdateDishAsync()
        {
            ContextSeeders.Seed();
            var dbo = new DishBusinessObject();
            var resList = dbo.List();
            var item = resList.Result.FirstOrDefault();


            var drbo = new DietaryRestrictionBusinessObject();


            var dr = new DietaryRestriction("vegan");
            var newDish = new Dish("ok", dr.Id);


            drbo.Create(dr);


            item.DietaryRestrictionId = newDish.DietaryRestrictionId;
            item.Name = newDish.Name;

            var resUpdate = dbo.UpdateAsync(item).Result;
            resList = dbo.ListAsync().Result;

            Assert.IsTrue(resList.Success && resUpdate.Success &&
                resList.Result.First().DietaryRestrictionId == newDish.DietaryRestrictionId
                && resList.Result.First().Name == newDish.Name);
        }

        [TestMethod]
        public void TestDeleteDish()
        {
            ContextSeeders.Seed();
            var bo = new DishBusinessObject();

            var resList = bo.List();
            var resDelete = bo.Delete(resList.Result.First().Id);
            resList = bo.List();

            Assert.IsTrue(resDelete.Success && resList.Success && resList.Result.First().IsDeleted);
        }


        [TestMethod]
        public void TestDeleteDishAsync()
        {
            ContextSeeders.Seed();
            var bo = new DishBusinessObject();

            var resList = bo.List();
            var resDelete = bo.DeleteAsync(resList.Result.First().Id).Result;
            resList = bo.ListAsync().Result;

            Assert.IsTrue(resDelete.Success && resList.Success && resList.Result.First().IsDeleted);
        }
    }
}
