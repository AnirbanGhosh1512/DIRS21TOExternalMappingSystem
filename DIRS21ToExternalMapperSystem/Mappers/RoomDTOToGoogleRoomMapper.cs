using System;
using DIRS21ToExternalMapperSystem.Exceptions;
using DIRS21ToExternalMapperSystem.MapperInterface;
using DIRS21ToExternalMapperSystem.Models.DTO;
using DIRS21ToExternalMapperSystem.Models.PartnerModels;

namespace DIRS21ToExternalMapperSystem.Mappers
{
    public class RoomDTOToGoogleRoomMapper : IModelMapper
    {
        public object Map(object source)
        {
            var roomDto = source as RoomDTO;

            if (roomDto == null)
            {
                throw new InvalidMappingException("Expected RoomDTO object but received something else.",
                    source?.GetType().Name, "GoogleRoom");
            }

            return new GoogleRoom
            {
                GoogleRoomId = roomDto.Id,
                RoomCategory = roomDto.Type,
                MaxOccupancy = roomDto.Occupancy
            };
        }
    }

}

