# Blazor SPA – Product & Category Management System

Single Page Application (SPA) built with Blazor and .NET, evolving from a monolithic structure to a decoupled client-server architecture using a versioned REST API.

---

## 🎯 Purpose

This project was created as a hands-on environment to practice real-world backend and frontend architecture concepts, focusing on:

- Transition from monolithic to API-first architecture
- REST API design with versioning (/api/v1)
- Decoupling UI from data access
- DTO-based contract design (Request/Response models)
- Service-based frontend communication
- Clean separation of concerns

---

## 🛠 Technologies Used

### Backend
- ASP.NET Core Minimal API
- .NET
- Entity Framework Core
- SQL Server
- Swagger (OpenAPI)

### Frontend
- Blazor
- Bootstrap 5
- HttpClient (API consumption)

---

## 🧠 Architecture

The project now follows a **client-server architecture**:

### Backend (API)
- Versioned REST API (`/api/v1`)
- Endpoints organized by feature
- DTOs used as contract (no EF exposure)
- Standardized responses via `ApiResponse<T>`
- Validation handled manually for Minimal API

### Frontend (Blazor)
- Fully decoupled from database
- Communicates exclusively via HTTP
- Uses service layer (`CategoryService`, `ProductService`)
- UI components consume API data via DTOs

---

## 🔄 Evolution

This project originally started as a **monolithic Blazor application**, directly accessing the database via `DbContext`.

It has been refactored to:

- Remove all direct database dependencies from the UI
- Introduce a versioned REST API
- Implement full CRUD via HTTP endpoints
- Establish a stable API contract using DTOs
- Add response standardization (`ApiResponse`)
- Introduce validation layer for incoming requests

---

## 🧩 Core Features

- Full CRUD for Categories (API + UI)
- Full CRUD for Products (API + UI)
- API versioning (`/api/v1`)
- Swagger documentation
- DTO-based communication
- Centralized response pattern
- Validation for POST and PUT requests
- SPA navigation (no page reload)

---

## 📁 Project Structure

### Backend
```bash
/ApiHelpers → Shared utilities
/Contracts → Request and Response DTOs
/Data → DbContext and EF Core configuration
/Endpoints → Minimal API endpoints
/Models → Domain entities
```

### Frontend
```
/Contracts → DTOs used to consume API
/Pages → Routed UI components
/Services → HTTP communication layer
/Shared → Reusable UI components
```

---

## 🧠 Structural Notes

- The **Contracts layer exists on both frontend and backend**, ensuring a clear and explicit HTTP contract.
- The frontend does **not depend on EF Core or database concerns**, only on HTTP communication.
- Backend **Models are internal**, preventing leakage of persistence structure to external clients.
- Services in the frontend act as an **abstraction layer over HttpClient**, centralizing API communication.

---

## 🚀 Running the Project

```bash
git clone https://github.com/EbelBernardo/Projeto-SPA-Blazor.git
cd app-blazor-spa

dotnet restore
dotnet ef database update
dotnet run
```

--- 

## 📌 Project Status

### 🚧 Actively evolving

This project is continuously being improved, including:
- New features
- Architectural refinements
- Code quality improvements
- Better API design patterns

Future updates may include:
- Authentication & Authorization
- Global error handling middleware
- API versioning strategies (v2)
- Automated validation pipelines
- Deployment and cloud integration

---

## 👤 Author

Bernardo Ebel
GitHub | LinkedIn

---

## 📄 License

Free for educational use.
