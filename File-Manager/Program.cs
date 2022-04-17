using System;
using File_Manager.Entities;
using File_Manager.Helpers;

namespace File_Manager
{
    class Program
    {
        public delegate void OnKey(ConsoleKeyInfo key);

        static void Main(string[] args)
        {
            Console.Title = "File Manager";

            var baseDirectory = new BaseDirectoryHelper();
            Properties.Settings.Default.LogFilePath = baseDirectory.SetBaseDirectory();

            var manager = new FileManager();
            manager.Commands();
        }
    }
}
