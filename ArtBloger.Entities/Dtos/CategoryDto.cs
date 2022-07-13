﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArtBloger.Shared.Entities.Abstract;

namespace ArtBloger.Entities.Dtos
{
    public class CategoryDto :DtoGetBase
    {
        [Required]
        public int Id { get; set; }
        [DisplayName("Category Name")]
        [Required(ErrorMessage = "{0}cant be empty")]
        [MaxLength(70, ErrorMessage = "{0}  must be {1} char")]
        [MinLength(3, ErrorMessage = ("{0} must not be less that {1} char"))]
        public string Name { get; set; }
    }
}
