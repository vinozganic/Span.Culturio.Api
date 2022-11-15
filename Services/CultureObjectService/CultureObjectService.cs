using AutoMapper;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using Span.Culturio.Api.Data;
using Span.Culturio.Api.Models.CultureObject;

namespace Span.Culturio.Api.Services.CultureObject
{
    public class CultureObjectService : ICultureObjectService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public CultureObjectService(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }


        public async Task<CultureObjectDto> CreateCultureObjectAsync(CreateCultureObjectDto request)
        {
            var cultureObject = _mapper.Map<Data.Entities.CultureObject>(request);

            _context.Add(cultureObject);
            await _context.SaveChangesAsync();

            var cultureObjectDto = _mapper.Map<CultureObjectDto>(cultureObject);
            return cultureObjectDto;
        }

        public async Task<CultureObjectDto> GetCultureObjectAsync(int id)
        {
            var cultureObject = await _context.CultureObjects.FindAsync(id);
            if (cultureObject is null) return null;

            var cultureObjectDto = _mapper.Map<CultureObjectDto>(cultureObject);

            return cultureObjectDto;

        }

        public async Task<IEnumerable<CultureObjectDto>> GetCultureObjectsAsync()
        {
            var cultureObjects = await _context.CultureObjects.ToListAsync();
            var cultureObjectsDto = _mapper.Map<List<CultureObjectDto>>(cultureObjects);

            return cultureObjectsDto;
        }
    }
}
