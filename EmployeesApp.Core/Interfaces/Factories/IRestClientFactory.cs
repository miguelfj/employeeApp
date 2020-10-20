using RestSharp;

namespace EmployeesApp.Core.Interfaces.Factories
{
    public interface IRestClientFactory
    {
        IRestClient Create(string url);
    }
}