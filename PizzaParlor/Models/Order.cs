using System.Collections.Generic;

namespace PizzaParlor.Models
{
  public class Order
  {
    public Order()
    {
      this.JoinEntities = new HashSet<CustomerOrder>();
    }

    public int OrderId { get; set; }
    public int Total { get; set; }
    public virtual ICollection<MenuItem> MenuItems { get; set; }
    public virtual ICollection<CustomerOrder> JoinEntities { get; set; }
  }
}