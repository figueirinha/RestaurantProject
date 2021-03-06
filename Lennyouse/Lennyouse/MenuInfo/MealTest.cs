﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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
    public class MealTest
    {
        [TestMethod]
        public void TestCreateMeal()
        {
            ContextSeeders.Seed();
            var mbo = new MealBusinessObject();

            var meal = new Meal("pizza", "7pm", "11pm");
            var resCreate = mbo.Create(meal);
            var resGet = mbo.Read(meal.Id);

            Assert.IsTrue(resCreate.Success && resGet.Success && resGet.Result != null);
        }

        [TestMethod]
        public void TestCreateMealAsync()
        {
            ContextSeeders.Seed();
            var mbo = new MealBusinessObject();

            var meal = new Meal("pizza", "7pm", "11pm");
            var resCreate = mbo.CreateAsync(meal).Result;
            var resGet = mbo.ReadAsync(meal.Id).Result;

            Assert.IsTrue(resCreate.Success && resGet.Success && resGet.Result != null);
        }

        [TestMethod]
        public void TestListMeal()
        {
            ContextSeeders.Seed();
            var bo = new MealBusinessObject();
            var resList = bo.List();

            Assert.IsTrue(resList.Success && resList.Result.Count == 1);
        }

        [TestMethod]
        public void TestListMealAsync()
        {
            ContextSeeders.Seed();
            var bo = new MealBusinessObject();
            var resList = bo.ListAsync().Result;

            Assert.IsTrue(resList.Success && resList.Result.Count == 1);
        }

        [TestMethod]
        public void TestUpdateMeal()
        {
            ContextSeeders.Seed();
            var mbo = new MealBusinessObject();
            var resList = mbo.List();
            var item = resList.Result.FirstOrDefault();

            var newMeal = new Meal("lasagna", "8pm", "10pm");

            item.Name = newMeal.Name;
            item.StartingHours = newMeal.StartingHours;
            item.EndingHours = newMeal.EndingHours;

            var resUpdate = mbo.Update(item);
            resList = mbo.List();

            Assert.IsTrue(resList.Success && resUpdate.Success &&
                resList.Result.First().Name == newMeal.Name && resList.Result.First().StartingHours == newMeal.StartingHours
                && resList.Result.First().EndingHours == newMeal.EndingHours);
        }

        [TestMethod]
        public void TestUpdateMealAsync()
        {
            ContextSeeders.Seed();
            var mbo = new MealBusinessObject();
            var resList = mbo.List();
            var item = resList.Result.FirstOrDefault();

            var newMeal = new Meal("lasagna", "8pm", "10pm");

            item.Name = newMeal.Name;
            item.StartingHours = newMeal.StartingHours;
            item.EndingHours = newMeal.EndingHours;

            var resUpdate = mbo.UpdateAsync(item).Result;
            resList = mbo.ListAsync().Result;

            Assert.IsTrue(resList.Success && resUpdate.Success &&
                resList.Result.First().Name == newMeal.Name && resList.Result.First().StartingHours == newMeal.StartingHours
                && resList.Result.First().EndingHours == newMeal.EndingHours);
        }

        [TestMethod]
        public void TestDeleteMeal()
        {
            ContextSeeders.Seed();
            var bo = new MealBusinessObject();

            var resList = bo.List();
            var resDelete = bo.Delete(resList.Result.First().Id);
            resList = bo.List();

            Assert.IsTrue(resDelete.Success && resList.Success && resList.Result.First().IsDeleted);
        }


        [TestMethod]
        public void TestDeleteMealAsync()
        {
            ContextSeeders.Seed();
            var bo = new MealBusinessObject();

            var resList = bo.List();
            var resDelete = bo.DeleteAsync(resList.Result.First().Id).Result;
            resList = bo.ListAsync().Result;

            Assert.IsTrue(resDelete.Success && resList.Success && resList.Result.First().IsDeleted);
        }

    }
}
