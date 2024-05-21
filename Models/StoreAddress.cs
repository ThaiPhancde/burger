using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace burger.Models
{
    [Table("StoreAddress")]
    public class StoreAddress
    {
        [Key]
        public int StoreID { get; set; }
        public string? StoreName { get; set; }
        public string? Address { get; set; }
        public string? WorkingTime { get; set; }
        public bool? IsActive { get; set; }
        public string? Phone { get; set; }
    }
}
