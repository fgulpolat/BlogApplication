using Blog.Data.Abstract;
using Blog.Entities.Concrete;
using Blog.Shared.Data.Concrete.EntityFramework;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Data.Concrete.EntityFramework.Contexts
{
    public class EfArticleRepository : EFEntityRepository<Article>, IArticleRepository
    {
        public EfArticleRepository(DbContext context) : base(context)
        {
        }
    }
}
