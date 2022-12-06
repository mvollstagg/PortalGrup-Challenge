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
        // Domain to Resource
        // CreateMap<User, UserDTO>();
        // CreateMap<HelpRequest, HelpRequestDTO>();
        // CreateMap<HelpResponse, HelpResponseDTO>();

        // Resource to Domain
        // CreateMap<UserDTO, User>();
        // CreateMap<CreateUserDTO, User>();
        // CreateMap<SaveUserDTO, User>();
    }
}