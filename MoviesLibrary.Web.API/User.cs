namespace MoviesLibrary.Web.API
{
    public class User
    {
        public List<UserModel> users { get; set; }
    }
    public class UserModel
    {
        public int id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }


    }
}
