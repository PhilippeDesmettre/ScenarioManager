Projet FullStack: Scénarios Manager 🎬

Ce projet est une application web fullstack développée avec :
- **ASP.NET Core Web API** pour le back-end (C#)
- **Vue.js 3 + TypeScript + Vuetify** pour le front-end
- **SQLite** (prochainement) pour la base de données

## 🎯 Objectif
Créer un site permettant de :
- Lister, créer, modifier des scénarios (titre, genre, auteur, etc.)
- Gérer plusieurs utilisateurs avec authentification
- Associer chaque scénario à un utilisateur

---

## ✅ Fonctionnalités disponibles

- 🎬 Affichage dynamique de scénarios depuis l’API
- ➕ Ajout de scénario via formulaire `v-dialog`
- 🗑️ Suppression de scénario avec confirmation
- 🧭 Routage Vue 3 (`/scenarios`) avec Vue Router
- 🔗 Communication front/back via Axios + Vite env
- ⚙️ Back-end .NET Core + EF Core + SQLite + Swagger
- 🔐 Authentification complète par JWT (register/login)
- 🔒 Sécurisation des routes API (`[Authorize]`)
- 🚦 Redirection automatique selon l’état connecté
- ⚙️ Token enregistré dans `localStorage` et injecté dans les requêtes
- 🌐 Possibilité de marquer un scénario comme **public** (visible par tous) ou **privé**
- 🛡️ Seul le créateur peut modifier ou supprimer ses propres scénarios
- 🕒 Affichage des dates de création et modification




---

## 📁 Structure du projet

ProjetFullStackAppretissage/
├── FrontEnd/ # Application Vue 3 + TypeScript + Vuetify (Vite)
└── BackEnd/ # API ASP.NET Core (.NET 8 + EF Core + SQLite)

---

## ℹ️ Informations générales

- 🧑‍💻 Auteur : Philippe Desmettre
- 🛠️ Technologies : ASP.NET Core, Vue.js 3, TypeScript, Vuetify, Vite
- 🗃️ Base de données prévue : SQLite (via Entity Framework Core)
- 📦 Gestion de versions : Git + GitHub
- 🔧 IDE utilisés : Visual Studio, VS Code

---
