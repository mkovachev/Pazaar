using System;

namespace Pazaar.Domain.Common
{
    public abstract class Entity : IAuditable, IDeletable
    {
        public int Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime ModifiedOn { get; set; }

        public DateTime DeletedOn { get; set; }

        public bool IsDeleted { get; set; }

    }
}
