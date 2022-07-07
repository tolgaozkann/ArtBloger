using ArtBloger.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtBloger.Entities.Concrete
{
    public class Category : BaseEntity, IEntity
    {
        public string Name { get; set; }
        public ICollection<Article> Articles { get; set; }
    }
}
