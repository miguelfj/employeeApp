using EmployeesApp.Core.Configuration;
using EmployeesApp.Core.DTOs;
using EmployeesApp.Core.Interfaces.Factories;
using EmployeesApp.Core.Interfaces.HttpRequests;
using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;

namespace EmployeesApp.DataAccess.HttpRequests
{
    public sealed class GetEmployeesRequest : IGetEmployeesRequest
    {
        private readonly IRestClient _client;

        public GetEmployeesRequest(IRestClientFactory restClientFactory, HttpRequestConfiguration httpRequestConfiguration)
        {
            _client = restClientFactory.Create(httpRequestConfiguration.GetEmployeesUrl);
        }
        public IEnumerable<EmployeeResponseDto> Execute()
        {
            RestRequest request = CreateRequest();
            IRestResponse response = _client.Execute(request);

            return JsonConvert.DeserializeObject<IEnumerable<EmployeeResponseDto>>(response.Content);
        }

        private static RestRequest CreateRequest()
        {
            var request = new RestRequest(Method.GET);
            request.AddHeader("Postman-Token", "9f67874a-fcec-4def-baef-af45e9725b9a");
            request.AddHeader("cache-control", "no-cache");

            return request;
        }
    }
}
