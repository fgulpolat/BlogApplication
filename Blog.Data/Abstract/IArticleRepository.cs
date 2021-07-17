using Blog.Entities.Concrete;
using Blog.Shared.Data.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Data.Abstract
{
   public interface IArticleRepository:IEntityRepository<Article>
    {

    }
}
