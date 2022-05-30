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
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(DbContext context) : base(context)
        {
        }

        private NewsyDbContext NewsyDbContext
        {
            get { return Context as NewsyDbContext; }
        }
    }
}
