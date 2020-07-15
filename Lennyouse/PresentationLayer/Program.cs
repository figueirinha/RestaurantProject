using Recodme.RD.Lennyouse.Data.MenuInfo;
using Recodme.RD.Lennyouse.Data.RestaurantInfo;
using Recodme.RD.Lennyouse.Data.UserInfo;
using Recodme.RD.Lennyouse.DataAccessLayer.Contexts;
using Recodme.RD.Lennyouse.DataAccessLayer.DataAccessObjects;
using Recodme.RD.Lennyouse.DataAccessLayer.DataAccessObjects.MenuInfo;
using Recodme.RD.Lennyouse.DataAccessLayer.DataAccessObjects.RestaurantInfo;
using Recodme.RD.Lennyouse.DataAccessLayer.DataAccessObjects.UserInfo;
using System;

namespace Recodme.RD.Lennyouse.PresentationLayer
{
    class Program
    {
        static void Main(string[] args)
        {
            var ctx = new RestaurantContext();
            ctx.Database.EnsureCreated();

            //var daodr = new dietaryrestrictiondataaccessobject();
            //var veganrestriction = new dietaryrestriction("vegan");
            //var daodr.create(veganrestriction);

            //var daodish = new dishdataaccessobject();
            //var newdish = new dish("mocoto", veganrestriction.id);
            //daodish.create(newdish);

            //var daocourse = new coursedataaccessobject();
            //var newcourse = new course("main course");
            //daocourse.create(newcourse);

            //var dao = new mealdataaccessobject();
            //var newmeal = new meal("dinner", "18:00", "22:00");
            //dao.create(newmeal);

            //var daorestaurant = new restaurantdataaccessobject();
            //var newrestaurant = new restaurant("sushinow", "rua das oliveiras, nº 123, parque das nações",
            //    "11:00", "22:00", "terça-feira", 15);
            //daorestaurant.create(newrestaurant);

            //var daotitle = new titledataaccessobject();
            //var newtitle = new title("sushiman", "responsible for preparing typical japanese dishes," +
            //    " specializing in sashimi, sushi, among other culinary items.", "ricardo");
            //daotitle.create(newtitle);

            //var daomenu = new menudataaccessobject();
            //var newmenu = new menu(datetime.parse("04/07/2020"), newrestaurant.id, newmeal.id);
            //daomenu.create(newmenu);

            //var daoserving = new servingdataaccessobject();
            //var newserving = new serving(newmenu.id, newcourse.id, newdish.id);
            //daoserving.create(newserving);

        }
    }
}
