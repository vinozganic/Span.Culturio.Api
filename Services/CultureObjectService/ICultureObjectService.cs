using Span.Culturio.Api.Models.CultureObject;

namespace Span.Culturio.Api.Services.CultureObject
{
    public interface ICultureObjectService
    {
        Task<IEnumerable<CultureObjectDto>> GetCultureObjectsAsync();
        Task<CultureObjectDto> GetCultureObjectAsync(int id);
        Task<CultureObjectDto> CreateCultureObjectAsync(CreateCultureObjectDto request);

    }
}
