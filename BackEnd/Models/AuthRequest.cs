namespace BackEnd.Models.Auth
{
    public class AuthRequest
    {
        public string Email { get; set; } = null!;
        public string MotDePasse { get; set; } = null!;
    }
}
