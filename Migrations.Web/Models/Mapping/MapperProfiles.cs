using AutoMapper;
using Migrations.Web.Models.DTOs;
using Migrations.Web.Models.NorthwindDB.Entities;

namespace Migrations.Web.Models.Mapping
{
    public class MapperProfiles : Profile
    {
        public MapperProfiles()
        {
            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryCreateDto, Category>();
        }
    }
}
