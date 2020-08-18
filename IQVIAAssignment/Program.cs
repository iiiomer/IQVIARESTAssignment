using System;
using System.IO;
using ConsoleApplication1;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace IQVIAAssignment
{
    class Program
    {
        static void Main(string[] args)
        {
            
            using (var sr = File.OpenText(@"C:\Dummy Data.txt"))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    var EmpsArray = line.Split(',');

                    var emp = new Employee()
                    {
                        Name = EmpsArray[0],
                        Salary = EmpsArray[1],
                        Age = EmpsArray[2]
                    };

                    CreateEmployee(emp);
                }
            }

        }

        private static void CreateEmployee(Employee e)
        {
            //Url
            var client = new RestClient("	http://dummy.restapiexample.com/api/v1/create");

            client.Timeout = 90000;

            var request = new RestRequest(Method.POST);

            //Request Json
            JObject jObjectBody = new JObject();
            jObjectBody.Add("name", e.Name);
            jObjectBody.Add("salary", e.Salary);
            jObjectBody.Add("age", e.Age);

            request.Parameters.Clear();



            //Add Json to the request
            request.AddParameter("application/json", jObjectBody, ParameterType.RequestBody);



            //Execute the request and get the result
            IRestResponse response = client.Execute(request);

            //Mapping response to object

            var createEmpRes = JsonConvert.DeserializeObject<CreateEmpResponse>(response.Content);
            Console.WriteLine(createEmpRes.Data.Name + " Created Successfully!");
        }
    }
}
