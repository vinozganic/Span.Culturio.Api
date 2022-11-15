using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Span.Culturio.Api.Data;
using Span.Culturio.Api.Data.Entities;
using Span.Culturio.Api.Models.Subscriptions;

namespace Span.Culturio.Api.Services.Subscriptions
{
    public class SubscriptionService : ISubscriptionService {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public SubscriptionService(DataContext context, IMapper mapper) {
            _context = context;
            _mapper = mapper;
        }

        public async Task<string> Activate(ActivateDto activateDto) {
            var subscription = await _context.Subscriptions.FindAsync(activateDto.SubscriptionId);
            if (subscription is null) return "SubscriptionNotFound";

            if (subscription.State == "active") return "SubscriptionAlreadyActive";

            var subscriptionLength = (await _context.Packages.FindAsync(subscription.PackageId)).ValidDays;
            subscription.State = "active";
            subscription.ActiveFrom = DateTime.Now;
            subscription.ActiveTo = DateTime.Now.AddDays(subscriptionLength);
            _context.Subscriptions.Update(subscription);
            await _context.SaveChangesAsync();

            return "SubscriptionActivated";
        }

        public async Task<SubscriptionDto> CreateAsync(CreateSubscriptionDto createSubscriptionDto) {
            var subscription = _mapper.Map<Subscription>(createSubscriptionDto);

            await _context.Subscriptions.AddAsync(subscription);
            await _context.SaveChangesAsync();

            var package = await _context.Packages.FindAsync(subscription.PackageId);
            var packageItems = await _context.PackageItems.Where(x => x.PackageId == subscription.PackageId).ToListAsync();

            packageItems.ForEach(async x =>
            {
                var visit = new Visits
                {
                    SubscriptionId = subscription.Id,
                    PackageItemId = x.Id,
                    VisitsLeft = x.AvailableVisitsCount
                };

                await _context.Visits.AddAsync(visit);
            });

            await _context.SaveChangesAsync();

            var subscriptionDto = _mapper.Map<SubscriptionDto>(subscription);
            return subscriptionDto;
        }

        public async Task<IEnumerable<SubscriptionDto>> GetAsync(int userId) {
            var subscriptions = await _context.Subscriptions.Where(x => x.UserId == userId).ToListAsync();
            var subscriptionsDto = _mapper.Map<List<SubscriptionDto>>(subscriptions);

            return subscriptionsDto;
        }

        public async Task<string> TrackVisit(TrackVisitDto trackVisitDto) {
            var subscription = await _context.Subscriptions.FindAsync(trackVisitDto.SubscriptionId);
            if (subscription is null) return "SubscriptionNotFound";
            if (subscription.State != "active") return "SubscriptionNotActive";

            var visit = await _context.Visits.FirstAsync(x => x.SubscriptionId == trackVisitDto.SubscriptionId && x.PackageItemId == trackVisitDto.PackageItemId);
            if (visit is null) return "VisitNotFound";

            var visitsLeft = visit.VisitsLeft;
            if (visitsLeft == 0) return "NoVisitsLeft";

            visit.VisitsLeft = visitsLeft - 1;

            subscription.RecordedVisits += 1;
            _context.Subscriptions.Update(subscription);
            await _context.SaveChangesAsync();
            return "VisitTracked";
        }
    }
}
