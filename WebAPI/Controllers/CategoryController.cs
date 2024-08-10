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
        public IActionResult Create(AddCategoryDTO model)
        {
            _categoryService.AddCategoryAsyncByLanguage(model);
            return Ok();
        }
        [HttpPut("[action]")]
        public async Task<IActionResult> Update([FromBody] UpdateCategoryDTO model)
        {
            await _categoryService.UpdateCategoryAsyncByLanguage(model);
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult Get([FromRoute] Guid Id)
        {
            var langCode = Request.Headers.AcceptLanguage.ToString();
            var result=_categoryService.GetCategoryById(Id,langCode);
            return Ok(result);
        }
    }
}
