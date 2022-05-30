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
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<CategoryDto>>> GetAllCategories()
        {
            var categories = await _categoryService.GetAllCategories();

            IEnumerable<CategoryDto> categoriesDto = _mapper.Map<IEnumerable<Category>, IEnumerable<CategoryDto>>(categories);

            return Ok(categoriesDto);
        }

        [HttpPost("Create")]
        public async Task<ActionResult<CategoryDto>> CreateCategory(CreateCategoryDto categoryToBeCreated)
        {
            Category category = _mapper.Map<CreateCategoryDto, Category>(categoryToBeCreated);

            var newCategory = await _categoryService.CreateCategory(category);

            return Ok(newCategory);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult> DeleteCategory(int id)
        {
            var category = await _categoryService.GetCategoryById(id);

            if (category == null) return BadRequest("Categroy you want to delete, doesn't exist");

            await _categoryService.DeleteCategory(category);

            return Ok();
        }

    }
}
