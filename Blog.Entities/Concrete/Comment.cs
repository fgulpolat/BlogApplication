using Blog.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;

namespace Blog.Entities.Concrete
{
   public class Comment : EntityBase, IEntity
    {
        public string Text { get; set; }
        public int ArticleId { get; set; }
        public Article Article { get; set; }
    }
}
