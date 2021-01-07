using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using System.Collections.Generic;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace RESTSharpTests
{
    public class Employee
    {
        public int id { get; set; }
        public string name { get; set; }
        public string salary { get; set; }

        public Employee(string name, string salary)
        {
            this.name = name;
            this.salary = salary;
        }
       
        /// <summary>
        /// Method to add employee to the list 
        /// </summary>
        /// <returns></returns>
        public static List<Employee> EmployeeList()
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee("Sejal", "30000"));
            employees.Add(new Employee("Komal", "50000"));
            employees.Add(new Employee("Rama", "55000"));
            employees.Add(new Employee("Rakhi", "45000"));
            return employees;
        }
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

        /// <summary>
        /// Test Case to add new Employee using JsonServer and RESTSharp
        /// </summary>
        [TestMethod]
        public void GivenEmployee_OnPost_ShouldReturnAddedEmpl()
        {
            RestRequest request = new RestRequest("/employee", Method.POST);
            JObject jObjectbody = new JObject();
            jObjectbody.Add("name", "Clark");
            jObjectbody.Add("Salary", "15000");
            request.AddParameter("application/json", jObjectbody, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            Assert.AreEqual(response.StatusCode, HttpStatusCode.Created);
            Employee dataResponse = JsonConvert.DeserializeObject<Employee>(response.Content);
            Assert.AreEqual("Clark", dataResponse.name);
            Assert.AreEqual("15000", dataResponse.salary);
            System.Console.WriteLine(response.Content);
        }

        /// <summary>
        /// Test Case to add multiple new Employees using JsonServer and RESTSharp
        /// </summary>
        [TestMethod]
        public void GivenEmployee_OnPost_ShouldReturnMultipleAddedEmployee()
        {
            List<Employee> list = Employee.EmployeeList();
            foreach (Employee e in list)
            {
                RestRequest request = new RestRequest("/employee", Method.POST);
                JObject jObjectbody = new JObject();
                jObjectbody.Add("name", e.name);
                jObjectbody.Add("Salary",e.salary);
                request.AddParameter("application/json", jObjectbody, ParameterType.RequestBody);
                client.Execute(request);               
            }
            IRestResponse responses = GetEmployeeList();
            Assert.AreEqual(responses.StatusCode, HttpStatusCode.OK);
            List<Employee> dataResponse = JsonConvert.DeserializeObject<List<Employee>>(responses.Content);
            Assert.AreEqual(10, dataResponse.Count);
            foreach (Employee e in dataResponse)
            {
                System.Console.Write("id: " + e.id + "Name: " + e.name + "Salary: " + e.salary);
            }
        }

        /// <summary>
        /// Test Case to Update Employee  Salary using JsonServer and RESTSharp
        /// </summary>
        [TestMethod]
        public void GivenEmployee_OnPut_ShouldReturnUpdatedEmpDetails()
        {
            RestRequest request = new RestRequest("/employee/3", Method.PUT);
            JObject jObjectbody = new JObject();
            jObjectbody.Add("name", "Arti");
            jObjectbody.Add("Salary", "45000");
            request.AddParameter("application/json", jObjectbody, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
            Employee dataResponse = JsonConvert.DeserializeObject<Employee>(response.Content);
            Assert.AreEqual("Arti", dataResponse.name);
            Assert.AreEqual("45000", dataResponse.salary);
            System.Console.WriteLine(response.Content);
        }

        /// <summary>
        /// Test Case to Delete Employee Details using JsonServer and RESTSharp
        /// </summary>
        [TestMethod]
        public void GivenEmployee_OnDelete_ShouldEmpDetails()
        {
            RestRequest request = new RestRequest("/employee/7", Method.DELETE);
            IRestResponse response = client.Execute(request);
            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
            IRestResponse responses = GetEmployeeList();
            Assert.AreEqual(responses.StatusCode, HttpStatusCode.OK);
            List<Employee> dataResponse = JsonConvert.DeserializeObject<List<Employee>>(responses.Content);
            Assert.AreEqual(9, dataResponse.Count);
            foreach (Employee e in dataResponse)
            {
                System.Console.Write("id: " + e.id + "Name: " + e.name + "Salary: " + e.salary);
            }
        }
    }
}
