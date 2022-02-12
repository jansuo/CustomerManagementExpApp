using System.Collections.Generic;

namespace CustomersAPI.Errors
{
    public struct CustomerValidationError
    {
        public IReadOnlyList<string> Messages { get; init; }
    }
}
