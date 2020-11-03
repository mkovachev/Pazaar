using Pazaar.Domain.Common;
using Pazaar.Domain.Exceptions;

namespace Pazaar.Domain.Models.Ads
{
    public class Image : AuditableEntity
    {
        internal Image(string url)
        {
            ValidateUrl(url);
            this.Url = url;
        }

        public int Id { get; private set; }
        public string Url { get; private set; }

        public Image UpdateUrl(string url)
        {
            ValidateUrl(url);
            this.Url = url;
            return this;
        }

        public void ValidateUrl(string url)
        {
            Guard.ForValidUrl<InvalidImageException>(url);
        }
    }
}
