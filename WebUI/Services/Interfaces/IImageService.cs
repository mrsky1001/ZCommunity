using Domain.Models;

namespace WebUI.Services.Interfaces
{
    public interface IImageService
    {
        Image GetBy(int id);
        void Create(string pathImg, Message message);
    }
}