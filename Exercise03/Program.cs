using Exercise03.Model;
using Newtonsoft.Json;
using RestSharp;
using Retrofit.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise03
{
    class Program
    {
        static void Main(string[] args)
        {
            var restClient = new RestClient("http://api.openweathermap.org/data/2.5/");
            restClient.Authenticator = new HttpBasicAuthenticator("Default", "32e86d2782c009304019c7b0526d0155");
            restClient.AddDefaultHeader("content-type", "application/json; charset=utf-8");
            restClient.AddDefaultHeader("charset", "utf-8");

            var adapter = new RestAdapter(restClient); 
            var service = adapter.Create<IService>();

            var response = service.GetWeatherFollowGeoLocation("16","108");
            Console.WriteLine($"Request: {response.ResponseStatus}");
            Console.WriteLine(response.Content);

            response = service.GetWeatherFollowId("1905468");
            Console.WriteLine($"Request: {response.ResponseStatus}");
            Console.WriteLine(response.Content);

            response = service.GetWeatherFollowZipCode("70055");
            Console.WriteLine($"Request: {response.ResponseStatus}");
            Console.WriteLine(response.Content);

            response = service.GetWeatherFollowCityName("Danang");
            Console.WriteLine($"Request: {response.ResponseStatus}");
            Console.WriteLine(response.Content);
            Console.ReadKey();
        }
    }
}
