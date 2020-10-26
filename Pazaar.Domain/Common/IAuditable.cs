using System;

namespace Pazaar.Domain.Common
{
    internal interface IAuditable
    {
        DateTime CreatedOn { get; set; }

        DateTime ModifiedOn { get; set; }
    }
}
