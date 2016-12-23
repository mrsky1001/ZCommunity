using System.Web.Mvc;
using WebUI.ViewModel;

namespace WebUI.Controllers
{
    public class HomeController : MessageControllerBase
    {
        public HomeController() : base() { }

        public ActionResult Index()
        {
            if (Security.IsAuthenticated)
            {
                if (DataContext.Messages == null)
                {
                    return View();
                }
                return View();
            }
            return View("SignIn", new LoginSignupViewModel());
        }
    }
}