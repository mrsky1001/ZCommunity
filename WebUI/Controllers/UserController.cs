using System.Web.Mvc;

namespace WebUI.Controllers
{
    public class UserController : MessageControllerBase
    {
        // GET: User
        public ActionResult Index(string username)
        {
            var user = Users.GetAllFor(username);

            if (user == null)
            {
                // return new HttpNotFoundResult();
                return RedirectToAction("Index", "Home");
            }

            /*  return View("UserProfile", new UserViewModel()
              {
                  User = user,
                  Messages = user.Messages
              });*/
            return RedirectToAction("Index", "Home");

        }

        public ActionResult Followers(string username)
        {
            var user = Users.GetAllFor(username);

            if (user == null)
            {
                return new HttpNotFoundResult();
            }

            /*  return View("Buddies", new BuddiesViewModel()
              {
                  User = user,
                  Buddies = user.Followers
              });*/
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Following(string username)
        {
            var user = Users.GetAllFor(username);

            if (user == null)
            {
                return new HttpNotFoundResult();
            }
            return RedirectToAction("Index", "Home");

            /*   return View("Buddies", new BuddiesViewModel()
               {
                   User = user,
                   Buddies = user.Followings
               });*/
        }
    }
}