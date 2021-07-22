using Blog.Entities.Concrete;
using Blog.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Entities.Dtos
{
   public class CategoryListDto:DtoGetBase
    {
        public IList<Category> Categories { get; set; }
    }
}
