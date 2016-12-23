using System.Data.Entity;
using Domain.Data.Interfaces;
using Domain.Models;

namespace Domain.Data.Repositories
{
    public class ImageRepository : Repository<Image>, IImageRepository
    {
        public ImageRepository(DbContext context, bool sharedContext) : base(context, sharedContext)
        {
            
        }
    }
}
