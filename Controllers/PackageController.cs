using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Span.Culturio.Api.Models.Package;
using Span.Culturio.Api.Services.Package;

namespace Span.Culturio.Api.Controllers
{
    [Route("api/packages")]
    [ApiController]
    public class PackageController : ControllerBase
    {
        private readonly IPackageService _packageService;


        public PackageController(IPackageService packageService)
        {
            _packageService = packageService;
        }
        /// <summary>
        /// Create a new package
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<PackageDto>> CreatePackageAsync([FromBody] CreatePackageDto createPackageDto)
        {
            var package = await _packageService.CreatePackageAsync(createPackageDto);
            return Ok(package);
        }
        /// <summary>
        /// Get packages
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<List<PackageDto>>> GetPackagesAsync()
        {
            var packages = await _packageService.GetPackagesAsync();
            return Ok(packages);
        }
    }
}
