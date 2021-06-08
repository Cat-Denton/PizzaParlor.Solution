using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using PizzaParlor.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

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
      return View();
    }

    public ActionResult Create()
    {
      ViewBag.MenuItemId = new SelectList(_db.MenuItems, "MenuItemId", "Name");
      return View();
    }

    [HttpPost]
    public ActionResult Create(Order order, int MenuItemId)
    {
      _db.Orders.Add(order);
      _db.SaveChanges();
      if (MenuItemId != 0)
      {
        _db.MenuItemOrders.Add(new MenuItemOrder() { MenuItemId = MenuItemId, OrderId = order.OrderId });
      }
      _db.SaveChanges();
      return RedirectToAction("Details", new {id = order.OrderId});
    }

    public ActionResult Details(int id)
    {
      ViewBag.MenuItemId = new SelectList(_db.MenuItems, "MenuItemId", "Name");
      Order thisOrder = _db.Orders
        .Include(order => order.JoinEntities)
        .ThenInclude(join => join.MenuItem)
        .FirstOrDefault(order => order.OrderId == id);

      return View(thisOrder);

    }

    [HttpPost]
    public ActionResult Details(Order order, int MenuItemId)
    {
      if (MenuItemId != 0)
      {
        _db.MenuItemOrders.Add(new MenuItemOrder() { MenuItemId = MenuItemId, OrderId = order.OrderId });
      }
      _db.Entry(order).State = EntityState.Modified;
      _db.SaveChanges();
      return View();
    }
  }
}