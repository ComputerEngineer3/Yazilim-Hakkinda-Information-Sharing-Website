using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class MemberValidator : AbstractValidator<Member>
    {
        public MemberValidator()
        {
            RuleFor(p => p.MemberName).NotEmpty().WithMessage("Adı boş geçemezsiniz!");
            RuleFor(p => p.MemberName).MinimumLength(2).WithMessage("Ad minimum 2 karakter olmalıdır!");
            RuleFor(p => p.MemberSurname).NotEmpty().WithMessage("Soyadı boş geçemezsiniz!");
            RuleFor(p => p.MemberSurname).MinimumLength(2).WithMessage("Soyad minimum 2 karakter olmalıdır!");
            RuleFor(p => p.MemberUsername).NotEmpty().WithMessage("Kullanıcı adını boş geçemezsiniz!");
            RuleFor(p => p.MemberUsername).MinimumLength(6).WithMessage("Kullanıcı adı minimum 6 karakter olmalıdır!");
            RuleFor(p => p.MemberJob).NotEmpty().WithMessage("Mesleği boş geçemezsiniz!");
            RuleFor(p => p.MemberJob).NotEmpty().WithMessage("Meslek minimum 3 karakter olmalıdır!");
            RuleFor(p => p.MemberAbout).NotEmpty().WithMessage("Hakkında kısmını boş geçemezsiniz!");
            RuleFor(p => p.MemberEmail).NotEmpty().WithMessage("E-mail adresini boş geçemezsiniz!");
            RuleFor(p => p.MemberPassword).NotEmpty().WithMessage("Şifreyi boş geçemezsiniz!");
        }
    }
}
