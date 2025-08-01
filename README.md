# Employee API

A .NET 8 Web API project for employee management using Entity Framework Core.

## Project Overview

This project provides a RESTful API for managing employee data with the following features:
- CRUD operations for employees
- Entity Framework Core integration
- SQL Server database support
- Swagger/OpenAPI documentation
- Data validation and annotations

## Employee Model

The Employee model includes the following fields:
- **EmployeeId** - Primary Key (auto-generated)
- **FullName** - Employee's full name (required, max 100 characters)
- **Email** - Email address (required, unique, max 255 characters)
- **Position** - Job position/title (required, max 100 characters)
- **Department** - Department name (required, max 100 characters)
- **Phone** - Phone number (optional, max 20 characters)
- **HireDate** - Date of hire (required)

## Prerequisites

- .NET 8 SDK
- XAMPP (with MySQL and phpMyAdmin)
- Visual Studio Code or Visual Studio

## Setup Instructions

1. **Install .NET 8 SDK**
   ```bash
   # Download from https://dotnet.microsoft.com/download
   ```

2. **Start XAMPP services**
   - Start Apache and MySQL services in XAMPP Control Panel
   - Access phpMyAdmin at http://localhost/phpmyadmin/

3. **Restore packages**
   ```bash
   dotnet restore new1.sln
   ```

4. **Install Entity Framework Core global tools**
   ```bash
   dotnet tool install --global dotnet-ef
   ```

5. **Build the project**
   ```bash
   dotnet build new1.sln
   ```

6. **Update database connection string (if needed)**
   - The project is configured to use MySQL with default XAMPP settings
   - Connection string: `Server=localhost;Port=3306;Database=EmployeeDB;Uid=root;Pwd=;`
   - Modify `appsettings.json` if your MySQL credentials are different

7. **Create and apply migrations**
   ```bash
   dotnet ef migrations add InitialCreate
   dotnet ef database update
   ```

8. **Run the application**
   ```bash
   dotnet run --project EmployeeAPI.csproj
   ```

The application will be available at:
- **Web Interface**: http://localhost:5000 (Home page with authentication)
- **Registration**: http://localhost:5000/Account/Register (Create new account)
- **Login**: http://localhost:5000/Account/Login (Sign in to existing account)
- **Employee Management**: http://localhost:5000/Employee (CRUD Operations - Requires Authentication)
- **API Endpoints**: http://localhost:5000/api/employees (REST API - Requires Authentication)
- **Swagger Documentation**: http://localhost:5000/swagger (API Documentation)

## API Endpoints

### REST API (for programmatic access - requires authentication):
- `GET /api/employees` - Get all employees
- `GET /api/employees/{id}` - Get employee by ID
- `POST /api/employees` - Create new employee
- `PUT /api/employees/{id}` - Update employee
- `DELETE /api/employees/{id}` - Delete employee

### Web Interface (MVC CRUD Operations):
- `/` - Home page (public)
- `/Account/Register` - User registration (public)
- `/Account/Login` - User login (public)
- `/Account/Logout` - User logout (authenticated users)
- `/Employee` - Employee list (authenticated users only)
- `/Employee/Create` - Add new employee (authenticated users only)
- `/Employee/Details/{id}` - View employee details (authenticated users only)
- `/Employee/Edit/{id}` - Edit employee (authenticated users only)
- `/Employee/Delete/{id}` - Delete employee confirmation (authenticated users only)

## Authentication & Security

### ASP.NET Core Identity Features:
- **User Registration** - Create new accounts with email and password
- **User Login/Logout** - Secure authentication with session management
- **Password Requirements** - Minimum 6 characters with uppercase, lowercase, and digits
- **Account Lockout** - Protection against brute force attacks (5 failed attempts)
- **Email Uniqueness** - Each user must have a unique email address
- **Authorization** - Employee management pages require authentication
- **Secure Sessions** - Automatic redirect to login for unauthorized access

### Security Implementation:
- All employee management pages protected with `[Authorize]` attribute
- API endpoints require authentication
- Automatic redirection to login page for unauthorized users
- User-friendly access denied pages
- Logout functionality with session cleanup

## Entity Framework Core Features Used

- **Code First approach** - Models define database schema
- **Data Annotations** - For validation and constraints
- **Auto-generated primary keys** - EmployeeId is auto-incremented
- **Unique constraints** - Email field has unique index
- **Fluent API configuration** - Additional model configuration in DbContext

## Sample Employee JSON

```json
{
  "fullName": "John Doe",
  "email": "john.doe@company.com",
  "position": "Software Developer",
  "department": "IT",
  "phone": "+1-555-0123",
  "hireDate": "2024-01-15T00:00:00"
}
```

## Development

### Entity Framework Core Conventions Used

1. **Primary Key Convention** - Property named `Id` or `{ClassName}Id` is automatically configured as primary key
2. **Auto-increment** - Integer primary keys are auto-generated by default
3. **Required Properties** - Reference types are nullable by default in .NET 8, explicitly marked as required
4. **String Length** - Configured via data annotations and Fluent API
5. **Table Naming** - DbSet property name becomes table name (Employees)

### Building and Testing

```bash
# Build the project
dotnet build

# Run tests (if any)
dotnet test

# Run in development mode
dotnet run --environment Development
```

## Technologies Used

- **.NET 8** - Framework
- **ASP.NET Core MVC** - Web application framework
- **ASP.NET Core Web API** - API framework
- **ASP.NET Core Identity** - Authentication and user management
- **Entity Framework Core 8** - ORM
- **MySQL** - Database (via XAMPP)
- **Pomelo.EntityFrameworkCore.MySql** - MySQL provider for EF Core
- **Bootstrap 5** - Frontend CSS framework
- **Font Awesome** - Icons
- **Swagger/OpenAPI** - API documentation
- **Data Annotations** - Model validation
- **Razor Pages** - Server-side rendering
- **phpMyAdmin** - Database management interface

## License

This project is for educational/demonstration purposes.
