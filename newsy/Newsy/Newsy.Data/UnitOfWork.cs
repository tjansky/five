using Newsy.Core;
using Newsy.Core.Repositories;
using Newsy.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Newsy.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly NewsyDbContext _context;
        private ArticleRepository _articleRepository;
        private AuthorRepository _authorRepository;
        private CategoryRepository _categoryRepository;

        public UnitOfWork(NewsyDbContext context)
        {
            _context = context;
        }

        public IArticleRepository Articles => _articleRepository ?? new ArticleRepository(_context);
        public IAuthorRepository Authors => _authorRepository ?? new AuthorRepository(_context);
        public ICategoryRepository Categories => _categoryRepository ?? new CategoryRepository(_context);

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
