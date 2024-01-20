# Hotel Guide ASP.NET Core Project Documentation

This documentation provides instructions on how to set up and run the Hotel Guide ASP.NET Core project. The project is available on GitHub at [https://github.com/enginsermet/Hotel-Guide](https://github.com/enginsermet/Hotel-Guide).

## Prerequisites

Before running the project, ensure that you have the following prerequisites installed on your machine:

- [.NET SDK](https://dotnet.microsoft.com/download) (version 7.0 or later)
- [Visual Studio](https://visualstudio.microsoft.com/) or any other code editor of your choice
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
  
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




# HotelsController API Documentation

   The `HotelsController` in the Hotel Guide ASP.NET Core project provides endpoints to perform CRUD (Create, Read, Update, Delete) operations on hotel-related entities. This documentation explains the functionality of each endpoint and how to interact with them.

## Endpoints Overview

### 1. `GET: api/Hotels/Officials`

- **Description:** Retrieves a list of hotels along with basic information.
- **Endpoint:** `/api/Hotels/Officials`
- **HTTP Method:** GET
- **Returns:** List of hotel officials.

### 2. `GET: api/Hotels/Details/{id}`

- **Description:** Retrieves detailed information about a specific hotel, including contact information.
- **Endpoint:** `/api/Hotels/Details/{id}`
- **HTTP Method:** GET
- **Parameters:**
  - `id` (Guid): The unique identifier of the hotel.
- **Returns:** Detailed information about the hotel, including contact information.

### 3. `PUT: api/Hotels/Update/{id}`

- **Description:** Updates the information of a specific hotel.
- **Endpoint:** `/api/Hotels/Update/{id}`
- **HTTP Method:** PUT
- **Parameters:**
  - `id` (Guid): The unique identifier of the hotel.
  - `hotelDto` (RequestBody): The updated information for the hotel in the form of a `HotelDto` object.
- **Returns:** No content on success.

### 4. `POST: api/Hotels/Create`

- **Description:** Creates a new hotel record along with contact information.
- **Endpoint:** `/api/Hotels/Create`
- **HTTP Method:** POST
- **Parameters:**
  - `createHotelDto` (RequestBody): The information for creating a new hotel in the form of a `CreateHotelDto` object.
- **Returns:** A `CreateHotelDto` object containing information about the created hotel.

### 5. `POST: api/Hotels/Report`

- **Description:** Creates a report for a specified location and publishes a message queue using MassTransit.
- **Endpoint:** `/api/Hotels/Report`
- **HTTP Method:** POST
- **Parameters:**
  - `location` (QueryParameter): The location for which the report is generated.
- **Returns:** OK with a message if the report creation message is successfully published.

### 6. `DELETE: api/Hotels/Delete/{id}`

- **Description:** Deletes a specific hotel.
- **Endpoint:** `/api/Hotels/Delete/{id}`
- **HTTP Method:** DELETE
- **Parameters:**
  - `id` (Guid): The unique identifier of the hotel.
- **Returns:** No content on success. 

# ContactsController API Documentation

The `ContactsController` in the Hotel Service ASP.NET Core project provides endpoints to manage contact information related to hotels. This documentation explains the functionality of each endpoint and how to interact with them.

## Endpoints Overview

### 1. `POST: api/Contacts/Add`

- **Description:** Adds contact information for a specific hotel.
- **Endpoint:** `/api/Contacts/Add`
- **HTTP Method:** POST
- **Parameters:**
  - `hotelId` (QueryParameter): The unique identifier of the hotel for which the contact information is being added.
  - `contactInfoDto` (RequestBody): The contact information to be added in the form of a `ContactInfoDto` object.
- **Returns:** A `ContactInfo` object containing information about the added contact.

### 2. `DELETE: api/Contacts/Delete/{id}`

- **Description:** Deletes a specific contact information entry.
- **Endpoint:** `/api/Contacts/Delete/{id}`
- **HTTP Method:** DELETE
- **Parameters:**
  - `id` (Guid): The unique identifier of the contact information entry.
- **Returns:** No content on success.

## Prerequisites

Before interacting with the API, make sure the Hotel Service ASP.NET Core project is set up and running.

## How to Interact

Use a tool like [Postman](https://www.postman.com/) or `curl` commands to interact with the API endpoints. Ensure proper authentication if required.

## Note

- The API uses AutoMapper for mapping between DTOs and entities.
- The `hotelId` parameter in the `AddContactInfo` endpoint is used to associate contact information with a specific hotel.
- Ensure that the `HotelDbContext` is configured correctly, and the `Contacts` entity set is available.

# ReportsController API Documentation

The `ReportsController` in the Report Service ASP.NET Core project provides endpoints to manage reports. This documentation explains the functionality of each endpoint and how to interact with them.

## Endpoints Overview

### 1. `GET: api/Reports`

- **Description:** Retrieves a list of all reports.
- **Endpoint:** `/api/Reports`
- **HTTP Method:** GET
- **Returns:** A list of `Report` objects.

### 2. `GET: api/Reports/{id}`

- **Description:** Retrieves a specific report by its unique identifier.
- **Endpoint:** `/api/Reports/{id}`
- **HTTP Method:** GET
- **Parameters:**
  - `id` (Guid): The unique identifier of the report.
- **Returns:** A `Report` object with detailed information.

### 3. `DELETE: api/Reports/{id}`

- **Description:** Deletes a specific report by its unique identifier.
- **Endpoint:** `/api/Reports/{id}`
- **HTTP Method:** DELETE
- **Parameters:**
  - `id` (Guid): The unique identifier of the report.
- **Returns:** No content on success.

## Prerequisites

Before interacting with the API, make sure the Report Service ASP.NET Core project is set up and running.

## Note

- The API uses AutoMapper for mapping between DTOs and entities.
- Ensure that the `ReportDbContext` is configured correctly, and the `Reports` entity set is available.



