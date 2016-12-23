using System.Collections.Generic;
using Domain.Models;

namespace WebUI.ViewModel
{
    public class BuddiesViewModel
    {
        public User User { get; set; }
        public IEnumerable<User> Buddies { get; set; }
    }
}