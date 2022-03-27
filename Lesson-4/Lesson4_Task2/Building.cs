using System;

namespace Lesson4_Task2
{
    internal class Building
    {
        private int _id;
        private int _height;
        private int _floors;
        private int _flats;
        private int _entrances;
        private BuildingType _type;

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Building"/>
        /// </summary>
        public Building() : this(0, 0, 0, 0, (BuildingType)1) { }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Building"/>
        /// </summary>
        /// <param name="height"></param>
        /// <param name="floors"></param>
        /// <param name="flats"></param>
        /// <param name="entrances"></param>
        /// <param name="type"></param>
        public Building(int height, int floors, int flats, int entrances, BuildingType type)
        {
            LastID = UpdateLastID(LastID);

            _id = LastID;
            _height = height;
            _floors = floors;
            _flats = flats;
            _entrances = entrances;
            _type = type;
        }

        /// <summary>
        /// Получает или задает ИД здания
        /// </summary>
        public int Id => _id;

        /// <summary>
        /// Получает или задает последний использованный ИД здания
        /// </summary>
        public static int LastID { get; set; } = 0;

        /// <summary>
        /// Получает или задает высоту здания
        /// </summary>
        public int Height => _height;

        /// <summary>
        /// Получает или задает кол-во этажей здания
        /// </summary>
        public int Floors => _floors;

        /// <summary>
        /// Получает или задает кол-во квартир здания
        /// </summary>
        public int Flats => _flats;

        /// <summary>
        /// Получает или задает кол-во подъездов здания
        /// </summary>
        public int Entrances => _entrances;

        /// <summary>
        /// Получает или задает тип здания
        /// </summary>
        public BuildingType Type => _type;

        /// <summary>
        /// Представляет метод вычисления основных характеристик здания
        /// </summary>
        /// <param name="building"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public static int CalculateCharacteristics(Building building, BuildingCharacteristic param)
        {
            if (building == null)
            {
                throw new Exception("Building instance is null or empty!");
            }

            var buildingType = building.Type.ToString();
            var paramType = param.ToString();
            int result;

            switch (paramType)
            {
                case "FloorHeight":
                    result = CalculateFloorHeight(buildingType);
                    return result;
                case "FlatsPerEntrance":
                    result = CalculateFlatsPerFloor(buildingType);
                    return result;
                case "FlatsPerFloor":
                    result = CalculateFlatsPerEntrance(buildingType);
                    return result;
                default:
                    break;
            }

            return 0;
        }

        /// <summary>
        /// Представляет метод вычисления высоты этажа
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static int CalculateFloorHeight(string type)
        {
            switch (type)
            {
                case "A":
                    return 4;
                case "B":
                    return 2;
                case "C":
                    return 3;
                default:
                    break;
            }

            return 0;
        }

        /// <summary>
        /// Представляет метод вычисления кол-ва квартир на этаже
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static int CalculateFlatsPerFloor(string type)
        {
            switch (type)
            {
                case "A":
                    return 5;
                case "B":
                    return 6;
                case "C":
                    return 4;
                default:
                    break;
            }

            return 0;
        }

        /// <summary>
        /// Представляет метод вычисления кол-ва квартир в подъезде
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static int CalculateFlatsPerEntrance(string type)
        {
            switch (type)
            {
                case "A":
                    return 20;
                case "B":
                    return 45;
                case "C":
                    return 19;
                default:
                    break;
            }

            return 0;
        }

        /// <summary>
        /// Представляет метод вычисления последнего ИД здания
        /// </summary>
        /// <param name="lastID"></param>
        /// <returns></returns>
        public int UpdateLastID(int lastID)
        {
            return ++lastID;
        }

        /// <summary>
        /// Представляет перечисление типов зданий
        /// 1 - сталинка, 2 - хрущевка, 3 - брежневка
        /// </summary>
        public enum BuildingType
        {
            A = 1,
            B = 2,
            C = 3
        }

        /// <summary>
        /// Представляет перечисление вычисляемых характеристик
        /// 1 - высота этажа, 2 - квартир на подъезд, 3 - квартир на этаж
        /// </summary>
        public enum BuildingCharacteristic
        {
            FloorHeight = 1,
            FlatsPerEntrance = 2,
            FlatsPerFloor = 3
        }
    }
}
