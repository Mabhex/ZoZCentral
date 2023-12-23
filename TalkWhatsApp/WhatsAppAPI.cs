using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TalkWhatsApp
{
    internal class WhatsAppAPI
    {
        private string _toNumber;
        private string _waMessage;
        private string _phoneNumberId;
        private string _waBusAccId;
        private string _token;
        public string toNumber 
        {
            get => _toNumber;
            set
            {
                _toNumber = value;
            }
        }
        public string waMessage
        {
            get => _waMessage;
            set
            {
                _waMessage = value;
            }
        }
        
        public string phoneNumberId
        {
            get => _phoneNumberId;
            set 
            {
                _phoneNumberId = value;
            }
        }

        public string waBusAccId
        {
            get => _waBusAccId;
            set 
            { 
                _waBusAccId = value; 
            }

        }
        public string token
        {
            get => _token;
            set
            {
                _token = value;
            }

        }
        public async Task<dynamic> SendMessage(WhatsAppAPI whatsAppAPI) 
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post, "https://graph.facebook.com/v17.0/101144246045386/messages");

            request.Headers.Add("Accept", "application/json; charset=UTF-8");
            request.Headers.Add("x-redlock-auth", whatsAppAPI.token);
            var jsonAsString = "{\r\n    \"messaging_product\": \"whatsapp\",\r\n    \"to\": \"27794228401\",\r\n    \"type\": \"template\",\r\n    \"template\": {\r\n        \"name\": \"hello_world\",\r\n        \"language\": {\r\n            \"code\": \"en_US\"\r\n        }\r\n    }\r\n}";
            var jsonContent = new StringContent(jsonAsString, Encoding.UTF8, "application/json");
            request.Content = jsonContent;
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            string stringResponse = await response.Content.ReadAsStringAsync();
            dynamic jsonedstringResponse = JsonConvert.DeserializeObject(stringResponse);
            return jsonedstringResponse;

        } 
    }
}

