# CloudCRM

CloudCRM is a CRM web application built with **ASP.NET Core 8 MVC** and **Clean Architecture**.

The project demonstrates modern .NET development practices including Entity Framework Core, ASP.NET Core Identity, role-based authorization, Docker containerisation, Azure deployment and automated CI/CD with GitHub Actions.

## Features

- Dashboard with customer, membership, payment and revenue information
- Customer management
- Membership type management
- Membership management
- Payment tracking
- ASP.NET Core Identity authentication
- Admin role-based authorization
- Entity Framework Core data access
- SQL Server database

## Technology Stack

### Backend
- C#
- .NET 8
- ASP.NET Core MVC
- Entity Framework Core
- ASP.NET Core Identity

### Frontend
- HTML
- CSS
- Bootstrap 5

### Database
- SQL Server
- Azure SQL Database

### Architecture
- Clean Architecture
- Repository Pattern
- Service Layer
- Dependency Injection

### DevOps & Cloud
- Docker
- Docker Compose
- Microsoft Azure App Service
- Azure SQL Database
- Git
- GitHub
- GitHub Actions
- CI/CD
- Azure OIDC authentication

## Architecture

The solution follows Clean Architecture and separates responsibilities across four projects:

```text
CloudCRM.Core
    Domain entities

CloudCRM.Application
    Application services and interfaces

CloudCRM.Infrastructure
    Entity Framework Core
    Repository implementations
    Identity
    Database configuration

CloudCRM.Web
    ASP.NET Core MVC
    Controllers
    Views
    Authentication
    User interface
```

This structure keeps business logic separate from infrastructure and presentation concerns.

## Screenshots

### Dashboard

![Dashboard](Screenshots/dashboard.png)

---

### Customers

![Customers](Screenshots/customers.png)

---

### Membership Types

![Membership Types](Screenshots/membership-types.png)

---

### Memberships

![Memberships](Screenshots/memberships.png)

---

### Payments

![Payments](Screenshots/payments.png)

## Security

CloudCRM uses ASP.NET Core Identity for authentication and authorization.

Security features include:

- Custom login page
- ASP.NET Core Identity
- Admin role-based authorization
- `[Authorize(Roles = "Admin")]` protection
- Secure configuration using .NET User Secrets for local development
- Azure App Service environment variables for production configuration
- Passwords and database credentials are not stored in source control

## Docker

The application can be run locally using Docker Compose.

```bash
docker compose up --build
```

Docker Compose runs:

```text
CloudCRM Web Application
        |
        v
SQL Server Container
```

The SQL Server data is stored using a persistent Docker volume.

To stop the containers:

```bash
docker compose down
```

## Azure Deployment

CloudCRM is deployed to Microsoft Azure using:

- Azure App Service for the ASP.NET Core application
- Azure SQL Database for application data
- App Service environment variables for production configuration

The same application can therefore run locally, with Docker, or in Azure.

## CI/CD

GitHub Actions provides automated continuous integration and deployment.

```text
Developer
    |
    | git push
    v
GitHub
    |
    v
GitHub Actions
    |
    | Build & Publish
    v
Azure App Service
    |
    v
Azure SQL Database
```

Pushes to the `main` branch automatically trigger the GitHub Actions workflow.

The workflow:

1. Restores project dependencies
2. Builds the application
3. Publishes the ASP.NET Core application
4. Authenticates to Azure using OIDC
5. Deploys the application to Azure App Service

## Running Locally

### Prerequisites

- .NET 8 SDK
- SQL Server
- Git

Clone the repository:

```bash
git clone https://github.com/shivali-github/CloudCRM-Clean.git
cd CloudCRM-Clean
```

Restore dependencies:

```bash
dotnet restore
```

Apply database migrations:

```bash
dotnet ef database update \
  --project src/CloudCRM.Infrastructure \
  --startup-project src/CloudCRM.Web
```

Run the application:

```bash
dotnet run --project src/CloudCRM.Web
```

## Project Purpose

CloudCRM was developed as a portfolio project to refresh and demonstrate practical experience with modern **.NET, Clean Architecture, Entity Framework Core, Docker, Azure and CI/CD**.

It builds on previous commercial experience developing CRM, membership, payment and reporting applications using C#, ASP.NET and relational databases.

## Author

**Shivali Gharde**

.NET Full Stack Developer  
Aberdeen, Scotland, UK