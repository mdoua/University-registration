using FluentValidation;
using UniversityRegistration.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityRegistration.Validators
{
    internal class StudentVaLidator : AbstractValidator<Student>
    {
        public StudentVaLidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Email).NotEmpty();
            RuleFor(x => x.Id).GreaterThan(0);
        }
    }
}
