# BillingAndCollectionSystem  
(2024)

**BillingAndCollectionSystem** is a desktop application developed in **VB.NET** designed for utility service providers to manage consumer billing and payments.  
It allows administrators to create consumer records, generate electricity bills based on meter readings, and track collections and payments.

## Features
- Register and manage consumer information
- Record meter readings and generate monthly electricity bills
- Track billing history and payment status
- Record partial or full payments
- Windows Forms interface with MySQL database integration

## Requirements
- Visual Studio 2012 or later  
  [Download Visual Studio](https://visualstudio.microsoft.com/downloads/)
- .NET Framework 4.8.1 or later  
  [Download .NET Framework 4.8.1](https://dotnet.microsoft.com/en-us/download/dotnet-framework/net481)
- XAMPP or WAMP (for MySQL)  
  [Download XAMPP](https://www.apachefriends.org/index.html)  
  [Download WAMP](https://www.wampserver.com/en/)
- SQLYog or any MySQL client  
  [Download SQLYog](https://github.com/webyog/sqlyog-community/wiki/Downloads)
- MySQL .NET Connector (`MySql.Data.dll`)  
  [Download Connector/NET](https://dev.mysql.com/downloads/connector/net/)

## Installation
1. Download and extract the project `.zip` file.
2. Start MySQL using XAMPP, WAMP, or another server stack.
3. Use SQLYog to import the `.sql` file located in the `sql` folder to initialize the database.
4. Open `BillingAndCollectionSystem.sln` in Visual Studio.
5. Verify the following before running the application:  
   - The project is targeting .NET Framework 4.8.1 or later.  
   - `MySql.Data.dll` is properly referenced in the project.
6. Build and run the application.

---

**Developer:** Janelle Ann Castillo ([nncast](https://github.com/nncast))
