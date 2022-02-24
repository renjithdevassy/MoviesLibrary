using Microsoft.AspNetCore.Mvc;
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
        [HttpGet(Name = "GetUser")]
        public User Get()
        {
            User user = new User();
            using (StreamReader r = new StreamReader("Data/user.json"))
            {
                string json = r.ReadToEnd();
                User item = JsonSerializer.Deserialize<User>(json);
                return item;
            }
            return user;

        }
    }
}
