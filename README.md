# Library Management System

A Windows Forms desktop application for managing a library's books, members, book issues/returns, and announcements. Built with .NET 10 (Windows Forms) and Microsoft SQL Server.

## Project Structure

```
LibraryManagement/
├── App.Core/                  # Class library: models, contracts, and business/data services
│   ├── Models/                 # Book, Member, BookIssue, Announcement
│   ├── Contracts/               # Service interfaces (IBookService, IMemberService, etc.)
│   ├── Services/                 # SQL Server-backed service implementations
│   └── Utilities/                 # Enums (BookCategory, BookStatus, IssueStatus)
├── App.WindowsApp/             # WinForms UI application
│   ├── Forms/                    # Add/Edit dialogs and picker forms
│   ├── Views/                     # Main views (Dashboard, Books, Members, Book Issues, Announcements)
│   └── App.config                  # Database connection string
└── LibraryManagement.sln       # Visual Studio solution file
```

## Features

- **Books** – add, edit, delete, search, and track stock/status (Available, Issued, Lost)
- **Members** – manage member records (name, phone, email, address)
- **Book Issues** – issue and return books, track issue status (Issued, Returned, Overdue)
- **Announcements** – create and manage library announcements
- **Dashboard** – overview of library activity

## Tech Stack

- C# / .NET 10
- Windows Forms (`net10.0-windows`)
- Microsoft SQL Server (via `Microsoft.Data.SqlClient`)
- `WinForms.DataVisualization` for charts on the dashboard

## Prerequisites

- Windows OS
- Visual Studio 2022 (17.x) or later with the **.NET desktop development** workload
- .NET 10 SDK
- SQL Server (LocalDB, Express, or full instance)

## Database Setup

The application expects a SQL Server database named `LibraryDB`. The connection string is configured in `App.WindowsApp/App.config`:

```xml
<connectionStrings>
  <add name="LibraryDB"
       connectionString="Server=localhost;Database=LibraryDB;Trusted_Connection=True;TrustServerCertificate=True;"
       providerName="Microsoft.Data.SqlClient" />
</connectionStrings>
```

Update the `Server` value to match your local SQL Server instance, and create the corresponding tables (`Book`, `Member`, `BookIssue`, `Announcement`) matching the model properties before running the app.

## Getting Started

1. Clone the repository.
2. Open `LibraryManagement.slnx` in Visual Studio.
3. Update the connection string in `App.WindowsApp/App.config` if needed.
4. Set `App.WindowsApp` as the startup project (right-click the project → **Set as Startup Project**).
5. Build and run (F5).

## License

This project is for educational/personal use.
