using RestSharp;
using Retrofit.Net.Attributes.Methods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise02.Model
{
    public interface IUserService
    {
        [Get("users")]
        RestResponse<List<User>> GetUser();
    }
}
