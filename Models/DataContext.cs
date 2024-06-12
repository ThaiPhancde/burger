using Microsoft.EntityFrameworkCore;
using burger.Areas.Admin.Models;
namespace burger.Models
{
    public class DataContext : DbContext
    {
         public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }   
        public DbSet<tblMenu> Menu { get; set; }
        public DbSet<AdminMenu> AdminMenu { get; set; }
        public DbSet<tblFoodMenu> FoodMenu { get; set; }
        public DbSet<tblBurger> Burger { get; set; }
        public DbSet<ViewBurger> ViewBurger { get; set; }
        public DbSet<tblCombo> Combo { get; set; }
        public DbSet<ViewCombo> ViewCombo { get; set; }
        public DbSet<tblDrink> Drink { get; set; }
        public DbSet<ViewDrink> ViewDrink { get; set; }
        public DbSet<tblFriedChicken> FriedChicken { get; set; }
        public DbSet<ViewFriedChicken> ViewFriedChicken { get; set; }
        public DbSet<tblHappySnack> HappySnack { get; set; }
        public DbSet<ViewHappySnack> ViewHappySnack { get; set; }
        public DbSet<AdminUser> AdminUser { get; set; }
        public DbSet<tblDeals> Deals { get; set; }
        public DbSet<StoreAddress> StoreAddress { get; set; }
    }
}