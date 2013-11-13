using System.Text.RegularExpressions;

namespace CL.Models.Validation
{
    public class EmailIsValid : ISpecification<CustomerLead>
    {
        private const string Match = "^[a-zA-Z0-9_\\+-]+(\\.[a-zA-Z0-9_\\+-]+)*@[a-zA-Z0-9-]+(\\.[a-zA-Z0-9-]+)*\\.([a-zA-Z]{2,4})$";

        public bool IsSatisfied(CustomerLead customerLead)
        {
            return !string.IsNullOrEmpty(customerLead.EmailAddress) && Regex.IsMatch(customerLead.EmailAddress, Match);
        }
    }
}
