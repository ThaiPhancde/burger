using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace burger.Models
{
    [Table("tblDrink")]
    public class tblDrink
    {
        [Key]
        public int DrinkID { get; set; }
        public string? Name { get; set; }
        public string? Image { get; set; }
        public string? Details { get; set; }
        public string? Link { get; set; }
        public bool IsActive { get; set; }
        public int FoodOrder { get; set; }
        [ForeignKey("FMenuID")]       
        public int FMenuID { get; set; }
        public int Price { get; set; }
    }
}