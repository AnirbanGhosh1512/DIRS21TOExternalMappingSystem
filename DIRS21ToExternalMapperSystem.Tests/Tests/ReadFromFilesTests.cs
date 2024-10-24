using Xunit;
using System.IO;
using System.Text.Json;
using Dynamic_Mapping_System.ReadFiles;

public class ReadFromFilesTests
{
    [Fact]
    public void ReadReservationFromJson_ValidFile_ReturnsGoogleReservation()
    {
        // This will get the current WORKING directory (i.e. \bin\Debug)
        string workingDirectory = Environment.CurrentDirectory;
        // This will get the current PROJECT directory
        string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
        // This will get current filePath for Reservation
        string filePath = Path.Combine(projectDirectory, "PayloadsTest", "valid_reservation.json");
        // Arrange
        string json = @"
        {
            ""GoogleId"": ""RES-123"",
            ""UserName"": ""John Doe"",
            ""BookingDate"": ""2023-10-17""
        }";

        File.WriteAllText(filePath, json);  // Create a temporary JSON file for testing

        // Act
        var result = ReadFromFiles.ReadReservationFromJson(filePath);

        // Assert
        Assert.NotNull(result);
        Assert.Equal("RES-123", result.GoogleId);
        Assert.Equal("John Doe", result.UserName);
        Assert.Equal("2023-10-17", result.BookingDate);

        // Cleanup
        File.Delete(filePath);
    }

    [Fact]
    public void ReadRoomFromJson_ValidFile_ReturnsGoogleRoom()
    {
        // This will get the current WORKING directory (i.e. \bin\Debug)
        string workingDirectory = Environment.CurrentDirectory;
        // This will get the current PROJECT directory
        string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
        // This will get current filePath for Reservation
        string filePath = Path.Combine(projectDirectory, "PayloadsTest", "valid_room.json");
        // Arrange
        string json = @"
        {
            ""GoogleRoomId"": ""ROOM-001"",
            ""RoomCategory"": ""Deluxe"",
            ""MaxOccupancy"": 2
        }";

        File.WriteAllText(filePath, json);  // Create a temporary JSON file for testing

        // Act
        var result = ReadFromFiles.ReadRoomFromJson(filePath);

        // Assert
        Assert.NotNull(result);
        Assert.Equal("ROOM-001", result.GoogleRoomId);
        Assert.Equal("Deluxe", result.RoomCategory);
        Assert.Equal(2, result.MaxOccupancy);

        // Cleanup
        File.Delete(filePath);
    }

    [Fact]
    public void ReadReservationFromJson_FileNotFound_ReturnsNull()
    {
        // This will get the current WORKING directory (i.e. \bin\Debug)
        string workingDirectory = Environment.CurrentDirectory;
        // This will get the current PROJECT directory
        string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
        // This will get current filePath for Reservation
        string filePath = Path.Combine(projectDirectory, "PayloadsTest", "non_existent_reservation.json");

        // Act
        var result = ReadFromFiles.ReadReservationFromJson(filePath);

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void ReadRoomFromJson_FileNotFound_ReturnsNull()
    {
        // This will get the current WORKING directory (i.e. \bin\Debug)
        string workingDirectory = Environment.CurrentDirectory;
        // This will get the current PROJECT directory
        string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
        // This will get current filePath for Reservation
        string filePath = Path.Combine(projectDirectory, "PayloadsTest", "non_existent_room.json");

        // Act
        var result = ReadFromFiles.ReadRoomFromJson(filePath);

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void ReadReservationFromJson_InvalidJson_ThrowsJsonException()
    {

        // Arrange
        string invalidJson = @"{ Invalid Json }";
        // This will get the current WORKING directory (i.e. \bin\Debug)
        string workingDirectory = Environment.CurrentDirectory;
        // This will get the current PROJECT directory
        string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
        // This will get current filePath for Reservation
        string filePath = Path.Combine(projectDirectory, "PayloadsTest", "invalid_reservation.json");

        File.WriteAllText(filePath, invalidJson);  // Create a temporary invalid JSON file

        // Act & Assert
        var ex = Record.Exception(() => ReadFromFiles.ReadReservationFromJson(filePath));

        Assert.NotNull(ex);
        Assert.IsType<JsonException>(ex);

        // Cleanup
        File.Delete(filePath);
    }

    [Fact]
    public void ReadRoomFromJson_InvalidJson_ThrowsJsonException()
    {
        // Arrange
        string invalidJson = @"{ Invalid Json }";
        // This will get the current WORKING directory (i.e. \bin\Debug)
        string workingDirectory = Environment.CurrentDirectory;
        // This will get the current PROJECT directory
        string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
        // This will get current filePath for Reservation
        string filePath = Path.Combine(projectDirectory, "PayloadsTest", "invalid_room.json");

        File.WriteAllText(filePath, invalidJson);  // Create a temporary invalid JSON file

        // Act & Assert
        var ex = Record.Exception(() => ReadFromFiles.ReadRoomFromJson(filePath));

        Assert.NotNull(ex);
        Assert.IsType<JsonException>(ex);

        // Cleanup
        File.Delete(filePath);
    }
}


