using Business.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete.ErrorResults;
using Core.Utilities.Results.Concrete.SuccessResults;
using Entities.DTOs.CategoryDTOs;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class RoleManager : IRoleService
    {
        private readonly RoleManager<AppRole> _roleManager;

        public RoleManager(RoleManager<AppRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task<IResult> CreateRoleAsync(string role)
        {
            AppRole appRole = new()
            {
                Id = Guid.NewGuid().ToString(),
                Name = role,
            };
           await _roleManager.CreateAsync(appRole);
            return new SuccessResult(System.Net.HttpStatusCode.OK);
        }

        public IResult DeleteRole(string Id)
        {
           var findRole=_roleManager.Roles.FirstOrDefault(x => x.Id == Id);
            if (findRole != null)
            {

             _roleManager.DeleteAsync(findRole);
                return new SuccessResult(message:"Ugurla silindi :)",System.Net.HttpStatusCode.OK);
            }
            
            return new ErrorResult(System.Net.HttpStatusCode.BadRequest);
        }

        public async Task<IResult> UpdateRoleAsync(string Id,string role)
        {
            var findRole=_roleManager.Roles.FirstOrDefault(x => x.Id == Id);
            if (findRole == null)
            
                return new ErrorResult(System.Net.HttpStatusCode.NotFound);

            findRole.Name = role;
           var result= await _roleManager.UpdateAsync(findRole);
          if(result.Succeeded)
            return new SuccessResult(System.Net.HttpStatusCode.OK);
          return new ErrorResult(System.Net.HttpStatusCode.BadRequest);
           
            

           

        }
    }
}
