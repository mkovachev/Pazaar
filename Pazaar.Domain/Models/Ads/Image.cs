using Pazaar.Domain.Common;

namespace Pazaar.Domain.Models.Ads
{
    public class Image : AuditEntity
    {
        internal Image(string url)
        {
            this.Url = url;
        }
        public string Url { get; }
    }
}
