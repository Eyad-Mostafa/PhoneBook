---

# Phone Book

## Introduction
Welcome to the **Phone Book Project**! This application is a powerful yet simple tool designed to help you manage your contacts efficiently. Built with a database-driven approach, this project demonstrates how to perform **CRUD (Create, Read, Update, Delete)** operations using **Entity Framework Core** in a real-world scenario. Whether you're a beginner or an experienced developer, this project will help you understand how to integrate a database with a .NET application while ensuring data validation and organization.

---

## Features
- **Record contacts** with their details (name, phone number, email, and category).
- **CRUD operations**: Add, Delete, Update, and Read contacts seamlessly.
- **Entity Framework Core** (Code-First Approach) for efficient database management.
- **SQL Server** as the database backend for reliable data storage.
- **Contact validation** for email and phone number formats to ensure data integrity.
- **Categorization** of contacts using an `enum` for better organization.

---

## Requirements
- **.NET 6 or later**
- **SQL Server** installed and running
- **Entity Framework Core**

---

## Installation & Setup

### 1. Clone the Repository
```sh
git clone https://github.com/Eyad-Mostafa/PhoneBook.git
cd PhoneBook
```

2. Configure Database Connection
Open appsettings.json and ensure the constr key is correctly set:

```json
{
  "constr": "Server=your_server;Database=PhoneBook;Integrated Security=SSPI;TrustServerCertificate=True;"
}
```
Replace your_server with your SQL Server instance name.
Ensure SQL Server is running and the connection string matches your setup.

- Replace `your_server` with your SQL Server instance name.
- Ensure SQL Server is running and the connection string matches your setup.

### 3. Install Dependencies
```sh
dotnet restore
```

### 4. Apply Migrations
Entity Framework will generate the database schema for you. Run the following commands:
```sh
dotnet ef migrations add InitialCreate
dotnet ef database update
```
This ensures the database structure is created and ready to use.

### 5. Run the Application
```sh
dotnet run
```

---

## Screenshots
Here are some screenshots showcasing the application's functionality:

### Main Menu
![Main Menu](Images/MainMenu.png)

### Add Contact
![Add Contact](Images/AddContact.png)

### Search Results
![Search Results](Images/Search.png)

### View Contacts
![View Contacts](Images/ViewContacts.png)
