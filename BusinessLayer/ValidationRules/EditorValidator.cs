using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class EditorValidator : AbstractValidator<Editor>
    {
        public EditorValidator()
        {
            RuleFor(p => p.EditorName).NotEmpty().WithMessage("Editör adını boş geçemezsiniz!");
            RuleFor(p => p.EditorName).MinimumLength(2).WithMessage("Editör adı minimum 2 karakter olmalıdır!");
            RuleFor(p => p.EditorSurname).NotEmpty().WithMessage("Editör soyadını boş geçemezsiniz!");
            RuleFor(p => p.EditorSurname).MinimumLength(2).WithMessage("Editör soyadı minimum 2 karakter olmalıdır!");
            RuleFor(p => p.EditorUsername).NotEmpty().WithMessage("Editör kullanıcı adı boş geçilemez!");
            RuleFor(p => p.EditorEmail).NotEmpty().WithMessage("Editör e-mail boş geçilemez!");
            RuleFor(p => p.EditorPassword).NotEmpty().WithMessage("Editör şifresi boş geçilemez!");
            RuleFor(p => p.TitleID).NotEmpty().WithMessage("Editörün yetkili olduğu başlık boş geçilemez!");
        }
    }
}
