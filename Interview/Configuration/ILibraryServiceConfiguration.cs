using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.Interfaces
{
   public interface ILibraryServiceConfiguration
    {
       public string BaseUrl { get; }
        public string ServiceEndpoint { get; }
    }
}
