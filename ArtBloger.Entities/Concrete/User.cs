﻿using ArtBloger.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtBloger.Entities.Concrete
{
    public class User : BaseEntity,IEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public string UserName { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
        public string Picture { get; set; }
        public ICollection<Article> Articles { get; set; }
    }
}
