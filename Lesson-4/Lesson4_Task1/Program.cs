using System;
using System.Collections.Generic;
using static Lesson4_Task1.Building;

namespace Lesson4_Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            var buildings = new List<Building>()
            {
                new Building(150, 10, 60, 3, (BuildingType)2),
                new Building(50, 5, 26, 1, (BuildingType)1),
                new Building(62, 8, 45, 2, (BuildingType)3)
            };

            foreach (var building in buildings)
            {
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

            Console.ReadLine();

        }
    }
}
