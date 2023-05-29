namespace WebUI.Models
{
    public class AuthRequestModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        public AuthRequestModel(string userName, string password) { UserName = userName; Password = password; }
    }
}
