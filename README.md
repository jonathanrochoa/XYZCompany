# XYZCompany

##Introduction
Web API, employee management application for XYZCompany created for learning purposes using .NET Core

The Employee Management API is a .NET Core application that serves as a simple platform for managing basic employee information such as name and job titles. This project was developed for educational purposes to demonstrate the creation of a RESTful API using .NET Core and Entity Framework Core with MSSQLLocalDB.

##eatures
- Create, Read, Update, and Delete (CRUD) operations for employee data.
- Retrieve a list of available job titles.
- Secure endpoints using JWT-based authentication.

##Getting Started
Prerequisites
To run this project, you'll need the following software installed on your machine:

-.NET Core SDK (version x.x or later)
-Visual Studio or your preferred code editor
-MSSQLLocalDB (or a connection to your MSSQL database)

##Installation
1. Clone this repository to your local machine.
git clone https://github.com/your-username/employee-management-api.git
2. Open the solution in Visual Studio or your code editor.
3. In the appsettings.json file, configure the connection string to your MSSQLLocalDB or database server:
  {
    "ConnectionStrings": {
      "DefaultConnection": "Server=(localdb)\\MSSQLLocalDB;Database=EmployeeManagementDb;Trusted_Connection=True;"
    },
  }
4. Build and run the application
   dotnet run


## API Endpoint Usage

### Employees

#### Retrieve All Employees
- **GET /employees**

  Retrieve a list of all employees.

#### Retrieve Employee by ID
- **GET /employees/{id}**

  Retrieve a specific employee by their ID.

#### Search for Employees
- **GET /employees?search={keyword}**

  Search for employees by a keyword in their name.

#### Create a New Employee
- **POST /employees**

  Create a new employee by sending a JSON request body with the following fields:
  ```json
  {
    "firstName": "John",
    "lastName": "Doe",
    "titleId": "TitleIdHere"
  }

Update an Existing Employee
PUT /employees/{id}

Update an existing employee by their ID. Send a JSON request body with the fields you want to update.

Delete an Employee
DELETE /employees/{id}

Delete an employee by their ID.

##Titles
Retrieve All Job Titles
GET /titles

Retrieve a list of available job titles.

Retrieve Job Title by ID
GET /titles/{id}

Retrieve a specific job title by its ID.

Create a New Job Title
POST /titles

Create a new job title by sending a JSON request body with the following fields:
{
  "name": "Software Developer",
  "description": "A software developer's job title."
}

Update an Existing Job Title
PUT /titles/{id}

Update an existing job title by its ID. Send a JSON request body with the fields you want to update.

Delete a Job Title
DELETE /titles/{id}

Delete a job title by its ID.



![XYZCompanyDataFlow](https://github.com/jonathanrochoa/XYZCompany/assets/49356114/1ceb5fd3-7f67-4b56-b912-fed69dd9fded)

Working API
Request to POST data to titles:
![POST_titles](https://github.com/jonathanrochoa/XYZCompany/assets/49356114/999f03c9-f492-45c5-abb5-d7b5b5c53f8e)

Response from POST data to titles:
![POST_titles_RESPONSE](https://github.com/jonathanrochoa/XYZCompany/assets/49356114/6c19e45f-c244-4ce0-b999-20b041f84991)

Request to POST data to employees:
![POST_employee](https://github.com/jonathanrochoa/XYZCompany/assets/49356114/a0830825-6171-4cb0-87d4-9eaaf28257b7)

Response from POST data to employees:
![POST_employee_RESPONSE](https://github.com/jonathanrochoa/XYZCompany/assets/49356114/a66d08ef-9d6f-4c44-839f-ca35d9c945b4)
