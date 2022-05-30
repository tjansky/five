using Newsy.Core;
using Newsy.Core.Entities;
using Newsy.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Newsy.Service
{
    public class ArticleService : IArticleService
    {
        private IUnitOfWork _unitOfWork;

        public ArticleService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Article> CreateArticle(Article article)
        {
            await _unitOfWork.Articles.AddAsync(article);
            await _unitOfWork.CommitAsync();
            
            return article;
        }

        public async Task DeleteArticle(Article article)
        {
            _unitOfWork.Articles.Remove(article);
            await _unitOfWork.CommitAsync();
        }

        public async Task<List<Article>> GetAllWithCategoryAuthor()
        {
            return await _unitOfWork.Articles.GetAllWithAuthorAndCategoryAsync();
        }

        public async Task<Article> GetById(int id)
        {
            return await _unitOfWork.Articles.GetByIdAsync(id);
        }

        public async Task<Article> GetByIdWithCategoryAuthor(int id)
        {
            return await _unitOfWork.Articles.GetByIdWithAuthorAndCategoryAsync(id);
        }

        public async Task UpdateArticle(Article articleToBeUpdated, Article article)
        {
            articleToBeUpdated.Title = article.Title;
            articleToBeUpdated.Content = article.Content;

            articleToBeUpdated.CategoryId = article.CategoryId;
            articleToBeUpdated.Category = article.Category;

            await _unitOfWork.CommitAsync();
        }
    }
}
