﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Data.Abstract
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        IArticleRepository Articles { get; }

        ICategoryRepository Categories { get; }

        ICommentRepository Comments { get; }

        IRoleRepository Roles { get; }

        IUserRepository Users { get; }

        Task<int> SaveAsync();
    }
}
