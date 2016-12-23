using System.Web.Mvc;
using System.Web.Routing;

namespace WebUI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "ProfileDefault",
                url: "Profile/{action}",
                defaults: new { controller = "Profile", action = "Index" }
            );
   
           
            routes.MapRoute(
                     name: "Account",
                     url: "Account/{action}",
                     defaults: new { controller = "Account"}
                 );
            routes.MapRoute(
                name: "Create",
                url: "Create",
                defaults: new { controller = "Comment", action = "AddMessage" }
            );

            routes.MapRoute(
                name: "Followers",
                url: "Followers",
                defaults: new { controller = "Follow", action = "Followers" }
            );

            routes.MapRoute(
                name: "Following",
                url: "Following",
                defaults: new { controller = "Follow", action = "Following" }
            );
            routes.MapRoute(
               name: "Like",
               url: "Comment",
               defaults: new { controller = "Comment", action = "Like" }
           );

            routes.MapRoute(
                name: "Dislike",
                url: "Comment",
                defaults: new { controller = "Comment", action = "Dislike" }
            );
            routes.MapRoute(
                name: "Follow",
                url: "Follow/{action}",
                defaults: new { controller = "Follow" }
            );

            routes.MapRoute(
                name: "Unfollow",
                url: "Unfollow",
                defaults: new { controller = "Follow", action = "Unfollow" }
            );

            routes.MapRoute(
                name: "Profiles",
                url: "Profiles",
                defaults: new { controller = "Follow", action = "Profiles" }
            );

            routes.MapRoute(
                name: "UserDefault",
                url: "{username}/{action}",
                defaults: new { controller = "User", action = "Index" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
