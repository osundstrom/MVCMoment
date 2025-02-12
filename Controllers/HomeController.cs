using Microsoft.AspNetCore.Mvc;

namespace MVCMoment.Controllers
{
    //home kontroller
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //returnerar vyn
            return View();
        }



    }
}
