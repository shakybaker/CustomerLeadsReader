namespace CL.Models.Validation
{
    public class LastnameIsSupplied : ISpecification<CustomerLead>
    {
        public bool IsSatisfied(CustomerLead customerLead)
        {
            return !string.IsNullOrEmpty(customerLead.Lastname);
        }
    }
}
