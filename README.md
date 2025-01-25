# Employee Management System

A web application to manage employee details, attendance, leave requests, and payroll.

## Technologies

- Backend: .NET Core
- Database: SQL Server
- Authentication: JWT

## Setup

1. Clone the repository:
   ```bash
   git clone https://github.com/lahiruudayakumara/employee-managment-system-dot-net.git
   ```

2. Navigate to the project folder:
   ```bash
   cd employee-managment-system-dot-net
   ```

3. Restore dependencies:
   ```bash
   dotnet restore
   ```

4. Apply database migrations:
   ```bash
   dotnet ef database update
   ```

5. Run the app:
   ```bash
   dotnet run
   ```