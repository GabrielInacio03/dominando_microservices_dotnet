using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeekShooping.Web.Utils
{
    public static class HttpClientExtensions
    {
        private static MediaTypeHeaderValue _mediaTypeHeaderValue = new MediaTypeHeaderValue("application/json");
        public static async Task<T> ReadContentAs<T>(this HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException($"Something went wrong calling the API: {response.ReasonPhrase}");
            }

            var dataAsString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            return System.Text.Json.JsonSerializer.Deserialize<T>(dataAsString, new System.Text.Json.JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }
        public static async Task<HttpResponseMessage> PostAsJson<T>(this HttpClient httpClient, string url, T data)
        {
            var dataAsString = System.Text.Json.JsonSerializer.Serialize(data);
            var content = new StringContent(dataAsString, System.Text.Encoding.UTF8, "application/json");
            return await httpClient.PostAsync(url, content);
        }
        public static async Task<HttpResponseMessage> PutAsJson<T>(this HttpClient httpClient, string url, T data)
        {
            var dataAsString = System.Text.Json.JsonSerializer.Serialize(data);
            var content = new StringContent(dataAsString, System.Text.Encoding.UTF8, "application/json");
            return await httpClient.PutAsync(url, content);
        }
        public static async Task<HttpResponseMessage> DeleteAsync(this HttpClient httpClient, string url)
        {
            return await httpClient.DeleteAsync(url);
        }
        public static async Task<HttpResponseMessage> GetAsync(this HttpClient httpClient, string url)
        {
            return await httpClient.GetAsync(url);
        }
    }
}