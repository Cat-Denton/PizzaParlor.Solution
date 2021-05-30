namespace PizzaParlor.Models
{
  public class CustomerOrder
  {
    public int CustomerOrderId { get; set; }
    public int CustomerId { get; set; }
    public int OrderId { get; set; }
    public virtual Customer Customer { get; set; }
    public virtual Order Order { get; set; }
  }
}