using Microsoft.EntityFrameworkCore;
using burger.Areas.Admin.Models;
namespace burger.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base(options){

        }
        public DbSet<tblMenu> Menu { get; set; }
        public DbSet<AdminMenu> AdminMenu { get; set; }
        public DbSet<ViewBurger> ViewBurger { get; set; }
        public DbSet<AdminUser> AdminUser { get; set; }
        public DbSet<tblDeals> Deals { get; set; }
        public DbSet<CartItem> CartItem { get; set; }
        public DbSet<StoreAddress> StoreAddress { get; set; }
    }
}