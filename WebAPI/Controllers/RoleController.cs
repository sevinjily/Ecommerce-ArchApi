using Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }
        [HttpPost]
        public async Task<IActionResult> CreateRole([FromBody]string roleName)
        {
            var result=await _roleService.CreateRoleAsync(roleName);
            if(result.Success)
            return Ok(result);
            return BadRequest(result);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateRole( [FromRoute]string Id, [FromBody]string roleName)
        {
            var result=await _roleService.UpdateRoleAsync(Id, roleName);

            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpDelete]
        public IActionResult DeleteRole([FromRoute]string Id)
        {
            var result=_roleService.DeleteRole(Id);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }
    }
}
