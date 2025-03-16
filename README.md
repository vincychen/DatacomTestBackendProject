# RESTful API Project

This project is a RESTful API for managing job applications using ASP.NET Core and Entity Framework Core. It provides endpoints to retrieve and create job applications, utilizing an in-memory database or SQLite for data storage.

## Project Structure

- **Controllers**: Contains the API controllers that define the endpoints.
- **Data**: Contains the database context and repository classes for data access.
- **Models**: Contains the entity models representing the data structure.
- **Services**: Contains the service classes that implement business logic.
- **Program.cs**: The entry point of the application.
- **Startup.cs**: Configures services and the request pipeline.

## Setup Instructions

1. **Clone the repository:**

   ```
   git clone <repository-url>
   ```

2. Navigate to the project directory:

   ```
   cd DatacomTestProject
   ```

3. Restore the dependencies:

   ```
   dotnet restore
   ```

4. Run the application:

   ```
   dotnet run
   ```

5. Access the Swagger UI for API documentation at `http://localhost:5000/swagger`

## Frontend Instructiion

1. Clone the repository:

   ```sh
   git clone https://github.com/vincychen/datacom-test-front-end-project.git
   ```

2. Navigate to the project directory:

   ```sh
   cd datacom-front-end-project
   ```

3. Install the dependencies:

   ```sh
   npm install
   ```

## Additional Information

CORS Configuration: The application is configured to allow requests from http://localhost:3000 by default. You can modify the CORS policy in Startup.cs to suit your needs.
Swagger Configuration: Swagger is configured in Startup.cs to provide API documentation. You can customize the Swagger setup as needed.

## Assumptions

- Added put endpoint for updating status
- Assume the wait time for BE response is short enough since it is running locally - no loading effact
- A network interceptor could have been added in Front End to add authentication header. It was not necessary in this case
