using DIRS21ToExternalMapperSystem.Exceptions;
using DIRS21ToExternalMapperSystem.Factory;
using DIRS21ToExternalMapperSystem.Handler;
using DIRS21ToExternalMapperSystem.Models.DIRS21Models;
using DIRS21ToExternalMapperSystem.Models.DTO;
using DIRS21ToExternalMapperSystem.Models.PartnerModels;
using Dynamic_Mapping_System.ReadFiles;
using Serilog;

namespace DIRS21ToExternalMapperSystem;


class Program
{
    static void Main(string[] args)
    {
        // This will get the current WORKING directory (i.e. \bin\Debug)
        string workingDirectory = Environment.CurrentDirectory;
        // This will get the current PROJECT directory
        string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
        // This will get current filePath for Reservation
        string filepathReservationJSON = Path.Combine(projectDirectory, "Payloads", "GoogleReservationPayload.json");
        // This will get current filePath for Reservation
        string filepathRoomJSON = Path.Combine(projectDirectory, "Payloads", "GoogleRoomPayload.json");
        // This will get current filePath for logs
        string filepathLOG = Path.Combine(projectDirectory, "logs", "mappinglog.txt");

        // Reservation Mechanism @Anirban 22.10.2024
        ReservationMechanismDIRS21FromGoogle(filepathReservationJSON, filepathLOG);
        ReservationMechanismGoogleFromDIRS21(filepathLOG);

        // Room Mechanism @Anirban 22.10.2024
        RoomMechanismDIRS21FromGoogle(filepathRoomJSON, filepathLOG);
        RoomMechanismGoogleFromDIRS21(filepathLOG);
    }


    private static void ReservationMechanismDIRS21FromGoogle(string filepathReservationJSON, string filepathLOG)
    {
        // Configure Serilog to log to console and file
        Log.Logger = new LoggerConfiguration()
            .WriteTo.Console()
            .WriteTo.File(filepathLOG, rollingInterval: RollingInterval.Day)
            .CreateLogger();

        Log.Information("Application Starting...");

        try
        {
            var factory = new MapperFactory();
            var handler = new MapHandler(factory);

            // Test Google to GoogleReservationDTO mapping
            var googleReservationData = ReadFromFiles.ReadReservationFromJson(filepathReservationJSON);
            Log.Information("Attempting to map GoogleReservation to GoogleReservationDTO");
            var googleReservationDTO = handler.Map(googleReservationData, "Google.Reservation", "DTO.GoogleReservationDTO") as GoogleReservationDTO;

            if (googleReservationDTO != null)
            {
                Log.Information("Mapping from Google Reservation to Google ReservationDTO successful.");
                Console.WriteLine($"Mapped to ReservationDTO: {googleReservationDTO.GoogleId}, {googleReservationDTO.UserName}");
            }
            else
                Log.Information("Mapping from Google Reservation to Google ReservationDTO failed.");

            // Map Google ReservationDTO to DIRS21 Reservation
            Log.Information("Attempting to map GoogleReservationDTO to DIRS21Reservation");
            var dirs21Reservation = handler.Map(googleReservationDTO, "DTO.GoogleReservationDTO", "DIRS21.Reservation") as Reservation;


            if (dirs21Reservation != null)
            {
                Console.WriteLine($"Mapped to DIRS21: {dirs21Reservation.ReservationId}, {dirs21Reservation.CustomerName}");
            }
            else
            {
                Console.WriteLine("Failed to map Google ReservationDTO to DIRS21 Reservation.");
            }
        }
        catch (MappingValidationException ex)
        {
            // Handle validation exception and log it
            Log.Error(ex, $"Validation error during mapping: {ex.Message}");
            Console.WriteLine($"Validation error: {ex.Message}");
        }
        catch (InvalidMappingException ex)
        {
            // Handle other mapping exceptions and log it
            Log.Error(ex, $"Mapping error: {ex.Message}");
            Console.WriteLine($"Mapping error: {ex.Message}");
        }
        catch (Exception ex)
        {
            // Handle general exceptions and log it
            Log.Fatal(ex, "An unexpected error occurred");
            Console.WriteLine($"Unexpected error: {ex.Message}");
        }
        finally
        {
            Log.Information("Application Ending...");
            Log.CloseAndFlush();
        }
    }

