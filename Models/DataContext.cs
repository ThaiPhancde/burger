using Microsoft.EntityFrameworkCore;

namespace burger.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base(options){

        }
        public DbSet<tblMenu> Menus { get; set; }
        
    }
}