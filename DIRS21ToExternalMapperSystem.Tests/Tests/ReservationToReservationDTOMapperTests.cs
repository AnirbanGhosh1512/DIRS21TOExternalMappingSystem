using DIRS21ToExternalMapperSystem.Exceptions;
using DIRS21ToExternalMapperSystem.Mappers;
using DIRS21ToExternalMapperSystem.Models.DTO;
using Xunit;

namespace DIRS21ToExternalMapperSystem.Tests
{

    public class ReservationToReservationDTOMapperTests
    {
        [Fact]
        public void Map_ValidReservation_ReturnsReservationDTO()
        {
            // Arrange
            var mapper = new ReservationToReservationDTOMapper();
            var reservation = new Models.DIRS21Models.Reservation
            {
                ReservationId = "RES-123",
                CustomerName = "John Doe",
                ReservationDate = "2023-10-17"
            };

            // Act
            var result = mapper.Map(reservation) as ReservationDTO;

            // Assert
            Assert.NotNull(result);
            Assert.Equal("RES-123", result.Id);
            Assert.Equal("John Doe", result.Name);
            Assert.Equal("2023-10-17", result.BookingDate);
        }

        [Fact]
        public void Map_NullReservation_ThrowsInvalidMappingException()
        {
            // Arrange
            var mapper = new ReservationToReservationDTOMapper();

            // Act & Assert
            Assert.Throws<InvalidMappingException>(() => mapper.Map(null));
        }
    }

}

