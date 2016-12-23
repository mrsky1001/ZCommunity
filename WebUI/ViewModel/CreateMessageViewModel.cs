using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace WebUI.ViewModel
{
    public class CreateMessageViewModel
    {
        [Required]
        [MaxLength(140, ErrorMessage = "Status cannot be more than 140 characters.")]
        public string Status { get; set; }
        private ICollection<string> _pathImg;
        public virtual ICollection<string> PathImg
        {
            get { return _pathImg ?? (_pathImg = new Collection<string>()); }
            set { _pathImg = value; }
        }
    }
}