using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using System.Collections.Generic;
using System.Net;
using Newtonsoft.Json;

namespace RESTSharpTests
{
    public class Employee
    {
        public int id { get; set; }
        public string name { get; set; }
        public string salary { get; set; }
    }

    [TestClass]
    public class UnitTest1
    {
        RestClient client;

        [TestInitialize]
        public void Setup()
        {
            client = new RestClient("http://localhost:4000");
        }

        public IRestResponse GetEmployeeList()
        {
            //arrange
            RestRequest request = new RestRequest("/employee", Method.GET);
            
            //act
            IRestResponse response = client.Execute(request);
            return response;
        }

        /// <summary>
        /// Test case to retrieve all employee using json server and match result by asserting
        /// </summary>
        [TestMethod]
        public void onCallingGETApi_ReturnEmployeeList()
        { 
            IRestResponse response = GetEmployeeList();
            //assert
            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
            List<Employee> dataResponse = JsonConvert.DeserializeObject<List<Employee>>(response.Content);
            Assert.AreEqual(11, dataResponse.Count);
            foreach(Employee e in dataResponse)
            {
                System.Console.Write("id: " +e.id + "Name: " + e.name + "Salary: " + e.salary);
            }
        }

    }
}
