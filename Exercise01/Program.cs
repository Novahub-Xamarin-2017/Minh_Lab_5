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
            var restClient = new RestClient("https://us17.api.mailchimp.com/3.0/");
            restClient.Authenticator = new HttpBasicAuthenticator("username", ApiKey);
            restClient.AddDefaultHeader("content-type", "application/json");

            var adapter = new RestAdapter(restClient);
            var service = adapter.Create<IService>();

            Console.Write("Send mail to email: ");
            var str = Console.ReadLine();
            var email = new Email { EmailAddress = str, Status = "subscribed" };
            SimpleJson.CurrentJsonSerializerStrategy = new SerializerStrategy();
            var responseAddEmail = service.AddEmail(IdList, email);
            Console.WriteLine($"Add email: {responseAddEmail.ResponseStatus}");

            Console.WriteLine("Create campaign: ");
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
            IdCompaign = GetIdCompaign(responseCreateCampaign.Content);
            Console.WriteLine($"Create campaign: {responseCreateCampaign.ResponseStatus}");

            Console.Write("Set content to mail: ");
            str = Console.ReadLine();
            var responseSetContent = service.SetContent(IdCompaign, new { html = str });
            Console.WriteLine($"set content: {responseSetContent.ResponseStatus}");

            var responseSendContent = service.SendContent(IdCompaign);
            Console.WriteLine($"send content: {responseSendContent.ResponseStatus}");

            Console.ReadKey();
        }

        static string GetIdCompaign(string str)
        {
            var count = 0;
            var start = 0;
            var end = 0;

            for (int i = 0; i < str.Length; i++)
            {
                if (str[i].ToString() == @"""")
                {
                    count++;
                    if (count == 3)
                    {
                        start = i + 1;
                    }

                    if (count == 4)
                    {
                        end = i - 1;
                        break;
                    }
                }
            }

            return str.Substring(start, end - start + 1);
        }

        static async void Test()
        {
            using (var http = new HttpClient())
            {
                http.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Basic", ApiKey);
                string content = await http.GetStringAsync(@"https://us17.api.mailchimp.com/3.0/campaigns");
                Console.WriteLine(content);
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

        static async void CreateList()
        {
            using (var http = new HttpClient())
            {
                http.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Basic", ApiKey);
                var obj = new
                {
                    name = "listofminh",
                    contact = new {
                        company = "MailChimp",
                        address1 = "address1",
                        address2 = "address2",
                        city = "Atlanta",
                        state = "GA",
                        zip = "30308",
                        country = "US"},
                    permission_reminder = "I",
                    campaign_defaults = new {
                        from_name = "minh",
                        from_email = "huynhngocminh2511@gmail.com",
                        subject = "",
                        language = "en" },
                    email_type_option = true
                };
                var json = JsonConvert.SerializeObject(obj);
                var objcontent = new StringContent(json,Encoding.UTF8, "application/json");
                var rscontent = await http.PostAsync(@"https://us17.api.mailchimp.com/3.0/lists",objcontent);
                Console.WriteLine(rscontent.IsSuccessStatusCode.ToString());
            }
        }
    }
}
