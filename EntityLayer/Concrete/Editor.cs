using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Editor
    {
        [Key]
        public int EditorID { get; set; }
        [Required]
        public string EditorName { get; set; }
        [Required]
        public string EditorSurname { get; set; }
        [Required]
        public string EditorUsername { get; set; }
        [Required]
        public string EditorEmail { get; set; }
        [Required]
        public string EditorPassword { get; set; }


        public int TitleID { get; set; }
        public virtual Title Title { get; set; }
    }
}
