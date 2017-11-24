using Exercise07.Model;
using RestSharp;
using Retrofit.Net.Attributes.Methods;
using Retrofit.Net.Attributes.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise07.Model
{
    public interface IBusService
    {
        [Get("bus-services.json")]
        RestResponse<BusService> GetBusService();

        [Get("bus-services/{id}.json")]
        RestResponse<BusServiceId> GetBusServiceId([Path("id")] string id);
    }
}
