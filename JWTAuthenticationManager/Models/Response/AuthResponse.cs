namespace JWTAuthenticationManager.Models.Response
{
    public class AuthResponse
    {
        public string UserName { get; set; }
        public string Token { get; set; }
        public int ExpiresIn { get; set; }
    }
}
