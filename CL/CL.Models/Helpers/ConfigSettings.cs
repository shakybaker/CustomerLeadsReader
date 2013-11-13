using System.Configuration;
using System.IO;

namespace CL.Models.Helpers
{
    public class ConfigSettings
    {
        public ConfigSettings() {}

        public string FilePath { get; set; }
        public string FileExtension { get; set; }

        public ConfigSettings PopulateFromConfig()
        {
            FilePath = ConfigurationManager.AppSettings["FileFolder"];
            FileExtension = Path.GetExtension(FilePath);

            return this;
        }
    }
}
