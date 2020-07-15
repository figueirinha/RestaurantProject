using Recodme.RD.Lennyouse.Data.MenuInfo;
using Recodme.RD.Lennyouse.Data.RestaurantInfo;
using Recodme.RD.Lennyouse.Data.UserInfo;
using Recodme.RD.Lennyouse.DataAccessLayer.Contexts;
using System;

namespace Recodme.RD.Lennyouse.DataAccessLayer.Seeders
{
    public static class ContextSeeders
    {
        public static void Seed()
        {
            using var _ctx = new RestaurantContext();
            _ctx.Database.EnsureDeleted();
            _ctx.Database.EnsureCreated();
            var course = new Course("Dinner");
            var dietaryRestriction = new DietaryRestriction("Vagan");
            var dish = new Dish("Panacota", dietaryRestriction.Id);
            var meal = new Meal("Lunch", "11:00", "15:00");
            var restaurant = new Restaurant("Lennyouse", "Avenida da Liberdade, numero 1334, Lisboa", "10:00", "22:00", "Segunda", 20);
            var menu = new Menu(DateTime.Parse("09/08/2010"), restaurant.Id, meal.Id);
            var serving = new Serving(menu.Id, course.Id, dish.Id);
            var lennyouseUser = new LennyouseUser(Guid.NewGuid());
            var person = new Person(1234567, 9999 - 9999, "Miguel Marco", "Silva Costa", DateTime.Parse(" 25/12/1997"), lennyouseUser.Id);
            var clientRecord = new ClientRecord(DateTime.Parse("25/12/1997"), person.Id, restaurant.Id);
            var booking = new Booking(clientRecord.Id, DateTime.Parse("25 /12/1997"));
            var title = new Title("Empregada de mesa", "é o profissional que, no respeito pelas normas de higiene e segurança," +
                " executa e prepara o serviço de restaurante, acolhe e atende os clientes, efectua o serviço de mesa, " +
                "aconselha a escolha de pratos e bebidas, executa serviços de buffets, banquetes, cocktails e outros, " +
                "efectua a facturação dos serviços prestados em restaurantes, hotéis e estabelecimentos similares.", 
                "Ana Bruna Figueirinha Pereira");
            var staffRecord = new StaffRecord(DateTime.Parse("12/12/2000"), DateTime.Parse("12/12/2020"), person.Id, restaurant.Id);
            var staffTitle = new StaffTitle(staffRecord.Id, title.Id, DateTime.Now, DateTime.Now.AddDays(1));

            _ctx.Course.AddRange(course);
            _ctx.DietaryRestriction.AddRange(dietaryRestriction);
            _ctx.Dish.AddRange(dish);
            _ctx.Meal.AddRange(meal);
            _ctx.Restaurant.AddRange(restaurant);
            _ctx.Menu.AddRange(menu);
            _ctx.Serving.AddRange(serving);
            _ctx.LennyouseUser.AddRange(lennyouseUser);
            _ctx.Person.AddRange(person); 
            _ctx.ClientRecord.AddRange(clientRecord);
            _ctx.Booking.AddRange(booking);
            _ctx.Title.AddRange(title);
            _ctx.StaffRecord.AddRange(staffRecord);
            _ctx.StaffTitle.AddRange(staffTitle);

            _ctx.SaveChanges();

        }
    }
}