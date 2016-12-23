using System.Web.Mvc;
using Domain.Context;
using Domain.Data.Interfaces;
using Domain.Models;
using WebUI.Services.Interfaces;
using WebUI.Services.Services;

namespace WebUI.Controllers
{
    public class MessageControllerBase : Controller
    {
        protected IContext DataContext;
        public User CurrentUser { get; private set; }
        public IMessageService Messages { get; private set; }
        public IImageService Images { get; private set; }
        public IUserService Users { get; private set; }
        public ISecurityService Security { get; private set; }
        public IUserProfileService Profiles { get; private set; }
        public ILikeService Likes { get; private set; }

        public MessageControllerBase()
        {
            DataContext = new EfDbContext();
            Users = new UserService(DataContext);
            Images = new ImageService(DataContext);
            Messages = new MessageService(DataContext);
            Likes = new LikeService(DataContext);
            Security = new SecurityService(Users);
            CurrentUser = Security.GetCurrentUser();
            Profiles = new UserProfileService(DataContext);
        }

        protected override void Dispose(bool disposing)
        {
            if (DataContext != null)
            {
                DataContext.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult GoToReferrer()
        {
            if (Request.UrlReferrer != null)
            {
                return Redirect(Request.UrlReferrer.AbsoluteUri);
            }

            return RedirectToAction("Index", "Home");
        }


    }
}