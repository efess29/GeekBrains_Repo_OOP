using System;
using System.Collections;
using static Lesson4_Task2.Building;

namespace Lesson4_Task2
{
    internal sealed class BuildingFactory
    {
        private static BuildingFactory _buildingFactory;

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="BuildingFactory"/>
        /// </summary>
        private BuildingFactory()
        {
            Buildings = new Hashtable();
        }

        /// <summary>
        /// Получает или задает хэш-таблицу зданий
        /// </summary>
        public static Hashtable Buildings { get; set; }

        /// <summary>
        /// Представляет перегруженный метод создания здания
        /// </summary>
        /// <param name="height"></param>
        /// <param name="floors"></param>
        /// <param name="flats"></param>
        /// <param name="entrances"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        internal static Building CreateBuilding(int height, int floors, int flats, int entrances, BuildingType type)
        {
            if (_buildingFactory == null) _buildingFactory = new BuildingFactory();

            Building building = new Building(height, floors, flats, entrances, type);
            Buildings.Add(building.Id, building);

            return building;
        }
    }
}
