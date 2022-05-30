using Microsoft.EntityFrameworkCore;
using Newsy.Core.Entities;
using Newsy.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Newsy.Data.Repositories
{
    public class ArticleRepository : Repository<Article>, IArticleRepository
    {
        public ArticleRepository(DbContext context) : base(context)
        {
        }

        public async Task<List<Article>> GetAllWithAuthorAsync()
        {
            return await NewsyDbContext.Articles
                .Include(x => x.Author)
                .ToListAsync();
        }

        public async Task<List<Article>> GetAllWithAuthorAndCategoryAsync(int categoryId)
        {
            var articleList = await NewsyDbContext.Articles
                .Include(x => x.Author)
                .Include(x => x.Category)
                .ToListAsync();

            if (categoryId != 1)
            {
                articleList = articleList.Where(x => x.CategoryId == categoryId).ToList();
            }

            return articleList;
        }

        public async Task<Article> GetByIdWithAuthorAndCategoryAsync(int id)
        {
            return await NewsyDbContext.Articles
                .Include(x => x.Author)
                .Include(x => x.Category)
                .SingleOrDefaultAsync(x => x.Id == id);
        }

        private NewsyDbContext NewsyDbContext
        {
            get { return Context as NewsyDbContext; }
        }

    }
}
