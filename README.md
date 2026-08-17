# TishiesVeggies 🥦🍎

A simple fruit and vegetable intake tracker built with ASP.NET Core Razor Pages.

## Overview

TishiesVeggies is a lightweight web app that helps users log and track their daily fruit and vegetable intake. It was built as a hands-on portfolio project to get practical, real-world experience with the full lifecycle of a web application — from data modelling and local development through to deploying a live app on Azure.

## Why I built it

I wanted a project that went beyond tutorials and forced me to solve real problems: designing a data model, writing migrations, handling a persistent database in the cloud, and debugging deployment issues that only show up once an app is actually running in production (not just on localhost). Tracking fruit and veg intake is also a genuinely useful, everyday problem — small enough in scope to finish, but with enough moving parts (data relationships, logging over time, a real database) to be a solid demonstration of my ASP.NET Core and C# skills for my portfolio.

## Features

- Log fruit and vegetable servings, including custom (non-preset) items
- View a history of past entries
- Simple, clean Razor Pages UI

## Tech Stack

- **Framework:** ASP.NET Core Razor Pages (C#)
- **Database:** SQLite, accessed via `TishiesVeggiesDbContext`
- **ORM:** Entity Framework Core, with migrations:
  - `InitialCreate`
  - `AddCustomFruitNameToLog`
  - `FixedNullableLogs`
- **Hosting:** Azure App Service

## Data Model

Two core tables:

- **Fruit** — the catalogue of fruits/vegetables that can be logged
- **Log** — individual intake entries, linked back to a `Fruit` (or a custom name if not in the catalogue)

## Deployment Notes

The app is deployed to Azure App Service, with the SQLite database persisted at `/home/data/vegie.db`. One notable fix during deployment: an early version threw a `no such table: Fruits` error on Azure because migrations weren't being applied automatically — resolved by adding `db.Database.Migrate()` to `Program.cs` so EF Core applies pending migrations on startup.

## Getting Started

```bash
git clone <repo-url>
cd TishiesVeggies
dotnet restore
dotnet ef database update
dotnet run
```

## Future Ideas

- Charts/visualisations of intake trends over time
- Daily/weekly goals and streaks
- User accounts for multiple people to track separately

---

*Built as a personal portfolio project to develop practical skills in ASP.NET Core, EF Core, and cloud deployment.*
