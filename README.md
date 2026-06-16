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
- [License](#license)

---

## Features

- **Books** — Add, edit, view, delete, search, and filter books by category and status (Available, Issued, Lost). Includes stock tracking, a live pie chart of book status distribution, and business-rule validation (e.g. status/stock consistency checks, blocking deletion of books with active issue history).
- **Members** — Manage member records including name, phone, email, and address. Full CRUD with search support and validation (name length, phone format, email format). Deletion is blocked while a member has unreturned books.
- **Book Issues** — Issue and return books with automatic stock and status updates. Tracks issue status (Issued, Returned, Overdue), prevents issuing books that are Lost/already Issued/out of stock, and locks a Returned record from being reverted.
- **Announcements** — Create, edit, delete, and toggle active/inactive library announcements, with an "Active Only" filter.
- **Dashboard** — Overview of total books, members, issued/returned/overdue counts, available books, and a live feed of active announcements.
- **Search & Filter** — Text search combined with category/status dropdowns (Books), text search (Members), and status filter (Book Issues).
- **Status Bar** — Displays the current view name and timestamp in the main window, updated on every navigation action.

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
├── App.Core/                       # Class library — models, contracts, services
│   ├── App.Core.csproj
│   ├── Contracts/
│   │   IAnnouncementService.cs
│   │   IBookIssueService.cs
│   │   IBookService.cs
│   │   IMemberService.cs
│   ├── Models/
│   │   Announcement.cs
│   │   Book.cs
│   │   BookIssue.cs
│   │   Member.cs
│   ├── Services/
│   │   DBAnnouncementService.cs
│   │   DBBookIssueService.cs
│   │   DBBookService.cs
│   │   DBMemberService.cs
│   └── Utilities/
│       BookCategoryEnum.cs
│       BookStatusEnum.cs
│       IssueStatusEnum.cs
│
├── App.WindowsApp/                 # WinForms UI application
│   ├── App.WindowsApp.csproj
│   ├── App.config                  # Database connection string
│   ├── Program.cs                  # Application entry point
│   ├── Forms/
│   │   BookForm.cs
│   │   BookIssueForm.cs
│   │   BookPicker.cs
│   │   FormModeEnums.cs
│   │   MainForm.cs
│   │   MemberForm.cs
│   │   MemberPicker.cs
│   ├── Properties/
│   │   Resources.resx
│   ├── Resources/
│   │   (23 icon PNGs — toolbar/navigation icons)
│   └── Views/
│       AnnouncementsView.cs
│       BookIssuesView.cs
│       BooksView.cs
│       DashboardView.cs
│       MembersView.cs
│
├── LibraryManagement.slnx          # Visual Studio solution file
└── README.md
```

*Each form/view listed above has a matching `.resx` file alongside it, plus an auto-generated `.Designer.cs` partial class (regenerated automatically by the Visual Studio Forms Designer, containing only `InitializeComponent()` layout code) — both omitted here for readability.*

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
    BookTitle  NVARCHAR(200) NOT NULL DEFAULT '',
    MemberId   NVARCHAR(20)  NOT NULL REFERENCES Member(Id),
    MemberName NVARCHAR(200) NOT NULL DEFAULT '',
    IssueDate  DATETIME      NOT NULL,
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
