using jodeware2.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace jodeware2.Data
{
    class RestService
    {
        HttpClient client;
        string grant_type = "password";

        public RestService()
        {
            client = new HttpClient();
            client.MaxResponseContentBufferSize = 256000;
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded' "));
        }

        public async Task<Token> Login(User user)
        {
            var postData = new List<KeyValuePair<string, string>>();
            postData.Add(new KeyValuePair<string, string>("grant_type", grant_type));
            postData.Add(new KeyValuePair<string, string>("username", user.username));
            postData.Add(new KeyValuePair<string, string>("password", user.password));
            var content = new FormUrlEncodedContent(postData);
            
        }
    }
}
