using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview
{
    public interface IGarageService
    {
        Task<string> BookMot(Car car);
    }
}
