using System.Collections.Generic;

namespace CL.Models.Helpers
{
    public class CustomerLeadSorter : IComparer<CustomerLead>
    {
        public int Compare(CustomerLead a, CustomerLead b)
        {
            int compare = string.Compare(a.Lastname, b.Lastname);
            if (compare == 0)
                compare = string.Compare(a.FirstName, b.FirstName);

            return compare;
        }
    }
}
