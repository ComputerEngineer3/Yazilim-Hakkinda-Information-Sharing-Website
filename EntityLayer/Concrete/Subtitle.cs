using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Subtitle
    {
        [Key]
        public int SubtitleID { get; set; }
        [Required]
        public string SubtitleName { get; set; }
        [Required]
        public bool SubtitleStatus { get; set; }


        public int? TitleID { get; set; }
        public virtual Title Title { get; set; }


        public ICollection<Writing> Writings { get; set; }
    }
}
