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
    public class CourseTest
    {
        [TestMethod]
        public void TestCreateCourse()
        {
            ContextSeeders.Seed();
            var mbo = new CourseBusinessObject();

            var course = new Course("pizza");
            var resCreate = mbo.Create(course);
            var resGet = mbo.Read(course.Id);

            Assert.IsTrue(resCreate.Success && resGet.Success && resGet.Result != null);
        }

        [TestMethod]
        public void TestCreateCourseAsync()
        {
            ContextSeeders.Seed();
            var mbo = new CourseBusinessObject();

            var course = new Course("pizza");
            var resCreate = mbo.CreateAsync(course).Result;
            var resGet = mbo.ReadAsync(course.Id).Result;

            Assert.IsTrue(resCreate.Success && resGet.Success && resGet.Result != null);
        }

        [TestMethod]
        public void TestListCourse()
        {
            ContextSeeders.Seed();
            var bo = new CourseBusinessObject();
            var resList = bo.List();

            Assert.IsTrue(resList.Success && resList.Result.Count == 1);
        }

        [TestMethod]
        public void TestListCourseAsync()
        {
            ContextSeeders.Seed();
            var bo = new CourseBusinessObject();
            var resList = bo.ListAsync().Result;

            Assert.IsTrue(resList.Success && resList.Result.Count == 1);
        }

        [TestMethod]
        public void TestUpdateCourse()
        {
            ContextSeeders.Seed();
            var mbo = new CourseBusinessObject();
            var resList = mbo.List();
            var item = resList.Result.FirstOrDefault();

            var newCourse = new Course("lasagna");

            item.Name = newCourse.Name;
           

            var resUpdate = mbo.Update(item);
            resList = mbo.List();

            Assert.IsTrue(resList.Success && resUpdate.Success &&
                resList.Result.First().Name == newCourse.Name);
        }

        [TestMethod]
        public void TestUpdateCourseAsync()
        {
            ContextSeeders.Seed();
            var mbo = new CourseBusinessObject();
            var resList = mbo.List();
            var item = resList.Result.FirstOrDefault();

            var newCourse = new Course("lasagna");

            item.Name = newCourse.Name;
           

            var resUpdate = mbo.UpdateAsync(item).Result;
            resList = mbo.ListAsync().Result;

            Assert.IsTrue(resList.Success && resUpdate.Success &&
                resList.Result.First().Name == newCourse.Name);
        }

        [TestMethod]
        public void TestDeleteCourse()
        {
            ContextSeeders.Seed();
            var bo = new CourseBusinessObject();

            var resList = bo.List();
            var resDelete = bo.Delete(resList.Result.First().Id);
            resList = bo.List();

            Assert.IsTrue(resDelete.Success && resList.Success && resList.Result.First().IsDeleted);
        }


        [TestMethod]
        public void TestDeleteCourseAsync()
        {
            ContextSeeders.Seed();
            var bo = new CourseBusinessObject();

            var resList = bo.List();
            var resDelete = bo.DeleteAsync(resList.Result.First().Id).Result;
            resList = bo.ListAsync().Result;

            Assert.IsTrue(resDelete.Success && resList.Success && resList.Result.First().IsDeleted);
        }
    }
}
