using System.Collections.Generic;

namespace BackEnd.Models
{
    public class Utilisateur
    {
        public int Id { get; set; }
        public string Nom { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string MotDePasseHash { get; set; } = null!;

        // Navigation
        public ICollection<Scenario> Scenarios { get; set; } = new List<Scenario>();
    }
}
