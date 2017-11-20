using RestSharp;
using Retrofit.Net.Attributes.Methods;
using Retrofit.Net.Attributes.Parameters;
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
        RestResponse<List<User>> GetUsers();

        [Get("users/{id}")]
        RestResponse<User> GetUser([Path("id")] int id);

        [Post("users")]
        RestResponse<bool> EditUser([Body] object obj);

        [Put("users/{id}")]
        RestResponse<bool> UpdateUser([Path("id")] int id, [Body] object obj);

        [Delete("users/{id}")]
        RestResponse<bool> DeleteUser([Path("id")] int id);
    }
}
