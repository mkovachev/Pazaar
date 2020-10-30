using Pazaar.Domain.Common;

namespace Pazaar.Domain.Models.Ads
{
    public class Image : AuditableEntity
    {
        internal Image(string name, string url)
        {
            this.Name = name;
            this.Url = url;
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Url { get; private set; }
    }
}
