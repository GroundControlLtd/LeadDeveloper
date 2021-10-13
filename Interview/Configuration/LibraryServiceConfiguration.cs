using Interview.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.Configuration
{
    public class LibraryServiceConfiguration : ILibraryServiceConfiguration
    {
        public string BaseUrl => ConfigurationManager.AppSettings["LibraryServiceBaseUrl"];
        public string ServiceEndpoint => ConfigurationManager.AppSettings["LibraryServiceEndPoints"];

    }
}
