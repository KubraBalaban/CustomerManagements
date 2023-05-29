namespace WebUI.Models
{
    public class AuthResponseModel
    {
        public string UserName { get; set; }
        public string Token { get; set; }
        public int ExpiresIn { get; set; }

    }
}
