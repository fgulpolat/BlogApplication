using Blog.Entities.Concrete;
using Blog.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Entities.Dtos
{
   public class ArticleDto: DtoGetBase
    {
        public Article Article { get; set; }        
    }
}
