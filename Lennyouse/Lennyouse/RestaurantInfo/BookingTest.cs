using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recodme.RD.Lennyouse.BusinessLayer.BusinessObjects.RestaurantInfo;
using Recodme.RD.Lennyouse.BusinessLayer.BusinessObjects.UserInfo;
using Recodme.RD.Lennyouse.Data.RestaurantInfo;
using Recodme.RD.Lennyouse.Data.UserInfo;
using Recodme.RD.Lennyouse.DataAccessLayer.Seeders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Recodme.RD.Lennyouse.LennyouseTest.RestaurantInfo
{
    [TestClass]
    public class BookingTest
    {
        [TestMethod]
        public void TestCreateBooking()
        {
            ContextSeeders.Seed();
            var crbo = new ClientRecordBusinessObject();
            var bbo = new BookingBusinessObject();
            var pbo = new PersonBusinessObject();
            var rbo = new RestaurantBusinessObject();
            var lhubo = new LennyouseUserBusinessObject();

            var _lennyouseUser = new LennyouseUser(Guid.NewGuid());
            var newP = new Person(11111, 11111, "ok", "ok", DateTime.UtcNow, _lennyouseUser.Id);
            var newR = new Restaurant("ok", "ok", "ok", "ok", "ok", 5);
            
           

            var cr = new ClientRecord(DateTime.UtcNow, newP.Id, newR.Id);
            var booking = new Booking(cr.Id, DateTime.UtcNow);


            
            crbo.Create(cr);
            pbo.Create(newP);
            rbo.Create(newR);
            lhubo.Create(_lennyouseUser);

            var resCreate = bbo.Create(booking);
            var resGet = bbo.Read(booking.Id);

            Assert.IsTrue(resCreate.Success && resGet.Success && resGet.Result != null);
        }

        [TestMethod]
        public void TestCreateBookingAsync()
        {
            ContextSeeders.Seed();
            var crbo = new ClientRecordBusinessObject();
            var bbo = new BookingBusinessObject();
            var pbo = new PersonBusinessObject();
            var rbo = new RestaurantBusinessObject();
            var lhubo = new LennyouseUserBusinessObject();

            var _lennyouseUser = new LennyouseUser(Guid.NewGuid());
            var newP = new Person(11111, 11111, "ok", "ok", DateTime.UtcNow, _lennyouseUser.Id);
            var newR = new Restaurant("ok", "ok", "ok", "ok", "ok", 5);



            var cr = new ClientRecord(DateTime.UtcNow, newP.Id, newR.Id);
            var booking = new Booking(cr.Id, DateTime.UtcNow);


            
            crbo.Create(cr);
            pbo.Create(newP);
            rbo.Create(newR);
            lhubo.Create(_lennyouseUser);

            var resCreate = bbo.CreateAsync(booking).Result;
            var resGet = bbo.ReadAsync(booking.Id).Result;

            Assert.IsTrue(resCreate.Success && resGet.Success && resGet.Result != null);
        }

        [TestMethod]
        public void TestListBooking()
        {
            ContextSeeders.Seed();
            var bo = new BookingBusinessObject();
            var resList = bo.List();

            Assert.IsTrue(resList.Success && resList.Result.Count == 1);
        }

        [TestMethod]
        public void TestListBookingAsync()
        {
            ContextSeeders.Seed();
            var bo = new BookingBusinessObject();
            var resList = bo.ListAsync().Result;

            Assert.IsTrue(resList.Success && resList.Result.Count == 1);
        }

        [TestMethod]
        public void TestUpdateBooking()
        {
            ContextSeeders.Seed();
            var bbo = new BookingBusinessObject();
            var resList = bbo.List();
            var item = resList.Result.FirstOrDefault();


            var crbo = new ClientRecordBusinessObject();
            var pbo = new PersonBusinessObject();
            var rbo = new RestaurantBusinessObject();
            var lhubo = new LennyouseUserBusinessObject();

            var _lennyouseUser = new LennyouseUser(Guid.NewGuid());
            var newP = new Person(11111, 11111, "ok", "ok", DateTime.UtcNow, _lennyouseUser.Id);
            var newR = new Restaurant("ok", "ok", "ok", "ok", "ok", 5);



            var cr = new ClientRecord(DateTime.UtcNow, newP.Id, newR.Id);
            var booking = new Booking(cr.Id, DateTime.UtcNow);

            
            crbo.Create(cr);
            pbo.Create(newP);
            rbo.Create(newR);
            lhubo.Create(_lennyouseUser);


            item.ClientRecordId = booking.ClientRecordId;

            var resUpdate = bbo.Update(item);
            resList = bbo.List();

            Assert.IsTrue(resList.Success && resUpdate.Success &&
                resList.Result.First().ClientRecordId == booking.ClientRecordId
                && resList.Result.First().Date == booking.Date);
        }

        [TestMethod]
        public void TestUpdateBookingAsync()
        {
            ContextSeeders.Seed();
            var bbo = new BookingBusinessObject();
            var resList = bbo.List();
            var item = resList.Result.FirstOrDefault();


            var crbo = new ClientRecordBusinessObject();
            var pbo = new PersonBusinessObject();
            var rbo = new RestaurantBusinessObject();
            var lhubo = new LennyouseUserBusinessObject();

            var _lennyouseUser = new LennyouseUser(Guid.NewGuid());
            var newP = new Person(11111, 11111, "ok", "ok", DateTime.UtcNow, _lennyouseUser.Id);
            var newR = new Restaurant("ok", "ok", "ok", "ok", "ok", 5);



            var cr = new ClientRecord(DateTime.UtcNow, newP.Id, newR.Id);
            var booking = new Booking(cr.Id, DateTime.UtcNow);

            
            crbo.Create(cr);
            pbo.Create(newP);
            rbo.Create(newR);
            lhubo.Create(_lennyouseUser);


            item.ClientRecordId = booking.ClientRecordId;

            var resUpdate = bbo.UpdateAsync(item).Result;
            resList = bbo.ListAsync().Result;

            Assert.IsTrue(resList.Success && resUpdate.Success &&
                resList.Result.First().ClientRecordId == booking.ClientRecordId
                && resList.Result.First().Date == booking.Date);
        }

        [TestMethod]
        public void TestDeleteBooking()
        {
            ContextSeeders.Seed();
            var bo = new BookingBusinessObject();

            var resList = bo.List();
            var resDelete = bo.Delete(resList.Result.First().Id);
            resList = bo.List();

            Assert.IsTrue(resDelete.Success && resList.Success && resList.Result.First().IsDeleted);
        }


        [TestMethod]
        public void TestDeleteBookingAsync()
        {
            ContextSeeders.Seed();
            var bo = new BookingBusinessObject();

            var resList = bo.List();
            var resDelete = bo.DeleteAsync(resList.Result.First().Id).Result;
            resList = bo.ListAsync().Result;

            Assert.IsTrue(resDelete.Success && resList.Success && resList.Result.First().IsDeleted);
        }
    }
}
