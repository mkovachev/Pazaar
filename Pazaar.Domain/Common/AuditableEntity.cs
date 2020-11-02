using System;

namespace Pazaar.Domain.Common
{
    public abstract class AuditableEntity
    {
        public DateTime CreatedOn { get; set; }

        public DateTime ModifiedOn { get; set; }

        public DateTime DeletedOn { get; set; }

        public bool IsDeleted { get; set; }

        public string? LastModifiedBy { get; set; } = default!;
        public string? CreatedBy { get; set; } = default!;
        public string? DeleteBy { get; set; } = default!;
    }
}
