using Domain.Data.Interfaces;
using Domain.Models;
using WebUI.Services.Interfaces;

namespace WebUI.Services.Services
{
    public class LikeService : ILikeService
    {
        private readonly IContext _context;
        private readonly ILikeRepository _likes;

        public LikeService(IContext context)
        {
            _context = context;
            _likes = context.Likes;
        }

        public Like GetBy(int id)
        {
            return _likes.Find(p => p.Id == id);
        }

        public void Create(Message message)
        {
            var like = new Like()
            {
                IsLike = true,
                MessageId = message.Id,
                Message = message

            };

            _likes.Create(like);

            _context.SaveChanges();
        }
        public void Delete(Message message)
        {
            var like = new Like()
            {
                IsLike = false,
                MessageId = message.Id,
                Message = message

            };

            _likes.Delete(like);

            _context.SaveChanges();
        }
    }
}