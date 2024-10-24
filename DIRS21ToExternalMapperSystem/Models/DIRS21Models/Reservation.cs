using System;
namespace DIRS21ToExternalMapperSystem.Models.DIRS21Models
{
	public class Reservation
	{
        public required string ReservationId { get; set; }
        public required string CustomerName { get; set; }
        public string ReservationDate { get; set; }
    }
}

