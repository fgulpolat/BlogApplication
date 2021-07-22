using Blog.Entities.Concrete;
using Blog.Entities.Dtos;
using Blog.Shared.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Services.Abstract
{
    public interface IArticleService
    {
        Task<IDataResult<ArticleListDto>> GetAll();

        Task<IDataResult<ArticleListDto>> GetAllByNonDeleted();

        Task<IDataResult<ArticleListDto>> GetAllByNonDeletedAndActive();

        Task<IDataResult<ArticleListDto>> GetAllByCategory(int categoryId);

        Task<IDataResult<ArticleDto>> Get(int articleId);

        Task<IResult> Add(ArticleAddDto article, string createdByName);

        Task<IResult> Update(ArticleUpdateDto article, string modifiedByName);

        Task<IResult> Delete(int articleId);

        Task<IResult> HardDelete(int articleId);


    }

}
