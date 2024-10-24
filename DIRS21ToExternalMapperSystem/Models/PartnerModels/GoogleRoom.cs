using System;
namespace DIRS21ToExternalMapperSystem.Models.PartnerModels
{
    public class GoogleRoom
    {
        public required string GoogleRoomId { get; set; }
        public required string RoomCategory { get; set; }
        public int MaxOccupancy { get; set; }
    }
}



