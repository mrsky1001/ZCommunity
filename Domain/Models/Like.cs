using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    public class Like
    {
        public int Id { get; set; }
        public bool IsLike { get; set; }

        public int MessageId { get; set; }
        [ForeignKey("MessageId")]
        public virtual Message Message { get; set; }
    }
}
