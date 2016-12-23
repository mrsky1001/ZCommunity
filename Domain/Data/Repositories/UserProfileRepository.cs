using System.Data.Entity;
using Domain.Data.Interfaces;
using Domain.Models;

namespace Domain.Data.Repositories
{
    public class UserProfileRepository : Repository<UserProfile>, IUserProfileRepository
    {
        public UserProfileRepository(DbContext context, bool sharedContext) : base(context, sharedContext)
        {
            
        }
    }
}
