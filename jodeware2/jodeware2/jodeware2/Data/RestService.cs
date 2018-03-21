using jodeware2.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace jodeware2.Data
{
    public class RestService
    {
        HttpClient client;
        //string grant_type = "password";

        public RestService()
        {
            client = new HttpClient();
            client.MaxResponseContentBufferSize = 256000;
            //client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded' "));
        }

        public async Task<Produkt[]> GetProduktsAsync()
        {
            client.BaseAddress = new Uri("API URL");
            var response = await client.GetAsync("earthquakesJSON?north=44.1&south=-9.9&east=-22.4&west=55.2&username=bertt");
            var produktsJson = response.Content.ReadAsStringAsync().Result;
            var rootobject = JsonConvert.DeserializeObject<Rootobject>(produktsJson);
            return rootobject.produkts;
        }





            //    public async Task<Token> Login(User user)
            //    {
            //        var postData = new List<KeyValuePair<string, string>>();
            //        postData.Add(new KeyValuePair<string, string>("grant_type", grant_type));
            //        postData.Add(new KeyValuePair<string, string>("username", user.username));
            //        postData.Add(new KeyValuePair<string, string>("password", user.password));
            //        var content = new FormUrlEncodedContent(postData);
            //        var weburl = "www.test.com";
            //        var response = await PostResponse<Token>(weburl, content);
            //        DateTime dt = new DateTime();
            //        dt = DateTime.Today;
            //        response.expire_date = dt.AddSeconds(response.expire_in);
            //        return response;

            //    }

            //    public async Task<T> PostResponseLogin<T>(string weburl, FormUrlEncodedContent content) where T : class
            //    {
            //        var response = await client.PostAsync(weburl, content);
            //        var jsonResult = response.Content.ReadAsStringAsync().Result;
            //        var responseObject = JsonConvert.DeserializeObject<T>(jsonResult);
            //        return responseObject;
            //    }

            //    public async Task<T> PostResponse<T>(string weburl, string jsonstring) where T : class
            //    {
            //        //var Token = App.TokenDataBase.getToken();
            //        string Contentype = "application/json";
            //        client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Token.access_token);
            //        var Result = await client.PostAsync(weburl, new StringContent(jsonstring, Encoding.UTF8, Contentype));
            //        var JsonResult = Result.Content.ReadAsStringAsync().Result;
            //        var ContentResp = JsonConvert.DeserializeObject<T>(JsonResult);
            //        return ContentResp;
            //    }

            //    public async Task<T> GetResponse<T>(string weburl) where T : class
            //    {
            //        var Token = App.TokenDatabase.GetToken();
            //        client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Token.access_token);
            //        var response = await client.GetAsync(weburl);
            //    }
        }
    }