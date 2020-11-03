using Pazaar.Domain.Common;

namespace Pazaar.Domain.Models.Ads
{
    public class Image : AuditableEntity
    {
        internal Image(string url)
        {
            this.Url = url;
        }

        public int Id { get; private set; }
        public string Url { get; private set; }
    }
}
