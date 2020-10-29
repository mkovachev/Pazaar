using Pazaar.Domain.Common;

namespace Pazaar.Domain.Models.Ads
{
    public class Category : AuditableEntity
    {
        internal Category(string name)
        {
            this.Name = name;
        }

        public int Id { get; }
        public string Name { get; }
    }
}
