using System;
using DIRS21ToExternalMapperSystem.Exceptions;
using DIRS21ToExternalMapperSystem.MapperInterface;
using DIRS21ToExternalMapperSystem.Models.DTO;

namespace DIRS21ToExternalMapperSystem.Mappers
{
    public class ReservationToReservationDTOMapper : IModelMapper
    {
        public object Map(object source)
        {
            var reservation = source as Models.DIRS21Models.Reservation;

            if (reservation == null)
            {
                throw new InvalidMappingException("Invalid object type provided for mapping.",
                    source?.GetType().Name ?? "null", "ReservationDTO");
            }

            return new ReservationDTO
            {
                Id = reservation.ReservationId,
                Name = reservation.CustomerName,
                BookingDate = reservation.ReservationDate
            };
        }
    }

}

