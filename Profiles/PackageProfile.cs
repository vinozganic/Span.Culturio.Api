using AutoMapper;
using Span.Culturio.Api.Data.Entities;
using Span.Culturio.Api.Models.Package;

namespace Span.Culturio.Api.Profiles
{
    public class PackageProfile : Profile
    {

        public PackageProfile()
        {
            CreateMap<CreatePackageDto, Package>().ForMember(dest => dest.PackageItems, opt => opt.Ignore());

            CreateMap<CreatePackageItemDto, PackageItem>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.CultureObjectId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.AvailableVisitsCount, opt => opt.MapFrom(src => src.AvailableVisits));

            CreateMap<Package, PackageDto>().ForMember(dest => dest.CultureObjects, opt => opt.MapFrom(src => src.PackageItems));

            CreateMap<PackageItem, PackageItemDto>()
                .ForMember(dest => dest.AvailableVisits, opt => opt.MapFrom(src => src.AvailableVisitsCount))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.CultureObjectId));
        }
    }
}
