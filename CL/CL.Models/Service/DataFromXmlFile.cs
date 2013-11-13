using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace CL.Models.Service
{
    public class DataFromXmlFile : IDataFactory
    {
        public IEnumerable<CustomerLead> GetData(string filePath)
        {
            var xdoc = XDocument.Load(filePath);
            var list = from xelement in xdoc.Elements("CustomerLeads").Elements("CustomerLead")
                       select new CustomerLead
                       {
                           FirstName = GetElement("FirstName", xelement),
                           EmailAddress = GetElement("Email", xelement),
                           Lastname = GetElement("LastName", xelement)
                       };

            return list;
        }

        private static string GetElement(string elementName, XElement xElement)
        {
            try
            {
                return xElement.Element(elementName).Value;
            }
            catch (NullReferenceException)
            {
                return string.Empty;
            }
        }
    }
}
