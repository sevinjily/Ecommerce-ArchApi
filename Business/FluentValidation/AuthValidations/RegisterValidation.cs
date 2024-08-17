using Entities.DTOs.AuthDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.FluentValidation.AuthValidations
{
    public class RegisterValidation:AbstractValidator<RegisterDTO>
    {
        public RegisterValidation()
        {
            RuleFor(x=>x.Email).NotEmpty().WithName("E-poçt").NotNull().EmailAddress();
            RuleFor(x=>x.FirstName).NotEmpty().NotNull().WithName("Ad");
            RuleFor(x => x.LastName).NotEmpty().NotNull().WithName("Soyad");
            RuleFor(x => x.Password).NotNull().NotEmpty().Equal(x=>x.ConfirmPassword);  
            RuleFor(x=>x.ConfirmPassword).NotNull().NotEmpty().Equal(x=>x.Password);
        }
    }
}
