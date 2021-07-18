using FluentValidation;
using MvcBootcamp.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcBootcamp.BLL.ValidationRules.FluentValidation
{
    public class MessageValidator:AbstractValidator<Message>
    {
        public MessageValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Adınızı giriniz.");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Soyadınızı giriniz.");
            RuleFor(x => x.EMail).EmailAddress().WithMessage("Geçerli bir mail adresi giriniz.").When(x => !string.IsNullOrEmpty(x.EMail));
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konu giriniz.");
            RuleFor(x => x.Subject).MaximumLength(150).WithMessage("max. 150 karakter içermeli.");

            RuleFor(x => x.Text).NotEmpty().WithMessage("Mesajınızı giriniz.");
            RuleFor(x => x.Text).MaximumLength(500).WithMessage("Mesaj max. 500 karakter içermeli.");

        }
    }
}
