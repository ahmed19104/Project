# Project (MoviesCLS) - Cinema Ticket Platform

A full-stack **ASP.NET Core 9 MVC** web app for browsing movies and buying cinema tickets. It uses SQL Server with Entity Framework Core (Code-First), ASP.NET Core Identity for accounts and roles, and a per-user shopping cart stored in the database.

## Table of contents

- [Features](#features)
- [Tech stack](#tech-stack)
- [Architecture](#architecture)
- [Data model](#data-model)
- [Project structure](#project-structure)
- [Getting started](#getting-started)
- [Default accounts](#default-accounts)

## Features

**For visitors and customers**
- Browse movies with **pagination**.
- **Search** movies by text (`Movies/Filter`).
- Movie details: description, price, cinema, producer, actors, category and showing dates.
- Register, log in and log out (ASP.NET Core Identity).
- **Shopping cart:** add and remove tickets, review the cart.
- **Complete order** (login required) and view order history.

**For administrators**
- Full CRUD for **movies**, **actors**, **producers** and **cinemas**.
- Users list page.
- Toast notifications for user feedback (NToastNotify).

## Tech stack

- C# / .NET 9, ASP.NET Core MVC (Razor views)
- Entity Framework Core 9 (SQL Server), Code-First migrations
- ASP.NET Core Identity (`AppUser` extends `IdentityUser`, roles `Admin` and `User`)
- NToastNotify (toast messages)
- Bootstrap (UI)

## Architecture

Layered MVC with the repository and service pattern:

- **Controllers** handle requests: Account, Actors, Cinema, Movies, Order, Producert (producers).
- **Services** (`Data/Services`) hold business logic behind interfaces (`IMoviesService`, `IActorsServices`, `ICinemaServise`, `IProducertServies`, `IOrdersService`).
- **Generic repository:** `EntityBaseRepository<T>` over `IEntityBase`.
- **ViewModels** for forms (`NewMovieVm`, `NewMovieDropDownVm`, `LoginVm`, `RegisterVm`, `ShoppingCartVm`).
- **ShoppingCart** service (per-user cart rows stored in the database, with quantity per movie).
- Dependency injection wires everything in `Program.cs`.

## Data model

| Entity | Key fields | Relations |
| --- | --- | --- |
| `Movie` | Name, Description, Price, ImageURL, StartDate, EndDate, MovieCategory | belongs to a `Cinema` and a `Producert`; many-to-many with `Actor` through `Actor_Movie` |
| `Actor` | FullName, ProfilePictureURL | many-to-many with movies |
| `Producert` (producer) | FullName, ProfilePictureURL | has many movies |
| `Cinema` | Name, Logo | has many movies |
| `Order` / `OrderItem` | Email, DateTime | order belongs to an `AppUser` and has many items, each linked to a movie |
| `ShoppingCartItem` | Movie, Price, Quantity, AppUserId | per-user cart rows |
| `AppUser` | FullName | extends `IdentityUser` |

Movie categories: `Action`, `Comedy`, `Drama`, `Documentary`, `Horror`, `Cartoon`.

## Project structure

```
Project/
├── Project.sln
└── Project/
    ├── Controllers/        # Account, Actors, Cinema, Movies, Order, Producert
    ├── Data/
    │   ├── AppDbContext.cs
    │   ├── AppDbInitialzier.cs   # Seed data, roles and users
    │   ├── Base/                 # Generic repository
    │   ├── Cart/ShoppingCart.cs
    │   ├── Services/             # Business logic
    │   ├── Static/               # Pager, UserRoles
    │   └── ViewModel/
    ├── Models/
    ├── Migrations/
    ├── Views/                    # Razor views per controller
    ├── wwwroot/                  # CSS, JS, libraries
    ├── appsettings.json
    └── Program.cs
```

## Getting started

**Prerequisites:** [.NET 9 SDK](https://dotnet.microsoft.com/download) and SQL Server (or SQL Server Express).

1. Clone the repo:
   ```bash
   git clone https://github.com/ahmed19104/Project.git
   cd Project/Project
   ```
2. Set your SQL Server connection string in `appsettings.json` under `ConnectionStrings:conString`.
3. Create the database (migrations are included):
   ```bash
   dotnet ef database update
   ```
4. Run:
   ```bash
   dotnet run
   ```

On startup the app seeds sample data, the two roles and two default users.

## Default accounts

Seeded at first run (`AppDbInitialzier.cs`):

| Role | Email |
| --- | --- |
| Admin | `Admin@etickets.com` |
| User | `user@etickets.com` |

The passwords are set in `AppDbInitialzier.cs`. Change them before any real deployment.

## Author

**Ahmed Yaser** - [@ahmed19104](https://github.com/ahmed19104)
