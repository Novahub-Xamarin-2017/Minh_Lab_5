using RestSharp;
using Retrofit.Net.Attributes.Methods;
using Retrofit.Net.Attributes.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise03.Model
{
    public interface IService
    {
        [Get("weatherweather?q={city},vn&APPID=32e86d2782c009304019c7b0526d0155")]
        RestResponse<WeatherObject> GetWeatherFollowCityName([Path("city")] string city);

        [Get("weather?lat={lat}&lon={lon}&APPID=32e86d2782c009304019c7b0526d0155")]
        RestResponse<WeatherObject> GetWeatherFollowGeoLocation([Path("lat")] string lat,[Path("lon")] string lon);

        [Get("weather?id={id}&APPID=32e86d2782c009304019c7b0526d0155")]
        RestResponse<WeatherObject> GetWeatherFollowId([Path("id")] string city);

        [Get("weather?zip={zip},vn&APPID=32e86d2782c009304019c7b0526d0155")]
        RestResponse<WeatherObject> GetWeatherFollowZipCode([Path("zip")] string city);
    }
}
