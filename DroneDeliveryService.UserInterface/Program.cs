using DroneDeliveryService.Domain;
using DroneDeliveryService.Domain.Managers;
using System;
using System.Collections.Generic;

namespace DroneDeliveryService.UserInterface
{
	internal class Program
	{
		private static void Main(string[] args)
		{
			Console.WriteLine("Welcome!");
			bool endApp = false;
			List<Drone> drones = new();
			List<Location> locations = new();
			while (!endApp)
			{
				ShowAppOptions();
				var selectedOption = Console.ReadLine().ToString().ToUpper();
				switch (selectedOption)
				{
					case "D":
						AddDroneData(drones);
						break;

					case "L":
						AddLocationData(locations);
						break;

					case "T":
						if (drones.Count > 0 && drones.Count <= 100 && locations.Count > 0)
						{
							var remainingLocations = locations.Count;
							var tripManager = new TripManager(drones, locations);
							while (remainingLocations > 0)
							{
								tripManager.AssignTrips();
								remainingLocations = tripManager.GetRemainingLocations();
							}
						}
						break;

					case "S":
						ShowInformation(drones);
						break;

					case "E":
						endApp = true;
						break;

					default:
						Console.WriteLine("Wrong option, try again...");
						break;
				}
			}
			Console.WriteLine("See you later...");
			Console.ReadKey();
		}

		private static void ShowAppOptions()
		{
			Console.WriteLine("Choose an option from the following list:");
			Console.WriteLine("\tD - Add Drone");
			Console.WriteLine("\tL - Add Location");
			Console.WriteLine("\tT - Set Trips");
			Console.WriteLine("\tS - Show Drones and Locations list");
			Console.WriteLine("\tE - Exit");
			Console.Write("Your option?: ");
		}

		private static void ShowInformation(List<Drone> drones)
		{
			Console.WriteLine("Trips list:");
			drones.ForEach((drone) =>
			{
				Console.WriteLine($"\t[{drone.Name}]");

				for (int i = 0; i < drone.Trips.Count; i++)
				{
					Console.WriteLine($"\tTrip #{i + 1}");
					var locationsText = "";
					drone.Trips[i].Locations.ForEach(location =>
					{
						locationsText += $"[{location.Address}], ";
					});
					locationsText = locationsText[0..^2];
					Console.WriteLine($"\t{locationsText}");
					Console.WriteLine($"\b");
				}
			});
		}

		private static void AddDroneData(List<Drone> drones)
		{
			Console.WriteLine("Please enter the drones list data, then press enter.");
			Console.WriteLine("For example: [Drone #1 Name], [#1 Maximum Weight], [Drone #2 Name], [#2 Maximum Weight], etc.");
			var droneData = Console.ReadLine().Split(",");

			if (droneData.Length % 2 == 0 && droneData.Length > 0 && droneData.Length <= 100)
			{
				for (int i = 0; i < droneData.Length; i += 2)
				{
					drones.Add(new Drone
					{
						Name = droneData[i].Trim(),
						LoadCapacity = Convert.ToDecimal(droneData[i + 1]),
						Trips = new()
				});
				}
			}
		}

		private static void AddLocationData(List<Location> locations)
		{
			Console.WriteLine("Please enter the location's data, then press enter.");
			Console.WriteLine("For example: [Location #1 Name],[Location #1 Package Weight]");
			var locationData = Console.ReadLine().Split(",");

			if (locationData.Length % 2 == 0 && locationData.Length > 0)
			{
				for (int i = 0; i < locationData.Length; i += 2)
				{
					locations.Add(new Location
					{
						Address = locationData[i].Trim(),
						Weight = Convert.ToDecimal(locationData[i + 1])
					});
				}
			}
		}
	}
}