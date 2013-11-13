using System.Collections.Generic;
using System.Linq;
using CL.Models.Helpers;
using CL.Models.Validation;

namespace CL.Models.Service
{
    public class CustomerLeadsService
    {
        private readonly ICustomerLeadsClient _customerLeadsClient;

        public CustomerLeadsService(ICustomerLeadsClient customerLeadsClient)
        {
            _customerLeadsClient = customerLeadsClient;
        }

        public virtual IEnumerable<CustomerLead> GetAll()
        {
            var allCustomerLeads = _customerLeadsClient.ReadFile();
            return allCustomerLeads.Where(customerLead => new CustomerLeadsValidator(customerLead).Passes());
        }

        public virtual IEnumerable<CustomerLead> GetAllSorted()
        {
            var list = GetAll().ToList();
            if (list.Count > 0)
                list.Sort(new CustomerLeadSorter());

            return list;
        }
    }
}
