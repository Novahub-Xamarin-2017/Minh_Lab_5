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
        public static object obj { set; get; }

        static void Main(string[] args)
        {
            RestAdapter adapter = new RestAdapter(@"https://jsonplaceholder.typicode.com/");
            IUserService service = adapter.Create<IUserService>();
            RestResponse<List<User>> userResponse = service.GetUser();
            List<User> listUser = userResponse.Data;
            listUser.ForEach(Console.WriteLine);
            Console.ReadKey();
        }
    }
}
