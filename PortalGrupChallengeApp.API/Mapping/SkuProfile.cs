using AutoMapper;
using PortalGrupChallengeApp.API.Models;
using PortalGrupChallengeApp.Entities.Concrete;

namespace EmergencyCall.Api.Mapping;

public class SkuProfile : Profile
{
    public SkuProfile()
    {
        CreateMap<SKU, SkuDTO>();
        CreateMap<SkuDTO, SKU>();
    }
}