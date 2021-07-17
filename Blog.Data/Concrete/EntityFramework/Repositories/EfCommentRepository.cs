using Blog.Data.Abstract;
using Blog.Entities.Concrete;
using Blog.Shared.Data.Concrete.EntityFramework;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Data.Concrete.EntityFramework.Contexts
{
   public class EfCommentRepository: EFEntityRepository<Comment>, ICommentRepository
    {
        public EfCommentRepository(DbContext context):base(context)
        {

        }
    }
}
