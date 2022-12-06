using AutoMapper;
using PortalGrupChallengeApp.API.Models;
using PortalGrupChallengeApp.Entities.Concrete;

namespace EmergencyCall.Api.Mapping;

public class AddressProfile : Profile
{
    public AddressProfile()
    {
        CreateMap<Address, AddressDTO>();
        CreateMap<AddressDTO, Address>();
    }
}