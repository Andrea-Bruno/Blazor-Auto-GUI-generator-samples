using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace API
{
    /// <summary>
    /// API Client Factory to manage HttpClient instances efficiently.
    /// </summary>
    public class APIClientFactory
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public APIClientFactory()
        {
            var services = new ServiceCollection();
            services.AddHttpClient();
            var serviceProvider = services.BuildServiceProvider();
            _httpClientFactory = serviceProvider.GetRequiredService<IHttpClientFactory>();
        }

        public HttpClient CreateClient() => _httpClientFactory.CreateClient();
    }

    /// <summary>
    /// API consumer client for interacting with API methods.
    /// </summary>
    public class ApiProviderAPIClient
    {
        private readonly APIClientFactory _clientFactory;
        private readonly string _apiEntryPoint;

        /// <summary>
        /// Initializes a new instance of <see cref="ApiProviderAPIClient"/>.
        /// </summary>
        /// <param name="apiEntryPoint">Base API URL.</param>
        public ApiProviderAPIClient(string apiEntryPoint)
        {
            _clientFactory = new APIClientFactory();
            _apiEntryPoint = apiEntryPoint;
        }

        /// <summary>
        /// Add a new record to the database
        /// </summary>
        /// <param name="nameAndSurname">First and last name for the item to add</param>
        /// <param name="email">Email address referring to the person</param>
        /// <returns>True if the operation was successful</returns>
        public async Task<bool> AddNewRecord(String nameAndSurname, String email)
        {
            using var httpClient = _clientFactory.CreateClient();
            var requestData = new {
                nameAndSurname = nameAndSurname,
                email = email,
            };
            var jsonContent = new StringContent(JsonSerializer.Serialize(requestData), Encoding.UTF8, "application/json");
            using var response = await httpClient.PostAsync(_apiEntryPoint + "/addnewrecord", jsonContent).ConfigureAwait(false);
            return response.IsSuccessStatusCode;
        }

        /// <summary>
        /// Get the electronic mail address associated with a name and surname
        /// </summary>
        /// <param name="nameAndSurname">Name and surname of the person whose email address you want to obtain</param>
        /// <returns>Email address</returns>
        public async Task<String> GetEmail(String nameAndSurname)
        {
            using var httpClient = _clientFactory.CreateClient();
            var requestData = new {
                nameAndSurname = nameAndSurname,
            };
            var jsonContent = new StringContent(JsonSerializer.Serialize(requestData), Encoding.UTF8, "application/json");
            using var response = await httpClient.PostAsync(_apiEntryPoint + "/getemail", jsonContent).ConfigureAwait(false);
            var responseData = await response.Content.ReadAsStringAsync();
            if (string.IsNullOrWhiteSpace(responseData)) return default;
            return JsonDocument.Parse(responseData).RootElement.GetProperty("result").GetString();
        }

        /// <summary>
        /// Delete a record from the database
        /// </summary>
        /// <param name="nameAndSurname">Name and surname referring to the record to be deleted</param>
        /// <returns>True if the operation was successful</returns>
        public async Task<Boolean> DeleteRecord(String nameAndSurname)
        {
            using var httpClient = _clientFactory.CreateClient();
            var requestData = new {
                nameAndSurname = nameAndSurname,
            };
            var jsonContent = new StringContent(JsonSerializer.Serialize(requestData), Encoding.UTF8, "application/json");
            using var response = await httpClient.PostAsync(_apiEntryPoint + "/deleterecord", jsonContent).ConfigureAwait(false);
            var responseData = await response.Content.ReadAsStringAsync();
            if (string.IsNullOrWhiteSpace(responseData)) return default;
            return JsonDocument.Parse(responseData).RootElement.GetProperty("result").GetBoolean();
        }

    }
}
