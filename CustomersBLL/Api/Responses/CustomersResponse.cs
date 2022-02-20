using CustomersBLL.Api.Models;
using System.Collections;
using System.Collections.Generic;

namespace CustomersBLL.Api.Responses
{
    public record CustomersResponse : IReadOnlyList<Customer>
    {
        public Customer this[int index] => throw new System.NotImplementedException();

        public int Count => throw new System.NotImplementedException();

        public IEnumerator<Customer> GetEnumerator()
        {
            throw new System.NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new System.NotImplementedException();
        }
    }
}
