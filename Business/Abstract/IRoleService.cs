using Core.Entities.Concrete;
using Core.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IRoleService

    {
        Task<IResult> CreateRoleAsync(string role);
        Task<IResult> UpdateRoleAsync(string Id,string role);
        IResult DeleteRole(string Id);
    }
}
