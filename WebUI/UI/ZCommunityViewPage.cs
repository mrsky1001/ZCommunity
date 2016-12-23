using System.Web.Mvc;
using Domain.Context;
using Domain.Data.Interfaces;
using Domain.Models;
using WebUI.Services.Interfaces;
using WebUI.Services.Services;

namespace WebUI.UI
{
    public abstract class ZCommunityViewPage : WebViewPage
    {
        protected IContext DataContext;
        public User CurrentUser { get; private set; }
        public IUserService Users { get; private set; }
        public ISecurityService Security { get; private set; }
        public IMessageService Messages { get; }
        public ILikeService Likes { get; }

        public ZCommunityViewPage()
        {
            DataContext = new EfDbContext();
            Users = new UserService(DataContext);
            Security = new SecurityService(Users);
            CurrentUser = Security.GetCurrentUser();
            Messages = new MessageService(DataContext);
            Likes = new LikeService(DataContext);
        }
    }

    public abstract class ZCommunityViewPage<TModel> : WebViewPage<TModel>
    {
        protected IContext DataContext;
        public User CurrentUser { get; private set; }
        public IUserService Users { get; private set; }
        public ISecurityService Security { get; private set; }
        public IMessageService Messages { get; }
        public ILikeService Likes { get; }

        public ZCommunityViewPage()
        {
            DataContext = new EfDbContext();
            Users = new UserService(DataContext);
            Security = new SecurityService(Users);
            CurrentUser = Security.GetCurrentUser();
            Messages = new MessageService(DataContext);
            Likes = new LikeService(DataContext);
        }
    }
}