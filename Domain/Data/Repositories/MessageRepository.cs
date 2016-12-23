using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Domain.Data.Interfaces;
using Domain.Models;

namespace Domain.Data.Repositories
{
    public class MessageRepository : Repository<Message>, IMessageRepository
    {
        public MessageRepository(DbContext context, bool sharedContext) : base(context, sharedContext)
        {
            
        }

        public Message GetBy(int id)
        {
            return Find(r => r.Id == id);
        }

        public IEnumerable<Message> GetFor(User user)
        {
            return user.Messages.OrderByDescending(r => r.DateCreated);
        }

        public void AddFor(Message Message, User user)
        {
            user.Messages.Add(Message);

            if (!ShareContext)
            {
                Context.SaveChanges();
            }
        }
    }
}
