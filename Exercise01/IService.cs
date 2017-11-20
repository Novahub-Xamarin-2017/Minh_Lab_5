using RestSharp;
using Retrofit.Net.Attributes.Methods;
using Retrofit.Net.Attributes.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise01
{
    public interface IService
    {
        [Post("lists/{idList}/members")]
        RestResponse<bool> AddEmail([Path("idList")] string id, [Body] object obj);

        [Put("campaigns/{idCompaign}/content")]
        RestResponse<bool> SetContent([Path("idCompaign")] string id, [Body] object obj);

        [Post("campaigns/{idCompaign}/actions/send")]
        RestResponse<bool> SendContent([Path("idCompaign")] string id);
    }
}
