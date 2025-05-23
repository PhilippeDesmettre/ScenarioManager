using System;

namespace BackEnd.Models
{
    public class Scenario
    {
        public int Id { get; set; }
        public string Titre { get; set; } = null!;
        public string Genre { get; set; } = null!;
        public string Auteur { get; set; } = null!;
        public DateTime DateCreation { get; set; } = DateTime.UtcNow;

        // Clé étrangère
        public int UtilisateurId { get; set; }

        // Navigation
        public Utilisateur Utilisateur { get; set; } = null!;
    }
}
