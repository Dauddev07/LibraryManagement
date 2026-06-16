# Library Management System

A Windows Forms desktop application for managing a library's books, members, book issues/returns, and announcements. Built with C# / .NET 10 and Microsoft SQL Server using raw ADO.NET for all data access.

---

## Table of Contents

- [Features](#features)
- [Tech Stack](#tech-stack)
- [Project Structure](#project-structure)
- [Prerequisites](#prerequisites)
- [Database Setup](#database-setup)
- [Getting Started](#getting-started)
- [Screenshots](#screenshots)
- [License](#license)

---

## Features

- **Books** — Add, edit, delete, search, and filter books by category and status (Available, Issued, Lost). Includes stock tracking and a live pie chart of book status distribution.
- **Members** — Manage member records including name, phone, email, and address. Full CRUD with search support.
- **Book Issues** — Issue and return books with automatic stock and status updates. Tracks issue status (Issued, Returned, Overdue).
- **Announcements** — Create and manage library announcements with active/inactive toggling.
- **Dashboard** — Overview of total books, members, issued/returned/overdue counts, available books, and active announcements at a glance.
- **Search & Filter** — Text search combined with category and status dropdowns on the Books view.
- **Status Bar** — Displays the current view name and timestamp, updated on every navigation action.

---

## Tech Stack

| Component | Technology |
|---|---|
| Language | C# (.NET 10) |
| UI Framework | Windows Forms (`net10.0-windows`) |
| Database | Microsoft SQL Server |
| Data Access | ADO.NET (`Microsoft.Data.SqlClient`) |
| Charting | `WinForms.DataVisualization` |
| Configuration | `System.Configuration.ConfigurationManager` |

---

## Project Structure

```
LibraryManagement/
├── App.Core/                        # Class library — models, contracts, services
│   ├── Contracts/                   # Service interfaces
│   │   ├── IBookService.cs
│   │   ├── IMemberService.cs
│   │   ├── IBookIssueService.cs
│   │   └── IAnnouncementService.cs
│   ├── Models/                      # Domain models
│   │   ├── Book.cs
│   │   ├── Member.cs
│   │   ├── BookIssue.cs
│   │   └── Announcement.cs
│   ├── Services/                    # ADO.NET implementations
│   │   ├── DBBookService.cs
│   │   ├── DBMemberService.cs
│   │   ├── DBBookIssueService.cs
│   │   └── DBAnnouncementService.cs
│   └── Utilities/                   # Enums
│       ├── BookCategoryEnum.cs
│       ├── BookStatusEnum.cs
│       └── IssueStatusEnum.cs
│
├── App.WindowsApp/                  # WinForms UI application
│   ├── Forms/                       # Add/Edit dialogs
│   │   ├── MainForm.cs
│   │   ├── BookForm.cs
│   │   ├── MemberForm.cs
│   │   └── BookIssueForm.cs
│   ├── Views/                       # Main content views
│   │   ├── DashboardView.cs
│   │   ├── BooksView.cs
│   │   ├── MembersView.cs
│   │   ├── BookIssuesView.cs
│   │   └── AnnouncementsView.cs
│   └── App.config                   # Database connection string
│
└── LibraryManagement.slnx           # Visual Studio solution file
```

---

## Prerequisites

- Windows OS
- Visual Studio 2022 (v17.x or later) with the **.NET desktop development** workload installed
- .NET 10 SDK
- SQL Server (LocalDB, Express, or full instance)

---

## Database Setup

The application connects to a SQL Server database named `LibraryDB`.

### Step 1 — Create the database

Run the following script in SQL Server Management Studio (SSMS) or any SQL client:

```sql
CREATE DATABASE LibraryDB;
GO

USE LibraryDB;
GO

CREATE TABLE Book (
    Id      NVARCHAR(20)  PRIMARY KEY,
    Title   NVARCHAR(200) NOT NULL,
    Author  NVARCHAR(200) NOT NULL,
    ISBN    NVARCHAR(20)  NOT NULL DEFAULT '',
    Category NVARCHAR(50) NOT NULL,
    Stock   INT           NOT NULL DEFAULT 1,
    Status  NVARCHAR(20)  NOT NULL DEFAULT 'Available'
);

CREATE TABLE Member (
    Id      NVARCHAR(20)  PRIMARY KEY,
    Name    NVARCHAR(200) NOT NULL,
    Phone   NVARCHAR(20)  NOT NULL DEFAULT '',
    Email   NVARCHAR(100) NOT NULL DEFAULT '',
    Address NVARCHAR(300) NOT NULL DEFAULT ''
);

CREATE TABLE BookIssue (
    Id         NVARCHAR(20)  PRIMARY KEY,
    BookId     NVARCHAR(20)  NOT NULL REFERENCES Book(Id),
    MemberId   NVARCHAR(20)  NOT NULL REFERENCES Member(Id),
    IssueDate  DATETIME      NOT NULL,
    DueDate    DATETIME      NOT NULL,
    ReturnDate DATETIME      NULL,
    Status     NVARCHAR(20)  NOT NULL DEFAULT 'Issued'
);

CREATE TABLE Announcement (
    Id          NVARCHAR(20)  PRIMARY KEY,
    Title       NVARCHAR(200) NOT NULL,
    Message     NVARCHAR(1000) NOT NULL,
    PostedDate  DATETIME      NOT NULL,
    IsActive    BIT           NOT NULL DEFAULT 1
);
```

### Step 2 — Configure the connection string

Open `App.WindowsApp/App.config` and update the `Server` value to match your SQL Server instance:

```xml
<connectionStrings>
  <add name="LibraryDB"
       connectionString="Server=localhost;Database=LibraryDB;Trusted_Connection=True;TrustServerCertificate=True;"
       providerName="Microsoft.Data.SqlClient" />
</connectionStrings>
```

Common server name values:

| Instance type | Server value |
|---|---|
| SQL Server Express | `.\SQLEXPRESS` |
| LocalDB | `(localdb)\MSSQLLocalDB` |
| Default local instance | `localhost` or `.` |

---

## Getting Started

1. Clone the repository:
   ```
   git clone https://github.com/Dauddev07/LibraryManagement.git
   ```
2. Open `LibraryManagement.slnx` in Visual Studio.
3. Complete the [Database Setup](#database-setup) steps above.
4. Update the connection string in `App.WindowsApp/App.config` if needed.
5. Right-click `App.WindowsApp` in Solution Explorer → **Set as Startup Project**.
6. Press **F5** to build and run.

---

## License

This project is for educational use — COSC-5136 Advanced Programming, Spring 2026.
