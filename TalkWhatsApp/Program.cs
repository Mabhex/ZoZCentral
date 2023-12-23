using System;
using System.Net.Http;
using System.Threading.Tasks;
namespace TalkWhatsApp
{
    internal class Program
    {
        static async Task Main()
        {
            try
            {
                string pageId = "101144246045386"; // Replace with your actual page ID
                string accessToken = "EAAcuBJcuFfcBO9aLFTGQeWtnhf5duJvAGtKIK4kbHgnVVXaC7AQWZAA0Qy2zyWxZCFWXNqocwmUOZCmpsZAW44iQDX5GUVpIODAZCyJY8dZAoV1ZB4gZBECRZBoT1ZAcZCjpZAbkgOxxbuSAJdDkDkK62NuqeuRh2rdXZAoqulzE6d688HYYR6eChMZCBHeiOOsozDM812ytMLCZBeFBiubfejOXJbvcbq475jjBGfSW2jkGqI9HLgZD";

                var httpClient = new HttpClient();
                var jsonAsString = "{\r\n    \"messaging_product\": \"whatsapp\",\r\n    \"to\": \"27794228401\",\r\n    \"type\": \"template\",\r\n    \"template\": {\r\n        \"name\": \"hello_world\",\r\n        \"language\": {\r\n            \"code\": \"en_US\"\r\n        }\r\n    }\r\n}";
                var messageContent = new StringContent(jsonAsString);

                // Construct the request URL
                string requestUrl = $"https://graph.facebook.com/v17.0/{pageId}/messages?access_token={accessToken}";

                // Make the POST request
                var response = await httpClient.PostAsync(requestUrl, messageContent);
                response.EnsureSuccessStatusCode();

                // Read the response content (optional)
                string responseContent = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Message sent successfully! Response: {responseContent}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}



        ////token  "EAAcuBJcuFfcBO9aLFTGQeWtnhf5duJvAGtKIK4kbHgnVVXaC7AQWZAA0Qy2zyWxZCFWXNqocwmUOZCmpsZAW44iQDX5GUVpIODAZCyJY8dZAoV1ZB4gZBECRZBoT1ZAcZCjpZAbkgOxxbuSAJdDkDkK62NuqeuRh2rdXZAoqulzE6d688HYYR6eChMZCBHeiOOsozDM812ytMLCZBeFBiubfejOXJbvcbq475jjBGfSW2jkGqI9HLgZD"
        //WhatsAppAPI whatsAppAPI = new WhatsAppAPI();
        //    whatsAppAPI.token = "EAAcuBJcuFfcBO9aLFTGQeWtnhf5duJvAGtKIK4kbHgnVVXaC7AQWZAA0Qy2zyWxZCFWXNqocwmUOZCmpsZAW44iQDX5GUVpIODAZCyJY8dZAoV1ZB4gZBECRZBoT1ZAcZCjpZAbkgOxxbuSAJdDkDkK62NuqeuRh2rdXZAoqulzE6d688HYYR6eChMZCBHeiOOsozDM812ytMLCZBeFBiubfejOXJbvcbq475jjBGfSW2jkGqI9HLgZD";

        //    dynamic APIResponse = whatsAppAPI.SendMessage(whatsAppAPI);
        //    Console.WriteLine(APIResponse);
        //    Console.ReadLine();
