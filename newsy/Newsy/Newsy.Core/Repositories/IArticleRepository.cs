using Newsy.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Newsy.Core.Repositories
{
    public interface IArticleRepository : IRepository<Article>
    {
        Task<List<Article>> GetAllWithAuthorAsync();
        Task<List<Article>> GetAllWithAuthorAndCategoryAsync(int categoryId);
        Task<Article> GetByIdWithAuthorAndCategoryAsync(int id);
        Task<List<Article>> GetAllWithCategoryAuthorByAuthorIdAsync(int authorId);
    }
}
