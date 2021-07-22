using AutoMapper;
using Blog.Data.Abstract;
using Blog.Entities.Concrete;
using Blog.Entities.Dtos;
using Blog.Services.Abstract;
using Blog.Shared.Utilities.Results.Abstract;
using Blog.Shared.Utilities.Results.ComplexTypes;
using Blog.Shared.Utilities.Results.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Services.Concrete
{
    public class ArticleManager : IArticleService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;


        public ArticleManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        public async Task<IResult> Add(ArticleAddDto articleAddDto, string createdByName)
        {
            var article = _mapper.Map<Article>(articleAddDto);
            article.CreatedByName = createdByName;
            article.ModifiedByName = createdByName;
            article.UserId = 1;

            await _unitOfWork.Articles.AddAsync(article);
            await _unitOfWork.SaveAsync();

            return new Result(ResultStatus.Success, $"{articleAddDto.Title} makalesi başarı ile eklenmiştir.");
        }



        public async Task<IResult> Delete(int articleId)
        {
            var deletedArticle = await _unitOfWork.Articles.GetAsync(a => a.Id == articleId);

            if (deletedArticle!=null)
            {
                deletedArticle.IsDeleted = true;
                deletedArticle.ModifiedDate = DateTime.Now;
                await _unitOfWork.Articles.UpdateAsync(deletedArticle);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{deletedArticle.Title} makalesi başarı ile silinmiştir.");
            }

            return new Result(ResultStatus.Success, $"Böyle bir  makale bulunamamıştır.");
        }



        public async Task<IDataResult<ArticleDto>> Get(int articleId)
        {
            var article = await _unitOfWork.Articles.GetAsync(a => a.Id == articleId, a => a.User, a => a.Category);

            if (article != null)
            {
                return new DataResult<ArticleDto>(ResultStatus.Success, new ArticleDto
                {
                    Article = article,
                    ResultStatus = ResultStatus.Success
                });
            }

            return new DataResult<ArticleDto>(ResultStatus.Error, "Böyle bir makale bulunamadı.", null);
        }




        public async Task<IDataResult<ArticleListDto>> GetAll()
        {
            var articles = await _unitOfWork.Articles.GetAllAsync(null, a => a.User, a => a.Category);

            if (articles.Count > -1)
            {
                return new DataResult<ArticleListDto>(ResultStatus.Success, new ArticleListDto
                {
                    Articles = articles,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<ArticleListDto>(ResultStatus.Error, "Böyle bir makale bulunamadı.", null);
        }



        public async Task<IDataResult<ArticleListDto>> GetAllByCategory(int categoryId)
        {

            var result = await _unitOfWork.Categories.AnyAsync(c => c.Id == categoryId);

            if (result)
            {
                var articles = await _unitOfWork.Articles.GetAllAsync(a => a.CategoryId == categoryId && a.IsActive && !a.IsDeleted, a => a.Category, a => a.User);

                if (articles.Count > -1)
                {
                    return new DataResult<ArticleListDto>(ResultStatus.Success, new ArticleListDto
                    {
                        Articles = articles,
                        ResultStatus = ResultStatus.Success
                    });
                }
                return new DataResult<ArticleListDto>(ResultStatus.Error, "Böyle bir makale bulunamadı.", null);
            }
            return new DataResult<ArticleListDto>(ResultStatus.Error, "Böyle bir kategori bulunamadı.", null);
        }




        public async Task<IDataResult<ArticleListDto>> GetAllByNonDeleted()
        {
            var articles = await _unitOfWork.Articles.GetAllAsync(a => !a.IsDeleted, a => a.Category, a => a.User);

            if (articles.Count > -1)
            {
                var articleListDto = new ArticleListDto();
                articleListDto.Articles = articles;
                articleListDto.ResultStatus = ResultStatus.Success;
                return new DataResult<ArticleListDto>(ResultStatus.Success, articleListDto);
            }

            return new DataResult<ArticleListDto>(ResultStatus.Error, "Böyle bir makale bulunamadı.", null);

        }



        public async Task<IDataResult<ArticleListDto>> GetAllByNonDeletedAndActive()
        {
            var articles = await _unitOfWork.Articles.GetAllAsync(a => !a.IsDeleted && a.IsActive, a => a.Category, a => a.User);

            if (articles.Count > -1)
            {
                var articleListDto = new ArticleListDto();
                articleListDto.Articles = articles;
                articleListDto.ResultStatus = ResultStatus.Success;
                return new DataResult<ArticleListDto>(ResultStatus.Success, articleListDto);
            }

            return new DataResult<ArticleListDto>(ResultStatus.Error, "Böyle bir makale bulunamadı.", null);
        }



        public async Task<IResult> HardDelete(int articleId)
        {
            var article = await _unitOfWork.Articles.GetAsync(a => a.Id == articleId);

            if (article != null)
            {
                await _unitOfWork.Articles.DeleteAsync(article);
                await _unitOfWork.SaveAsync();

                return new Result(ResultStatus.Success, $"{article.Title} başlıklı makale başarı ile silinmiştir.");
            }

            return new DataResult<ArticleListDto>(ResultStatus.Error, "Böyle bir makale bulunamadı.", null);
        }



        public async Task<IResult> Update(ArticleUpdateDto articleUpdateDto, string modifiedByName)
        {
            var updatedArticle = _mapper.Map<Article>(articleUpdateDto);
            updatedArticle.ModifiedByName = modifiedByName;

            await _unitOfWork.Articles.UpdateAsync(updatedArticle);

            return new Result(ResultStatus.Success, $"{articleUpdateDto.Title} başlıklı makale güncellenmiştir.");
        }
    }
}
