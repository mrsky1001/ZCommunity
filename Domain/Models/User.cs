using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    public class User
    {

        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime DateCreated { get; set; }

        //вот в этом все дело
        public int UserProfileId { get; set; }

        [ForeignKey("UserProfileId")]
        public virtual UserProfile Profile { get; set; }

        private ICollection<Message> _messages;
        public virtual ICollection<Message> Messages
        {
            get { return _messages ?? (_messages = new Collection<Message>()); }
            set { _messages = value; }
        }

        private ICollection<User> _followings;
        public virtual ICollection<User> Followings
        {
            get { return _followings ?? (_followings = new Collection<User>()); }
            set { _followings = value; }
        }

        private ICollection<User> _followers;
        public virtual ICollection<User> Followers
        {
            get { return _followers ?? (_followers = new Collection<User>()); }
            set { _followers = value; }
        }
    }
}