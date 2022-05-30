using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newsy.Api.Dtos;
using Newsy.Core.Entities;
using Newsy.Core.Services;

namespace Newsy.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly IArticleService _articleService;
        private readonly ICategoryService _categoryService;
        private readonly IAuthorService _authorService;
        private readonly IMapper _mapper;

        public ArticleController(IArticleService articleService, ICategoryService categoryService, IAuthorService authorService, IMapper mapper)
        {
            _articleService = articleService;
            _categoryService = categoryService;
            _authorService = authorService;
            _mapper = mapper;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<ArticleDto>>> GetAllArticle()
        {
            var articles = await _articleService.GetAllWithCategoryAuthor();

            var articlesDto = _mapper.Map<List<Article>, List<ArticleDto>>(articles);

            return Ok(articlesDto);
        }

        [HttpGet("GetById/{id}")]
        public async Task<ActionResult<List<ArticleDto>>> GetByIdArticle(int id)
        {
            var article = await _articleService.GetByIdWithCategoryAuthor(id);

            var articleDto = _mapper.Map<Article, ArticleDto>(article);

            return Ok(articleDto);
        }

        [HttpPost("Create")]
        public async Task<ActionResult<ArticleDto>> CreateArticle(CreateArticleDto article)
        {
            var category = await _categoryService.GetCategoryById(article.CategoryId);
            if (category == null) return BadRequest("Category does not exist");

            int currentId = 1;
            var author = await _authorService.GetAuthorById(currentId);
            if (author == null) return Unauthorized("Author does not exist");

            Article articleToBeAdded = _mapper.Map<CreateArticleDto, Article>(article);

            articleToBeAdded.CreationDate = DateTime.Now;
            articleToBeAdded.PictureUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQBDdjfCGn7rtiZhl8QieKNnOHpCjFijJJKMg&usqp=CAU";
            articleToBeAdded.Author = author;
            articleToBeAdded.Category = category;

            var addedArticle = await _articleService.CreateArticle(articleToBeAdded);

            ArticleDto addedArticleDto = _mapper.Map<Article, ArticleDto>(addedArticle);

            return Ok(addedArticleDto);
        }

        [HttpDelete("DeleteById/{id}")]
        public async Task<ActionResult> DeleteArticle(int id)
        {
            var article = await _articleService.GetById(id);

            if (article == null) return BadRequest("Article you want to delete, does not exist");

            await _articleService.DeleteArticle(article);
            
            return Ok();
        }

        [HttpPut("Update/{id}")]
        public async Task<ActionResult> UpdateArticle(int id, CreateArticleDto updateArticleData)
        {
            var category = await _categoryService.GetCategoryById(updateArticleData.CategoryId);
            if (category == null) return BadRequest("Category does not exist");

            int currentId = 1;
            var author = await _authorService.GetAuthorById(currentId);
            if (author == null) return Unauthorized("Author does not exist");

            var articleToBeUpdated = await _articleService.GetById(id);
            if (articleToBeUpdated == null) return BadRequest("Article you want to update, does not exist");

            Article article = _mapper.Map<CreateArticleDto, Article>(updateArticleData);

            article.CreationDate = DateTime.Now;
            article.PictureUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQBDdjfCGn7rtiZhl8QieKNnOHpCjFijJJKMg&usqp=CAU";
            article.Category = category;

            await _articleService.UpdateArticle(articleToBeUpdated, article);

            return Ok();
        }

    }
}
