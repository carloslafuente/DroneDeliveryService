# Drone Delivery Service
## Problem
A squad of drones have been tasked with delivering packages for a major online reseller in a world where time and distance do not matter. Each drone can carry a specific weight, and can make multiple deliveries before returning to home base to pick up additional loads; however the goal is to make the fewest number of trips as each time the drone returns to home base it is extremely costly to refuel and reload the drone.

The purpose of the written software will be to accept input which will include the name of each drone and the maximum weight it can carry, along with a series of locations and the total weight needed to be delivered to that specific location. The software should highlight the most efficient deliveries for each drone to make on each trip.

Assume that time and distance to each drop off location do not matter, and that size of each package is also irrelevant. It is also assumed that the cost to refuel and restock each drone is a constant and does not vary between drones. The maximum number of drones in a squad is 100, and there is no maximum number of deliveries which are required.

## Solution: Console Application
I created a console app, I thought it was the best choice for the example input data. Besides being the solution that does not require a database connection for this problem.

### Input data:
> **Option 'D' - Add Drones. Example:**
`Drone #1, 10, Drone #2, 20, Drone #3, 25`

> **Option 'L' - Add Locations. Example:**
`Location #1, 5, Location #2, 20, Location #3, 15, Location #4, 2, Location #5, 10, Location #6, 11, Location #7, 22, Location #8, 21`

> **Option 'T' - Generate Trips for the squad of drones**

> **Option 'S' - Show all generated Trips**

> **Option 'E' - Exit Application**
