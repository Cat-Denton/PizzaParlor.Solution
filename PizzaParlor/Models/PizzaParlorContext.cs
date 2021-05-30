using Microsoft.EntityFrameworkCore;

namespace PizzaParlor.Models
{
  public class PizzaParlorContext : DbContext
  {
    public virtual DbSet<Customer> Customers { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<CustomerOrder> CustomerOrder { get; set; }
    public DbSet<MenuItem> MenuItems { get; }

    public PizzaParlorContext(DbContextOptions options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseLazyLoadingProxies();
    }
  }
}