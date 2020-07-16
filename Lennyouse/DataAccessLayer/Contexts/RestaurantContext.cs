using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Recodme.RD.Lennyouse.Data.UserInfo;
using Recodme.RD.Lennyouse.Data.MenuInfo;
using Recodme.RD.Lennyouse.Data.RestaurantInfo;
using Recodme.RD.Lennyouse.DataAccessLayer.Properties;

namespace Recodme.RD.Lennyouse.DataAccessLayer.Contexts
{
    public class RestaurantContext : IdentityDbContext
    {
        public RestaurantContext() : base()
        {

        }

        public RestaurantContext(DbContextOptions<RestaurantContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Resources.ConnectionString);
            }
        }


        public DbSet<Course> Course { get; set; }
        public DbSet<DietaryRestriction> DietaryRestriction { get; set; }
        public DbSet<Dish> Dish { get; set; }
        public DbSet<Meal> Meal { get; set; }
        public DbSet<Menu> Menu { get; set; }
        public DbSet<ClientRecord> ClientRecord { get; set; }
        public DbSet<Person> Person { get; set; }
        public DbSet<StaffRecord> StaffRecord { get; set; }
        public DbSet<StaffTitle> StaffTitle { get; set; }
        public DbSet<Title> Title { get; set; }
        public DbSet<Restaurant> Restaurant { get; set; }
        public DbSet<Booking> Booking { get; set; }
        public DbSet<Serving> Serving { get; set; }
        public DbSet<LennyouseUser> LennyouseUser { get; set; }
    }
}
