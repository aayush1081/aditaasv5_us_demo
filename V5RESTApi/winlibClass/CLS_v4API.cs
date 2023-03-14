using Microsoft.AspNetCore.Antiforgery;
using Microsoft.Net.Http.Headers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace V5WinService.Classes
{
    public static class CLS_v4API
    {
        //public static async Task<string> Get_ApiToken()
        //{
        //    //CookieContainer cookieContainer = new CookieContainer();
        //    //HttpClientHandler handler = new HttpClientHandler
        //    //{
        //    //    CookieContainer = cookieContainer
        //    //};
        //    //handler.CookieContainer = cookieContainer;

        //    //var client = new HttpClient(handler);
        //    var client = new HttpClient();
        //    client.BaseAddress = new Uri(CLS_Global_Class.apiUrl);
        //    client.DefaultRequestHeaders.Accept.Clear();
        //    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //    var responseObj = await client.GetAsync("AntiForgery/GetAntiforgeryWinService");
        //    var response = await responseObj.Content.ReadAsStringAsync();

        //    //var response = await client.GetStringAsync("AntiForgery/GetAntiforgeryWinService");

        //    //var RequestToken = cookieContainer.GetCookies(new Uri("http://localhost:10049")).Cast<Cookie>().Single(cookie => cookie.Name == "XSRF-TOKEN");
        //    //return RequestToken.Value;

        //    var json = JsonConvert.DeserializeObject<AntiforgeryTokenSet>(response);
        //    return json.RequestToken;
        //}
     
        public static async Task<AntiForgeryToken> Get_ApiToken()
        {
            var antiForgerytoken = new AntiForgeryToken();

            var client = new HttpClient();
            client.BaseAddress = new Uri(CLS_Global_Class.apiUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = await client.GetAsync("AntiForgery/GetAntiforgeryWinService");
            response.EnsureSuccessStatusCode();

            if (response.Headers.TryGetValues("Set-Cookie", out IEnumerable<string> values))
            {
                var cookies = SetCookieHeaderValue.ParseList(values.ToList());

                var _antiforgeryCookie = cookies.SingleOrDefault(c =>
                    c.Name.Value.Contains("XSRF-TOKEN", StringComparison.OrdinalIgnoreCase));

                // Value of XSRF token cookie
                antiForgerytoken.XsrfToken = _antiforgeryCookie.Value.ToString();

                // and the cookies unparsed (both XSRF-TOKEN and .AspNetCore.Antiforgery.{someId})
                antiForgerytoken.Cookies = values.ToArray();
            }

            return antiForgerytoken;
        }
        public static async Task<string> GetApiTokenForHub(string apiUrl)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(apiUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await client.GetStringAsync("AntiForgery/GetAntiforgeryWinService");
            var json = JsonConvert.DeserializeObject<AntiforgeryTokenSet>(response);
            return json.RequestToken;
        }
        public static async Task<dynamic> Get_ApiRequest(string path)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(CLS_Global_Class.apiUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("X-XSRF-TOKEN", CLS_Global_Class.apiToken.XsrfToken);
            client.DefaultRequestHeaders.Add("FROM-WINSERVICE", "WinServiceToken" + CLS_Global_Class.apiToken.XsrfToken);
            client.DefaultRequestHeaders.Add("X-XSRF-TOKEN", CLS_Global_Class.apiToken.XsrfToken);
            client.DefaultRequestHeaders.Add("Cookie", CLS_Global_Class.apiToken.Cookies[0]);
            client.DefaultRequestHeaders.Add("Cookie", CLS_Global_Class.apiToken.Cookies[1]);
            var response = await client.GetStringAsync(path);
            var json = JsonConvert.DeserializeObject(response);
            return json;
        }

        public static async Task<string> Post_ApiRequest(string path, dynamic objRequest)
        {
            try
            {
                var client = new HttpClient();
                client.BaseAddress = new Uri(CLS_Global_Class.apiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("X-XSRF-TOKEN", CLS_Global_Class.apiToken.XsrfToken);
                client.DefaultRequestHeaders.Add("FROM-WINSERVICE", "WinServiceToken" + CLS_Global_Class.apiToken.XsrfToken);
                client.DefaultRequestHeaders.Add("Cookie", CLS_Global_Class.apiToken.Cookies[0]);
                client.DefaultRequestHeaders.Add("Cookie", CLS_Global_Class.apiToken.Cookies[1]);

                HttpContent c = new StringContent(JsonConvert.SerializeObject(objRequest), Encoding.UTF8, "application/json");
                var response = await client.PostAsync(path, c);
                if (response.StatusCode == HttpStatusCode.NoContent || response.StatusCode == HttpStatusCode.OK)
                {
                    var str_DAta = await response.Content.ReadAsStringAsync();
                    return str_DAta;
                }
                else
                {
                    var str_DAta = await response.Content.ReadAsStringAsync();
                    throw new Exception(response.ReasonPhrase);
                }
               
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static async Task<string> PostFileData(string path, dynamic objRequest)
        {
            try
            {
                var client = new HttpClient();
                client.BaseAddress = new Uri(CLS_Global_Class.apiUrl);
                client.DefaultRequestHeaders.Add("FROM-WINSERVICE", "WinServiceToken" + CLS_Global_Class.apiToken.XsrfToken);
                client.DefaultRequestHeaders.Add("X-XSRF-TOKEN", CLS_Global_Class.apiToken.XsrfToken);
                client.DefaultRequestHeaders.Add("Cookie", CLS_Global_Class.apiToken.Cookies[0]);
                client.DefaultRequestHeaders.Add("Cookie", CLS_Global_Class.apiToken.Cookies[1]);

                var response = await client.PostAsync(path, objRequest);
                if (response.StatusCode == HttpStatusCode.NoContent || response.StatusCode == HttpStatusCode.OK)
                {
                    var str_DAta = await response.Content.ReadAsStringAsync();
                    return str_DAta;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static async Task<string> Put_ApiRequest(string path, dynamic objRequest)
        {
            try
            {
                var client = new HttpClient();
                client.BaseAddress = new Uri(CLS_Global_Class.apiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("FROM-WINSERVICE", "WinServiceToken" + CLS_Global_Class.apiToken.XsrfToken);
                client.DefaultRequestHeaders.Add("X-XSRF-TOKEN", CLS_Global_Class.apiToken.XsrfToken);
                client.DefaultRequestHeaders.Add("Cookie", CLS_Global_Class.apiToken.Cookies[0]);
                client.DefaultRequestHeaders.Add("Cookie", CLS_Global_Class.apiToken.Cookies[1]); 
                ;
                HttpContent c = new StringContent(JsonConvert.SerializeObject(objRequest), Encoding.UTF8, "application/json");
                var response = await client.PutAsync(path, c);
                if (response.StatusCode == HttpStatusCode.NoContent || response.StatusCode == HttpStatusCode.OK)
                {
                    var str_DAta = await response.Content.ReadAsStringAsync();
                    return str_DAta;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static async Task<Byte[]> Get_ApiRequest_ByteArray(string path)
        {
            try
            {
                var client = new HttpClient();
                client.BaseAddress = new Uri(CLS_Global_Class.apiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));               
                client.DefaultRequestHeaders.Add("FROM-WINSERVICE", "WinServiceToken" + CLS_Global_Class.apiToken.XsrfToken);
                client.DefaultRequestHeaders.Add("X-XSRF-TOKEN", CLS_Global_Class.apiToken.XsrfToken);
                client.DefaultRequestHeaders.Add("Cookie", CLS_Global_Class.apiToken.Cookies[0]);
                client.DefaultRequestHeaders.Add("Cookie", CLS_Global_Class.apiToken.Cookies[1]);

                client.Timeout = TimeSpan.FromHours(1);

                string response123 = null;
                var response = await client.GetAsync(path);
                if (response.IsSuccessStatusCode)
                {
                    response123 = response.Content.ReadAsStringAsync().Result.Replace("\"", string.Empty);
                }
                var byte_Data = Convert.FromBase64String(response123);
                return byte_Data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }

    public class AntiForgeryToken
    {
        public string XsrfToken { get; set; }
        public string[] Cookies { get; set; }
    }

}
