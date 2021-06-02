namespace PizzaParlor.Models
{
  public class MenuItemOrder
  { 
    public int MenuItemOrderId { get; set; }
    public int MenuItemId { get; set; }
    public int OrderId { get; set; }
    public virtual MenuItem MenuItem { get; set; }
    public virtual Order Order { get; set; }
  }
}