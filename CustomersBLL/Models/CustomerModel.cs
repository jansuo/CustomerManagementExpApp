using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomersBLL.Models
{
    public record CustomerModel
    {
        public Guid Id { get; init; }
        public string Company { get; init; }
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public string Email { get; init; }
        public string Mobile { get; init; }
    }
}
