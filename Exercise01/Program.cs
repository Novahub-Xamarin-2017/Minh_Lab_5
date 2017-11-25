using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using Newtonsoft.Json;
using System.Threading;
using Retrofit.Net;
using RestSharp;

namespace Exercise01
{ 
    class Program
    {
        public static string ApiKey = "087498271007cb77b740b52dc9a1b4ad-us17";
        public static string IdList = "2a02210045";
        public static string IdCompaign = "fc0c0676fe";

        static void Main(string[] args)
        {
            Console.Write("Add email: ");
            var email = Console.ReadLine();

            Console.Write("Set content: ");
            var content = Console.ReadLine();

            SendEmail(email, content);

            Console.ReadKey();
        }

        static void SendEmail(string emailString, string content)
        {
            var restClient = new RestClient("https://us17.api.mailchimp.com/3.0/");
            restClient.Authenticator = new HttpBasicAuthenticator("username", ApiKey);
            restClient.AddDefaultHeader("content-type", "application/json");

            var adapter = new RestAdapter(restClient);
            var service = adapter.Create<IService>();

            var email = new Email { EmailAddress = emailString, Status = "subscribed" };
            SimpleJson.CurrentJsonSerializerStrategy = new SerializerStrategy();
            var responseAddEmail = service.AddEmail(IdList, email);

            var campaign = new
            {
                recipients = new { list_id = IdList },
                type = "regular",
                settings = new
                {
                    subject_line = "Only Test 1",
                    reply_to = "huynhngocminh2511@gmail.com",
                    from_name = "minh"
                }
            };
            var responseCreateCampaign = service.CreateCampaign(campaign);
            IdCompaign = JsonConvert.DeserializeObject<Campaign>(responseCreateCampaign.Content).id;

            var responseSetContent = service.SetContent(IdCompaign, new { html = content });

            var responseSendContent = service.SendContent(IdCompaign);

            if (responseAddEmail.ResponseStatus.ToString().Contains("Completed") && responseCreateCampaign.ResponseStatus.ToString().Contains("Completed") && responseSetContent.ResponseStatus.ToString().Contains("Completed") && responseSendContent.StatusCode.ToString().Contains("NoContent"))
            {
                Console.WriteLine("Send: complete");
            } else
            {
                Console.WriteLine("Send: error");
                Console.WriteLine($"Add email: {responseAddEmail.ResponseStatus}");
                Console.WriteLine($"Create campaign: {responseCreateCampaign.ResponseStatus}");
                Console.WriteLine($"Set content: {responseSetContent.ResponseStatus}");
                Console.WriteLine($"Send content: {responseSendContent.StatusCode}");
            }
        }

        static async void SentCampaign()
        {
            using (var http = new HttpClient())
            {
                http.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Basic", ApiKey);
                var rscontent = await http.PostAsync($"https://us17.api.mailchimp.com/3.0/campaigns/{IdCompaign}/actions/send", null);
                Console.WriteLine(rscontent.IsSuccessStatusCode.ToString());
            }
        }

        static async void SetContentCampaign()
        {
            using (var http = new HttpClient())
            {
                http.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Basic", ApiKey);
                var obj = new
                {
                    html = "<p> test test test test <./p>"
                };
                var json = JsonConvert.SerializeObject(obj);
                var objcontent = new StringContent(json, Encoding.UTF8, "application/json");
                var rscontent = await http.PutAsync($"https://us17.api.mailchimp.com/3.0/campaigns/{IdCompaign}/content", objcontent);
                Console.WriteLine(rscontent.IsSuccessStatusCode.ToString());
            }
        }

        static async void CreateCampaign()
        {
            using (var http = new HttpClient())
            {
                http.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Basic", ApiKey);
                var obj = new
                {
                    recipients = new { list_id = IdList },
                    type = "regular",
                    settings = new
                    {
                        subject_line = "Only Test",
                        reply_to = "huynhngocminh2511@gmail.com",
                        from_name = "minh"
                    }
                };
            var json = JsonConvert.SerializeObject(obj);
                var objcontent = new StringContent(json, Encoding.UTF8, "application/json");
                var rscontent = await http.PostAsync("https://us17.api.mailchimp.com/3.0/campaigns", objcontent);
                Console.WriteLine(rscontent.IsSuccessStatusCode.ToString());
            }
        }

        static async void AddMember()
        {

            using (var http = new HttpClient())
            {
                http.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Basic", ApiKey);
                var obj = new
                {
                    email_address = "huynhngocminh2511@gmail.com",
                    status = "subscribed"
                };
                var json = JsonConvert.SerializeObject(obj);
                var objcontent = new StringContent(json, Encoding.UTF8, "application/json");
                var rscontent = await http.PostAsync($"https://us17.api.mailchimp.com/3.0/lists/{IdList}/members", objcontent);
                Console.WriteLine(rscontent.IsSuccessStatusCode.ToString());
            }
        }
    }
}
