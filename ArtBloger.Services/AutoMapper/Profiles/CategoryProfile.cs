using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArtBloger.Entities.Concrete;
using ArtBloger.Entities.Dtos;
using AutoMapper;

namespace ArtBloger.Services.AutoMapper.Profiles
{
    public class CategoryProfile :Profile
    {
        public CategoryProfile()
        {
            CreateMap<CategoryAddDto, Category>();
            CreateMap<CategoryUpdateDto, Category>();
        }
    }
}
