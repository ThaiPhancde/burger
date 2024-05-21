using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace burger.Models
{
    [Table("CartItem")]
public class CartItem
{ 
    [Key]
    public int FoodID { get; set; }
    public string? FoodName { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public decimal TotalPrice 
    {
        get 
        {
            return Price * Quantity;
        }
    }
}
}
