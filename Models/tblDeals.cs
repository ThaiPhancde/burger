using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace burger.Models
{
    [Table("tblDeals")]
    public class tblDeals
    {
        [Key]
        public int DealID { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public int OriginalPrice { get; set; }
        public int DiscountedPrice { get; set; }
        public bool? IsActive{  get; set; }

        [NotMapped]
        public double DiscountPercentage
        {
            get
            {
                return OriginalPrice > 0 
                    ? ((OriginalPrice - DiscountedPrice) / (double)OriginalPrice) * 100 
                    : 0;
            }
        }
    }
}
