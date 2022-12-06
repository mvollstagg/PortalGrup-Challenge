using AutoMapper;
using PortalGrupChallengeApp.API.Models;
using PortalGrupChallengeApp.Entities.Concrete;

namespace EmergencyCall.Api.Mapping;

public class CategoryProfile : Profile
{
    public CategoryProfile()
    {
        CreateMap<Category, CategoryDTO>();
        CreateMap<CategoryDTO, Category>();
    }
}