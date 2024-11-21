using GUI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AccountManager _accountManager;

        public HomeController(ILogger<HomeController> logger, AccountManager accountManager)
        {
            _logger = logger;
            _accountManager = accountManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(AccountModel account)
        {
            _logger.LogInformation("Username = {un}", account.Username);
            _logger.LogInformation("Password = {pw}", account.Password);
            if (_accountManager.LoginValidation(account.Username, account.Password))
            {
                return RedirectToAction("Index", "DashBoard");
            }
            return RedirectToAction("Invalid");
        }

        [HttpGet]
        public IActionResult Invalid()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(AccountModel account)
        {
            _accountManager.AddAccount(new Account() 
            { 
                Username = account.Username,
                Password = account.Password,
                DisplayName = account.DisplayName
            });
            return RedirectToAction("Successful");
        }

        public IActionResult ViewAccounts()
        {
            var accounts = _accountManager.GetAllAccounts();
            return View(new AccountList() { Accounts = accounts.Select(a => new AccountModel() 
            { 
                DisplayName = a.DisplayName,
                Username = a.Username,
                Password = a.Password
            })});
        }

        public IActionResult Successful()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
