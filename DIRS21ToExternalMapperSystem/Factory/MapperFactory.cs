using System;
using DIRS21ToExternalMapperSystem.Exceptions;
using DIRS21ToExternalMapperSystem.MapperInterface;
using DIRS21ToExternalMapperSystem.Mappers;
using DIRS21ToExternalMapperSystem.Models.PartnerModels;
using Microsoft.Win32;

namespace DIRS21ToExternalMapperSystem.Factory
{
    public class MapperFactory
    {
        private readonly Dictionary<string, IModelMapper> _mappers = new Dictionary<string, IModelMapper>();

        public MapperFactory()
        {
            // Register mappings for Reservations(GoogleReservation To DRS21Reservation)
            _mappers.Add("Google.Reservation.DTO.GoogleReservationDTO", new GoogleReservationToGoogleReservationDTOMapper());
            _mappers.Add("DTO.GoogleReservationDTO.DIRS21.Reservation", new GoogleReservationDTOToReservationMapper());

            // Register mappings for Reservations(DRS21Reservation To GoogleReservation)
            _mappers.Add("DIRS21.Reservation.DTO.ReservationDTO", new ReservationToReservationDTOMapper());
            _mappers.Add("DTO.ReservationDTO.Google.Reservation", new ReservationDTOToGoogleReservationMapper());


            // Register mappings for Rooms(GoogleRoom To DRS21Room)
            _mappers.Add("Google.Room.DTO.GoogleRoomDTO", new GoogleRoomToGoogleRoomDTOMapper());
            _mappers.Add("DTO.GoogleRoomDTO.DIRS21.Room", new GoogleRoomDTOToRoomMapper());

            // Register mappings for Rooms(DRS21Room To GoogleRoom)
            _mappers.Add("DIRS21.Room.DTO.RoomDTO", new RoomToRoomDTOMapper());
            _mappers.Add("DTO.RoomDTO.Google.Room", new RoomDTOToGoogleRoomMapper());

        }

        public IModelMapper GetMapper(string sourceType, string targetType)
        {
            var key = $"{sourceType}.{targetType}";
            if (_mappers.TryGetValue(key, out var mapper))
            {
                return mapper;
            }

            throw new InvalidMappingException($"No mapper found for {sourceType} to {targetType}");
        }
    }

}

