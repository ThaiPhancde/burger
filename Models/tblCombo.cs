using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace burger.Models
{
    [Table("tblCombo")]
    public class tblCombo
    {
        [Key]
        public long ComboID { get; set; }
        public string? Name { get; set; }
        public string? Image { get; set; }
        public string? Details { get; set; }
        public string? Link { get; set; }
        public bool? IsActive { get; set; }
        public int FoodOrder { get; set; }
        public int FMenuID { get; set; }
        public int Price { get; set; }
    }
}