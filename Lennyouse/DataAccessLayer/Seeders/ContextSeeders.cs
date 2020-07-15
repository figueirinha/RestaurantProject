using Recodme.RD.Lennyouse.Data.MenuInfo;
using Recodme.RD.Lennyouse.Data.RestaurantInfo;
using Recodme.RD.Lennyouse.Data.UserInfo;
using Recodme.RD.Lennyouse.DataAccessLayer.Contexts;
using System;
using System.Collections.Generic;

namespace Recodme.RD.Lennyouse.DataAccessLayer.Seeders
{
    public static class ContextSeeders
    {
        public static void Seed()
        {
            using var _ctx = new RestaurantContext();
            _ctx.Database.EnsureDeleted();
            _ctx.Database.EnsureCreated();
            var dr = new List<DietaryRestriction>()
            {
                new DietaryRestriction("Vegan"),
                new DietaryRestriction("Vegetarian"),
                new DietaryRestriction("Pescatarian"),
                new DietaryRestriction("Omni")
            };
            var c = new List<Course>()
            {
                new Course("Entry"),
                new Course("Dessert"),
                new Course("Main dish"),
                new Course("Drink")
            };
            var m = new List<Meal>()
            {
                new Meal("Breakfast", "8:00", "12:00"),
                new Meal("Lunch", "12:00", "14:00"),
                new Meal("Tea", "16:00", "17:00"),
                new Meal("Dinner", "18:00", "21:00")
            };
            var p1 = new Person(1203, 1203, "A", "B", DateTime.Now);
            var r1 = new Restaurant("asd", "owewq", "123", "1232", "23ed", 4);
            var cr1 = new ClientRecord(DateTime.Now, p1.Id, r1.Id);
            var t1 = new Title("123", "4134", "woe");
            var sr1 = new StaffRecord(DateTime.Now, DateTime.Now, p1.Id, r1.Id);
            var st1 = new StaffTitle(sr1.Id, t1.Id,  DateTime.Now, DateTime.Now);
            var b1 = new Booking(cr1.Id, DateTime.Now);
            var me = new List<Menu>()
            {
                new Menu(DateTime.Now, r1.Id, m[0].Id),
                new Menu(DateTime.Now, r1.Id, m[1].Id),
                new Menu(DateTime.Now, r1.Id, m[2].Id),
                new Menu(DateTime.Now, r1.Id, m[3].Id)
            };
            var dsh = new List<Dish>
            {
                new Dish("Roasted Esparagus", dr[0].Id),
                new Dish("Veggie Lasagna", dr[0].Id),
                new Dish("Brownie Vegan", dr[0].Id),
                new Dish("Poached Egg", dr[1].Id),
                new Dish("Small Fish from the garden", dr[1].Id),
                new Dish("Green Broth Sorbet", dr[1].Id),
                new Dish("Toast and Fish Eggs", dr[2].Id),
                new Dish("CodFish at Joseph Small Barrel", dr[2].Id),
                new Dish("Sardine Panacotta", dr[2].Id),
                new Dish("Beef Tartar", dr[3].Id),
                new Dish("Female Gardner", dr[3].Id),
                new Dish("Camel's Drool", dr[3].Id)
            };
            var se = new List<Serving>()
            {
                new Serving(me[0].Id, c[0].Id, dsh[0].Id),
                new Serving(me[0].Id, c[1].Id, dsh[1].Id),
                new Serving(me[0].Id, c[2].Id, dsh[2].Id),
                new Serving(me[0].Id, c[0].Id, dsh[3].Id),
                new Serving(me[0].Id, c[1].Id, dsh[4].Id),
                new Serving(me[0].Id, c[2].Id, dsh[5].Id),
                new Serving(me[0].Id, c[0].Id, dsh[6].Id),
                new Serving(me[0].Id, c[1].Id, dsh[7].Id),
                new Serving(me[0].Id, c[2].Id, dsh[8].Id),
                new Serving(me[0].Id, c[0].Id, dsh[9].Id),
                new Serving(me[0].Id, c[1].Id, dsh[10].Id),
                new Serving(me[0].Id, c[2].Id, dsh[11].Id)
        };
            _ctx.DietaryRestriction.AddRange(dr);
            _ctx.ClientRecord.AddRange(cr1);
            _ctx.StaffRecord.AddRange(sr1);
            _ctx.StaffTitle.AddRange(st1);
            _ctx.Restaurant.AddRange(r1);
            _ctx.Serving.AddRange(se);
            _ctx.Booking.AddRange(b1);
            _ctx.Dish.AddRange(dsh);
            _ctx.Course.AddRange(c);
            _ctx.Title.AddRange(t1);
            _ctx.Person.AddRange(p1);
            _ctx.Meal.AddRange(m);
            _ctx.Menu.AddRange(me);
            _ctx.SaveChanges();
        }
        //public static void Seed()
        //{
        //    using var _ctx = new RestaurantContext();
        //    _ctx.Database.EnsureDeleted();
        //    _ctx.Database.EnsureCreated();
        //    var course = new Course("Dinner");
        //    var dietaryRestriction = new DietaryRestriction("Vagan");
        //    var dish = new Dish("Panacota", dietaryRestriction.Id);
        //    var meal = new Meal("Lunch", "11:00", "15:00");
        //    var restaurant = new Restaurant("Lennyouse", "Avenida da Liberdade, numero 1334, Lisboa", "10:00", "22:00", "Segunda", 20);
        //    var menu = new Menu(DateTime.Parse("09/08/2010"), restaurant.Id, meal.Id);
        //    var serving = new Serving(menu.Id, course.Id, dish.Id);
        //    var lennyouseUser = new LennyouseUser();
        //    var person = new Person(1234567, 9999 - 9999, "Miguel Marco", "Silva Costa", DateTime.Parse(" 25/12/1997"));
        //    var clientRecord = new ClientRecord(DateTime.Parse("25/12/1997"), person.Id, restaurant.Id);
        //    var booking = new Booking(clientRecord.Id, DateTime.Parse("25 /12/1997"));
        //    var title = new Title("Empregada de mesa", "é o profissional que, no respeito pelas normas de higiene e segurança," +
        //        " executa e prepara o serviço de restaurante, acolhe e atende os clientes, efectua o serviço de mesa, " +
        //        "aconselha a escolha de pratos e bebidas, executa serviços de buffets, banquetes, cocktails e outros, " +
        //        "efectua a facturação dos serviços prestados em restaurantes, hotéis e estabelecimentos similares.", 
        //        "Ana Bruna Figueirinha Pereira");
        //    var staffRecord = new StaffRecord(DateTime.Parse("12/12/2000"), DateTime.Parse("12/12/2020"), person.Id, restaurant.Id);
        //    var staffTitle = new StaffTitle(staffRecord.Id, title.Id, DateTime.Now, DateTime.Now.AddDays(1));

        //    _ctx.Course.AddRange(course);
        //    _ctx.DietaryRestriction.AddRange(dietaryRestriction);
        //    _ctx.Dish.AddRange(dish);
        //    _ctx.Meal.AddRange(meal);
        //    _ctx.Restaurant.AddRange(restaurant);
        //    _ctx.Menu.AddRange(menu);
        //    _ctx.Serving.AddRange(serving);
        //    _ctx.LennyouseUser.AddRange(lennyouseUser);
        //    _ctx.Person.AddRange(person); 
        //    _ctx.ClientRecord.AddRange(clientRecord);
        //    _ctx.Booking.AddRange(booking);
        //    _ctx.Title.AddRange(title);
        //    _ctx.StaffRecord.AddRange(staffRecord);
        //    _ctx.StaffTitle.AddRange(staffTitle);

        //    _ctx.SaveChanges();

        //}
    }
}