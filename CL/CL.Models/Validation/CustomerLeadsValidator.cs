namespace CL.Models.Validation
{
    public class CustomerLeadsValidator 
    {
        private readonly CustomerLead _customerLead;

        public CustomerLeadsValidator(CustomerLead customerLead)
        {
            _customerLead = customerLead;
        }

        public bool Passes()
        {
            return (new FirstnameIsSupplied().IsSatisfied(_customerLead)) &&
                    (new LastnameIsSupplied().IsSatisfied(_customerLead)) &&
                    (new EmailIsValid().IsSatisfied(_customerLead));
        }
    }
}
