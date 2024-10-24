using Xunit;
using DIRS21ToExternalMapperSystem.Exceptions;
using DIRS21ToExternalMapperSystem.Models.DIRS21Models;
using DIRS21ToExternalMapperSystem.Models.DTO;

public class GoogleReservationDTOToReservationMapperTests
{
    [Fact]
    public void Map_ValidGoogleReservationDTO_ReturnsReservation()
    {
        // Arrange
        var mapper = new GoogleReservationDTOToReservationMapper();
        var googleReservationDTO = new GoogleReservationDTO
        {
            GoogleId = "RES-123",
            UserName = "John Doe",
            BookingDate = "2023-10-17"
        };

        // Act
        var result = mapper.Map(googleReservationDTO) as Reservation;

        // Assert
        Assert.NotNull(result);
        Assert.Equal("RES-123", result.ReservationId);
        Assert.Equal("John Doe", result.CustomerName);
        Assert.Equal("2023-10-17", result.ReservationDate);
    }

    [Fact]
    public void Map_NullGoogleReservationDTO_ThrowsInvalidMappingException()
    {
        // Arrange
        var mapper = new GoogleReservationDTOToReservationMapper();

        // Act & Assert
        Assert.Throws<InvalidMappingException>(() => mapper.Map(null));
    }
}


