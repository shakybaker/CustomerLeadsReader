using CL.Models.Service;
using Registry = StructureMap.Configuration.DSL.Registry;

namespace CL.Models.Helpers
{
    public class IocRegistry : Registry
    {
        public IocRegistry()
        {
            For<ConfigSettings>()
                .Singleton()
                .Use(x => new ConfigSettings().PopulateFromConfig());
            For<ICustomerLeadsClient>()
                .Use<CustomerLeadsClient>();
        }
    }
}
