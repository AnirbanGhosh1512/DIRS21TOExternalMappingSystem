using DIRS21ToExternalMapperSystem.Exceptions;
using DIRS21ToExternalMapperSystem.MapperInterface;
using DIRS21ToExternalMapperSystem.Models.DTO;
using DIRS21ToExternalMapperSystem.Models.PartnerModels;


public class GoogleRoomToGoogleRoomDTOMapper : IModelMapper
{
    public object Map(object source)
    {
        // Cast the source object to GoogleRoom
        var googleRoom = source as GoogleRoom;

        // Validate the input object
        if (googleRoom == null)
        {
            throw new InvalidMappingException("Expected GoogleRoom object but received something else.",
                source?.GetType().Name ?? "null", "GoogleRoomDTO");
        }

        // Perform the mapping from GoogleRoom to GoogleRoomDTO
        var googleRoomDTO = new GoogleRoomDTO
        {
            GoogleRoomId = googleRoom.GoogleRoomId,            // Map GoogleRoomId to Id in DTO
            RoomCategory = googleRoom.RoomCategory,      // Map RoomCategory to Category in DTO
            MaxOccupancy = googleRoom.MaxOccupancy      // Map MaxOccupancy to Occupancy in DTO
        };

        return googleRoomDTO;
    }
}


