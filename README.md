# Blazor SPA – Product & Category Management System

Single Page Application (SPA) developed in Blazor with .NET 8 and C#, implementing a complete CRUD system for products and categories using Entity Framework Core for data persistence.

The project focuses on stateful UI, data-driven components, and backend-integrated front-end logic, following modern SPA principles with Blazor.

---

## 🎯 Purpose

This project was developed for educational purposes to practice and consolidate concepts such as:

- Building Single Page Applications with Blazor
- Implementing CRUD workflows for related entities (Products & Categories)
- Applying server-side validation with Data Annotations
- Managing component state and navigation without page reloads
- Using Entity Framework Core for database persistence
- Structuring a real-world Blazor application

---

## 🛠 Technologies Used

- C#
- .NET 8
- Blazor
- Entity Framework Core
- Bootstrap 5

---

## 📁 Project Structure

```
/Pages
  Razor components representing application pages
/Data
  DbContext and EF Core migrations
/Models
  Domain entities (Category, Product, etc.)
/wwwroot
  Static assets (CSS, JS)
/Program.cs
  Application bootstrap and configuration

```
 
---

## 🧩 Core Features

- CRUD for Categories
- CRUD for Products
- Form validation using Data Annotations
- SPA navigation without full page reload
- Database connection via Entity Framework Core
- Basic error handling

---

## 🚀 Running the Project

Clone the repository
   ```
      git clone https://github.com/EbelBernardo/Projeto-SPA-Blazor.git
   ```

Navigate to the project folder
   ```
      cd app-blazor-spa
   ```

Restore NuGet packages
   ```
      dotnet restore
   ```

Apply Entity Framework migrations
   ```
      dotnet ef database update
   ```

Run the application
   ```
      dotnet run
   ```
--- 

## 🧠 Architecture

The application is built as a Single Page Application using Blazor, where:
- UI is composed of stateful Razor components
- Navigation happens without full page reloads
- Business data is persisted through Entity Framework Core
- Validation is enforced at the model and UI level 
This architecture enables a responsive user experience while keeping a strong backend-driven data model.

---

## 📌 Project Status

✔️ Completed for study and learning purposes.

---

## 📄 License

This project is free to use for educational purposes.

---

## 👤 Autor
Bernardo Ebel <br>
[GitHub](https://github.com/EbelBernardo) | [LinkedIn](https://www.linkedin.com/in/bernardo-ebel-743831303/)

## 📌 Final Notes

This project represents a practical study of SPA development with Blazor, focusing on component-based UI, data persistence, and real application structure rather than isolated UI demos.
