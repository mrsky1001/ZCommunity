using System;
using System.Collections.Generic;
using Domain.Models;

namespace WebUI.Services.Interfaces
{
    public interface IMessageService
    {
        
        Message GetBy(int id);
        Message Create(int userId, string status,  DateTime? created = null);
        Message Create(User user, string status,   DateTime? created = null);
        Message Update(int id, int userId, string status,   DateTime? created = null);
        IEnumerable<Message> GetTimelineFor(int userId);
    }
}