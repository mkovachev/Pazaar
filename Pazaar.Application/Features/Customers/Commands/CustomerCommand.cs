namespace Pazaar.Application.Features.Customers.Commands
{
    public abstract class CustomerCommand<TCommand> : EntityCommand<int>
    {
        public string Name { get; private set; } = default!;
        public string Email { get; private set; } = default!;
        public string? PhoneNumber { get; private set; } = default!;
        public string? City { get; private set; } = default!;
        public string? ProfileImage { get; private set; } = default!;
    }
}
