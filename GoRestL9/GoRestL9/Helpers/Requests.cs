using GoRestL9.Models;
using Newtonsoft.Json;

namespace GoRestL9.Helpers
{
    public static class Requests
    {
        public static async Task<string> GetUser(HttpClient client, string url, string token)
        {
            var message = new HttpRequestMessage(HttpMethod.Get, url);
            message.Headers.Add("Authorization", token);

            var response = await client.SendAsync(message);
            string content = await response.Content.ReadAsStringAsync();
            return content;
        }

        public static async Task<string> CreateUser(HttpClient client, string url, string token, User user)
        {
            var message = new HttpRequestMessage(HttpMethod.Post, url);

            string jsonUser = JsonConvert.SerializeObject(user);

            message.Content = new StringContent(jsonUser);
            message.Headers.Add("Accept", "application/json");
            message.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            message.Headers.Add("Authorization", token);

            var response = await client.SendAsync(message);
            string content = await response.Content.ReadAsStringAsync();
            return content;
        }

        public static async Task<string> PatchUser(HttpClient client, string url, string token, string patchString)
        {
            var message = new HttpRequestMessage(HttpMethod.Patch, url);

            message.Content = new StringContent(patchString);
            message.Headers.Add("Accept", "application/json");
            message.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            message.Headers.Add("Authorization", token);

            var response = await client.SendAsync(message);
            string content = await response.Content.ReadAsStringAsync();
            return content;
        }

        public static async void DeleteUser(HttpClient client, string url, string token)
        {
            var message = new HttpRequestMessage(HttpMethod.Delete, url);

            message.Headers.Add("Authorization", token);

            var response = await client.SendAsync(message);
        }
    }
}
