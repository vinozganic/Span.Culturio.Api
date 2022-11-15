namespace Span.Culturio.Api.Models.CultureObject
{
    public class CultureObjectDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ContactEmail { get; set; }
        public string Address { get; set; }
        public int ZipCode { get; set; }
        public string City { get; set; }
        public int AdminUserId { get; set; }
    }
}
