using Blog.Data.Abstract;
using Blog.Data.Concrete.EntityFramework.Contexts;
using Blog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Data.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BlogContext _blogContext;

        private EfArticleRepository _articleRepository;
        private EfCategoryRepository _categoryRepository;
        private EfCommentRepository _commentRepository;
        private EfRoleRepository _roleRepository;
        private EfUserRepository _userRepository;


        public UnitOfWork(BlogContext blogContext)
        {
            _blogContext = blogContext;
        }

        public IArticleRepository Articles => _articleRepository ?? new EfArticleRepository(_blogContext);

        public ICategoryRepository Categories => _categoryRepository ?? new EfCategoryRepository(_blogContext);

        public ICommentRepository Comments => _commentRepository ?? new EfCommentRepository(_blogContext);

        public IRoleRepository Roles => _roleRepository ?? new EfRoleRepository(_blogContext);

        public IUserRepository Users => _userRepository ?? new EfUserRepository(_blogContext);


        public async ValueTask DisposeAsync()
        {
             await _blogContext.DisposeAsync();
        }

        public async Task<int> SaveAsync()
        {
           return await _blogContext.SaveChangesAsync();
        }
    }
}
