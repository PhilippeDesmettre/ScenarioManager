# 📝 Changelog

Toutes les modifications notables de ce projet seront documentées ici.

---
## [1.7.0] - 26/05/2025
### Ajouté
- Barre de navigation (`v-app-bar`) avec bouton de déconnexion
- Masquage de la barre de navigation lorsque l’utilisateur n’est pas connecté


## [1.6.0] - 26/05/2025
### Ajouté
- Champ `estPublic` dans le modèle `Scenario` (back + front)
- Filtrage des scénarios visibles (publics + scénarios de l’utilisateur connecté)
- Switch dans le formulaire pour marquer un scénario comme public
- Affichage de la propriété `estPublic` dans la liste
- Champ `dateModification` ajouté au modèle `Scenario` et affiché dans la vue

### Corrigé
- Problème de soumission silencieuse (champ manquant dans `newScenario`)
- Rendu du switch et du formulaire de création


## [1.5.0] - 26/05/2025
### Ajouté
- Authentification par JWT (register / login) côté back via `AuthController`
- Ajout des modèles `AuthRequest` et `AuthResponse`
- Génération du token JWT avec `Claim` de l’ID utilisateur
- Middleware d’authentification et configuration dans `Startup.cs`
- Interface de connexion/inscription dans `AuthPage.vue`
- Ajout de la route `/` (page d’authentification) et redirection vers `/scenarios` si connecté
- Protection des routes front via `meta.requiresAuth` + `router.beforeEach`
- Centralisation des appels API via `api.ts` (avec injection automatique du token dans les headers)

### Modifié
- Correction des appels `axios` pour utiliser l’instance `api`
- Mise à jour de `vite.config.ts` avec l’alias `@`

## [1.4.0] - 2025-05-25
### Ajouté
- Création du composant `ScenarioList.vue` avec affichage depuis l'API
- Intégration de Vue Router avec route `/scenarios`
- Ajout du bouton "Ajouter" et d’un `v-dialog` pour créer un scénario
- Intégration de la suppression de scénarios via bouton 🗑️
- API : ajout de la route `POST /api/scenarios` avec affectation d’un `UtilisateurId` par défaut

### Corrigé
- Erreur 500 lors de la création (due à `UtilisateurId` non renseigné)
- Mise à jour de `tsconfig.app.json` pour supporter `import.meta.env`

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
