using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class ContactMessageValidator :AbstractValidator<ContactMessage>
    {
        public ContactMessageValidator()
        {
            RuleFor(p => p.SenderName).NotEmpty().WithMessage("Adı boş geçemezsiniz!");
            RuleFor(p => p.SenderSurname).NotEmpty().WithMessage("Soyadı boş geçemezsiniz!");
            RuleFor(p => p.SenderEmail).NotEmpty().WithMessage("Email adresini boş geçemezsiniz!");
            RuleFor(p => p.MessageSubject).NotEmpty().WithMessage("Mesaj konusunu boş geçemezsiniz!");
            RuleFor(p => p.MessageText).NotEmpty().WithMessage("Mesaj metnini boş geçemezsiniz!");
        }
    }
}
