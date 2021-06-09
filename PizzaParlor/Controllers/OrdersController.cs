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
      var orderList = _db.Orders.ToList();
      return View(orderList);
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
    public ActionResult AddMenuItem(Order order, int MenuItemId)
    {
      if (MenuItemId != 0)
      {
        _db.MenuItemOrders.Add(new MenuItemOrder() { MenuItemId = MenuItemId, OrderId = order.OrderId });
      }
      _db.SaveChanges();
      return RedirectToAction("Details", new {id = order.OrderId});
    }
    public ActionResult Edit(int id)
    {
      Order thisOrder = _db.Orders.FirstOrDefault(order => order.OrderId == id);
      return View(thisOrder);
    }
    [HttpPost]
    public ActionResult Edit(Order order)
    {
      _db.Entry(order).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Details", new {id = order.OrderId});
    }
    public ActionResult Delete(int id)
    {
      var thisOrder = _db.Orders.FirstOrDefault(order => order.OrderId == id);
      return View(thisOrder);
    }
    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      Order thisOrder = _db.Orders.FirstOrDefault(order => order.OrderId == id);
      _db.Orders.Remove(thisOrder);
      _db.SaveChanges();
      return RedirectToAction("Index", "Home");
    }
    public ActionResult RemoveMenuItem(int joinId)
    {
      MenuItemOrder joinEntry = _db.MenuItemOrders.FirstOrDefault(menuItem => menuItem.MenuItemOrderId == joinId);
      int orderId = joinEntry.OrderId;
      _db.MenuItemOrders.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Details", new { id = orderId });
    }
  }
}