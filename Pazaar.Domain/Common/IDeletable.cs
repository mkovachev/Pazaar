using System;

namespace Pazaar.Domain.Common
{
    internal interface IDeletable
    {
        DateTime DeletedOn { get; set; }

        bool IsDeleted { get; set; }
    }
}
