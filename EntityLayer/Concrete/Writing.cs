using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Writing
    {
        [Key]
        public int WritingID { get; set; }
        [Required]
        public string WritingTitle { get; set; }
        [Required]
        public string WritingText { get; set; }
        [Required]
        public DateTime WritingDate { get; set; }
        [Required]
        public bool ApprovalStatus { get; set; }



        public int TitleID { get; set; }
        public virtual Title Title { get; set; }

        public int SubtitleID { get; set; }
        public virtual Subtitle Subtitle { get; set; }

        public int? MemberID { get; set; }
        public virtual Member Member { get; set; }

    }
}
