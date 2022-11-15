using AutoMapper;
using Span.Culturio.Api.Data;
using Span.Culturio.Api.Models.Subscriptions;

namespace Span.Culturio.Api.Services.Subscriptions
{
    public interface ISubscriptionService {
        Task<SubscriptionDto> CreateAsync(CreateSubscriptionDto createSubscriptionDto);
        Task<IEnumerable<SubscriptionDto>> GetAsync(int userId);
        Task<string> TrackVisit(TrackVisitDto trackVisitDto);
        Task<string> Activate(ActivateDto activateDto);
    }
}
