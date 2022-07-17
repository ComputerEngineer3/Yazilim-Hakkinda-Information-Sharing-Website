using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Member
    {
        [Key]
        public int MemberID { get; set; }
        [Required]
        public string MemberName { get; set; }
        [Required]
        public string MemberSurname { get; set; }
        [Required]
        public string MemberUsername { get; set; }
        [Required]
        public string MemberJob { get; set; }
        [Required]
        public string MemberAbout { get; set; }
        [Required]
        public string MemberEmail { get; set; }
        [Required]
        public string MemberPassword { get; set; }


        public ICollection<Writing> Writings { get; set; }
    }
}
