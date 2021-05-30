using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using PizzaParlor.Models;

namespace PizzaParlor.Controllers
{
  public class OrdersController : Controller
  {
    private readonly PizzaParlorContext _db;

    public OrdersController(PizzaParlorContext db)
    {
      _db = db;
    }
    public ActionResult Index()
    {
      ViewBag.Menu = _db.MenuItems.ToList();
      return View();
    }
  }
}