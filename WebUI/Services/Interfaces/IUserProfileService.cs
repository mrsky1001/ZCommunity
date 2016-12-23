using Domain.Models;
using WebUI.ViewModel;

namespace WebUI.Services.Interfaces
{
    public interface IUserProfileService
    {
        UserProfile GetBy(int id);
        void Update(EditProfileViewModel model);
    }
}