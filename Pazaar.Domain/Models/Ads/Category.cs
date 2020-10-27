using Pazaar.Domain.Common;

namespace Pazaar.Domain.Models.Ads
{
    public class Category : AuditEntity
    {
        internal Category(string name)
        {
            this.Name = name;
        }

        public string Name { get; }
    }
}
