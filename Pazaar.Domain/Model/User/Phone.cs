using Pazaar.Domain.Common;

namespace Pazaar.Domain.Model.User
{
    public class Phone : EntityAudit
    {
        internal Phone(string number)
        {
            this.Number = number;
        }

        public string Number { get; private set; }

        public static implicit operator Phone(string number) => new Phone(number);

    }
}