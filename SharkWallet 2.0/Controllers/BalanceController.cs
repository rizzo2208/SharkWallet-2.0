using Microsoft.AspNetCore.Mvc;

namespace SharkWallet_2._0.Controllers
{
    public class BalanceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
