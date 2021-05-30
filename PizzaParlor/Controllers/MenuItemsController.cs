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
  }
}