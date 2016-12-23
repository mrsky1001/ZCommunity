using Domain.Data.Interfaces;
using Domain.Models;
using WebUI.Services.Interfaces;

namespace WebUI.Services.Services
{
    public class ImageService : IImageService
    {
        private readonly IContext _context;
        private readonly IImageRepository _images;

        public ImageService(IContext context)
        {
            _context = context;
            _images = context.Images;
        }

        public Image GetBy(int id)
        {
            return _images.Find(p => p.Id == id);
        }

        public void Create(string pathImg, Message message)
        {
            var image = new Image()
            {
                Path = pathImg,
                MessageId = message.Id,
                Message = message

            };

            _images.Create(image);

            _context.SaveChanges();
        }
    }
}