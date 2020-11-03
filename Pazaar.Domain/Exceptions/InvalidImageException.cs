namespace Pazaar.Domain.Exceptions
{
    public class InvalidImageException : BaseDomainException
    {
        public InvalidImageException()
        {
        }

        public InvalidImageException(string error) => this.Error = error;
    }
}
