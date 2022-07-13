using ArtBloger.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtBloger.Entities.Concrete
{
    public class Article : BaseEntity, IEntity
    {
        [Required,MaxLength(250)]
        public string Title { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(max)")]
        public string Content { get; set; }
        public string Image { get; set; }
        public DateTime CreatedTime { get; set; } = DateTime.Now;
        public int ViewsCount { get; set; } = 0;
        public int CommentCount { get; set; } = 0;
        public string SeoDescription { get; set; }
        public string SeoAuthor { get; set; }
        public string SeoTags { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}
