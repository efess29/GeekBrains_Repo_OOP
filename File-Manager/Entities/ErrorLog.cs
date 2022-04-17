using System;
using System.IO;

namespace File_Manager.Entities
{
    /// <summary>
    /// Представляет класс методов для записи ошибок в файл
    /// </summary>
    public class ErrorLog
    {
        /// <summary>
        /// Представляет метод записи исключений в файл логов
        /// </summary>
        public static void AddError(string errorType, string fullPath)
        {
            try
            {
                File.AppendAllLines(fullPath, new[] { DateTime.Now.ToString() });
                File.AppendAllLines(fullPath, new[] { errorType });
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }

    /// <summary>
    /// Представляет класс локализованных наименований типов исключений
    /// </summary>
    public static class ErrorTypeName
    {
        public static string InvalidTopCoordinate = "File panel \"TOP\" coordinate is out of acceptable value.";
        public static string InvalidLeftCoordinate = "File panel \"LEFT\" coordinate is out of acceptable value.";
        public static string InvalidHeight = "File panel \"HEIGHT\" is more than window size.";
        public static string InvalidWidth = "File pane \"WIDTH\" is more than window size.";
        public static string InvalidPath = "Path does not exist.";
        public static string InvalidElementIndex = "Enable to print element. Index is out of range.";
        public static string EmptyFilePanel = "File panel elements list is empty.";
    }
}
