using Business.Abstract;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using Core.Utilities.Results.Concrete.ErrorResults;
using Core.Utilities.Results.Concrete.SuccessResults;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs.CategoryDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDAL _categoryDAL;

        public CategoryManager(ICategoryDAL categoryDAL)
        {
            _categoryDAL = categoryDAL;
        }

        public async Task AddCategoryAsyncByLanguage(AddCategoryDTO model)
        {
           await _categoryDAL.AddCategoryAsync(model);
        }

        public IResult DeleteCategory(Guid id)
        {
            var findCategory=_categoryDAL.Get(x=>x.Id == id);
            if (findCategory == null)
            return new ErrorResult(System.Net.HttpStatusCode.NotFound);


            _categoryDAL.Delete(findCategory);
            return new SuccessResult("Ugurla silindi",System.Net.HttpStatusCode.NotFound);
        }

        public IDataResult<GetCategoryDTO> GetCategoryById(Guid id, string langCode)
        {
           var result=_categoryDAL.GetCategoryById(id, langCode);
            if (result==null)
            {
                return new ErrorDataResult<GetCategoryDTO>(System.Net.HttpStatusCode.BadRequest);
            }
            return new SuccessDataResult<GetCategoryDTO>(data:result,System.Net.HttpStatusCode.OK);
        }

        public async Task UpdateCategoryAsyncByLanguage(UpdateCategoryDTO model)
        {
            await _categoryDAL.UpdateCategoryAsync(model);
        }
    }
}
