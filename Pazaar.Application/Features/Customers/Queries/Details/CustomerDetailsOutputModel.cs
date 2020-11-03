namespace Pazaar.Application.Features.Customers.Queries.Details
{
    public class CustomerDetailsOutputModel
    {
        public int Id { get; private set; }
        public string Name { get; private set; } = default!;
        public string Email { get; private set; } = default!;
        public string PhoneNumber { get; private set; } = default!;
        public string City { get; private set; } = default!;
        public string ProfileImage { get; private set; } = default!;
    }
}
