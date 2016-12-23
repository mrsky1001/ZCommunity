using System.Data.Entity;
using Domain.Data.Interfaces;
using Domain.Models;

namespace Domain.Data.Repositories
{
    public class LikeRepository : Repository<Like>, ILikeRepository
    {
        public LikeRepository(DbContext context, bool sharedContext) : base(context, sharedContext)
        {
            
        }
    }
}
