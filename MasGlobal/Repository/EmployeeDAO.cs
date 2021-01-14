using System;
using System.Collections.Generic;
using System.Net.Http;
using MasGlobal.Repository.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace MasGlobal.Repository
{
    public class EmployeeDAO : IEmployeeDAO
    {
        private readonly ILogger<List<Employee>> _logger;
        private readonly IConfiguration _configuration;
        private readonly string apiBaseUrl;

        public EmployeeDAO(ILogger<List<Employee>> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
            apiBaseUrl = _configuration.GetValue<string>("WebAPIBaseUrl");
        }


        public List<Employee> GetEmployees()
        {
            HttpClient client = new HttpClient();
            string endpoint = apiBaseUrl;
            List<Employee> result = null;

            try
            {
                var response = client.GetAsync(endpoint).Result;

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    result = JsonConvert.DeserializeObject<List<Employee>>(data);
                }
                else
                {
                    _logger.LogError($"The Employee API response was not valid. URL: {apiBaseUrl}. REQUEST METHOD: GET");
                    throw new Exception("Something went wrong! Coudln't retrive employees information.");
                }

                return result;
            }
            catch(Exception ex)
            {
                _logger.LogError($"Failed to connect to the Employee API. URL: {apiBaseUrl}. Error: {ex.Message}. INNER EXCEPTION: {ex.InnerException}");
                throw new Exception("Something went wrong! Coudln't retrive employees information.");
            }
        }
    }
}
