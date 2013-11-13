namespace CL.Models.Validation
{
    public class FirstnameIsSupplied : ISpecification<CustomerLead>
    {
        public bool IsSatisfied(CustomerLead customerLead)
        {
            return !string.IsNullOrEmpty(customerLead.FirstName);
        }
    }
}
