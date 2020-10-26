﻿using System;

namespace Pazaar.Domain.Common
{
    public abstract class AuditEntity : IAuditable, IDeletable
    {
        public DateTime CreatedOn { get; set; }

        public DateTime ModifiedOn { get; set; }

        public DateTime DeletedOn { get; set; }

        public bool IsDeleted { get; set; }

    }
}