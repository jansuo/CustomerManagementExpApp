using System.Collections.Generic;

namespace CustomersAPI.Errors
{
    public record CustomerValidationError
    {
        public IReadOnlyList<string> Messages { get; init; }
    }
}
