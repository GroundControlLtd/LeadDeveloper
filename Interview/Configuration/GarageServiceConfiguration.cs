using Interview.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview
{
    public class GarageServiceConfiguration : IGarageServiceConfiguration
    {
        public string BaseUrl => ConfigurationManager.AppSettings["GarageServiceBaseUrl"];
        public string ServiceEndpoint => ConfigurationManager.AppSettings["GarageServiceEndPoints"];

    }
}
