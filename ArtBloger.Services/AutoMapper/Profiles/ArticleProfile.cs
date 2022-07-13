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
    public class ArticleProfile : Profile
    {
        public ArticleProfile()
        {
            CreateMap<ArticleAddDto, Article>().ForMember(dest =>dest.CreatedTime,
                opt => opt.MapFrom(src => DateTime.Now));
            CreateMap<ArticleUpdateDto, Article>();
        }
    }
}
