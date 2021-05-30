using System.Collections.Generic;

namespace PizzaParlor.Models
{
  public class Customer
  {
    public Customer()
    {
      this.JoinEntities = new HashSet<CustomerOrder>();
    }

    public int CustomerId { get; set; }
    public string Name { get; set; }
    public string ContactInfo { get; set; }
    public virtual ICollection<CustomerOrder> JoinEntities { get; set; }
  }
}