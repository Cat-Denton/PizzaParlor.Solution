using Microsoft.AspNetCore.Mvc;
using PizzaParlor.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace PizzaParlor.Controllers
{
  public class MenuItemsController : Controller
  {
    private readonly PizzaParlorContext _db;

    public MenuItemsController(PizzaParlorContext db)
    {
      _db = db;
    }
    public ActionResult Index()
    {
      List<MenuItem> model = _db.MenuItems.ToList();
      return View(model);
    }
    public ActionResult Create()
    {
      return View();
    }
    [HttpPost]
    public ActionResult Create(MenuItem menuItem)
    {
      _db.MenuItems.Add(menuItem);
      _db.SaveChanges();
      return RedirectToAction("Create");  
    }
    public ActionResult Edit(int id)
    {
      MenuItem thisMenuItem = _db.MenuItems.FirstOrDefault(menuItem => menuItem.MenuItemId == id);
      return View(thisMenuItem);
    }
    [HttpPost]
    public ActionResult Edit(MenuItem menuItem)
    {
      _db.Entry(menuItem).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      MenuItem thisMenuItem = _db.MenuItems.FirstOrDefault(menuItem => menuItem.MenuItemId == id);
      return View(thisMenuItem);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      MenuItem thisMenuItem = _db.MenuItems.FirstOrDefault(menuItem => menuItem.MenuItemId == id);
      _db.MenuItems.Remove(thisMenuItem);
      _db.SaveChanges();
      return RedirectToAction("Index", "MenuItems");
    }
  }
}
