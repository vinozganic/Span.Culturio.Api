using AutoMapper;
using Span.Culturio.Api.Data.Entities;
using Span.Culturio.Api.Models.CultureObject;

namespace Span.Culturio.Api.Profiles
{
    public class CultureObjectProfile : Profile
    {
        public CultureObjectProfile()
        {
            CreateMap<CreateCultureObjectDto, CultureObject>();
            CreateMap<CultureObjectDto, CultureObject>();
            CreateMap<CultureObject, CultureObjectDto>();
        }
    }
}