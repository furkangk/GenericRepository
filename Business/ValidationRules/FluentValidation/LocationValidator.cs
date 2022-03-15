using Entities.Concreate;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class LocationValidator:AbstractValidator<Location>
    {
        public LocationValidator()
        {
            RuleFor(l => l.Title).NotEmpty();
            RuleFor(l => l.Shelf).NotEmpty();
            RuleFor(l => l.Floor).NotEmpty();
            RuleFor(l => l.Block).NotEmpty();
        }
    }
}
