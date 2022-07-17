using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class EditorialApplicationValidator :AbstractValidator<EditorialApplication>
    {
        public EditorialApplicationValidator()
        {
            RuleFor(p => p.NameSurname).NotEmpty().WithMessage("Ad-Soyad boş geçilemez!");
        }
    }
}
