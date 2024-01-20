# Hotel Guide ASP.NET Core Project Documentation

This documentation provides instructions on how to set up and run the Hotel Guide ASP.NET Core project. The project is available on GitHub at [https://github.com/enginsermet/Hotel-Guide](https://github.com/enginsermet/Hotel-Guide).

## Prerequisites

Before running the project, ensure that you have the following prerequisites installed on your machine:

- [.NET SDK](https://dotnet.microsoft.com/download) (version 5.0 or later)
- [Visual Studio](https://visualstudio.microsoft.com/) or any other code editor of your choice
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) or [SQL Server Express](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) (optional if you want to use a local database)

## Getting Started

Follow these steps to set up and run the Hotel Guide ASP.NET Core project:

1. **Clone the Repository:**

   Open a terminal or command prompt and run the following command to clone the repository to your local machine:

   ```bash
   git clone https://github.com/enginsermet/Hotel-Guide.git
   ```

2. **Navigate to the Project Directory:**

   Change your current directory to the project folder:

   ```bash
   cd Hotel-Guide
   ```

3. **Update Connection String (Optional):**

   If you want to use a local database, open the `appsettings.json` file and update the connection string under the `DefaultConnection` section:

   HotelService.appsettings.json

   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=HotelDb;Trusted_Connection=True;MultipleActiveResultSets=true"
   },
   ```
   ReportService.appsettings.json
   
      ```json
   "ConnectionStrings": {
     "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=ReportDb;Trusted_Connection=True;MultipleActiveResultSets=true"
   },
   ```

   Update the connection string based on your SQL Server instance.

5. **Run the Application:**

   Run the following command to build and run the application:

   ```bash
   dotnet run
   ```

   This command will restore dependencies, build the project, and start the application. Open your browser and navigate to [https://localhost:5001](https://localhost:5001) to view the Hotel Guide application.

6. **Explore the Application:**

   Explore the Hotel Guide application and test its features.

7. **Stopping the Application:**

   To stop the application, press `Ctrl + C` in the terminal where the application is running.
