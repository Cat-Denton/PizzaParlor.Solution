using System.Collections.Generic;

namespace PizzaParlor.Models
{
  public class Order
  {
    public Order()
    {
      this.JoinEntities = new HashSet<MenuItemOrder>();
    }
    public int OrderId { get; set; }
    public int Total { get; set; }
    public string CustomerInfo { get; set; }
    public bool IsDelivery { get; set; }
    public bool IsComplete { get; set; }
    public virtual ICollection<MenuItemOrder> JoinEntities { get; set; }

  }
}