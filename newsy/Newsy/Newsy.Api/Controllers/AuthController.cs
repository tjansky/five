using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newsy.Api.Dtos;
using Newsy.Core.Entities;
using Newsy.Core.Services;
using System.Security.Cryptography;
using System.Text;

namespace Newsy.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IAuthorService _authorService;

        public AuthController(IAuthService authService, IAuthorService authorService)
        {
            _authService = authService;
            _authorService = authorService;
        }


        [HttpPost("Register")]
        public async Task<ActionResult<AuthorWithTokenDto>> RegisterUser([FromBody] RegisterAuthorDto registerAuthorDto)
        {
            using var hmac = new HMACSHA512();

            var author = new Author
            {
                FirstName = registerAuthorDto.FirstName,
                LastName = registerAuthorDto.LastName,
                Email = registerAuthorDto.Email,
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerAuthorDto.Password)),
                PasswordSalt = hmac.Key
            };

            // add new author to db
            var addedUser = await _authorService.CreateAuthor(author);

            // generate token
            string token = _authService.CreateJwtToken(author);

            var authorWithToken = new AuthorWithTokenDto
            {
                Id = author.Id,
                FirstName = author.FirstName,
                LastName = author.LastName,
                Email = author.Email,
                Token = token
            };

            return authorWithToken;
        }

        [HttpPost("Login")]
        public async Task<ActionResult<AuthorWithTokenDto>> LoginUser([FromBody] LoginAuthorDto loginAuthorDto)
        {
            // get author from db
            var author = await _authorService.GetAuthorByEmail(loginAuthorDto.Email);

            if (author == null) return Unauthorized("Invalid credentials");

            using var hmac = new HMACSHA512(author.PasswordSalt);

            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginAuthorDto.Password));
            // check if password is correct
            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != author.PasswordHash[i]) return Unauthorized("Invalid password");
            }

            // generate token
            string token = _authService.CreateJwtToken(author);

            var authorWithToken = new AuthorWithTokenDto
            {
                Id = author.Id,
                FirstName = author.FirstName,
                LastName = author.LastName,
                Email = author.Email,
                Token = token
            };

            return authorWithToken;
        }

    }
}
