using System.Web.Mvc;

namespace WebUI.Controllers
{
    public class FollowController : MessageControllerBase
    {
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Follow(string username)
        {
            if (!Security.IsAuthenticated)
            {
                 return RedirectToAction("Index", "Home");
            }

            Users.Follow(username, Security.GetCurrentUser());

            return GoToReferrer();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Unfollow(string username)
        {
            if (!Security.IsAuthenticated)
            {
                 return RedirectToAction("Index", "Home");
            }

            Users.Unfollow(username, Security.GetCurrentUser());

            return GoToReferrer();
        }
     

        public ActionResult Profiles()
        {
            if (!Security.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            var users = Users.All(true);

            return View(users);
        }

        public ActionResult Followers()
        {
            if (!Security.IsAuthenticated)
            {
                 return RedirectToAction("Index", "Home");
            }

            var user = Users.GetAllFor(Security.UserId);
            return View("Profiles", user.Followers);
           
        }
    }
}