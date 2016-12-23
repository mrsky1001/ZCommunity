using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebUI.ViewModel;

namespace WebUI.Controllers
{
    public class CommentController : MessageControllerBase
    {
        public CommentController() : base() { }

        [HttpGet]
        public ActionResult AddMessage()
        {
            return PartialView("_AddMessage", new CreateMessageViewModel());
        }

        [HttpPost]
        public ActionResult AddMessage(CreateMessageViewModel model, IEnumerable<HttpPostedFileBase> files)
        {
            if (files != null)
            {
                var ff = files as IList<HttpPostedFileBase> ?? files.ToList();
                if (ff.Count != 0 && ff[0] != null)
                {
                    for (int i = 0; i < ff.Count(); i++)
                    {
                        if (ff[i].ContentLength > 0)
                        {
                            string str = "";
                            string fileName = System.IO.Path.GetFileName(ff[i].FileName);
                            str = Server.MapPath("~/Content/resource/" + (int)Session["UserId"] + "/" + fileName);
                            DirectoryInfo dr = new DirectoryInfo(Server.MapPath("~/Content/resource/" + (int)Session["UserId"]));
                            dr.Create();
                            ff[i].SaveAs(str);

                            str = @"../../Content/resource/" + (int)Session["UserId"] + @"/" + fileName;
                            str = str.Replace(@"\", "/");
                            model.PathImg.Add(str);
                        }
                    }
                }
            }
            if (model.Status == null)
            {
                model.Status = "#";
            }
            var tw = Messages.Create(Security.UserId, model.Status);
            foreach (var path in model.PathImg)
            {
                Images.Create(path, tw);
            }
            return GoToReferrer();
        }

        [HttpPost]
        public ActionResult Like(int idMessage)
        {//попадает всегда сюда
            var message = Messages.GetBy(idMessage);
            Likes.Create(message);
            return GoToReferrer();
        }
        [HttpPost]
        public ActionResult Dislike(int idMessage)
        {
            var message = Messages.GetBy(idMessage);
            Likes.Delete(message);
            return GoToReferrer();
        }
    }
}