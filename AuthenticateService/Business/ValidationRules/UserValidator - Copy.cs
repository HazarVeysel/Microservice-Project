using Business.Constans;
using Core.Entities.Concrate;
using Core.Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules
{
    public class EntryTypeValidator : AbstractValidator<EntryType>
    {
        public EntryTypeValidator()
        {
            RuleFor(p => p.Name).NotEmpty().WithMessage("EntryType adı boş olamaz");
            RuleFor(p => p.Name).MinimumLength(3).WithMessage("EntryType adı 3 karakterden fazla olmalıdır");
            
            

        }
    }
}
