using ArtBloger.Data.Abstract;
using ArtBloger.Entities.Concrete;
using ArtBloger.Entities.Dtos;
using ArtBloger.Services.Abstract;
using ArtBloger.Shared.Utilities.Results.Abstract;
using ArtBloger.Shared.Utilities.Results.ComplexTypes;
using ArtBloger.Shared.Utilities.Results.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtBloger.Services.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IResult> Add(CategoryAddDto categoryAddDto)
        {
            var category = new Category
            {
                Name = categoryAddDto.Name
            };
            if(category != null)
            {
                await _unitOfWork.Categories.AddAsync(category).ContinueWith(t => _unitOfWork.SaveAsync());//task bitmeden diğerini yapar hız sağlar.
                
                return new Result(ResultStatus.Success, $"Category :{category.Name} added successfully");
            }
            return new Result(ResultStatus.Error, "Category not added");
        }
        
        public async Task<IResult> Delete(int id)
        {
            var category = await _unitOfWork.Categories.GetAsync(u => u.Id == id);
            if (category != null)
            {
                await _unitOfWork.Categories.DeleteAsync(category).ContinueWith(t => _unitOfWork.SaveAsync());
                return new Result(ResultStatus.Success, $"Category :{category.Name} deleted successfully");
            }
            return new Result(ResultStatus.Error, "Category not deleted");
        }
        
        public async Task<IDataResult<Category>> Get(int id)
        {
           var data = await _unitOfWork.Categories.GetAsync(c => c.Id == id, c=> c.Articles);
            if (data != null)
            {
                return new DataResult<Category>(data,ResultStatus.Success);
            }
            return new DataResult<Category>(null,ResultStatus.Error, "no such category found");
        }

        public async Task<IDataResult<IList<Category>>> GetAll()
        {
            var data = await _unitOfWork.Categories.GetAllAsync(null,c=>c.Articles);
            if(data.Count > -1)
            {
                return new DataResult<IList<Category>>(data, ResultStatus.Success);
            }
            return new DataResult<IList<Category>>(null, ResultStatus.Error, "There is no category"); 
        }


        public async Task<IResult> Update(CategoryUpdateDto categoryUpdateDto)
        {
            var category = await _unitOfWork.Categories.GetAsync(c => c.Id == categoryUpdateDto.Id);
            if (category != null)
            {
                category.Name = categoryUpdateDto.Name;
                await _unitOfWork.Categories.UpdateAsync(category).ContinueWith(t => _unitOfWork.SaveAsync());
                return new Result(ResultStatus.Success, $"Category :{category.Name} updated successfully");
            }
            return new Result(ResultStatus.Error, "Category not updated");
        }
    }
}
