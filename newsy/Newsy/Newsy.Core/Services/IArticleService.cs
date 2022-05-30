using Newsy.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Newsy.Core.Services
{
    public interface IArticleService
    {
        Task<Article> GetById(int id);
        Task<List<Article>> GetAllWithCategoryAuthor(int categoryId);
        Task<Article> GetByIdWithCategoryAuthor(int id);
        Task<Article> CreateArticle(Article article);
        Task UpdateArticle(Article articleToBeUpdated, Article article);
        Task DeleteArticle(Article article);
        Task<List<Article>> GetAllWithCategoryAuthorByAuthorId(int authorId);
    }
}
