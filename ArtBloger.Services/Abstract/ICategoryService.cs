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
        Task<IDataResult<Category>> Get(int id);
        Task<IDataResult<IList<Category>>> GetAll();
        Task<IResult> Add(CategoryAddDto categoryAddDto);
        Task<IResult> Update(CategoryUpdateDto categoryUpdateDto);
        Task<IResult> Delete(int id);
        
        
    }
}
