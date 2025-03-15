# RESTful API Project

This project is a RESTful API for managing job applications using ASP.NET Core and Entity Framework Core. It provides endpoints to retrieve and create job applications, utilizing an in-memory database or SQLite for data storage.

## Project Structure

- **Controllers**: Contains the API controllers that define the endpoints.
- **Data**: Contains the database context and repository classes for data access.
- **Models**: Contains the entity models representing the data structure.
- **Services**: Contains the service classes that implement business logic.
- **Program.cs**: The entry point of the application.
- **Startup.cs**: Configures services and the request pipeline.

## Endpoints

- **GET /applications**: Retrieve all job applications.
- **GET /applications/{id}**: Retrieve a specific job application by ID.
- **POST /applications**: Add a new job application.

## Setup Instructions

1. Clone the repository:
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

5. Access the Swagger UI for API documentation at `http://localhost:5000/swagger`.

## Technologies Used

- ASP.NET Core
- Entity Framework Core
- SQLite (or In-Memory Database)
- Swagger for API documentation

## Contributing

Feel free to submit issues or pull requests for improvements or bug fixes.