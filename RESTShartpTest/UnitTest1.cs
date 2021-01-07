using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using System.Collections.Generic;
using System.Net;

namespace RESTSharpTest
{
    public class Employee
    {
        public string id { get; set; }
        public string name { get; set; }
        public string salary { get; set; }
    }

    public class Tests
    {
        RestClient client;

        [SetUp]
        public void Setup()
        {
            client = new RestClient("http://localhost:4000/employee");
        }

        public IRestResponse GetEmployeeList()
        {
            RestRequest request = new RestRequest("/employee", Method.GET);
            IRestResponse response = client.Execute(request);
            return response;
        }

        [Test]
        public void onCallingGETApi_ReturnEmployeeList()
        {
            IRestResponse response = GetEmployeeList();
            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
            List<Employee> dataResponse = JsonConvert.DeserializeObject<List<Employee>>(response.Content);
            Assert.AreEqual(7, dataResponse.Count);
        }

    }
}