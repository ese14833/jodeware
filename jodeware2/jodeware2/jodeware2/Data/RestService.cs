using jodeware2.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace jodeware2.Data
{
    public class RestService
    {
        HttpClient client;
        //string grant_type = "password";
        public List<Produkt> Produkts { get; private set; }

        public RestService()
        {
            client = new HttpClient();
            client.MaxResponseContentBufferSize = 256000;
            //client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded' "));
        }

        public async Task<List<Produkt>> GetProduktsAsync()
        {
            Produkts = new List<Produkt>();

            var uri = new Uri(string.Format(Constants.RestUrl, string.Empty));

            try
            {
                var response = await client.GetAsync(uri);
                if(response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    Produkts = JsonConvert.DeserializeObject<List<Produkt>>(content);
                }
            } catch (Exception ex)
            {
                Debug.WriteLine(@"				ERROR {0}", ex.Message);
            }
            return Produkts;
        }

        public async Task SaveProduktAsync(Produkt produkt, bool isNewProdukt = false)
        {
            var uri = new Uri(string.Format(Constants.RestUrl, string.Empty));

            try
            {
                var json = JsonConvert.SerializeObject(produkt);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = null;
                if (isNewProdukt)
                {
                    response = await client.PostAsync(uri, content);
                }
                else
                {
                    response = await client.PutAsync(uri, content);
                }
                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine(@"				Produkt successfully saved.");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"				ERROR {0}", ex.Message);
            }
        }

        public async Task DeleteProduktAsync(int id)
        {
            var uri = new Uri(string.Format(Constants.RestUrl, id));
            try
            {
                var response = await client.DeleteAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine(@"				Produkt successfully deleted.");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"				ERROR {0}", ex.Message);
            }
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
    }
    }