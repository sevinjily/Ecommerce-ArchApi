using Entities.Concrete;
using Entities.DTOs.CategoryDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICategoryService
    {
        Task AddCategoryAsyncByLanguage(AddCategoryDTO category);
        Task UpdateCategoryAsyncByLanguage(UpdateCategoryDTO category);
        GetCategoryDTO GetCategoryById(Guid id,string langCode);
    }
}
