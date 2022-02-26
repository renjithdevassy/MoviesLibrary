using MoviesLibrary.API.Models;
using Newtonsoft.Json;
using System.Text;

namespace MoviesLibrary.Web.Client.Common
{
    public interface IApiClient
    {
        
        Task<Message<T1>> SendAsync<T1, T2>(Uri requestUrl, T2 content, HttpMethod method);
        Uri CreateRequestUri(string relativePath, string queryString = "");
        
    }
    public partial class ApiClient : IApiClient
    {
        public readonly HttpClient _httpClient;
        public string _url;
        public ApiClient(IConfiguration configuration, HttpClient httpClient)
        {
            
            _url = "https://localhost:7155/";
            _httpClient = httpClient;

        }
        public Uri CreateRequestUri(string relativePath, string queryString = "")
        {
            
            
               string address = _url;
           
            var endpoint = new Uri(new Uri(address), relativePath);
            var uriBuilder = new UriBuilder(endpoint);
            uriBuilder.Query = queryString;
            return uriBuilder.Uri;
        }
        public async Task<Message<T1>> SendAsync<T1, T2>(Uri requestUrl, T2 content, HttpMethod method)
        {
            HttpRequestMessage request = new HttpRequestMessage();
            if (content != null)
            {
                request.Content = CreateHttpContent<T2>(content);
                var c = CreateHttpContent<T2>(content);
            }
            request.Method = method;
            request.RequestUri = requestUrl;

            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var data = await response.Content.ReadAsStringAsync();
            Message<T1> result = new Message<T1>();

            if (data.Contains("{") || data.Contains("["))
            {
                result.Data = JsonConvert.DeserializeObject<T1>(data);
            }
            else
            {
                if (!string.IsNullOrEmpty(data.ToString()))
                {
                    result.Data = (T1)(object)data;
                }
            }

            result.IsSuccess = response.IsSuccessStatusCode;
            result.ReturnMessage = response.ReasonPhrase;
            return result;
        }
        public HttpContent CreateHttpContent<T>(T content)
        {
            var json = JsonConvert.SerializeObject(content);
            return new StringContent(json, Encoding.UTF8, "application/json");
        }
    }
}
