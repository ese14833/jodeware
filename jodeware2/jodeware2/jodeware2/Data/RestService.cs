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

            var uri = new Uri(string.Format(Constants.ProduktRead, string.Empty));

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

        public async Task SaveAsync(Object ob, bool isNewProdukt = false)
        {
            Uri uri = null;

            if (ob is Produkt)
            {
                if (isNewProdukt)
                    uri = new Uri(string.Format(Constants.ProduktInsert, string.Empty));
                else
                    uri = new Uri(string.Format(Constants.ProduktUpdate, string.Empty));
            }
            if (ob is Kategorie)
            {
                uri = new Uri(string.Format(Constants.KategorieInsert, string.Empty));
            }
            if (ob is Hersteller)
            {
                uri = new Uri(string.Format(Constants.HerstellerInsert, string.Empty));
            }
            if(ob is Regal)
            {
                uri = new Uri(string.Format(Constants.RegalInsert, string.Empty));
            }
            if (ob is Lagerbestand)
            {
                uri = new Uri(string.Format(Constants.LagerbestandInsert, string.Empty));
            }
            if (ob is Verkauf)
            {
                uri = new Uri(string.Format(Constants.VerkaufInsert, string.Empty));
            }

            try
            {
                var json = JsonConvert.SerializeObject(ob);
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

            var uri = new Uri(string.Format(Constants.ProduktDelete, string.Empty));
            Produkt produkt = new Produkt();
            produkt.pro_id = id;
            try
            {
                var json = JsonConvert.SerializeObject(produkt);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(uri, content);
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
    
        public async Task DeleteKategorieAsync(string id)
        {

            var uri = new Uri(string.Format(Constants.KategorieDelete, string.Empty));
            Kategorie kat = new Kategorie();
            kat.kat_id = id;
            try
            {
                var json = JsonConvert.SerializeObject(kat);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(uri, content);
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

        public async Task DeleteHerstellerAsync(string id)
        {

            var uri = new Uri(string.Format(Constants.HerstellerDelete, string.Empty));
            Hersteller her = new Hersteller();
            her.her_id = id;
            try
            {
                var json = JsonConvert.SerializeObject(her);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(uri, content);
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

        public async Task DeleteRegalAsync(string id)
        {

            var uri = new Uri(string.Format(Constants.RegalDelete, string.Empty));
            Regal regal = new Regal();
            regal.reg_id = id;
            try
            {
                var json = JsonConvert.SerializeObject(regal);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(uri, content);
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

        public async Task DeleteLagerbestandAsync(string id)
        {

            var uri = new Uri(string.Format(Constants.LagerbestandDelete, string.Empty));
            Lagerbestand lager = new Lagerbestand();
            lager.lag_id = id;
            try
            {
                var json = JsonConvert.SerializeObject(lager);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(uri, content);
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
        public async Task DeleteVerkaufAsync(string id)
        {
            var uri = new Uri(string.Format(Constants.VerkaufDelete, string.Empty));
            Verkauf verkauf = new Verkauf();
            verkauf.ver_id = id;
            try
            {
                var json = JsonConvert.SerializeObject(verkauf);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(uri, content);
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