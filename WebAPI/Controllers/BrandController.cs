using Business.Abstract;
using Core.Utilities.Results.Concrete.SuccessResults;
using Entities.DTOs.BrandDTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly IBrandService _brandService;

        public BrandController(IBrandService brandService)
        {
            _brandService = brandService;
        }
        [HttpPost]
        public IActionResult Create(AddBrandDTO model)
        {
            var result=_brandService.Create(model);
           return Ok(result);
        }
    }
}
