# MediCareWeb - added clinic features

## Included
- Dashboard shortcuts for Patients, Doctors, Appointments and Visits
- Doctor list, add, edit and delete screens
- Appointment booking and appointment list
- Complete Visit workflow with diagnosis and visit notes
- `medicare_db.sql` schema for XAMPP MariaDB/MySQL

## Run
1. Extract the folder.
2. Open `MediCareWeb.csproj` in VS Code / Visual Studio.
3. Run `dotnet restore`.
4. Run `dotnet run`.
5. Open the localhost URL printed in the terminal.

## Important database note
The current controllers use in-memory lists for demo records, so records reset when the app restarts. `medicare_db.sql` creates the SQL schema but is not yet connected to the controllers. To make records persist across restarts and laptops, the next step is wiring EF Core/Pomelo to these tables. The XAMPP MySQL service must be running for SQL import/use.
