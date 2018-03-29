using jodeware2.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace jodeware2.Data
{
    public class RestService : IRestService
    {
        HttpClient client;
        //string grant_type = "password";
        public RootObject Produkts { get; set; }

        public RestService()
        {
            var authData = string.Format("{0}:{1}", Constants.Username, Constants.Password);
            var authHeaderValue = Convert.ToBase64String(Encoding.UTF8.GetBytes(authData));

            client = new HttpClient();
            client.MaxResponseContentBufferSize = 256000;
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authHeaderValue);
        }

        public async Task<RootObject> RefreshDataAsync()
        {
            Produkts = new RootObject();

            var uri = new Uri(string.Format(Constants.RestRead, string.Empty));

            try
            {
                var response = await client.GetAsync(uri);
                if(response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    Produkts = JsonConvert.DeserializeObject<RootObject>(content);
                }
            } catch (Exception ex)
            {
                Debug.WriteLine(@"				ERROR {0}", ex.Message);
            }
            return Produkts;
        }

        public async Task SaveProduktAsync(Produkt produkt, bool isNewProdukt = false)
        {
            var uri = new Uri(string.Format(Constants.RestInsert, string.Empty));

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

        public async Task DeleteProduktAsync(string id)
        {
            var uri = new Uri(string.Format(Constants.RestDelete, id));
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
    }
}