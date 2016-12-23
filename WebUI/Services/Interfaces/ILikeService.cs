using Domain.Models;

namespace WebUI.Services.Interfaces
{
    public interface ILikeService
    {
        Like GetBy(int id);
        void Create(Message message);
        void Delete(Message message);
    }
}