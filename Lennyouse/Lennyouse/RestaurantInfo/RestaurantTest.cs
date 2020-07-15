using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recodme.RD.Lennyouse.BusinessLayer.BusinessObjects.RestaurantInfo;
using Recodme.RD.Lennyouse.Data.RestaurantInfo;
using Recodme.RD.Lennyouse.DataAccessLayer.Seeders;
using System.Linq;

namespace Recodme.RD.Lennyouse.LennyouseTest.RestaurantInfo
{
    [TestClass]
    public class RestaurantTest
    {
        #region Create
        [TestMethod]
        public void TestCreateRestaurant()
        {
            ContextSeeders.Seed();
            var bo = new RestaurantBusinessObject();
            var restaurant = new Restaurant("Lennyouse", "Rua alhusta, numero 456, Lisboa", "12:00", "23:00", "Segunda", 30);
            var resCreate = bo.Create(restaurant);
            Assert.IsTrue(resCreate.Success);
        }
        #endregion

        #region Read
        [TestMethod]
        public void TestReadRestaurant()
        {
            ContextSeeders.Seed();
            var bo = new StaffTitleBusinessObject();
            var resList = bo.List();
            Assert.IsTrue(resList.Success && resList.Result != null);
        }
        #endregion

        #region Update
        [TestMethod]
        public void TestUpdateRestaurant()
        {
            ContextSeeders.Seed();
            var bo = new RestaurantBusinessObject();
            var resList = bo.List();
            var item = resList.Result.FirstOrDefault();
            item.Name = "Ratatouille";
            var resUpdate = bo.Update(item);
            var resNotList = bo.List().Result.Where(x => !x.IsDeleted);
            Assert.IsTrue(resUpdate.Success && resNotList.First().Name == "Ratatouille");
        }
        #endregion

        #region Delete
        [TestMethod]
        public void TestDeleteRestaurant()
        {
            ContextSeeders.Seed();
            var bo = new RestaurantBusinessObject();
            var resList = bo.List();
            var resDelete = bo.Delete(resList.Result.First().Id);
            resList = bo.List();
            Assert.IsTrue(resDelete.Success && resList.Success && resList.Result.First().IsDeleted);
        }
        #endregion

        #region List
        [TestMethod]
        public void TestListRestaurant()
        {
            ContextSeeders.Seed();
            var bo = new RestaurantBusinessObject();
            var resList = bo.List();
            Assert.IsTrue(resList.Success && resList.Result.Count == 1);
        }
        #endregion

        #region Assync Delete
        [TestMethod]
        public void TestDeleteRestaurantAsync()
        {
            ContextSeeders.Seed();
            var bo = new RestaurantBusinessObject();
            var resList = bo.List();
            var resDelete = bo.Delete(resList.Result.First().Id);
            resList = bo.List();
            Assert.IsTrue(resDelete.Success && resList.Success && resList.Result.First().IsDeleted);
        }
        #endregion

        #region Assync Update
        [TestMethod]
        public void TestUpdateRestaurantAsync()
        {
            ContextSeeders.Seed();
            var mbo = new RestaurantBusinessObject();
            var resList = mbo.List();
            var item = resList.Result.FirstOrDefault();

            var newRestaurant = new Restaurant("Bartolomeu", "Rua tulipa, numero 234, Ericeira", "11:00", "22:00",
                "Segunfa-feira", 20);

            item.Name = newRestaurant.Name;
            item.Address = newRestaurant.Address;
            item.OpenningHours = newRestaurant.OpenningHours;
            item.ClosingHours = newRestaurant.ClosingHours;
            item.ClosingDays = newRestaurant.ClosingDays;
            item.TableCount = newRestaurant.TableCount;


            var resUpdate = mbo.UpdateAsync(item).Result;
            resList = mbo.ListAsync().Result;

            Assert.IsTrue(resList.Success && resUpdate.Success &&
                resList.Result.First().Name == newRestaurant.Name &&
                resList.Result.First().Address == newRestaurant.Address &&
                resList.Result.First().OpenningHours == newRestaurant.OpenningHours &&
                resList.Result.First().ClosingHours == newRestaurant.ClosingHours &&
                resList.Result.First().ClosingDays == newRestaurant.ClosingDays &&
                resList.Result.First().TableCount == newRestaurant.TableCount);
        }
        #endregion
    }
}

