using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recodme.RD.Lennyouse.BusinessLayer.BusinessObjects.MenuInfo;
using Recodme.RD.Lennyouse.BusinessLayer.BusinessObjects.RestaurantInfo;
using Recodme.RD.Lennyouse.Data.MenuInfo;
using Recodme.RD.Lennyouse.Data.RestaurantInfo;
using Recodme.RD.Lennyouse.DataAccessLayer.Seeders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Recodme.RD.Lennyouse.LennyouseTest.MenuInfo
{
    [TestClass]
    public class MenuTest
    {
        [TestMethod]
        public void TestCreateMenu()
        {
            ContextSeeders.Seed();
            var mbo = new MenuBusinessObject();

            var rbo = new RestaurantBusinessObject();
            var mealbo = new MealBusinessObject();

            var restaurant = new Restaurant("a", "b", "c", "d", "f", 6);
            var meal = new Meal("a", "b", "c");

            rbo.Create(restaurant);
            mealbo.Create(meal);

            var menu = new Menu(DateTime.Now, restaurant.Id, meal.Id);

            var resCreate = mbo.Create(menu);
            var resGet = mbo.Read(menu.Id);

            Assert.IsTrue(resCreate.Success && resGet.Success && resGet.Result != null);
        }

        [TestMethod]
        public void TestCreateMenuAsync()
        {
            ContextSeeders.Seed();
            var mbo = new MenuBusinessObject();

            var rbo = new RestaurantBusinessObject();
            var mealbo = new MealBusinessObject();

            var restaurant = new Restaurant("a", "b", "c", "d", "f", 6);
            var meal = new Meal("a", "b", "c");

            rbo.Create(restaurant);
            mealbo.Create(meal);

            var menu = new Menu(DateTime.Now, restaurant.Id, meal.Id);

            var resCreate = mbo.CreateAsync(menu).Result;
            var resGet = mbo.ReadAsync(menu.Id).Result;

            Assert.IsTrue(resCreate.Success && resGet.Success && resGet.Result != null);
        }

        [TestMethod]
        public void TestListMenu()
        {
            ContextSeeders.Seed();
            var bo = new MenuBusinessObject();
            var resList = bo.List();

            Assert.IsTrue(resList.Success && resList.Result.Count == 1);
        }

        [TestMethod]
        public void TestListMenuAsync()
        {
            ContextSeeders.Seed();
            var bo = new MenuBusinessObject();
            var resList = bo.ListAsync().Result;

            Assert.IsTrue(resList.Success && resList.Result.Count == 1);
        }

        [TestMethod]
        public void TestUpdateMenu()
        {
            ContextSeeders.Seed();
            var mbo = new MenuBusinessObject();
            var resList = mbo.List();
            var item = resList.Result.FirstOrDefault();

            var rbo = new RestaurantBusinessObject();
            var mealbo = new MealBusinessObject();

            var restaurant = new Restaurant("a", "b", "c", "d", "f", 6);
            var meal = new Meal("a", "b", "c");

            rbo.Create(restaurant);
            mealbo.Create(meal);

            var newMenu = new Menu(DateTime.Now, restaurant.Id, meal.Id);

            item.Date = newMenu.Date;
            item.RestaurantId = newMenu.RestaurantId;
            item.MealId = newMenu.MealId;

            var resUpdate = mbo.Update(item);
            resList = mbo.List();

            Assert.IsTrue(resList.Success && resUpdate.Success &&
                resList.Result.First().Date == newMenu.Date && resList.Result.First().RestaurantId == newMenu.RestaurantId
                && resList.Result.First().MealId == newMenu.MealId);
        }

        [TestMethod]
        public void TestUpdateMenuAsync()
        {
            ContextSeeders.Seed();
            var mbo = new MenuBusinessObject();
            var resList = mbo.List();
            var item = resList.Result.FirstOrDefault();

            var rbo = new RestaurantBusinessObject();
            var mealbo = new MealBusinessObject();

            var restaurant = new Restaurant("a", "b", "c", "d", "f", 6);
            var meal = new Meal("a", "b", "c");

            rbo.Create(restaurant);
            mealbo.Create(meal);

            var newMenu = new Menu(DateTime.Now, restaurant.Id, meal.Id);

            item.Date = newMenu.Date;
            item.RestaurantId = newMenu.RestaurantId;
            item.MealId = newMenu.MealId;

            var resUpdate = mbo.UpdateAsync(item).Result;
            resList = mbo.ListAsync().Result;

            Assert.IsTrue(resList.Success && resUpdate.Success &&
                resList.Result.First().Date == newMenu.Date && resList.Result.First().RestaurantId == newMenu.RestaurantId
                && resList.Result.First().MealId == newMenu.MealId);
        }

        [TestMethod]
        public void TestDeleteMenu()
        {
            ContextSeeders.Seed();
            var bo = new MenuBusinessObject();

            var resList = bo.List();
            var resDelete = bo.Delete(resList.Result.First().Id);
            resList = bo.List();

            Assert.IsTrue(resDelete.Success && resList.Success && resList.Result.First().IsDeleted);
        }


        [TestMethod]
        public void TestDeleteMenuAsync()
        {
            ContextSeeders.Seed();
            var bo = new MenuBusinessObject();

            var resList = bo.List();
            var resDelete = bo.DeleteAsync(resList.Result.First().Id).Result;
            resList = bo.ListAsync().Result;

            Assert.IsTrue(resDelete.Success && resList.Success && resList.Result.First().IsDeleted);
        }

    }
}
