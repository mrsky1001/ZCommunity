using System;

namespace Domain.Data.Interfaces
{
    public interface IContext : IDisposable
    {
        IUserRepository Users { get; }
        IMessageRepository Messages { get; }
        IUserProfileRepository Profiles { get; }
        IImageRepository Images { get; }
        ILikeRepository Likes { get; }

        int SaveChanges();
    }
}
