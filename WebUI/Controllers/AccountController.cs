using System.Web.Mvc;
using WebUI.ViewModel;

namespace WebUI.Controllers
{
    public class AccountController : MessageControllerBase
    {
         
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignIn(LoginSignupViewModel model)
        {
            if (Security.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            //создаем модель регистрации
            model.Signup = new SignupViewModel();

            var login = model.Login;

            //если модель не прошла валидацию
            if (!ModelState.IsValid || login == null)
            {
                return View("SignIn");
            }

            if (!Security.Authenticate(login.Username, login.Password) )
            {
                ModelState.AddModelError("Username", "Username and/or password was incorrect.");

                return View("SignIn");
            }
            //запись id в сессию
            Security.Login(login.Username);

            return RedirectToAction("Index", "Home");
        }
        

        [HttpPost]

        public ActionResult SignUp(LoginSignupViewModel model)
        {
            if (Security.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }

            model.Login = new LoginViewModel();

            var signup = model.Signup;

            if (!ModelState.IsValid || signup == null)
            {
                return View("SignUp", model);
            }

            if (Security.DoesUserExist(signup.Username))
            {
                ModelState.AddModelError("Username", "Username is already taken.");

                return View("SignUp", model);
            }

            Security.CreateUser(signup);

            return RedirectToAction("Index", "Profile");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Logout()
        {
            Security.Logout();

            return RedirectToAction("Index", "Home");
        }
        
        /*  
           public DbZCommunityContext dbZCommunityContext = new DbZCommunityContext();
            protected override void Dispose(bool disposing)
            {
                dbZCommunityContext.Dispose();
                base.Dispose(disposing);
            }

            [HttpGet]
            public ActionResult SignIn()
            {
                return View();
            }
            [HttpPost]
            public ActionResult SignIn(User user)
            {
                if (user.Password == null)
                {
                    ViewBag.Error = "Введите пароль!";
                    return View();
                }
                else if (user.Email == null)
                {
                    ViewBag.Error = "Введите электронную почту!";
                    return View();
                }
                else
                {
                    List<User> users = dbZCommunityContext.Users.ToList();
                    for (int i = 0; i < dbZCommunityContext.Users.Count(); i++)
                    {
                        if (users[i].Email == user.Email && users[i].Password == user.Password)
                        {
                            FormsAuthentication.SetAuthCookie(users[i].Email, true);
                            Session["userId"] =users[i].Id;
                            Session["userName"] =users[i].Name;
                            return Redirect("/Home/Index");
                        }
                    }
                    ViewBag.Error = "Такого пользователя не существует!";
                    return View();
                }
            }
            [HttpGet]
            [Authorize]
            public RedirectResult SignOut()
            {
                FormsAuthentication.SignOut();
                Session["userId"] = null;
                Session["userName"] = null;
                return Redirect("/Account/SignIn");
            }
            [HttpGet]
            public ActionResult SignUp()
            {
                return View();
            }
            [HttpPost]
            public ActionResult SignUp(User user, String passwordConfirm)
            {
                List<User> users = dbZCommunityContext.Users.ToList();

                if (users.Find(u => u.Email == user.Email) != null)
                {
                    ViewBag.Error = "Пользователь с данным email уже существует!";
                    return View();
                }
                else if(user.Name == null)
                {
                    ViewBag.Error = "Введите имя!";
                    return View();
                }
                else if (user.Password == null)
                {
                    ViewBag.Error = "Введите пароль!";
                    return View();
                }
                else if (user.Password != passwordConfirm)
                {
                    ViewBag.Error = "Пароли не совпадают!";
                    return View();
                }
                else if (user.Email == null)
                {
                    ViewBag.Error = "Введите электронную почту!";
                    return View();
                }
                else
                {
                   user.DateCreated = DateTime.Now;
                    ViewBag.Error = "-1";
                     dbZCommunityContext.Users.Add(user);
                    dbZCommunityContext.SaveChanges();
                    FormsAuthentication.SetAuthCookie(user.Email, true);
                    Session["userId"] = user.Id;
                    Session["userName"] = user.Name;
                    return Redirect("/Home/Index");
                }

            }
            [HttpGet]
            public RedirectResult Home()
            {
                return Redirect("/Home/Index");
            }
            [HttpGet]
            public ActionResult EditProfile()
            {
                return View();

            }

            [HttpPost]
            public ActionResult EditProfile(User user, string passwordConfirm)
            {

                List<User> users = dbZCommunityContext.Users.ToList();

                if (users.Find(u => u.Email == user.Email) != null && user.Email != HttpContext.User.Identity.Name)
                {
                    ViewBag.Error = "Пользователь с данным email уже существует!";
                    return View();
                }
                else if (user.Name == null)
                {
                    ViewBag.Error = "Введите имя!";
                    return View();
                }
                else if (user.Password == null)
                {
                    ViewBag.Error = "Введите пароль!";
                    return View();
                }
                else if (user.Password != passwordConfirm)
                {
                    ViewBag.Error = "Пароли не совпадают!";
                    return View();
                }
                else if (user.Email == null)
                {
                    ViewBag.Error = "Введите электронную почту!";
                    return View();
                }
                else
                {
                    user.DateCreated = DateTime.Now;
                    ViewBag.Error = "-1";
                    dbZCommunityContext.Entry(user).State = EntityState.Modified;
                    dbZCommunityContext.SaveChanges();

                    FormsAuthentication.SetAuthCookie(user.Email, true);
                    Session["userId"] = user.Id;
                    Session["userName"] = user.Name;
                    return Redirect("/Home/Index");
                }

            }
            */
    }
}