using Business.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete.ErrorResults;
using Core.Utilities.Results.Concrete.SuccessResults;
using Entities.Concrete;
using Entities.DTOs.AuthDTOs;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private readonly UserManager<AppUser> _userManager;

        public AuthManager(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public Task<IResult> LoginAsync(LoginDTO loginDTO)
        {
            throw new NotImplementedException();
        }

        public async Task<IResult> RegisterAsync(RegisterDTO registerDTO)
        {
            var checkEmail=await _userManager.FindByEmailAsync(registerDTO.Email);
            var checkUserName = await _userManager.FindByNameAsync(registerDTO.UserName);

            if (checkEmail != null)
            {
                return new ErrorResult("This email is already exist", System.Net.HttpStatusCode.BadRequest);
            }
            if (checkUserName != null)
            {
                return new ErrorResult("This username is already exist", System.Net.HttpStatusCode.BadRequest);
            }
            User newUser = new()
            {
                FirstName = registerDTO.FirstName,
                LastName = registerDTO.LastName,
                Email = registerDTO.Email,
                UserName = registerDTO.UserName,
            };
            var result=await _userManager.CreateAsync(newUser,registerDTO.Password);
            if (result.Succeeded)
                return new SuccessResult(System.Net.HttpStatusCode.Created);
            else
            {
                string response = string.Empty;
                foreach (var error in result.Errors)
                {
                    response += error.Description + ".";
                }
                return new ErrorResult(response, System.Net.HttpStatusCode.BadRequest);
            }
        }
    }
}
