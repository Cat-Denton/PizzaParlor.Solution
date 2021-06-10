using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using PizzaParlor.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Security.Claims;

namespace PizzaParlor.Controllers
{
  [Authorize]
  public class OrdersController : Controller
  {
    private readonly PizzaParlorContext _db;
    private readonly UserManager<ApplicationUser> _userManager;

    public OrdersController(UserManager<ApplicationUser> userManager, PizzaParlorContext db)
    {
      _db = db;
      _userManager = userManager;
    }
    public ActionResult Index()
    {
      var orderList = _db.Orders.ToList();
      return View(orderList);
    }
    [AllowAnonymous]
    public ActionResult Create()
    {
      ViewBag.MenuItemId = new SelectList(_db.MenuItems, "MenuItemId", "Name");
      return View();
    }
    [AllowAnonymous]
    [HttpPost]
    public ActionResult Create(Order order, int MenuItemId)
    {
      _db.Orders.Add(order);
      _db.SaveChanges();
      return RedirectToAction("Details", new {id = order.OrderId});
    }
    [AllowAnonymous]
    public ActionResult Details(int id)
    {
      ViewBag.MenuItemId = new SelectList(_db.MenuItems, "MenuItemId", "Name");
      Order thisOrder = _db.Orders
        .Include(order => order.JoinEntities)
        .ThenInclude(join => join.MenuItem)
        .FirstOrDefault(order => order.OrderId == id);

      return View(thisOrder);

    }
    [AllowAnonymous]
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
    [AllowAnonymous]
    public ActionResult Edit(int id)
    {
      Order thisOrder = _db.Orders.FirstOrDefault(order => order.OrderId == id);
      return View(thisOrder);
    }
    [AllowAnonymous]
    [HttpPost]
    public ActionResult Edit(Order order)
    {
      _db.Entry(order).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Details", new {id = order.OrderId});
    }
    [AllowAnonymous]
    public ActionResult Delete(int id)
    {
      var thisOrder = _db.Orders.FirstOrDefault(order => order.OrderId == id);
      return View(thisOrder);
    }
    [AllowAnonymous]
    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      Order thisOrder = _db.Orders.FirstOrDefault(order => order.OrderId == id);
      _db.Orders.Remove(thisOrder);
      _db.SaveChanges();
      return RedirectToAction("Index", "Home");
    }
    [AllowAnonymous]
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