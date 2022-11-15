using AutoMapper;
using Span.Culturio.Api.Data.Entities;
using Span.Culturio.Api.Models.Subscriptions;

namespace Span.Culturio.Api.Profiles
{
    public class SubscriptionProfile : Profile
    {

        public SubscriptionProfile()
        {
            CreateMap<CreateSubscriptionDto, Subscription>();
            CreateMap<Subscription, SubscriptionDto>();
        }
    }
}
