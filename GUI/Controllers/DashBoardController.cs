using GUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace GUI.Controllers
{
    public class DashBoardController : Controller
    {
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("DisplayName") == null)
            {
                return RedirectToAction("Login", "Home");
            }
            return View();
        }


    }
}
