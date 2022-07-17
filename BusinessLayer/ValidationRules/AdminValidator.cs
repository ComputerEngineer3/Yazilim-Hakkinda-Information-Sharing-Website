using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class AdminValidator :AbstractValidator<Admin>
    {
        public AdminValidator()
        {
            RuleFor(p => p.AdminName).NotEmpty().WithMessage("Adminin ismini boş geçemezsiniz!");
        }
    }
}
