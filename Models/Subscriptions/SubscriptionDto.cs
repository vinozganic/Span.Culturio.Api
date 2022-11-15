namespace Span.Culturio.Api.Models.Subscriptions
{
    public class SubscriptionDto
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string PackageId { get; set; }
        public string Name { get; set; }
        public DateTime ActiveFrom { get; set; }
        public DateTime ActiveTo { get; set; }
        public string State { get; set; }
        public int RecordedVisits { get; set; }
    }
}
