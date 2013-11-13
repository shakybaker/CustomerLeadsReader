using System.Linq;
using CL.Models.Helpers;
using CL.Models.Service;
using NUnit.Framework;
using StructureMap;

namespace CL.IntegrationTests
{
    [TestFixture]
    public class IntegrationTests
    {
        [SetUp]
        public void Initialize()
        {
            ObjectFactory.Initialize(x => x.AddRegistry(new IocRegistry()));
        }

        [Test]
        public void should_be_able_to_open_and_read_from_a_customer_leads_xml_file()
        {
            var settings = new ConfigSettings { FilePath = @"..\..\potentialcustomers.xml", FileExtension = "xml" };
            var customerleadsreader = new CustomerLeadsClient(settings);
            var service = new CustomerLeadsService(customerleadsreader);
            var returnedList = service.GetAll();

            Assert.IsNotEmpty(returnedList.ToList());
        }

        [Test]
        public void an_unsupported_filetype_returns_an_empty_list()
        {
            var settings = new ConfigSettings { FileExtension = "doc" };
            var customerleadsreader = new CustomerLeadsClient(settings);
            var service = new CustomerLeadsService(customerleadsreader);
            var returnedList = service.GetAll();

            Assert.IsEmpty(returnedList.ToList());
        }
    }
}
