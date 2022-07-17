using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class WritingValidator :AbstractValidator<Writing>
    {
        public WritingValidator()
        {
            RuleFor(p => p.WritingTitle).NotEmpty().WithMessage("Yazının başlığını boş geçemezsiniz!");
            RuleFor(p => p.WritingText).NotEmpty().WithMessage("Yazı metnini boş geçemezsiniz!");
            RuleFor(p => p.TitleID).NotEmpty().WithMessage("Yazı başlığını boş geçemezsiniz!");
            RuleFor(p => p.SubtitleID).NotEmpty().WithMessage("Yazı alt başlığını boş geçemezsiniz!");
        }
    }
}
