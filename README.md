# Brandify API (ASP.NET Core Web API)

Brandify is the backend API for a startup website that showcases projects and services.  
It provides CRUD endpoints for projects, project images, services, service categories, and customer requests, plus authentication using **JWT (Login/Register)**.

---

## Features

- ✅ **Authentication & Authorization**
  - Register / Login
  - JWT access token
  - Role-based authorization (optional if implemented)

- ✅ **Projects Module**
  - Projects CRUD
  - Project Images CRUD (linked to Projects)

- ✅ **Services Module**
  - Services CRUD
  - Service Categories CRUD (linked to Services)

- ✅ **Customer Requests**
  - Customers can send requests to buy a project or ask for details

- ✅ Clean REST API structure (Controllers/Services/Repositories depending on your architecture)

---

## Tech Stack

- **ASP.NET Core Web API**
- **Entity Framework Core**
- **SQL Server** (or any DB you configured)
- **JWT Authentication**
- **Swagger / OpenAPI** (if enabled)

---

## Database Entities (Tables)

Typical tables in this project:

- `Projects`
- `ProjectImages`
- `Services`
- `ServiceCategories`
- `Requests`
- `Users` (AspNetUsers) + Identity tables (if using ASP.NET Identity)

> Note: Exact names/relationships depend on your implementation.

---

## Getting Started

### Prerequisites
Make sure you have:
- .NET SDK (recommended: .NET 7/8 depending on your project)
- SQL Server (or your configured database)
- Visual Studio / VS Code

### 1) Clone the repository
```bash
git clone https://github.com/<your-username>/brandify-api.git
cd brandify-api
