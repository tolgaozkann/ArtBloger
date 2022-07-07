using ArtBloger.Entities.Concrete;
using ArtBloger.Shared.Entities.Abstract;
using ArtBloger.Shared.Utilities.Results.ComplexTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtBloger.Entities.Dtos
{
    public class ArticleListDto :DtoGetBase
    {
        public IList<Article> Articles { get; set; }
    }
}
