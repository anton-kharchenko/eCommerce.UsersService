using AutoMapper;
using eCommerce.Core.DTO;
using eCommerce.Core.Entities;

namespace eCommerce.Infrastructure.Mappers;

public class ApplicationUserMappingProfile : Profile
{
    public ApplicationUserMappingProfile()
    {
        CreateMap<ApplicationUser, AuthenticationResponse>()
            .ForMember(dest=>dest.Success, opt=> opt.Ignore())
            .ForMember(dest => dest.Token, opt => opt.Ignore());
    }
}