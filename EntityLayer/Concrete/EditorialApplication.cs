using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class EditorialApplication
    {
        [Key]
        public int EditorialApplicationID { get; set; }
        [Required]
        public string NameSurname { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string GraduationStatus { get; set; }
        [Required]
        public string RelatedTitle { get; set; }
        [Required]
        public string RelatedTitleExperiences { get; set; }
        [Required]
        public int WeeklyMinStudyTime { get; set; }
        [Required]
        public string ShortResume { get; set; }
    }
}
