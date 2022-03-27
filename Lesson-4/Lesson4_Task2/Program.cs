using System;
using System.Collections.Generic;
using static Lesson4_Task2.Building;

namespace Lesson4_Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();

            BuildingFactory.CreateBuilding(150, 10, 60, 3, (BuildingType)2);
            BuildingFactory.CreateBuilding(50, 5, 26, 1, (BuildingType)1);
            BuildingFactory.CreateBuilding(62, 8, 45, 2, (BuildingType)3);

            var count = BuildingFactory.Buildings.Count;

            foreach (var key in BuildingFactory.Buildings.Keys)
            {
                Building building = (Building)BuildingFactory.Buildings[key];

                int floorHeight = CalculateCharacteristics(building, (BuildingCharacteristic)1);
                int flatsPerFloor = CalculateCharacteristics(building, (BuildingCharacteristic)2);
                int flatsPerEntrance = CalculateCharacteristics(building, (BuildingCharacteristic)3);

                Console.WriteLine("=============");
                Console.WriteLine($"BUILDING {building.Id}");
                Console.WriteLine("-------------");
                Console.WriteLine($"ID: {building.Id}");
                Console.WriteLine($"Type: {building.Type}");
                Console.WriteLine($"Height: {building.Height}");
                Console.WriteLine($"Floors: {building.Floors}");
                Console.WriteLine($"Flats: {building.Flats}");
                Console.WriteLine($"Entrances: {building.Entrances}");
                Console.WriteLine($"Floor height: {floorHeight}");
                Console.WriteLine($"Flats per floor: {flatsPerFloor}");
                Console.WriteLine($"Flats per entrance: {flatsPerEntrance}");
                Console.WriteLine();
            }

            for (var i = 0; i < 3; i++)
            {
                var key = random.Next(count);

                BuildingFactory.Buildings.Remove(key);

                if (!BuildingFactory.Buildings.Contains(key) && BuildingFactory.Buildings.Count < count)
                {
                    count = BuildingFactory.Buildings.Count;
                    Console.WriteLine($"Building with ID {key} was deleted.");
                }
            }

            Console.ReadLine();

        }
    }
}
