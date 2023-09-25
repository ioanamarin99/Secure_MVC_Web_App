using Microsoft.AspNetCore.Mvc;

namespace ISM_Y1_Marin_Ioana_Web_Cloud_Project.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
