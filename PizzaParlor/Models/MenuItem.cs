using System.Collections.Generic;

namespace PizzaParlor.Models
{
  public class MenuItem
  {
    public MenuItem()
    {
      this.JoinEntities = new HashSet<MenuItemOrder>();
    }

    public int MenuItemId { get; set; }
    public string Name { get; set; }
    public int Price { get; set; }
    public string Description { get; set; }
    public bool IsTopping { get; set; }
    public virtual ApplicationUser User { get; set; }
    public virtual ICollection<MenuItemOrder> JoinEntities { get; set; }

  }
}
