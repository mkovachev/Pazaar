using Pazaar.Domain.Common;

namespace Pazaar.Domain.Model.Ad
{
    public class Image : AuditEntity
    {
        public Image(string url)
        {
            this.Url = url;
        }
        public string Url { get; set; }
    }
}
