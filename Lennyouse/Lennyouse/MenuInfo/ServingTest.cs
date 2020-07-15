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
    public class ServingTest
    {
        [TestClass]
        public class ServingTests
        {
            [TestMethod]
            public void TestCreateServing()
            {
                ContextSeeders.Seed();
                var sbo = new ServingBusinessObject();

                var rbo = new RestaurantBusinessObject();
                var mealbo = new MealBusinessObject();
                var drbo = new DietaryRestrictionBusinessObject();
                var mbo = new MenuBusinessObject();
                var cbo = new CourseBusinessObject();
                var dbo = new DishBusinessObject();

                var restaurant = new Restaurant("a", "b", "c", "d", "f", 6);
                var meal = new Meal("a", "b", "c");
                var dr = new DietaryRestriction("ok");
                var menu = new Menu(DateTime.Now, restaurant.Id, meal.Id);
                var course = new Course("yes");
                var dish = new Dish("uh", dr.Id);

                rbo.Create(restaurant);
                mealbo.Create(meal);
                drbo.Create(dr);
                mbo.Create(menu);
                cbo.Create(course);
                dbo.Create(dish);

                var serving = new Serving(menu.Id, course.Id, dish.Id);

                var resCreate = sbo.Create(serving);
                var resGet = sbo.Read(serving.Id);

                Assert.IsTrue(resCreate.Success && resGet.Success && resGet.Result != null);
            }

            [TestMethod]
            public void TestCreateServingAsync()
            {
                ContextSeeders.Seed();
                var sbo = new ServingBusinessObject();

                var rbo = new RestaurantBusinessObject();
                var mealbo = new MealBusinessObject();
                var drbo = new DietaryRestrictionBusinessObject();
                var mbo = new MenuBusinessObject();
                var cbo = new CourseBusinessObject();
                var dbo = new DishBusinessObject();

                var restaurant = new Restaurant("a", "b", "c", "d", "f", 6);
                var meal = new Meal("a", "b", "c");
                var dr = new DietaryRestriction("ok");
                var menu = new Menu(DateTime.Now, restaurant.Id, meal.Id);
                var course = new Course("yes");
                var dish = new Dish("uh", dr.Id);

                rbo.Create(restaurant);
                mealbo.Create(meal);
                drbo.Create(dr);
                mbo.Create(menu);
                cbo.Create(course);
                dbo.Create(dish);

                var serving = new Serving(menu.Id, course.Id, dish.Id);

                var resCreate = sbo.CreateAsync(serving).Result;
                var resGet = sbo.ReadAsync(serving.Id).Result;

                Assert.IsTrue(resCreate.Success && resGet.Success && resGet.Result != null);
            }

            [TestMethod]
            public void TestListServing()
            {
                ContextSeeders.Seed();
                var bo = new ServingBusinessObject();
                var resList = bo.List();

                Assert.IsTrue(resList.Success && resList.Result.Count == 1);
            }

            [TestMethod]
            public void TestListServingAsync()
            {
                ContextSeeders.Seed();
                var bo = new ServingBusinessObject();
                var resList = bo.ListAsync().Result;

                Assert.IsTrue(resList.Success && resList.Result.Count == 1);
            }

            [TestMethod]
            public void TestUpdateServing()
            {
                ContextSeeders.Seed();
                var sbo = new ServingBusinessObject();
                var resList = sbo.List();
                var item = resList.Result.FirstOrDefault();

                var rbo = new RestaurantBusinessObject();
                var mealbo = new MealBusinessObject();
                var drbo = new DietaryRestrictionBusinessObject();
                var mbo = new MenuBusinessObject();
                var cbo = new CourseBusinessObject();
                var dbo = new DishBusinessObject();

                var restaurant = new Restaurant("a", "b", "c", "d", "f", 6);
                var meal = new Meal("a", "b", "c");
                var dr = new DietaryRestriction("ok");
                var menu = new Menu(DateTime.Now, restaurant.Id, meal.Id);
                var course = new Course("yes");
                var dish = new Dish("uh", dr.Id);

                rbo.Create(restaurant);
                mealbo.Create(meal);
                drbo.Create(dr);
                mbo.Create(menu);
                cbo.Create(course);
                dbo.Create(dish);

                var newServing = new Serving(menu.Id, course.Id, dish.Id);

                item.MenuId = newServing.MenuId;
                item.CourseId = newServing.CourseId;
                item.DishId = newServing.DishId;

                var resUpdate = sbo.Update(item);
                resList = sbo.List();

                Assert.IsTrue(resList.Success && resUpdate.Success &&
                    resList.Result.First().MenuId == newServing.MenuId && resList.Result.First().CourseId == newServing.CourseId
                    && resList.Result.First().DishId == newServing.DishId);
            }

            [TestMethod]
            public void TestUpdateServingAsync()
            {
                ContextSeeders.Seed();
                var sbo = new ServingBusinessObject();
                var resList = sbo.List();
                var item = resList.Result.FirstOrDefault();

                var rbo = new RestaurantBusinessObject();
                var mealbo = new MealBusinessObject();
                var drbo = new DietaryRestrictionBusinessObject();
                var mbo = new MenuBusinessObject();
                var cbo = new CourseBusinessObject();
                var dbo = new DishBusinessObject();

                var restaurant = new Restaurant("a", "b", "c", "d", "f", 6);
                var meal = new Meal("a", "b", "c");
                var dr = new DietaryRestriction("ok");
                var menu = new Menu(DateTime.Now, restaurant.Id, meal.Id);
                var course = new Course("yes");
                var dish = new Dish("uh", dr.Id);

                rbo.Create(restaurant);
                mealbo.Create(meal);
                drbo.Create(dr);
                mbo.Create(menu);
                cbo.Create(course);
                dbo.Create(dish);

                var newServing = new Serving(menu.Id, course.Id, dish.Id);

                item.MenuId = newServing.MenuId;
                item.CourseId = newServing.CourseId;
                item.DishId = newServing.DishId;

                var resUpdate = sbo.UpdateAsync(item).Result;
                resList = sbo.ListAsync().Result;

                Assert.IsTrue(resList.Success && resUpdate.Success &&
                    resList.Result.First().MenuId == newServing.MenuId && resList.Result.First().CourseId == newServing.CourseId
                    && resList.Result.First().DishId == newServing.DishId);
            }

            [TestMethod]
            public void TestDeleteServing()
            {
                ContextSeeders.Seed();
                var bo = new ServingBusinessObject();

                var resList = bo.List();
                var resDelete = bo.Delete(resList.Result.First().Id);
                resList = bo.List();

                Assert.IsTrue(resDelete.Success && resList.Success && resList.Result.First().IsDeleted);
            }


            [TestMethod]
            public void TestDeleteServingAsync()
            {
                ContextSeeders.Seed();
                var bo = new ServingBusinessObject();

                var resList = bo.List();
                var resDelete = bo.DeleteAsync(resList.Result.First().Id).Result;
                resList = bo.ListAsync().Result;

                Assert.IsTrue(resDelete.Success && resList.Success && resList.Result.First().IsDeleted);
            }

        }
    }
}
