using System.Collections.Generic;
using System.Linq;

namespace DroneDeliveryService.Domain.Managers
{
	public class TripManager
	{
		private readonly List<Drone> _drones;
		private readonly List<Location> _locations;

		public TripManager(List<Drone> drones, List<Location> locations)
		{
			_drones = drones.OrderByDescending(drone => drone.LoadCapacity).ToList();
			_locations = locations.OrderBy(location => location.Weight).ToList();
		}

		public void AssignTrips()
		{
			_drones.ForEach(drone =>
			{
				List<Location> locations = new();
				List<int> takenLocations = new();
				for (int i = _locations.Count - 1; i >= 0; i--)
				{
					if (GetRemainingCapacity(drone, locations) - _locations[i].Weight >= 0)
					{
						locations.Add(_locations[i]);
						takenLocations.Add(i);
					}
				}
				takenLocations.ForEach(index => _locations.RemoveAt(index));
				if (locations.Count > 0)
				{
					drone.Trips.Add(new Trip
					{
						Drone = drone,
						Locations = locations
					});
				}
			});
		}

		public int GetRemainingLocations()
		{
			return _locations.Count;
		}

		private static decimal GetRemainingCapacity(Drone drone, List<Location> locations)
		{
			var currentLoad = 0m;
			locations.ForEach(location => currentLoad += location.Weight);
			return drone.LoadCapacity - currentLoad;
		}
	}
}