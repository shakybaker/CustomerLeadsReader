using System.Collections.Generic;
using System.Linq;
using CL.Models;
using CL.Models.Service;
using CL.Models.Validation;
using Moq;
using NUnit.Framework;

namespace CL.Tests
{
    [TestFixture]
    public class UnitTests
    {
        [Test]
        public void should_be_able_to_obtain_a_collection_of_customer_leads()
        {
            var customers = new List<CustomerLead>
            {
                new CustomerLead
                    {
                        FirstName = "Marge",
                        Lastname = "Simpson",
                        EmailAddress = "marge.simpson@email.com"
                    },
            };

            var customerleadsreaderMock = new Mock<ICustomerLeadsClient>();
            customerleadsreaderMock.Setup(x => x.ReadFile()).Returns(customers);

            var service = new CustomerLeadsService(customerleadsreaderMock.Object);
            var returnedList = service.GetAll();

            Assert.AreEqual(1, returnedList.Count());
        }

        [Test]
        public void should_be_able_to_obtain_a_collection_of_customer_leads_sorted_by_lastname_then_firstname()
        {
            var customers = new List<CustomerLead>
            {
                new CustomerLead
                    {
                        FirstName = "Homer",
                        Lastname = "Simpson",
                        EmailAddress = "homer.simpson@email.com"
                    },
                new CustomerLead
                    {
                        FirstName = "Bart",
                        Lastname = "Simpson",
                        EmailAddress = "bart.simpson@email.com"
                    },
                new CustomerLead
                    {
                        FirstName = "Marge",
                        Lastname = "Simpson",
                        EmailAddress = "marge.simpson@email.com"
                    },
            };
            
            var customerleadsreaderMock = new Mock<ICustomerLeadsClient>();
            customerleadsreaderMock.Setup(x => x.ReadFile()).Returns(customers);

            var service = new CustomerLeadsService(customerleadsreaderMock.Object);
            var returnedList = service.GetAllSorted();

            Assert.AreEqual("Bart", returnedList.First().FirstName);

        }
        
        [Test]
        public void a_firstname_is_supplied()
        {
            var input = new CustomerLead { FirstName = "Homer" };
            var spec = new FirstnameIsSupplied();

            Assert.IsTrue(spec.IsSatisfied(input));

        }

        [Test]
        public void a_firstname_is_not_supplied()
        {
            var input = new CustomerLead();
            var spec = new FirstnameIsSupplied();

            Assert.IsFalse(spec.IsSatisfied(input));

        }

        [Test]
        public void a_lastname_is_supplied()
        {
            var input = new CustomerLead { Lastname = "Homer" };
            var spec = new LastnameIsSupplied();

            Assert.IsTrue(spec.IsSatisfied(input));

        }

        [Test]
        public void a_lastname_is_not_supplied()
        {
            var input = new CustomerLead();
            var spec = new LastnameIsSupplied();

            Assert.IsFalse(spec.IsSatisfied(input));

        }

        [Test]
        public void email_is_not_supplied()
        {
            var input = new CustomerLead();
            var spec = new EmailIsValid();

            Assert.IsFalse(spec.IsSatisfied(input));

        }

        [Test]
        public void email_is_valid()
        {
            var input = new CustomerLead { EmailAddress = "a@a.com" };
            var spec = new EmailIsValid();

            Assert.IsTrue(spec.IsSatisfied(input));

        }

        [Test]
        public void email_has_an_incorrect_format()
        {
            var input = new CustomerLead { EmailAddress = "a@a" };
            var spec = new EmailIsValid();

            Assert.IsFalse(spec.IsSatisfied(input));

        }
        //TODO: more validation rules would be added here for email


        [Test]
        public void customerleads_failing_validation_should_not_be_returned()
        {
            var customers = new List<CustomerLead>
            {
                new CustomerLead
                    {
                        FirstName = "Homer",
                        Lastname = "Simpson",
                        EmailAddress = "homer.simpson@email.com"
                    },
                new CustomerLead
                    {
                        FirstName = null,
                        Lastname = "Simpson",
                        EmailAddress = "a@a.com"
                    },
                new CustomerLead
                    {
                        FirstName = "Maggie",
                        Lastname = null,
                        EmailAddress = "a@a.com"
                    },
                new CustomerLead
                    {
                        FirstName = "Lisa",
                        Lastname = "Simpson",
                        EmailAddress = "a@a"
                    },
            };

            var customerleadsreaderMock = new Mock<ICustomerLeadsClient>();
            customerleadsreaderMock.Setup(x => x.ReadFile()).Returns(customers);

            var service = new CustomerLeadsService(customerleadsreaderMock.Object);
            var returnedList = service.GetAllSorted();

            Assert.AreEqual(1, returnedList.Count());
        }
    }
}
