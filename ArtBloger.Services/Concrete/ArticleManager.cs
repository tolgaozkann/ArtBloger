using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArtBloger.Data.Abstract;
using ArtBloger.Entities.Dtos;
using ArtBloger.Services.Abstract;
using ArtBloger.Shared.Utilities.Results.Abstract;
using ArtBloger.Shared.Utilities.Results.ComplexTypes;
using ArtBloger.Shared.Utilities.Results.Concrete;

namespace ArtBloger.Services.Concrete
{
    public class ArticleManager :IArticleService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ArticleManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IDataResult<ArticleDto>> Get(int id)
        {
            var article = await _unitOfWork.Articles.GetAsync(a => a.Id ==id,a=>a.User,a=>a.Category);
            if (article != null)
            {
                return new DataResult<ArticleDto>(new ArticleDto
                {
                    Article = article,
                    ResultStatus = ResultStatus.Success,
                    
                },ResultStatus.Success);
            }
            return new DataResult<ArticleDto>(null, ResultStatus.Error);
        }   

        public async Task<IDataResult<ArticleListDto>> GetAll()
        {
            var articles = await _unitOfWork.Articles.GetAllAsync(null,a => a.User, a => a.Category);
            if (articles.Count > -1)
            {
                return new DataResult<ArticleListDto>(new ArticleListDto
                {
                    Articles = articles,
                    ResultStatus = ResultStatus.Success
                }, ResultStatus.Success);
            }
            return new DataResult<ArticleListDto>(null, ResultStatus.Error,"Articles not found");
        }

        public Task<IDataResult<ArticleListDto>> GetAllByCategory()
        {
            throw new NotImplementedException();
        }

        public Task<IResult> Add(ArticleAddDto articleAddDto)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> Update(ArticleUpdateDto articleUpdateDto)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
