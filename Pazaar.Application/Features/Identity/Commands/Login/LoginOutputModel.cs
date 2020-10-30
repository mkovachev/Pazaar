namespace Pazaar.Application.Features.Identity.Commands.Login
{
    public class LoginOutputModel
    {
        public LoginOutputModel(string token, int customerId)
        {
            this.Token = token;
            this.CustomerId = customerId;
        }

        public int CustomerId { get; }

        public string Token { get; }
    }
}
