using Entities.DTOs.AuthDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.FluentValidation.AuthValidations
{
    public class LoginValidation:AbstractValidator<LoginDTO>
    {
        public LoginValidation()
        {
            RuleFor(x => x.Password).NotNull().NotEmpty();
            RuleFor(x => x.UserNameOrEmail).NotNull().NotEmpty();


    }
}
}
