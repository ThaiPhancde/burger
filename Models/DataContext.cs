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
        
    }
}