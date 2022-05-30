using Newsy.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Newsy.Core.Services
{
    public interface IAuthorService
    {
        Task<Author> CreateAuthor(Author author);
        Task<Author> GetAuthorByEmail(string email);
        Task<Author> GetAuthorById(int id);
    }
}
