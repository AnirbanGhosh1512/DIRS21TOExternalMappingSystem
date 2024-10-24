using DIRS21ToExternalMapperSystem.Exceptions;
using DIRS21ToExternalMapperSystem.Mappers;
using DIRS21ToExternalMapperSystem.Models.DTO;
using DIRS21ToExternalMapperSystem.Models.PartnerModels;
using Xunit;

namespace DIRS21ToExternalMapperSystem.Tests
{

    public class ReservationDTOToGoogleReservationMapperTests
    {
        [Fact]
        public void Map_ValidReservationDTO_ReturnsGoogleReservation()
        {
            // Arrange
            var mapper = new ReservationDTOToGoogleReservationMapper();
            var reservationDto = new ReservationDTO
            {
                Id = "RES-123",
                Name = "John Doe",
                BookingDate = "2023-10-17"
            };

            // Act
            var result = mapper.Map(reservationDto) as GoogleReservation;

            // Assert
            Assert.NotNull(result);
            Assert.Equal("RES-123", result.GoogleId);
            Assert.Equal("John Doe", result.UserName);
            Assert.Equal("2023-10-17", result.BookingDate);
        }

        [Fact]
        public void Map_NullReservationDTO_ThrowsInvalidMappingException()
        {
            // Arrange
            var mapper = new ReservationDTOToGoogleReservationMapper();

            // Act & Assert
            Assert.Throws<InvalidMappingException>(() => mapper.Map(null));
        }
    }

}

