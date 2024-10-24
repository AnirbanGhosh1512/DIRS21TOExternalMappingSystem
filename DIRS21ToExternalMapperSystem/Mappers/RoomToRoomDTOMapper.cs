using System;
using DIRS21ToExternalMapperSystem.Exceptions;
using DIRS21ToExternalMapperSystem.MapperInterface;
using DIRS21ToExternalMapperSystem.Models.DTO;

namespace DIRS21ToExternalMapperSystem.Mappers
{
    public class RoomToRoomDTOMapper : IModelMapper
    {
        public object Map(object source)
        {
            var room = source as Models.DIRS21Models.Room;

            if (room == null)
            {
                throw new InvalidMappingException("Expected Room object but received something else.",
                    source?.GetType().Name, "RoomDTO");
            }

            return new RoomDTO
            {
                Id = room.RoomId,
                Type = room.RoomType,
                Occupancy = room.Capacity
            };
        }
    }

}

