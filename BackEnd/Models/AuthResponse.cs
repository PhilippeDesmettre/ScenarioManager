namespace BackEnd.Models.Auth
{
    public class AuthResponse
    {
        public string Token { get; set; } = null!;
        public string Nom { get; set; } = null!;
        public string Email { get; set; } = null!;
    }
}