    private static void ReservationMechanismGoogleFromDIRS21(string filepathLOG)
    {
        // Configure Serilog to log to console and file
        Log.Logger = new LoggerConfiguration()
            .WriteTo.Console()
            .WriteTo.File(filepathLOG, rollingInterval: RollingInterval.Day)
            .CreateLogger();

        Log.Information("Application Starting...");

        try
        {
            var factory = new MapperFactory();
            var handler = new MapHandler(factory);

            // Test DIRS21 Reservation to DIRS21 ReservationDTO mapping
            var dirs21ReservationData = new Reservation { ReservationId = "123", CustomerName = "John Doe" };
            Log.Information("Attempting to map Reservation to ReservationDTO");
            var reservationDTO = handler.Map(dirs21ReservationData, "DIRS21.Reservation", "DTO.ReservationDTO") as ReservationDTO;

            if (reservationDTO != null)
            {
                Log.Information("Mapping from DIRS21 Reservation to ReservationDTO successful.");
                Console.WriteLine($"Mapped to ReservationDTO: {reservationDTO.Id}, {reservationDTO.Name}");
            }
            else
                Log.Information("Mapping from DIRS21 Reservation to ReservationDTO failed.");

            // Map ReservationDTO to GoogleReservation
            Log.Information("Attempting to map ReservationDTO to GoogleReservation");
            var googleReservation = handler.Map(reservationDTO, "DTO.ReservationDTO", "Google.Reservation") as GoogleReservation;


            if (googleReservation != null)
            {
                Console.WriteLine($"Mapped to Google: {googleReservation.GoogleId}, {googleReservation.UserName}");
            }
            else
            {
                Console.WriteLine("Failed to map DIRS21 ReservationDTO to Google Reservation.");
            }
        }
        catch (MappingValidationException ex)
        {
            // Handle validation exception and log it
            Log.Error(ex, $"Validation error during mapping: {ex.Message}");
            Console.WriteLine($"Validation error: {ex.Message}");
        }
        catch (InvalidMappingException ex)
        {
            // Handle other mapping exceptions and log it
            Log.Error(ex, $"Mapping error: {ex.Message}");
            Console.WriteLine($"Mapping error: {ex.Message}");
        }
        catch (Exception ex)
        {
            // Handle general exceptions and log it
            Log.Fatal(ex, "An unexpected error occurred");
            Console.WriteLine($"Unexpected error: {ex.Message}");
        }
        finally
        {
            Log.Information("Application Ending...");
            Log.CloseAndFlush();
        }
    }

