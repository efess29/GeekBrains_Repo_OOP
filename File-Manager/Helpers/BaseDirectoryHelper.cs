using System;

namespace File_Manager.Helpers
{
    /// <summary>
    /// Представляет класс методов для работы с директорией / файлом логов
    /// </summary>
    class BaseDirectoryHelper
    {
        /// <summary>
        /// Представляет метод установки пути для файла логов
        /// </summary>
        /// <returns></returns>
        public string SetBaseDirectory()
        {
            return Properties.Settings.Default.LogFilePath = AppDomain.CurrentDomain.BaseDirectory + "Errors" + "\\" + "error_log.txt";
        }
    }
}
