using Blog.Entities.Concrete;
using Blog.Entities.Dtos;
using Blog.Shared.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Services.Abstract
{
   public interface ICategoryService
    {
        Task<IDataResult<CategoryDto>> Get(int categoryId);

        Task<IDataResult<CategoryListDto>> GetAll();

        Task<IDataResult<CategoryListDto>> GetAllByNonDeleted();

        Task<IDataResult<CategoryListDto>> GetAllByNonDeletedAndActive();

        Task<IResult> Add(CategoryAddDto categoryAddDto,string createdByName);

        Task<IResult> Update(CategoryUpdateDto categoryUpdateDto,string modifiedByName);

        Task<IResult> Delete(int categoryId, string modifiedByName);

        Task<IResult> HardDelete(int categoryId);

    }
}
