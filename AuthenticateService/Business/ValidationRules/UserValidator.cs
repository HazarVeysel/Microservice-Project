using Business.Constans;
using Core.Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(p => p.Name).NotEmpty().WithMessage("Kullanıcı adı boş olamaz");
            RuleFor(p => p.Name).MinimumLength(3).WithMessage(Messages.UserNameCharacter);
            RuleFor(p => p.Email).NotEmpty().WithMessage("Kullanıcı mail adresi boş olamaz");
            RuleFor(p => p.Email).EmailAddress().WithMessage("Geçerli bir mail adresi giriniz.");
            

        }
    }
}
