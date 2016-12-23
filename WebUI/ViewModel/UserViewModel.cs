using System.Collections.Generic;
using Domain.Models;

namespace WebUI.ViewModel
{
    public class UserViewModel
    {
        public User User { get; set; }
        public IEnumerable<Message> Messages { get; set; }
    }
}