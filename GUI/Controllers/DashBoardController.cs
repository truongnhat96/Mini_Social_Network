using GUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace GUI.Controllers
{
    public class DashBoardController : Controller
    {
        public IActionResult Index()
        {
           if(TempData["DisplayName"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
           ViewBag.DisplayName = TempData["DisplayName"];
            return View();
        }


    }
}
