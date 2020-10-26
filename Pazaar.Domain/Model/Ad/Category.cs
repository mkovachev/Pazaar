using Pazaar.Domain.Common;

namespace Pazaar.Domain.Model.Ad
{
    public class Category : AuditEntity
    {
        public Category(string name)
        {
            this.Name = name;
        }

        public string Name { get; }
    }
}
