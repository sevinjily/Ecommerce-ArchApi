using Business.Abstract;
using Entities.Concrete;
using Entities.DTOs.CategoryDTOs;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }


        [HttpPost]
        public async  Task<IActionResult> Create(AddCategoryDTO model)
        {
           await _categoryService.AddCategoryAsyncByLanguage(model);
            return Ok();
        }
        [HttpPut("[action]")]
        public async Task<IActionResult> Update([FromBody] UpdateCategoryDTO model)
        {
            await _categoryService.UpdateCategoryAsyncByLanguage(model);
            return Ok();
        }
        [HttpGet("{Id}")]
        public IActionResult Get([FromRoute] Guid Id)
        {
            var langCode = Request.Headers.AcceptLanguage.ToString();
            var result=_categoryService.GetCategoryById(Id,langCode);
            if(result.Success)
            
            return Ok(result);
         return BadRequest(result);
             
            
        }
        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid Id)
        {
         var result= _categoryService.DeleteCategory(Id);
            if(result.Success)
            return Ok(result);
            return NotFound(result);

        }
    }
}
