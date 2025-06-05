# 📝 Tweet Project – GraphQL avec .NET 8

Ce projet a été réalisé pour mettre en pratique mes connaissances en **GraphQL** dans un environnement **.NET 8**, avec **Entity Framework Core** et **SQL Server**.

---

## 📌 Description

Ce projet expose une API GraphQL permettant de consulter des **posts**, des **utilisateurs**, et des **commentaires**.  
Il démontre l’utilisation de requêtes GraphQL simples avec des données relationnelles.

---

## 🚀 Fonctionnalités GraphQL

Voici les requêtes disponibles dans l’API (définies dans `Query.cs`) :

- 🔹 `GetPosts` : Récupérer tous les posts
- 🔹 `GetUsers` : Récupérer tous les utilisateurs
- 🔹 `GetPostById` : Obtenir un post spécifique par son ID
- 🔹 `GetCommentsByPostID` : Obtenir les commentaires associés à un post donné

---

## ⚙️ Technologies utilisées

- ✅ **C# .NET 8**
- ✅ **GraphQL** avec [HotChocolate](https://chillicream.com/docs/hotchocolate)
- ✅ **Entity Framework Core**
- ✅ **SQL Server**
- ✅ **Visual Studio 2022 / VS Code**

---

## 🧩 Modèle de données

Le projet contient trois entités principales :
Post, User, Comment


## 🗃️ Base de données et Migrations
Ce projet utilise Entity Framework Core avec SQL Server.
Les migrations sont incluses dans le dossier Migrations.
La base se génère automatiquement à partir du modèle.

## 📦 Créer la base de données
dotnet ef database update
Vérifiez la chaîne de connexion dans appsettings.json:
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=TweetDb;Trusted_Connection=True;TrustServerCertificate=True;"
}

## ▶️ Lancer le projet
git clone https://github.com/AdnaneMezrag/Tweet-Project-GraphQL.git
cd Tweet-Project-GraphQL
dotnet restore
dotnet ef database update
dotnet run

Accédez ensuite à :
http://localhost:5000/graphql


## 📬 Exemples de requêtes GraphQL
# Récupérer tous les posts
query {
  posts {
    id
    title
    content
    user {
      name
    }
  }
}

# Obtenir les commentaires liés à un post
query {
  commentsByPostID(id: 1) {
    id
    text
  }
}


## 📥 Feedback
N'hésitez pas à me faire part de vos retours ou suggestions. Je suis disponible pour toute discussion ou amélioration du projet.
