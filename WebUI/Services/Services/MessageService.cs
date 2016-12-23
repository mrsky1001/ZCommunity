using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Data.Interfaces;
using Domain.Models;
using WebUI.Services.Interfaces;

namespace WebUI.Services.Services
{
    public class MessageService : IMessageService
    {
        private readonly IContext _context;
        private readonly IMessageRepository _messages;

        public MessageService(IContext context)
        {
            _context = context;
            _messages = context.Messages;
        }

        public Message GetBy(int id)
        {
            return _messages.GetBy(id);
        }

        public Message Create(User user, string status, DateTime? created = null)
        {
            return Create(user.Id, status, created);
        }

        public Message Create(int userId, string status, DateTime? created = null)
        {
            var message = new Message()
            {

                AuthorId = userId,
                Status = status,
                DateCreated = created.HasValue ? created.Value : DateTime.Now

            };

            _messages.Create(message);

            _context.SaveChanges();

            return message;
        }
        
        public Message Update(int id, int userId, string status, DateTime? created = null)
        {
            var message = new Message()
            {
                Id = id,
                AuthorId = userId,
                Status = status,
                DateCreated = created.HasValue ? created.Value : DateTime.Now

            };

            _messages.Update(message);

            _context.SaveChanges();

            return message;
        }
        public IEnumerable<Message> GetTimelineFor(int userId)
        {
            return _messages.FindAll(r => r.Author.Followers.Any(f => f.Id == userId) || r.AuthorId == userId)
                .OrderByDescending(r => r.DateCreated);
        }
    }
}