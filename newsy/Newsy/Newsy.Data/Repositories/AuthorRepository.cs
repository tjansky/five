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
    public class AuthorRepository : Repository<Author>, IAuthorRepository
    {
        public AuthorRepository(DbContext context) : base(context)
        {
        }

        public async Task<Author> GetAuthorByEmailAsync(string email)
        {
            return await NewsyDbContext.Authors
                .SingleOrDefaultAsync(x => x.Email == email);
        }

        private NewsyDbContext NewsyDbContext
        {
            get { return Context as NewsyDbContext; }
        }
    }
}
