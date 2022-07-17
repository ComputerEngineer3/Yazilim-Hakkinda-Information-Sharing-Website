using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Title
    {
        [Key]
        public int TitleID { get; set; }
        [Required]
        public string TitleName { get; set; }
        [Required]
        public bool TitleStatus { get; set; }


        public ICollection<Subtitle> Subtitles { get; set; }
        public ICollection<Writing> Writings { get; set; }
        public ICollection<Editor> Editors { get; set; }
    }
}