    private static void RoomMechanismGoogleFromDIRS21(string filepathLOG)
    {
        // Configure Serilog to log to console and file
        Log.Logger = new LoggerConfiguration()
            .WriteTo.Console()
            .WriteTo.File(filepathLOG, rollingInterval: RollingInterval.Day)
            .CreateLogger();

        Log.Information("Application Starting...");

        try
        {
            var factory = new MapperFactory();
            var handler = new MapHandler(factory);

            // Test DIRS21 Room to DIRS21 ReservationDTO mapping
            var dirs21RoomData = new Room { RoomId = "123", RoomType = "Delux", Capacity = 3 };
            Log.Information("Attempting to map Room to RoomDTO");
            var roomDTO = handler.Map(dirs21RoomData, "DIRS21.Room", "DTO.RoomDTO") as RoomDTO;

            if (roomDTO != null)
            {
                Log.Information("Mapping from DIRS21 Room to RoomDTO successful.");
                Console.WriteLine($"Mapped to RoomDTO: {roomDTO.Id}, {roomDTO.Type}, {roomDTO.Occupancy}");
            }
            else
                Log.Information("Mapping from DIRS21 Room to RoomDTO failed.");

            // Map ReservationDTO to GoogleReservation
            Log.Information("Attempting to map RoomDTO to GoogleRoom");
            var googleRoom = handler.Map(roomDTO, "DTO.RoomDTO", "Google.Room") as GoogleRoom;


            if (googleRoom != null)
            {
                Console.WriteLine($"Mapped to Google: {googleRoom.GoogleRoomId}, {googleRoom.RoomCategory}");
            }
            else
            {
                Console.WriteLine("Failed to map DIRS21 RoomDTO to GoogleRoom.");
            }
        }
        catch (MappingValidationException ex)
        {
            // Handle validation exception and log it
            Log.Error(ex, $"Validation error during mapping: {ex.Message}");
            Console.WriteLine($"Validation error: {ex.Message}");
        }
        catch (InvalidMappingException ex)
        {
            // Handle other mapping exceptions and log it
            Log.Error(ex, $"Mapping error: {ex.Message}");
            Console.WriteLine($"Mapping error: {ex.Message}");
        }
        catch (Exception ex)
        {
            // Handle general exceptions and log it
            Log.Fatal(ex, "An unexpected error occurred");
            Console.WriteLine($"Unexpected error: {ex.Message}");
        }
        finally
        {
            Log.Information("Application Ending...");
            Log.CloseAndFlush();
        }
    }

    private static void RoomMechanismDIRS21FromGoogle(string filepathRoomJSON, string filepathLOG)
    {
        // Configure Serilog to log to console and file
        Log.Logger = new LoggerConfiguration()
            .WriteTo.Console()
            .WriteTo.File(filepathLOG, rollingInterval: RollingInterval.Day)
            .CreateLogger();

        Log.Information("Application Starting...");

        try
        {
            var factory = new MapperFactory();
            var handler = new MapHandler(factory);

            // Test Google to GoogleReservationDTO mapping
            var googleRoomData = ReadFromFiles.ReadRoomFromJson(filepathRoomJSON);
            Log.Information("Attempting to map GoogleRoom to GoogleRoomDTO");
            var googleRoomDTO = handler.Map(googleRoomData, "Google.Room", "DTO.GoogleRoomDTO") as GoogleRoomDTO;

            if (googleRoomDTO != null)
            {
                Log.Information("Mapping from Google Room to Google RoomDTO successful.");
                Console.WriteLine($"Mapped to RoomDTO: {googleRoomDTO.GoogleRoomId}, {googleRoomDTO.RoomCategory}, {googleRoomDTO.MaxOccupancy}");
            }
            else
                Log.Information("Mapping from Google Reservation to Google ReservationDTO failed.");

            // Map Google RoomDTO to DIRS21 Room
            Log.Information("Attempting to map GoogleRoomDTO to DIRS21Room");
            var dirs21Room = handler.Map(googleRoomDTO, "DTO.GoogleRoomDTO", "DIRS21.Room") as Room;


            if (dirs21Room != null)
            {
                Console.WriteLine($"Mapped to DIRS21: {dirs21Room.RoomId}, {dirs21Room.RoomType}, {dirs21Room.Capacity}");
            }
            else
            {
                Console.WriteLine("Failed to map Google RoomDTO to DIRS21 Room.");
            }
        }
        catch (MappingValidationException ex)
        {
            // Handle validation exception and log it
            Log.Error(ex, $"Validation error during mapping: {ex.Message}");
            Console.WriteLine($"Validation error: {ex.Message}");
        }
        catch (InvalidMappingException ex)
        {
            // Handle other mapping exceptions and log it
            Log.Error(ex, $"Mapping error: {ex.Message}");
            Console.WriteLine($"Mapping error: {ex.Message}");
        }
        catch (Exception ex)
        {
            // Handle general exceptions and log it
            Log.Fatal(ex, "An unexpected error occurred");
            Console.WriteLine($"Unexpected error: {ex.Message}");
        }
        finally
        {
            Log.Information("Application Ending...");
            Log.CloseAndFlush();
        }
    }
}



