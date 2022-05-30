using Newsy.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Newsy.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IAuthorRepository  Authors { get; }
        IArticleRepository Articles { get; }
        ICategoryRepository Categories { get; }

        Task<int> CommitAsync();
    }
}
