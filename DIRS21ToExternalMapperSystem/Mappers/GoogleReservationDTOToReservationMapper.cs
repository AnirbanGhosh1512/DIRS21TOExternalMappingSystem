using DIRS21ToExternalMapperSystem.Exceptions;
using DIRS21ToExternalMapperSystem.MapperInterface;
using DIRS21ToExternalMapperSystem.Models.DIRS21Models;
using DIRS21ToExternalMapperSystem.Models.DTO;

public class GoogleReservationDTOToReservationMapper : IModelMapper
{
    public object Map(object source)
    {
        // Cast the source object to GoogleReservationDTO
        var googleReservationDTO = source as GoogleReservationDTO;

        // Validate the input object
        if (googleReservationDTO == null)
        {
            throw new InvalidMappingException("Expected GoogleReservationDTO object but received something else.",
                source?.GetType().Name ?? "null", "Reservation");
        }

        // Perform the mapping from GoogleReservationDTO to Reservation
        var reservation = new Reservation
        {
            ReservationId = googleReservationDTO.GoogleId,            // Map Id to ReservationId
            CustomerName = googleReservationDTO.UserName,            // Map UserName
            ReservationDate = googleReservationDTO.BookingDate      // Map BookingDate
        };

        return reservation;
    }
}


