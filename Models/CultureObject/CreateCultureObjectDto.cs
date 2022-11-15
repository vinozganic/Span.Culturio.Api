using FluentValidation;

namespace Span.Culturio.Api.Models.CultureObject
{
    public class CreateCultureObjectDto
    {
        public string Name { get; set; }
        public string ContactEmail { get; set; }
        public string Address { get; set; }
        public int ZipCode { get; set; }
        public string City { get; set; }
        public int AdminUserId { get; set; }
    }

    public class CreateCultureObjectValidator : AbstractValidator<CreateCultureObjectDto>
    {
        public CreateCultureObjectValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
            RuleFor(x => x.ContactEmail).NotEmpty().MaximumLength(25);
            RuleFor(x => x.ZipCode).NotEmpty().GreaterThanOrEqualTo(1);
            RuleFor(x => x.Address).NotEmpty().MaximumLength(250);
            RuleFor(x => x.City).NotEmpty().MaximumLength(250);
            RuleFor(x => x.AdminUserId).NotEmpty().GreaterThanOrEqualTo(1);
        }
    }
}
