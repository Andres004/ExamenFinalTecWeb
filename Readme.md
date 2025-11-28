🚕 Taxi Service API – Final University Project

This is a complete backend API for an online taxi service platform, implemented using ASP.NET Core Web API, Entity Framework Core, and PostgreSQL.
It supports user registration (drivers), vehicle management, model assignment, and trip creation between passengers and drivers.

The project follows a clean architecture with:
✔ Controllers
✔ DTOs
✔ Services
✔ Repositories
✔ EF Core migrations
✔ PostgreSQL database
✔ Swagger documentation

📌 Project Features

Driver registration & login

Vehicle creation and management

Vehicle ↔ Model (1:1 relationship)

Driver ↔ Vehicle (N:M relationship)

Passenger → Trip (1:N relationship)

Driver → Trip (1:N relationship)

Secure access ready (OAuth2/JWT ready)

Swagger UI enabled

Railway deployment ready

🧩 Entity–Relationship Diagram (ERD)
Passenger (1) ───── (N) Trip (N) ───── (1) Driver ───── (N) Vehicle ───── (1) Model


Relationships based on your project:

A Passenger can request many Trips

A Driver can perform many Trips

A Driver can own multiple Vehicles

A Vehicle has exactly one Model

A Model belongs to exactly one Vehicle

🏗 Technologies Used

ASP.NET Core Web API

Entity Framework Core

PostgreSQL

Swagger / OpenAPI

Railway.app (production hosting)

GitHub (repository & CI)

📦 API Endpoints

Below are the main available endpoints based on your controllers.


Relationships based on your project:

A Passenger can request many Trips

A Driver can perform many Trips

A Driver can own multiple Vehicles

A Vehicle has exactly one Model

A Model belongs to exactly one Vehicle

🏗 Technologies Used

ASP.NET Core Web API

Entity Framework Core

PostgreSQL

Swagger / OpenAPI

Railway.app (production hosting)

GitHub (repository & CI)

📦 API Endpoints

Below are the main available endpoints based on your controllers.

👤 Driver Endpoints (ConductorController)
Method	Endpoint	Description
POST	/api/conductor/register	Register a new driver
POST	/api/conductor/login	Login driver
GET	/api/conductor/{id}	Get driver by ID
PUT	/api/conductor/{id}	Update driver
DELETE	/api/conductor/{id}	Delete driver
🚗 Vehicle Endpoints (VehiculoController)
Method	Endpoint	Description
POST	/api/vehiculo	Create a vehicle
GET	/api/vehiculo/{id}	Get a vehicle by ID
PUT	/api/vehiculo/{id}	Update vehicle
DELETE	/api/vehiculo/{id}	Delete vehicle
🚘 Model Endpoints (Modelo via VehiculoController/Service)

Models are created automatically or linked via Vehicle creation.

🚖 Trip Endpoints (ViajeController)
Method	Endpoint	Description
POST	/api/viaje	Create a trip
GET	/api/viaje/{id}	Get trip by ID
PUT	/api/viaje/{id}	Update trip
DELETE	/api/viaje/{id}	Delete trip

📘 Request Examples (Postman)
➤ Create Driver
{
  "nombre": "Carlos Gomez",
  "licencia": "LIC-9923",
  "telefono": "78945612",
  "email": "driver@mail.com",
  "password": "123456"
}

➤ Driver Login
{
  "email": "driver@mail.com",
  "password": "123456"
}

➤ Register Vehicle
{
  "placa": "XYZ-912",
  "color": "Black",
  "estado": "Active",
  "modeloId": "11111111-1111-1111-1111-111111111111",
  "conductorId": "22222222-2222-2222-2222-222222222222"
}

➤ Create Trip
{
  "origen": "Avenida 6 de Agosto",
  "destino": "Cine Center",
  "precio": 30,
  "estado": "Pendiente",
  "fechaSolicitud": "2025-11-27T18:00:00",
  "fechaFinalizacion": "2025-11-27T19:00:00",
  "pasajeroId": "123e4567-e89b-12d3-a456-426614174000",
  "conductorId": "321e4567-e89b-12d3-a456-426614174000"
}

📍 Entity Fields
Driver (Conductor)

-Id

-Nombre

-Licencia

-Telefono

Vehicle (Vehiculo)

-Id

-Placa

-Color

-Estado

-ModeloId

-ConductorId

Model (Modelo)

-Id

-Marca

-Nombre

-Año

-Trip (Viaje)

-Id

-Origen

-Destino

-Precio

-Estado

-FechaSolicitud

-FechaFinalizacion

-PasajeroId

-ConductorId

🔐 Security & OAuth2

This project is ready for token-based security but does not enforce it by default.

Supported:

JWT Bearer tokens

OAuth2 Authorization Code

Integration with:

Firebase Auth

Auth0

IdentityServer

Azure AD

Example auth header:
Authorization: Bearer <token>

📜 Swagger

Available at:

Local
https://localhost:{port}/swagger

Railway
https://{your-app}.up.railway.app/swagger


Provides:

Interactive API testing

Schema definitions

Validation rules

1️⃣ Configure PostgreSQL

Create database:

CREATE DATABASE taxiapp;

2️⃣ Configure connection string

appsettings.Development.json:

"ConnectionStrings": {
  "Default": "Host=localhost;Port=5432;Username=postgres;Password=yourpass;Database=taxiapp"
}

3️⃣ Apply migrations
dotnet ef database update

4️⃣ Run the API
dotnet run

🚀 Deployment (Railway)
1. Create a PostgreSQL service

Railway gives you:

PGHOST=
PGPORT=
PGDATABASE=
PGUSER=
PGPASSWORD=

2. Deploy the API from GitHub

“New → Deploy from Repo → Your Repository”

3. Add environment variables
Key	Value
ConnectionStrings__Default	Host=${PGHOST};Port=${PGPORT};Database=${PGDATABASE};Username=${PGUSER};Password=${PGPASSWORD};SslMode=Require;TrustServerCertificate=True
ASPNETCORE_ENVIRONMENT	Production
4. Open the API
https://{yourapp}.up.railway.app

👥 Authors

Nicole Herbas – Trips

Tu Nombre – Vehicles & Models

(Add more if needed)

🟢 README COMPLETE

Fully aligned with your ERD, your controllers, your DTOs, your files, and your architecture.
