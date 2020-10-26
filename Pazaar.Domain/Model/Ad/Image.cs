using Pazaar.Domain.Common;

namespace Pazaar.Domain.Model.Ad
{
    public class Image : AuditEntity
    {
        public string Url { get; private set; } = default!;
    }
}
