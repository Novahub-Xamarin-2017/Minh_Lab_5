using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Retrofit;
using System.Net.Http;
using Retrofit.Net;
using Exercise02.Model;
using RestSharp;

namespace Exercise02
{
    class Program
    {
        static void Main(string[] args)
        {
            var adapter = new RestAdapter("https://jsonplaceholder.typicode.com/");
            var service = adapter.Create<IUserService>();
            var response = service.GetUsers();
            Console.WriteLine($"Request: {response.ResponseStatus}");
            var listOfUser = response.Data;
            listOfUser.ForEach(Console.WriteLine);
            var response2 = service.GetUser(1);
            var user = response2.Data;
            Console.WriteLine(user.ToString());
            Console.WriteLine($"Request: {response2.ResponseStatus}");
            var response3 = service.EditUser(new { name = "minh" });
            Console.WriteLine($"Request: {response3.ResponseStatus}");
            response3 = service.UpdateUser(1, new { name = "minh" });
            Console.WriteLine($"Request: {response3.ResponseStatus}");
            response3 = service.DeleteUser(1);
            Console.WriteLine($"Request: {response3.ResponseStatus}");
            Console.ReadKey();
        }
    }
}
