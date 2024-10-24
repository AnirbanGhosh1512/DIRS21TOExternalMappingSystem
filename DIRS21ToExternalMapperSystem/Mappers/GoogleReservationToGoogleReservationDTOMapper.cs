using DIRS21ToExternalMapperSystem.Exceptions;
using DIRS21ToExternalMapperSystem.MapperInterface;
using DIRS21ToExternalMapperSystem.Models.DTO;
using DIRS21ToExternalMapperSystem.Models.PartnerModels;


public class GoogleReservationToGoogleReservationDTOMapper : IModelMapper
{
    public object Map(object source)
    {
        // Cast the source object to GoogleReservation
        var googleReservation = source as GoogleReservation;

        // Validate the input object
        if (googleReservation == null)
        {
            throw new InvalidMappingException("Expected GoogleReservation object but received something else.",
                source?.GetType().Name ?? "null", "GoogleReservationDTO");
        }

        // Perform the mapping
        var googleReservationDTO = new GoogleReservationDTO
        {
            GoogleId = googleReservation.GoogleId,            // Map GoogleId to Id in DTO
            UserName = googleReservation.UserName,           // Map UserName to CustomerName in DTO
            BookingDate = googleReservation.BookingDate     // Map BookingDate to ReservationDate in DTO
        };

        return googleReservationDTO;
    }
}


