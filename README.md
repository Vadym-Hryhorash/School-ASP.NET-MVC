# School Management System (ASP.NET Core MVC)

A web application for managing students. This project was developed to demonstrate practical skills in building scalable ASP.NET Core applications using a clean, layered architecture and relational databases.

<img width="1856" height="935" alt="image" src="https://github.com/user-attachments/assets/85e5eb78-fc10-44a3-97d8-30a22299d46b" />


## 🚀 Features
* **Student Management:** Full CRUD (Create, Read, Update, Delete) operations for student records.
* **Relational Data Binding:** Students are correctly mapped to their respective Teachers and Classes.
* **Robust Validation:** Comprehensive server-side validation using `ModelState` and custom Business Logic rules.
* **Data Seeding:** Automatic database population with initial Teacher records using Entity Framework Core seeding.

## 🛠 Tech Stack & Architecture
* **Framework:** ASP.NET Core MVC (.NET)
* **Language:** C#
* **Database:** PostgreSQL
* **ORM:** Entity Framework Core
* **Architecture:** 3-Layer Architecture (Controllers -> Services -> Repositories)
* **Key Concepts:** Dependency Injection (DI), Inversion of Control (IoC), LINQ Projections, Separation of Concerns (SoC).

## 🧠 Technical Highlights
* **Optimized Database Queries:** Eliminated double-materialization (memory leaks) by returning `IQueryable` from Repositories and executing ordering/filtering at the database level.
* **Dependency Injection:** Controllers are completely decoupled from data access layers. `DbContext` is injected securely.
* **Clean Deletion:** Implemented EF Core's `ExecuteDelete()` for high-performance, tracking-free record removal.

## 💻 How to Run Locally

Follow these steps to get the project up and running on your local machine.

**1. Clone the repository**
```bash
git clone [https://github.com/Vadym-Hryhorash/SchoolManagement-MVC.git](https://github.com/Vadym-Hryhorash/SchoolManagement-MVC.git)
cd SchoolManagement-MVC
```

**2. Configure the Database Connection**
Open `appsettings.json` and update the `DefaultConnection` string with your PostgreSQL credentials:
```json
"ConnectionStrings": {
  "DefaultConnection": "Host=localhost;Port=5432;Database=school;Username=YOUR_USERNAME;Password=YOUR_PASSWORD"
}
```
*(Alternatively, you can use .NET User Secrets to keep your credentials safe).*

**3. Apply Migrations and Seed Data**
Open your terminal in the project folder and run Entity Framework tools to automatically create the database and seed initial data (Teachers):
```bash
dotnet ef database update
```

**4. Run the Application**
```bash
dotnet run
```
The application will start, and you can access it in your browser at `http://localhost:5000` (or the port specified in your terminal).
