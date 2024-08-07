using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs.CategoryDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EFCategoryDAL : EFRepositoryBase<Category, AppDbContext>, ICategoryDAL 
    {
        public async Task AddCategoryAsync(AddCategoryDTO model)
        {
			try
			{
				using var context = new AppDbContext();
				Category category = new()
				{
					CreatedDate = DateTime.Now,

				}
					;
				await context.Categories.AddAsync(category);
				await context.SaveChangesAsync();
				for (int i = 0; i < model.Language.Count; i++)
				{
					CategoryLanguage categoryLanguage = new()
					{
						CategoryName = model.Language[i].CategoryName,
						LangCode = model.Language[i].LangCode,
						CategoryId = category.Id
					};
					await context.CategoryLanguages.AddAsync(categoryLanguage);
				}
				await context.SaveChangesAsync();
			}
			catch (Exception)
			{

				throw;
			}
        }
    }
}
