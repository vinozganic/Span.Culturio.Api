using Span.Culturio.Api.Models.Package;

namespace Span.Culturio.Api.Services.Package
{
    public interface IPackageService
    {
        Task<PackageDto> CreatePackageAsync(CreatePackageDto createPackageDto);
        Task<List<PackageDto>> GetPackagesAsync();
    }
}
