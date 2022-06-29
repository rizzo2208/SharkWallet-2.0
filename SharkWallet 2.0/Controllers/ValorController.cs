using Microsoft.AspNetCore.Mvc;
using SharkWallet_2._0.entidades;


namespace SharkWallet_2._0.Controllers
{
    public class ValorController : Controller
    {
        private readonly IConsumirApiService _consumirApiServices;
        public ValorController(IConsumirApiService apiService)
        {
            _consumirApiServices = apiService;
        }
        public async Task<IActionResult> Index()
        {
            if (ModelState.IsValid)
            {
                var valor = await _consumirApiServices.GetValor();
                return View(valor);
            }
            else {
                return RedirectToAction("Index", "Home");
            }
        }
    }
}
