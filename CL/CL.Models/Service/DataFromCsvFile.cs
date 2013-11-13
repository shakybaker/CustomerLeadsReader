using System.Collections.Generic;

namespace CL.Models.Service
{
    public class DataFromCsvFile : IDataFactory
    {
        public IEnumerable<CustomerLead> GetData(string filePath)
        {
            //TODO: code to read from csv files would go here
            return new List<CustomerLead>();
        }
    }
}
