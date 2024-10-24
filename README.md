#DIRS21TOExternalMappingSystem

Overview:
  The Dynamic Mapping System is built using .NET and C# and is designed to map data between the internal DIRS21 models and external partner models (e.g., Google).    It facilitates the conversion of data between different models using an extensible architecture that leverages the Factory Pattern, Mapper Pattern, and follows     SOLID principles for maintainability and extensibility.

Key Features:
  Dynamic Mapping: Easily map data between external and internal models.
  JSON Support: Reads data from JSON files and deserializes them into objects.
  Extensibility: New mappers and models can be added to the system with minimal effort.
  Error Handling: Includes basic error handling and logging for deserialization and mapping failures.

Table of Contents:
  . Project Structure
  . Prerequisites
  . Setup and Installation
  . Usage
  . Adding New Mappers
  . Running Tests
  . Assumptions and Limitations
  . License


Project Structure:

<img width="661" alt="Screenshot 2024-10-24 at 08 08 16" src="https://github.com/user-attachments/assets/e7963eba-b141-4b75-ab59-8e1c8254c0bd">

Prerequisites:

  1. .NET SDK (version 6.0 or higher)
  2. C#
  3. xUnit for testing
Ensure that you have the .NET SDK installed before you proceed with running or testing the project.

Setup and Installation:

  Clone the repository:
  
  1. git clone https://github.com/AnirbanGhosh1512/DIRS21TOExternalMappingSystem
  2. cd DIRS21TOExternalMappingSystem

  Restore the required packages:

  1. dotnet restore

  Build the project:

  1. dotnet build

Usage:
The system reads JSON files and dynamically maps external models (like GoogleReservation and GoogleRoom) to internal models (like Reservation and Room).

Example Usage:
<img width="784" alt="Screenshot 2024-10-24 at 08 27 12" src="https://github.com/user-attachments/assets/be59ffa1-08e8-4a0d-8e3d-8b296074d828">

Adding New Mappers:
  Create a new Mapper Class:

  Implement the IModelMapper interface.
    . Define how the new source model is mapped to the target model.

<img width="711" alt="Screenshot 2024-10-24 at 08 30 01" src="https://github.com/user-attachments/assets/a4dd7cc0-2d24-494a-a8d3-915ae9ddfa76">

Register the Mapper:

Add the new mapper to MapperFactory.cs:

<img width="905" alt="Screenshot 2024-10-24 at 08 33 16" src="https://github.com/user-attachments/assets/9ce68ae9-c087-47eb-a383-e0c4bc9d33e5">

Running Tests
  1. Unit tests have been provided to validate the functionality of mappers and file reading methods.

Run all tests:

<img width="855" alt="Screenshot 2024-10-24 at 08 33 29" src="https://github.com/user-attachments/assets/fa9bd398-651c-4559-b7f8-97c3868337b6">

  2. Test specific functionality: To run specific tests, navigate to the corresponding test file in the Tests/ directory and run them using your IDE or terminal.

Assumptions and Limitations:

Assumptions:
  JSON files are well-formed and follow the expected structure.
  The system assumes the source and target models have a one-to-one correspondence.

Limitations:
  The current design assumes that models are stored in JSON files. More complex data sources like APIs or databases may need further enhancements.
  Concurrency: The system is not thread-safe and may need additional synchronization for multi-threaded environments.
  Error Handling: The current error handling is minimal and can be expanded with a logging framework for production use.

License:
  This project is licensed under the MIT License.

