using Pazaar.Domain.Common;
using Pazaar.Domain.Exceptions;

namespace Pazaar.Domain.Models.Ads
{
    using static ModelConstants.Category;

    public class Category : AuditableEntity
    {
        internal Category(string name)
        {
            ValidateName(name);
            this.Name = name;
        }

        public int Id { get; private set; }
        public string Name { get; private set; }

        public Category UpdateName(string name)
        {
            ValidateName(name);
            this.Name = name;
            return this;
        }

        public void ValidateName(string name)
        {
            Guard.ForStringLength<InvalidCategoryException>(name, NameMinLength, NameMaxLength);
        }
    }
}
