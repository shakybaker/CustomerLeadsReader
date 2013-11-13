using System.Collections.Generic;
using CL.Models.Helpers;

namespace CL.Models.Service
{
    public class CustomerLeadsClient : ICustomerLeadsClient
    {
        private readonly ConfigSettings _settings;

        public CustomerLeadsClient(ConfigSettings settings)
        {
            _settings = settings;
        }

        public virtual IEnumerable<CustomerLead> ReadFile()
        {
            switch (_settings.FileExtension)
            {
                case "xml":
                    var xmlFactory = new DataFromXmlFile();
                    return xmlFactory.GetData(_settings.FilePath);
                case "csv":
                    var csvFactory = new DataFromCsvFile();
                    return csvFactory.GetData(_settings.FilePath);
                default:
                    return new List<CustomerLead>();
            }
        }
    }
}
