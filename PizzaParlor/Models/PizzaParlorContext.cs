using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace PizzaParlor.Models
{
  public class PizzaParlorContext : IdentityDbContext<ApplicationUser>
  {
    public DbSet<Order> Orders { get; set; }
    public DbSet<MenuItemOrder> MenuItemOrders { get; set; }
    public DbSet<MenuItem> MenuItems { get; set; }

    public PizzaParlorContext(DbContextOptions options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseLazyLoadingProxies();
    }
  }
}