using Microsoft.AspNetCore.Mvc;

namespace PizzaParlor.Controllers
{
  public class HomeController : Controller 
  {
    [HttpGet("/")]
    public ActionResult Index()
    {
      return View();
    }
  }
}


