using System;
namespace DIRS21ToExternalMapperSystem.Models.DIRS21Models
{
	public class Room
	{
		public required string RoomId { get; set; }
		public required string RoomType { get; set; }
		public int Capacity { get; set; }
	}
}

