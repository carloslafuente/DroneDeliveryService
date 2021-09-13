using System.Collections.Generic;

namespace DroneDeliveryService.Domain
{
	public class Trip
	{
		public Drone Drone { get; set; }
		public List<Location> Locations { get; set; }
	}
}