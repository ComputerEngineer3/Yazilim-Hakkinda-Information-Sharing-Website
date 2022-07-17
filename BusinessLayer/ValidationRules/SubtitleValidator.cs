using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class SubtitleValidator :AbstractValidator<Subtitle>
    {
        public SubtitleValidator()
        {
            RuleFor(p => p.SubtitleName).NotEmpty().WithMessage("Alt başlık ismini boş geçemezsiniz!");
        }
    }
}
