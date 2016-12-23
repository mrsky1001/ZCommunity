﻿using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    public class Image
    {
        public int Id { get; set; }
        public string Path { get; set; }

        public int MessageId { get; set; }

        [ForeignKey("MessageId")]
        public virtual Message Message { get; set; }
    }
}
