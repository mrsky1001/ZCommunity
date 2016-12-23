using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    public class Message
    {
        public int Id { get; set; }
        public int AuthorId { get; set; }

        [ForeignKey("AuthorId")]
        public virtual User Author { get; set; }

        public string Status { get; set; }
        public DateTime DateCreated { get; set; }

        private ICollection<Image> _images;
        public virtual ICollection<Image> Images
        {
            get { return _images ?? (_images = new Collection<Image>()); }
            set { _images = value; }
        }

        private ICollection<Like> _likes;
        public virtual ICollection<Like> Likes
        {
            get { return _likes ?? (_likes = new Collection<Like>()); }
            set { _likes = value; }
        }
    }
}