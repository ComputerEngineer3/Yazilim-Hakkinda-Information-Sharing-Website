using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class ContactMessage
    {
        [Key]
        public int ContactMessageID { get; set; }
        [Required]
        public string SenderName { get; set; }
        [Required]
        public string SenderSurname { get; set; }
        [Required]
        public string SenderEmail { get; set; }
        [Required]
        public string MessageSubject { get; set; }
        [Required]
        public string MessageText { get; set; }
        [Required]
        public DateTime ContactMessageDate { get; set; }
        [Required]
        public bool ContactMessageStatus { get; set; }
    }
}
