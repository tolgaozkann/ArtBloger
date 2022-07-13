using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArtBloger.Data.Abstract;
using ArtBloger.Entities.Concrete;
using ArtBloger.Entities.Dtos;
using ArtBloger.Services.Abstract;
using ArtBloger.Shared.Utilities.Results.Abstract;
using ArtBloger.Shared.Utilities.Results.ComplexTypes;
using ArtBloger.Shared.Utilities.Results.Concrete;
using AutoMapper;

namespace ArtBloger.Services.Concrete
{
    public class ArticleManager :IArticleService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ArticleManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
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

        public async Task<IDataResult<ArticleListDto>> GetAllByCategory(int id)
        {
            var result = await _unitOfWork.Categories.AnyAsync(c => c.Id == id);

            if (result)
            {
                var data = await _unitOfWork.Articles.GetAllAsync(a => a.CategoryId == id, a => a.User, a => a.Category);
                if (data.Count > -1)
                {
                    return new DataResult<ArticleListDto>(new ArticleListDto
                    {
                        Articles = data,
                        ResultStatus = ResultStatus.Success
                    }, ResultStatus.Success);
                }
                return new DataResult<ArticleListDto>(null, ResultStatus.Error, "There is no Article related by this category");
            }

            return new DataResult<ArticleListDto>(null, ResultStatus.Error, "There is no category with this id");

        }

        public async Task<IResult> Add(ArticleAddDto articleAddDto)
        {
            var article = _mapper.Map<Article>(articleAddDto);
            article.UserId = 1;
                

            if (article != null)
            {
                _unitOfWork.Articles.AddAsync(article).ContinueWith(t=>_unitOfWork.SaveAsync());
                return new Result(ResultStatus.Success, $"Article {article.Title} added successfully");
            }
            return new Result(ResultStatus.Error, $"Article {article.Title} not added");
        }

        public async Task<IResult> Update(ArticleUpdateDto articleUpdateDto)
        {
            var data = await _unitOfWork.Articles.GetAsync(a => a.Id == articleUpdateDto.Id);
            
            if(data != null)
            {
                var article = _mapper.Map<Article>(articleUpdateDto);
                await _unitOfWork.Articles.UpdateAsync(article).ContinueWith(t => _unitOfWork.SaveAsync());
                return new Result(ResultStatus.Success, $"Article {articleUpdateDto.Title} updated successfully");
            }
            return new Result(ResultStatus.Error, $"Article {articleUpdateDto.Title} not updated");
        }

        public async Task<IResult> Delete(int id)
        {
            var result = await _unitOfWork.Articles.AnyAsync(a => a.Id == id);

            if (result)
            {
                var article = await _unitOfWork.Articles.GetAsync(a => a.Id == id);
                await _unitOfWork.Articles.DeleteAsync(article).ContinueWith(t => _unitOfWork.SaveAsync());
                return new Result(ResultStatus.Success, $"Article deleted successfully");
            }
            return new Result(ResultStatus.Error, $"Article not found");
        }
    }
}
