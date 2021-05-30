using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace PizzaParlor.Models
{
  public class PizzaParlorContextFactory : IDesignTimeDbContextFactory<PizzaParlorContext>
  {

    PizzaParlorContext IDesignTimeDbContextFactory<PizzaParlorContext>.CreateDbContext(string[] args)
    {
      IConfigurationRoot configuration = new ConfigurationBuilder()
          .SetBasePath(Directory.GetCurrentDirectory())
          .AddJsonFile("appsettings.json")
          .Build();

      var builder = new DbContextOptionsBuilder<PizzaParlorContext>();

      builder.UseMySql(configuration["ConnectionStrings:DefaultConnection"], ServerVersion.AutoDetect(configuration["ConnectionStrings:DefaultConnection"]));

      return new PizzaParlorContext(builder.Options);
    }
  }
}