using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomersDAL.Results
{
    public record CreateCustomerResult
    {
        public Guid Id { get; set; }
    }
}
