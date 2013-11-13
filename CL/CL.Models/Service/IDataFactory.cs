using System.Collections.Generic;

namespace CL.Models.Service
{
    public interface IDataFactory
    {
        IEnumerable<CustomerLead> GetData(string filePath);
    }
}
