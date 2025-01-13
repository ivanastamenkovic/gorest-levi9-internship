# GoRestL9 - QA Practice Project

This project was developed during a QA internship at Levi9. It demonstrates testing practices for a REST API using C#. The GoRest API is used for managing user data, with tests focusing on user creation, retrieval, updating, and deletion.

## Project Structure

- **Helpers**  
  - `Requests.cs`: Contains static methods for sending HTTP requests to the GoRest API (GET, POST, PATCH, DELETE).
  - `UserGenerator.cs`: Generates random user data using the Bogus library.

- **Models**  
  - `JsonFile.cs`: Represents JSON file data with `username` and `password` properties.  
  - `User.cs`: Defines a user model with properties like `id`, `name`, `email`, `gender`, and `status`.

- **Tests**  
  - `FileSaving.cs`: Tests serialization and deserialization of `JsonFile` objects to and from disk.  
  - `UnitTest1.cs`: Tests the GoRest API by verifying:
    - User creation and retrieval.
    - User creation and updating.
    - User creation and deletion.

## Libraries and Tools Used

- **Newtonsoft.Json**: For JSON serialization and deserialization.
- **Bogus**: For generating random user data.
- **xUnit**: For writing and running tests.
- **GoRest API**: A RESTful API for managing user resources.

## Key Features

1. **Dynamic User Generation**  
   - Random users are created using the `UserGenerator` class.

2. **Automated API Testing**  
   - Tests validate API functionality by comparing expected and actual results.

3. **File Handling**  
   - Includes tests for reading and writing JSON files to ensure data integrity.

## How to Run Tests

1. Ensure all dependencies are installed (e.g., `Newtonsoft.Json`, `Bogus`, `xUnit`).
2. Set up an environment variable or include a valid GoRest API token in the `UnitTest1.cs` file.
3. Run the tests using your preferred .NET test runner (e.g., `dotnet test`).

## Notes

- The API token used in the tests is for authentication and should be kept private.
- This project is desktop-first, with a focus on automating QA workflows.
