using System.Collections.Generic;
using Domain.Models;

namespace Domain.Data.Interfaces
{
    public interface IMessageRepository : IRepository<Message>
    {
        Message GetBy(int id);
        IEnumerable<Message> GetFor(User user);
        void AddFor(Message Message, User user);
    }
}
