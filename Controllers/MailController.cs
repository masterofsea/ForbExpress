using Microsoft.AspNetCore.Mvc;

namespace ForbExpress.Controllers
{
    public class MailController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}