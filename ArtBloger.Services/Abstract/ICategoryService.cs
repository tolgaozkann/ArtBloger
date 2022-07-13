using ArtBloger.Entities.Concrete;
using ArtBloger.Entities.Dtos;
using ArtBloger.Shared.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtBloger.Services.Abstract
{
    public interface ICategoryService
    {
        Task<IDataResult<CategoryDto>> Get(int id);
        Task<IDataResult<CategoryListDto>> GetAll();
        Task<IDataResult<CategoryDto>> Add(CategoryAddDto categoryAddDto);
        Task<IDataResult<CategoryDto>> Update(CategoryUpdateDto categoryUpdateDto);
        Task<IResult> Delete(int id);
        
        
    }
}
