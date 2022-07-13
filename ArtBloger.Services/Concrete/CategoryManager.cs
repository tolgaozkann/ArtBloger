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
using AutoMapper;

namespace ArtBloger.Services.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CategoryManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IDataResult<CategoryDto>> Add(CategoryAddDto categoryAddDto)
        {
            var category = _mapper.Map<Category>(categoryAddDto);
            if (category != null)
            {
                var data = await _unitOfWork.Categories.AddAsync(category);
                await _unitOfWork.SaveAsync();
                return new DataResult<CategoryDto>(new CategoryDto
                {
                    Name = data.Name,
                    ResultStatus = ResultStatus.Success,
                    Id = data.Id
                },ResultStatus.Success, $"Category :{category.Name} added successfully");
            }
            return new DataResult<CategoryDto>(new CategoryDto
            {
                ResultStatus = ResultStatus.Error,
                Message = $"Category :{category.Name} not added",
            }, ResultStatus.Error, "Category not added");
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
        
        public async Task<IDataResult<CategoryDto>> Get(int id)
        {
           var data = await _unitOfWork.Categories.GetAsync(c => c.Id == id, c=> c.Articles);
            if (data != null)
            {
                return new DataResult<CategoryDto>(new CategoryDto
                {
                    Name = data.Name,
                    ResultStatus = ResultStatus.Success,
                    Id = data.Id
                }, ResultStatus.Success);
            }
            return new DataResult<CategoryDto>(new CategoryDto
            {
                Message = "Category not found",
                ResultStatus = ResultStatus.Error,
            },ResultStatus.Error, "no such category found");
        }

        public async Task<IDataResult<CategoryListDto>> GetAll()
        {
            var data = await _unitOfWork.Categories.GetAllAsync(null,c=>c.Articles);
            //var categories = _mapper.Map<CategoryListDto>(data);
            if (data.Count > -1)
            {
                return new DataResult<CategoryListDto>(new CategoryListDto
                {
                    Categories = data,
                    ResultStatus = ResultStatus.Success
                }, ResultStatus.Success);
            }
            return new DataResult<CategoryListDto>(new CategoryListDto
            {
                ResultStatus = ResultStatus.Error,
                Message = "no categories found",
                Categories = null
            }, ResultStatus.Error, "There is no category"); 
        }


        public async Task<IDataResult<CategoryDto>> Update(CategoryUpdateDto categoryUpdateDto)
        {
            var category = await _unitOfWork.Categories.GetAsync(c => c.Id == categoryUpdateDto.Id);
            if (category != null)
            {
                category = _mapper.Map<Category>(categoryUpdateDto);
                var data = await _unitOfWork.Categories.UpdateAsync(category);
                await _unitOfWork.SaveAsync();
                return new DataResult<CategoryDto>(new CategoryDto
                {
                    Name = data.Name,
                    ResultStatus = ResultStatus.Success,
                    Id = data.Id
                }, ResultStatus.Success, $"Category :{category.Name} updated successfully");
            }
            return new DataResult<CategoryDto>(new CategoryDto
            {
                ResultStatus = ResultStatus.Error,
                Message = $"Category :{category.Name} not updated",
            }, ResultStatus.Error, "Category not updated");
        }
    }
}
