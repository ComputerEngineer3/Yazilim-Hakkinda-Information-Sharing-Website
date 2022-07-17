using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class TitleValidator :AbstractValidator<Title>
    {
        public TitleValidator()
        {
            RuleFor(p => p.TitleName).NotEmpty().WithMessage("Başlık ismini boş geçemezsiniz!");
        }
    }
}
