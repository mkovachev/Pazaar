namespace Pazaar.Domain.Exceptions
{
    public class InvalidCustomerException : BaseDomainException
    {
        public InvalidCustomerException()
        {
        }

        public InvalidCustomerException(string error) => this.Error = error;
    }
}
