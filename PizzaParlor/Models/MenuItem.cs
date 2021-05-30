using System.Collections.Generic;

namespace PizzaParlor
{
  public class MenuItem
  {
    public int MenuItemId { get; set; }
    public string Name { get; set; }
    public int price { get; set; }
    public string Description { get; set; }
    public bool IsTopping { get; set; }
  }
}
