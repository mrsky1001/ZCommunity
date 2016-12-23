using System;
using System.IO;
using System.Web;
using System.Web.Mvc;
using WebUI.ViewModel;

namespace WebUI.Controllers
{
    public class ProfileController : MessageControllerBase
    {
        public ActionResult Index()
        {
            if (!Security.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }

            var profile = Profiles.GetBy(CurrentUser.UserProfileId);

            return View(new EditProfileViewModel()
            {
                Bio = profile.Bio,
                Email = profile.Email,
                Id = profile.Id,
                Name = profile.Name,
                Website = profile.WebsiteUrl,
                PathAvatar = profile.PathAvatar
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EditProfileViewModel model, HttpPostedFileBase files)
        {
            if (!Security.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            if (files != null)
            {
                string str = "";
                string fileName = System.IO.Path.GetFileName(files.FileName);
                str = Server.MapPath("~/Content/resource/" + (int)Session["UserId"] + "/" + fileName);
                DirectoryInfo dr = new DirectoryInfo(Server.MapPath("~/Content/resource/" + (int)Session["UserId"]));
                dr.Create();
                files.SaveAs(str);

                str = @"../../Content/resource/" + (int)Session["UserId"] + @"/" + fileName;
                str = str.Replace(@"\", "/");
                model.PathAvatar = str;
            }
          
            if (!ModelState.IsValid || files == null)
            {
                return View("Index", model);
            }
              Profiles.Update(model);
           

            return RedirectToAction("Index", "Home");

            throw new NotImplementedException();
        }

    }
}