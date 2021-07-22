using Blog.Entities.Concrete;
using Blog.Shared.Entities.Abstract;
using Blog.Shared.Utilities.Results.ComplexTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Entities.Dtos
{
   public class ArticleListDto: DtoGetBase
    {
        public IList<Article> Articles{ get; set; }
    }
}
