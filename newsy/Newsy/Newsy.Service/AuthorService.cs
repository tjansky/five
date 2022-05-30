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
    public class AuthorService : IAuthorService
    {
        private IUnitOfWork _unitOfWork;

        public AuthorService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Author> CreateAuthor(Author author)
        {
            await _unitOfWork.Authors.AddAsync(author);
            await _unitOfWork.CommitAsync();

            return author;
        }

        public async Task<Author> GetAuthorByEmail(string email)
        {
            return await _unitOfWork.Authors.GetAuthorByEmailAsync(email);
        }

        public async Task<Author> GetAuthorById(int id)
        {
            return await _unitOfWork.Authors.GetByIdAsync(id);
        }
    }
}
