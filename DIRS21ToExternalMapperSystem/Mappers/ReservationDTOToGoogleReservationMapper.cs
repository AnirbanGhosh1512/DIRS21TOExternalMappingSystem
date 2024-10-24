using System;
using DIRS21ToExternalMapperSystem.Exceptions;
using DIRS21ToExternalMapperSystem.MapperInterface;
using DIRS21ToExternalMapperSystem.Models.DTO;
using DIRS21ToExternalMapperSystem.Models.PartnerModels;

namespace DIRS21ToExternalMapperSystem.Mappers
{
    public class ReservationDTOToGoogleReservationMapper : IModelMapper
    {
        public object Map(object source)
        {
            var reservationDto = source as ReservationDTO;

            if (reservationDto == null)
            {
                throw new InvalidMappingException("Expected ReservationDTO object but received something else.",
                    source?.GetType().Name, "GoogleReservation");
            }

            return new GoogleReservation
            {
                GoogleId = reservationDto.Id,
                UserName = reservationDto.Name,
                BookingDate = reservationDto.BookingDate
            };
        }
    }

}

