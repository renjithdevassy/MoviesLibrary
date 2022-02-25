using Microsoft.AspNetCore.Mvc;
using MoviesLibrary.Data.Entities;
using System.Text.Json;

namespace MoviesLibrary.Web.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CommonController :  ControllerBase
    {
        private readonly ILogger<CommonController> _logger;

        public CommonController(ILogger<CommonController> logger)
        {
            _logger = logger;
        }
        //[HttpGet(Name = "GetUser")]
        //public User Get()
        //{
        //    User user = new User();
        //    using (StreamReader r = new StreamReader("Data/user.json"))
        //    {
        //        string json = r.ReadToEnd();
        //        User item = JsonSerializer.Deserialize<User>(json);
        //        return item;
        //    }
        //    return user;

        //}
        //[HttpGet(Name = "GetAll")]
        //public List<MoviesEntity> GetAll()
        //{
        //    try
        //    {
        //        using (StreamReader r = new StreamReader("Data/moviedata.json"))
        //        {
        //            string json = r.ReadToEnd();
        //            List<MoviesEntity> movies = JsonSerializer.Deserialize<List<MoviesEntity>>(json);

        //            movies = movies.Take(10).ToList();
        //            return movies;
        //        }
        //        return new List<MoviesEntity>();
        //    }
        //    catch(Exception ex)
        //    {
        //        throw ex;
        //    }

            

        //}
    }
}
