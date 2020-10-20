using EmployeesApp.Core.Interfaces.Factories;
using RestSharp;

namespace EmployeesApp.Core.Factories
{
    public class RestClientFactory : IRestClientFactory
    {
        public IRestClient Create(string url)
        {
            return new RestClient(url);
        }
    }
}
