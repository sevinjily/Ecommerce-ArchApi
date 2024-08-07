using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs.CategoryDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
         //DAL-Data Access Layer
namespace DataAccess.Abstract
{
    public interface ICategoryDAL:IRepositoryBase<Category>
    {
        Task AddCategoryAsync(AddCategoryDTO model);
    }
}
