using System;

namespace mvcRegistrations.Models;

public class ProductModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string Description { get; set; }

    public virtual ICollection<CartModel> Carts { get; set; } // Navigation back to CartModel
}
