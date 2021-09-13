using System.Collections.Generic;

namespace DroneDeliveryService.Domain
{
	public class Drone
	{
		public string Name { get; set; }
		public decimal LoadCapacity { get; set; }
		public List<Trip> Trips { get; set; }
	}
}