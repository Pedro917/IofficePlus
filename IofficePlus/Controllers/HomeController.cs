using IofficePlus.Dados.Contexts;
using Microsoft.AspNetCore.Mvc;

namespace IofficePlus.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IofficedbContext _db;

        public HomeController(ILogger<HomeController> logger, IofficedbContext db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult Index()
        {
            var usuarios = _db.TabUsuarios.ToList();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}