namespace MyTestProjectAPI.Models
{
    public class AuthenticationResponse
    {
        public string AccessToken { get; set; }
        public string TokenType { get; set; }
        public int ExpiresIn { get; set; }
    }
}
