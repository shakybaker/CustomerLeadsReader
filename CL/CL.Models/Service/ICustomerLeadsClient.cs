using System.Collections.Generic;

namespace CL.Models.Service
{
    public interface ICustomerLeadsClient
    {
        IEnumerable<CustomerLead> ReadFile();
    }
}
