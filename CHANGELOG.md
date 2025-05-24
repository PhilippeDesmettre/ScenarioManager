# 📝 Changelog

Toutes les modifications notables de ce projet seront documentées ici.

---
## [1.3.0] - 2025-05-25
### Ajouté
- Modèle `DbContext` (`ApplicationDbContext`) avec EF Core et SQLite
- Script de **seeding** pour données de test (`DbInitializer`)
- Contrôleur API `ScenariosController` avec `GET /api/scenarios` et `GET /api/scenarios/{id}`
- Sérialisation corrigée pour les relations circulaires (ReferenceHandler.IgnoreCycles)


## [1.2.0] - 2025-05-24
### Ajouté
- Création des entités `Utilisateur` et `Scenario` côté back-end (modèles C#)
- Base de données prévue : SQLite via EF Core (en cours)

## [1.1.0] - 2025-05-23
### Ajouté
- Intégration de Vuetify dans le front Vue 3
- Affichage dynamique des tâches récupérées via Axios

## [1.0.0] - 2025-05-22
### Créé
- Initialisation du projet
- Front-end Vue 3 + TypeScript (Vite)
- Back-end ASP.NET Core Web API
- Connexion entre front et back via API
