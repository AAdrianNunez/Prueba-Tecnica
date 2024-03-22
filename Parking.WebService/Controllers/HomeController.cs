using System.Web.Mvc;

namespace Parking.WebService.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Parking WEB Service";
            return View();
        }
    }
}