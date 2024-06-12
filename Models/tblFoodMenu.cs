using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace burger.Models
{
    [Table("tblFoodMenu")]
    public class tblFoodMenu
    {
        [Key]
        public long FMenuID { get; set; }
        public string? FMenuName { get; set; }
        public string? ControllerName { get; set; }
        public string? ActionName { get; set; }
        public bool? IsActive { get; set; }
    }
}