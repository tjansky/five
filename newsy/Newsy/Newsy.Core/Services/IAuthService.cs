using Newsy.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Newsy.Core.Services
{
    public interface IAuthService
    {
        string CreateJwtToken(Author author);
    }
}
