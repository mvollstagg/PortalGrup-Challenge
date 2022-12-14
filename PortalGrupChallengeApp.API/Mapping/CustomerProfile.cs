using AutoMapper;
using PortalGrupChallengeApp.API.Models;
using PortalGrupChallengeApp.Entities.Concrete;

namespace EmergencyCall.Api.Mapping;

public class CustomerProfile : Profile
{
    public CustomerProfile()
    {
        CreateMap<Customer, CustomerDTO>();
        CreateMap<CustomerDTO, Customer>();
    }
}