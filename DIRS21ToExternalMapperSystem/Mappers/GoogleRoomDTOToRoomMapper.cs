using DIRS21ToExternalMapperSystem.Exceptions;
using DIRS21ToExternalMapperSystem.MapperInterface;
using DIRS21ToExternalMapperSystem.Models.DIRS21Models;
using DIRS21ToExternalMapperSystem.Models.DTO;

namespace DIRS21ToExternalMapperSystem.Mappers
{
    public class GoogleRoomDTOToRoomMapper : IModelMapper
    {
        public object Map(object source)
        {
            var googleRoomDto = source as GoogleRoomDTO;

            if (googleRoomDto == null)
            {
                throw new InvalidMappingException("Expected GoogleRoomDTO object but received something else.",
                    source?.GetType().Name, "Room");
            }

            return new Room
            {
                RoomId = googleRoomDto.GoogleRoomId,
                RoomType = googleRoomDto.RoomCategory,
                Capacity = googleRoomDto.MaxOccupancy
            };
        }
    }

}

