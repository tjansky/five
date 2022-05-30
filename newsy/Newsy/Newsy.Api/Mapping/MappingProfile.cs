using AutoMapper;
using Newsy.Api.Dtos;
using Newsy.Core.Entities;

namespace Newsy.Api.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Domain to Dto
            CreateMap<Category, CategoryDto>();
            CreateMap<Article, ArticleDto>();

            // Dto to Domain
            CreateMap<CreateCategoryDto, Category>();
            CreateMap<CreateArticleDto, Article>();
        }
    }
}
