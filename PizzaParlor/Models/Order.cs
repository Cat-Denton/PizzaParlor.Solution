using System.Collections.Generic;

namespace PizzaParlor.Models
{
  public class Order
  {
    public Order()
    {
      this.JoinEntities = new HashSet<MenuItemOrder>();
      this.JoinEntities2 = new HashSet<CustomerOrder>();
    }
    public int OrderId { get; set; }
    public int Total { get; set; }
    public virtual ICollection<MenuItemOrder> JoinEntities { get; set; }
    public virtual ICollection<CustomerOrder> JoinEntities2 { get; set; }

  }
}