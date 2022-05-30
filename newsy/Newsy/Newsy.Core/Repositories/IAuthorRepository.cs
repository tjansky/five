using Newsy.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Newsy.Core.Repositories
{
    public interface IAuthorRepository : IRepository<Author>
    {
        Task<Author> GetAuthorByEmailAsync(string email);
    }
}
