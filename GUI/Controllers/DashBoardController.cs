using Microsoft.AspNetCore.Mvc;

namespace GUI.Controllers
{
    public class DashBoardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
