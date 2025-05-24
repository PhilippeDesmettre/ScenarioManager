using BackEnd.Models;
using System.Collections.Generic;
using System.Linq;

namespace BackEnd.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            // Si la base contient déjà des scénarios, ne pas re-seeder
            if (context.Scenarios.Any())
                return;

            // Créer un utilisateur fictif
            var utilisateur = new Utilisateur
            {
                Nom = "Alice",
                Email = "alice@example.com",
                MotDePasseHash = "hashed" // à remplacer par vrai hash plus tard
            };
            context.Utilisateurs.Add(utilisateur);
            context.SaveChanges();

            // Créer des scénarios liés à ce user
            var scenarios = new List<Scenario>
            {
                new Scenario { Titre = "L'ombre des bois", Genre = "Horreur", Auteur = "Alice", UtilisateurId = utilisateur.Id },
                new Scenario { Titre = "Les étoiles d'acier", Genre = "Science-fiction", Auteur = "Alice", UtilisateurId = utilisateur.Id },
                new Scenario { Titre = "L'amour en 1942", Genre = "Drame historique", Auteur = "Alice", UtilisateurId = utilisateur.Id }
            };

            context.Scenarios.AddRange(scenarios);
            context.SaveChanges();
        }
    }
}
