using System.Data.Entity;
using Domain.Data.Interfaces;
using Domain.Data.Repositories;

namespace Domain.Context
{
    public class EfDbContext : IContext
    {
        private readonly DbContext _db;
        public EfDbContext(DbContext context = null, IUserRepository users = null, IMessageRepository messages = null, IUserProfileRepository profiles = null, IImageRepository images = null, ILikeRepository likes = null)
        {
            _db = context ?? new ContextDatabase();
            Users = users ?? new UserRepository(_db, true);
            Messages = messages ?? new MessageRepository(_db, true);
            Profiles = profiles ?? new UserProfileRepository(_db, true);
            Images = images ?? new ImageRepository(_db, true);
            Likes = likes ?? new LikeRepository(_db, true);
        }

        public ILikeRepository Likes
        {
            get;
            private set;
        }
        public IImageRepository Images
        {
            get;
            private set;
        }

        public IUserRepository Users
        {
            get;
            private set;
        }

        public IMessageRepository Messages
        {
            get;
            private set;
        }

        public IUserProfileRepository Profiles
        {
            get;
            private set;
        }

        public int SaveChanges()
        {
            return _db.SaveChanges();
        }
        public void Dispose()
        {
            if (_db != null)
            {
                try
                {
                    _db.Dispose();
                }
                catch { }
            }
        }
    }
    
}
