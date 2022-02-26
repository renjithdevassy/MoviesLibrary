using MoviesLibrary.API.Models;
using MoviesLibrary.Web.Client.Common;
using Newtonsoft.Json;

namespace MoviesLibrary.Web.Client.ViewModels
{
    public interface IMoviesViewModel
    {
        Task<List<MoviesModel>> GetAll();
        Task<MoviesModel> GetByTitle(string title);
    }
    public class MoviesViewModel : IMoviesViewModel
    {
        public IApiClient _apiClient { get; }
        public HttpClient _httpClient { get; }
        private readonly ILogger<MoviesModel> _logger;
        public MoviesViewModel(ILogger<MoviesModel> logger, IApiClient apiClient, HttpClient httpClient)
        {
            _logger = logger;
            _apiClient = apiClient;
            _httpClient = httpClient;
        }
        public async  Task<List<MoviesModel>> GetAll()
        {
            try
            {
                List<MoviesModel> movies = new List<MoviesModel>();
                string url = $"Movies/getall";
                string queryString = "";
                var requestUrl = _apiClient.CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture, url), queryString);
                Message<List<MoviesModel>> message = await _apiClient.SendAsync<List<MoviesModel>, string>(requestUrl, null, HttpMethod.Get);
                return message.Data;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Get Movies");
                return null;
            }
        }

        public async Task<MoviesModel> GetByTitle(string title)
        {
            try
            {
                MoviesModel movie = new MoviesModel();
                string url = $"Movies/{title}";
                string queryString = "";
                var requestUrl = _apiClient.CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture, url), queryString);
                Message<MoviesModel> message = await _apiClient.SendAsync<MoviesModel, string>(requestUrl, null, HttpMethod.Get);
                return message.Data;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Get Movie by title");
                return null;
            }
           
        }
    }
}
