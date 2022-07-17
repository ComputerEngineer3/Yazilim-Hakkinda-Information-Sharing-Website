using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Admin
    {
        [Key]
        public int AdminID { get; set; }
        [Required]
        public string AdminName { get; set; }
        [Required]
        public string AdminSurname { get; set; }
        [Required]
        public string AdminUsername { get; set; }
        [Required]
        public string AdminEmail { get; set; }
        [Required]
        public string AdminPassword { get; set; }
    }
}
