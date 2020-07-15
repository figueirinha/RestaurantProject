using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recodme.RD.Lennyouse.BusinessLayer.BusinessObjects.RestaurantInfo;
using Recodme.RD.Lennyouse.Data.RestaurantInfo;
using Recodme.RD.Lennyouse.DataAccessLayer.Seeders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Recodme.RD.Lennyouse.LennyouseTest.RestaurantInfo
{
    [TestClass]
    public class TitleTest
    {
        #region Create
        [TestMethod]
        public void TestCreateTitle()
        {
            ContextSeeders.Seed();            
            var bo = new TitleBusinessObject();
            var title = new Title("Kitchen chef", "Profissional que organiza, coordena, dirige e verifica os" +
                " trabalhos de cozinha em restaurantes, hotéis e estabelecimentos similares.", "Ronaldo");
            var resCreate = bo.Create(title);
            Assert.IsTrue(resCreate.Success);
        }
        #endregion

        #region Read
        [TestMethod]
        public void TestReadTitle()
        {
            ContextSeeders.Seed();
            var bo = new TitleBusinessObject();
            var resList = bo.List();     
            Assert.IsTrue(resList.Success && resList.Result != null);
        }
        #endregion

        #region Update
        [TestMethod]
        public void TestUpdateTitle()
        {
            ContextSeeders.Seed();
            var bo = new TitleBusinessObject();            
            var resList = bo.List();
            var item = resList.Result.FirstOrDefault();
            item.Name = "Robert";
            var resUpdate = bo.Update(item);
            var resNotList = bo.List().Result.Where(x => !x.IsDeleted);

            Assert.IsTrue(resUpdate.Success && resNotList.First().Name == "Robert");
        }
        #endregion

        #region Delete
        [TestMethod]
        public void TestDeleteTitle()
        {
            ContextSeeders.Seed();
            var bo = new TitleBusinessObject();
            var resList = bo.List();
            var resDelete = bo.Delete(resList.Result.First().Id);
            resList = bo.List();
            Assert.IsTrue(resDelete.Success && resList.Success && resList.Result.First().IsDeleted);
        }
        #endregion

        #region List
        [TestMethod]
        public void TestListTitle()
        {
            ContextSeeders.Seed();
            var bo = new TitleBusinessObject();
            var resList = bo.List();
            Assert.IsTrue(resList.Success && resList.Result.Count == 1);
        }
        #endregion

        #region Assync 
        [TestMethod]
        public void TestDeleteTitleAsync()
        {
            ContextSeeders.Seed();
            var bo = new TitleBusinessObject();
            var resList = bo.List();
            var resDelete = bo.Delete(resList.Result.First().Id);
            resList = bo.List();
            Assert.IsTrue(resDelete.Success && resList.Success && resList.Result.First().IsDeleted);
        }
        #endregion

        #region Assync Update
        [TestMethod]
        public void TestUpdateTitleAsync()
        {
            ContextSeeders.Seed();
            var mbo = new TitleBusinessObject();
            var resList = mbo.List();
            var item = resList.Result.FirstOrDefault();

            var newRestaurant = new Title("Empregada de mesa",
                "Prepara o serviço de mesa e acolhe os clientes", "Carla");

            item.Position = newRestaurant.Position;
            item.Description = newRestaurant.Description;
            item.Name = newRestaurant.Name;

            var resUpdate = mbo.UpdateAsync(item).Result;
            resList = mbo.ListAsync().Result;

            Assert.IsTrue(resList.Success && resUpdate.Success &&
                resList.Result.First().Position == newRestaurant.Position &&
                resList.Result.First().Description == newRestaurant.Description &&
                resList.Result.First().Name == newRestaurant.Name);
        }
        #endregion
    }
}
