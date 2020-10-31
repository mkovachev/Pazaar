using System.Collections.Generic;
using System.Linq;

namespace Pazaar.Application.Models
{
    public class Result
    {
        private readonly List<string> errors;

        internal Result(bool succeeded, List<string> errors)
        {
            this.Succeeded = succeeded;
            this.errors = errors;
        }

        public bool Succeeded { get; }

        public List<string> Errors
            => this.Succeeded
                ? new List<string>()
                : this.errors;

        public static Result Success
            => new Result(true, new List<string>());

        public static Result Failure(IEnumerable<string> errors)
            => new Result(false, errors.ToList());

        // convert to string
        public static implicit operator Result(string error)
            => Failure(new List<string> { error });

        // convert to List<sting>
        public static implicit operator Result(List<string> errors)
            => Failure(errors.ToList());
    }
}