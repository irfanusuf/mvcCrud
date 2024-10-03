using System;

namespace mvcRegistrations.Models;

public class CartModel
{
    public int Id { get; set; }
    public string UserId { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }

    public virtual ProductModel Product { get; set; }
}
