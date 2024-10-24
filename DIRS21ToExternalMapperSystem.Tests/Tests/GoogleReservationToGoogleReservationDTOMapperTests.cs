using Xunit;
using DIRS21ToExternalMapperSystem.Models.DTO;
using DIRS21ToExternalMapperSystem.Models.PartnerModels;
using DIRS21ToExternalMapperSystem.Exceptions;


public class GoogleReservationToGoogleReservationDTOMapperTests
{
    [Fact]
    public void Map_ValidGoogleReservation_ReturnsGoogleReservationDTO()
    {
        // Arrange
        var mapper = new GoogleReservationToGoogleReservationDTOMapper();
        var googleReservation = new GoogleReservation
        {
            GoogleId = "RES-123",
            UserName = "John Doe",
            BookingDate = "2023-10-17"
        };

        // Act
        var result = mapper.Map(googleReservation) as GoogleReservationDTO;

        // Assert
        Assert.NotNull(result);
        Assert.Equal("RES-123", result.GoogleId);
        Assert.Equal("John Doe", result.UserName);
        Assert.Equal("2023-10-17", result.BookingDate);
    }

    [Fact]
    public void Map_NullGoogleReservation_ThrowsInvalidMappingException()
    {
        // Arrange
        var mapper = new GoogleReservationToGoogleReservationDTOMapper();

        // Act & Assert
        Assert.Throws<InvalidMappingException>(() => mapper.Map(null));
    }
}
