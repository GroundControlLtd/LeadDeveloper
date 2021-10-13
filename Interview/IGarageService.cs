using System.Threading.Tasks;
using Shared;

namespace Interview
{
    public interface IGarageService
    {
        Task<string> BookMot(Car car);
    }
}