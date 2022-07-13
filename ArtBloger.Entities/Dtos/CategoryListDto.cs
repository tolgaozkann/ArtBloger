using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArtBloger.Entities.Concrete;
using ArtBloger.Shared.Entities.Abstract;

namespace ArtBloger.Entities.Dtos
{
    public class CategoryListDto: DtoGetBase
    {
        public IList<Category> Categories { get; set; }
    }
}
