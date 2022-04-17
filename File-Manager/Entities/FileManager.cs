using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using static File_Manager.Program;
using File_Manager.Helpers;

namespace File_Manager.Entities
{
    /// <summary>
    /// Представляет основной класс для работы с файловым менеджером
    /// </summary>
    internal class FileManager
    {
        // ====================================== FIELDS ====================================== //

        #region FIELDS

        public static int HeightKeys = 3;
        public static int BottomOffset = 2;

        public event OnKey KeyPress;
        readonly List<FilePanel> _panels = new List<FilePanel>();
        readonly FileInfoPanel _infoPanel = new FileInfoPanel();

        private int _activePanelIndex;

        #endregion

        // ====================================== CONSTRUCTORS ====================================== //

        #region CONSTRUCTORS

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="FileManager"/>
        /// </summary>
        static FileManager()
        {
            Console.CursorVisible = false;
            Console.SetWindowSize(120, 35);
            Console.SetBufferSize(120, 35);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.BackgroundColor = ConsoleColor.Black;
        }

        /// <summary>
        /// Конструктор класса <see cref="FileManager"/>
        /// </summary>
        public FileManager()
        {
            this.CreateLogDirectory();

            FilePanel filePanel = new FilePanel();
            filePanel.Top = 0;
            filePanel.Left = 0;
            this._panels.Add(filePanel);

            filePanel = new FilePanel();
            filePanel.Top = 0;
            filePanel.Left = 60;
            this._panels.Add(filePanel);

            _infoPanel.Top = _panels[0].Height;
            _infoPanel.Left = 0;
            _infoPanel.Height = 10;
            _infoPanel.Width = _panels[0].Width * _panels.Count;

            _activePanelIndex = 0;
            this._panels[this._activePanelIndex].IsActive = true;
            KeyPress += this._panels[this._activePanelIndex].KeyboardEvents;

            _infoPanel.Show();
            this.ShowBottomMenu(_infoPanel);

            foreach (FilePanel fp in _panels)
            {
                fp.Show();
            }
        }

        #endregion

        // ====================================== LOG DIRECTORY METHODS ====================================== //

        #region LOG DIRECTORY METHODS

        /// <summary>
        /// Представляет метод создания директории, хранящей логи
        /// </summary>
        /// <returns></returns>
        public void CreateLogDirectory()
        {
            string errorDirectory = AppDomain.CurrentDomain.BaseDirectory + "Errors";
            string errorFile = "error_log.txt";

            StringBuilder builder = new StringBuilder(errorDirectory);
            string fullPath = String.Empty;

            try
            {
                if (!Directory.Exists(builder.ToString()))
                {
                    Directory.CreateDirectory(errorDirectory);

                    builder.Append("\\" + errorFile);
                    fullPath = builder.ToString();

                    if (!File.Exists(fullPath))
                    {
                        var log = File.Create(fullPath);
                        log.Close();

                        using (StreamWriter sw = File.AppendText(fullPath))
                        {
                            sw.WriteLine(DateTime.Now.ToString());
                            sw.WriteLine($"Log file \"{errorFile}\" created.");
                            sw.WriteLine();
                            sw.Close();
                        }
                    }
                }
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        #endregion

        // ====================================== COMMANDS ====================================== //

        #region COMMANDS

        /// <summary>
        /// Представляет метод для обработки команд при работе с файловой системой
        /// </summary>
        public void Commands()
        {
            bool exit = false;
            while (!exit)
            {
                if (Console.KeyAvailable)
                {
                    this.ClearMessage();

                    ConsoleKeyInfo userKey = Console.ReadKey(true);
                    switch (userKey.Key)
                    {
                        case ConsoleKey.Tab:
                            this.ChangeActivePanel();
                            break;
                        case ConsoleKey.Enter:
                            this.OpenItem();
                            break;
                        case ConsoleKey.F1:
                            this.ShowItemInfo();
                            break;
                        case ConsoleKey.F3:
                            this.Copy();
                            break;
                        case ConsoleKey.F4:
                            this.Move();
                            break;
                        case ConsoleKey.F5:
                            this.CreateDirectory();
                            break;
                        case ConsoleKey.F7:
                            this.Delete();
                            break;
                        case ConsoleKey.Escape:
                            exit = true;
                            Properties.Settings.Default.LastPath = this._panels[_activePanelIndex].IsDisks ? null : this._panels[_activePanelIndex].Path;
                            Properties.Settings.Default.Save();
                            Console.ResetColor();
                            Console.Clear();
                            break;
                        case ConsoleKey.DownArrow:
                        case ConsoleKey.UpArrow:
                        case ConsoleKey.End:
                        case ConsoleKey.Home:
                        case ConsoleKey.PageDown:
                        case ConsoleKey.PageUp:
                            this.KeyPress(userKey);
                            break;
                    }
                }
            }
        }

        #endregion

        // ====================================== MAIN FILE / DIRECTORY METHODS ====================================== //

        #region MAIN FILE / DIRECTORY METHODS

        /// <summary>
        /// Представляет метод получения наименования элемента
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        private string GetItemName(string message)
        {
            string name;
            Console.CursorVisible = true;

            do
            {
                this.ClearMessage();
                this.ShowMessage(message);
                name = Console.ReadLine();
            } while (name.Length == 0);

            Console.CursorVisible = false;
            this.ClearMessage();

            return name;
        }

        /// <summary>
        /// Представляет метод открытия элемента
        /// </summary>
        private void OpenItem()
        {
            try
            {
                FileSystemInfo fsInfo = this._panels[this._activePanelIndex].GetActiveItem();

                if (fsInfo != null)
                {
                    if (fsInfo is DirectoryInfo)
                    {
                        try
                        {
                            Directory.GetDirectories(fsInfo.FullName);
                        }

                        catch
                        {
                            return;
                        }

                        this._panels[this._activePanelIndex].Path = fsInfo.FullName;
                        this._panels[this._activePanelIndex].GetElements();
                        this._panels[this._activePanelIndex].UpdatePanel();
                    }

                    else
                    {
                        Process.Start(((FileInfo)fsInfo).FullName);
                    }
                }

                else
                {
                    string currentPath = this._panels[this._activePanelIndex].Path;
                    DirectoryInfo currentDirectory = new DirectoryInfo(currentPath);
                    DirectoryInfo upLevelDirectory = currentDirectory.Parent;

                    if (upLevelDirectory != null)
                    {
                        this._panels[this._activePanelIndex].Path = upLevelDirectory.FullName;
                        this._panels[this._activePanelIndex].GetElements();
                        this._panels[this._activePanelIndex].UpdatePanel();
                    }

                    else
                    {
                        this._panels[this._activePanelIndex].GetDisks();
                        this._panels[this._activePanelIndex].UpdatePanel();
                    }
                }
            }

            catch (Exception e)
            {
                ErrorLogHelper.PrintExceptionMessage("Exception:", 120 / 2 - e.Message.Length / 2, 22, ConsoleColor.White, ConsoleColor.Black);
                ErrorLogHelper.PrintExceptionMessage(e.Message, 120 / 2 - e.Message.Length / 2, 23, ConsoleColor.White, ConsoleColor.Black);
                ErrorLog.AddError(e.Message, Properties.Settings.Default.LogFilePath);
            }
        }

        /// <summary>
        /// Представляет метод копирования элемента
        /// </summary>
        private void Copy()
        {
            foreach (FilePanel panel in _panels)
            {
                if (panel.IsDisks)
                    return;
            }

            if (this._panels[0].Path == this._panels[1].Path)
                return;

            try
            {
                string destPath = this._activePanelIndex == 0 ? this._panels[1].Path : this._panels[0].Path;
                FileSystemInfo fileObject = this._panels[this._activePanelIndex].GetActiveItem();
                FileInfo currentFile = fileObject as FileInfo;

                if (currentFile != null)
                {
                    string fileName = currentFile.Name;
                    string destName = Path.Combine(destPath, fileName);
                    File.Copy(currentFile.FullName, destName, true);
                }

                else
                {
                    string currentDir = ((DirectoryInfo)fileObject).FullName;
                    string destDir = Path.Combine(destPath, ((DirectoryInfo)fileObject).Name);
                    CopyDirectory(currentDir, destDir);
                }

                this.RefreshPanels();
            }

            catch (Exception e)
            {
                this.ShowMessage(e.Message);
                return;
            }
        }

        /// <summary>
        /// Представляет метод копирования директории
        /// </summary>
        /// <param name="sourceDirName"></param>
        /// <param name="destDirName"></param>
        private void CopyDirectory(string sourceDirName, string destDirName)
        {
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);
            DirectoryInfo[] dirs = dir.GetDirectories();

            if (!Directory.Exists(destDirName))
                Directory.CreateDirectory(destDirName);
            FileInfo[] files = dir.GetFiles();

            foreach (FileInfo file in files)
            {
                string temppath = Path.Combine(destDirName, file.Name);
                file.CopyTo(temppath, true);
            }

            foreach (DirectoryInfo subdir in dirs)
            {
                string temppath = Path.Combine(destDirName, subdir.Name);
                CopyDirectory(subdir.FullName, temppath);
            }
        }

        /// <summary>
        /// Представляет метод удаления элемента
        /// </summary>
        private void Delete()
        {
            if (this._panels[this._activePanelIndex].IsDisks)
                return;

            FileSystemInfo fileObject = this._panels[this._activePanelIndex].GetActiveItem();

            try
            {
                if (fileObject is DirectoryInfo)
                    ((DirectoryInfo)fileObject).Delete(true);

                else
                    ((FileInfo)fileObject).Delete();

                this.RefreshPanels();
            }

            catch (Exception e)
            {
                this.ShowMessage(e.Message);
                return;
            }
        }

        /// <summary>
        /// Представляет метод создания директории
        /// </summary>
        private void CreateDirectory()
        {
            if (this._panels[this._activePanelIndex].IsDisks)
                return;

            string destPath = this._panels[this._activePanelIndex].Path;
            string dirName = this.GetItemName("Введите имя каталога: ");

            try
            {
                string dirFullName = Path.Combine(destPath, dirName);
                DirectoryInfo dir = new DirectoryInfo(dirFullName);

                if (!dir.Exists)
                    dir.Create();

                else
                    this.ShowMessage("Каталог с таким именем уже существует");

                this.RefreshPanels();
            }

            catch (Exception e)
            {
                this.ShowMessage(e.Message);
            }
        }

        /// <summary>
        /// Представляет метод перемещения элемента
        /// </summary>
        private void Move()
        {
            foreach (FilePanel panel in _panels)
            {
                if (panel.IsDisks)
                    return;
            }

            if (this._panels[0].Path == this._panels[1].Path)
                return;

            try
            {
                string destPath = this._activePanelIndex == 0 ? this._panels[1].Path : this._panels[0].Path;
                FileSystemInfo fileObject = this._panels[this._activePanelIndex].GetActiveItem();
                string objectName = fileObject.Name;
                string destName = Path.Combine(destPath, objectName);

                if (fileObject is FileInfo)
                    ((FileInfo)fileObject).MoveTo(destName);

                else
                    ((DirectoryInfo)fileObject).MoveTo(destName);

                this.RefreshPanels();
            }

            catch (Exception e)
            {
                this.ShowMessage(e.Message);
                return;
            }
        }

        #endregion

        // ====================================== FILE PANELS METHODS ====================================== //

        #region FILE PANEL METHODS

        /// <summary>
        /// Представляет метод перерисовки панелей
        /// </summary>
        private void RefreshPanels()
        {
            try
            {
                if (this._panels == null || this._panels.Count == 0)
                {
                    return;
                }

                foreach (FilePanel panel in _panels)
                {
                    if (!panel.IsDisks)
                    {
                        panel.UpdateContent(true);
                    }
                }
            }

            catch (Exception e)
            {
                ErrorLogHelper.PrintExceptionMessage("Exception:", 120 / 2 - e.Message.Length / 2, 22, ConsoleColor.White, ConsoleColor.Black);
                ErrorLogHelper.PrintExceptionMessage(e.Message, 120 / 2 - e.Message.Length / 2, 23, ConsoleColor.White, ConsoleColor.Black);
                ErrorLog.AddError(e.Message, Properties.Settings.Default.LogFilePath);
            }
        }

        /// <summary>
        /// Представляет метод перерисовки панели с информацией об элементе
        /// </summary>
        /// <param name="fip"></param>
        private void RefreshInfoPanel(FileInfoPanel fip)
        {
            try
            {
                if (fip == null)
                {
                    return;
                }

                for (int i = 1; i < fip.Height - 1; i++)
                {
                    string space = new String(' ', fip.Width - 2);
                    Console.SetCursorPosition(fip.Left + 1, fip.Top + i);
                    Console.Write(space);
                }

                FileConsoleHelper.PrintBorderLineDouble(fip.Left, fip.Top, fip.Width, fip.Height, ConsoleColor.DarkYellow, ConsoleColor.Black);
            }

            catch (Exception e)
            {
                ErrorLogHelper.PrintExceptionMessage("Exception:", 120 / 2 - e.Message.Length / 2, 22, ConsoleColor.White, ConsoleColor.Black);
                ErrorLogHelper.PrintExceptionMessage(e.Message, 120 / 2 - e.Message.Length / 2, 23, ConsoleColor.White, ConsoleColor.Black);
                ErrorLog.AddError(e.Message, Properties.Settings.Default.LogFilePath);
            }
        }

        /// <summary>
        /// Представляет метод переключения между основными панелями
        /// </summary>
        private void ChangeActivePanel()
        {
            this._panels[this._activePanelIndex].IsActive = false;
            KeyPress -= this._panels[this._activePanelIndex].KeyboardEvents;
            this._panels[this._activePanelIndex].UpdateContent(false);

            this._activePanelIndex++;

            if (this._activePanelIndex >= this._panels.Count)
            {
                this._activePanelIndex = 0;
            }

            this._panels[this._activePanelIndex].IsActive = true;
            KeyPress += this._panels[this._activePanelIndex].KeyboardEvents;
            this._panels[this._activePanelIndex].UpdateContent(false);
        }

        /// <summary>
        /// Представляет метод вывода информации об элементе
        /// </summary>
        private void ShowItemInfo()
        {
            try
            {
                this.RefreshInfoPanel(this._infoPanel);

                int cellLeft = this._panels[0].Left + 1;
                int cellTop = this._panels[0].Height + 2;
                int cellWidth = 0;
                FileSystemInfo fsInfo = this._panels[this._activePanelIndex].GetActiveItem();

                List<string> itemAttributes = new List<string>();
                List<string> header = new List<string>();

                string fullName = fsInfo.Name;
                string shortName = fullName.Length > 30 ? fullName.Substring(0, 27) + ".." : fullName;

                header.Add("TYPE");

                if (fsInfo is DirectoryInfo)
                {
                    cellWidth = FilePanel.panelWidth / 2;
                    itemAttributes.Add("Folder");
                    itemAttributes.Add(shortName);
                    itemAttributes.Add(fsInfo.LastWriteTime.ToString());

                    header.Add("FOLDER NAME");
                }

                if (fsInfo is FileInfo)
                {
                    cellWidth = FilePanel.panelWidth / 2;
                    itemAttributes.Add("File");
                    itemAttributes.Add(shortName);
                    itemAttributes.Add(fsInfo.Extension);
                    itemAttributes.Add(fsInfo.LastWriteTime.ToString());

                    header.Add("FILE NAME");
                    header.Add("FILE EXTENSION");
                }

                header.Add("LAST WRITE TIME");

                StringBuilder caption = new StringBuilder();

                if (fsInfo == null)
                {
                    return;
                }

                caption.Append(' ').Append(fsInfo.FullName).Append(' ');
                FileConsoleHelper.PrintString(caption.ToString(), this._infoPanel.Left + this._infoPanel.Width / 2 - caption.ToString().Length / 2, this._infoPanel.Top, ConsoleColor.White, ConsoleColor.Black);

                for (int i = 0; i < itemAttributes.ToArray().Length; i++)
                {
                    FileConsoleHelper.PrintString(header[i], cellLeft + i * cellWidth + 1, cellTop, ConsoleColor.White, ConsoleColor.Black);
                    FileConsoleHelper.PrintString(itemAttributes[i], cellLeft + i * cellWidth + 1, cellTop + 1, ConsoleColor.White, ConsoleColor.Black);
                }
            }

            catch (Exception e)
            {
                ErrorLogHelper.PrintExceptionMessage("Exception:", 120 / 2 - e.Message.Length / 2, 22, ConsoleColor.White, ConsoleColor.Black);
                ErrorLogHelper.PrintExceptionMessage(e.Message, 120 / 2 - e.Message.Length / 2, 23, ConsoleColor.White, ConsoleColor.Black);
                ErrorLog.AddError(e.Message, Properties.Settings.Default.LogFilePath);
            }
        }

        #endregion

        // ====================================== UI METHODS ====================================== //

        #region UI METHODS

        /// <summary>
        /// Представляет метод вывода нижнего меню с кнопками
        /// </summary>
        private void ShowBottomMenu(FileInfoPanel fip)
        {
            string[] menu = { "F1 Info", "F3 Copy", "F4 Move", "F5 Create", "F7 Delete", "ESC Exit" };

            int cellLeft = this._panels[0].Left;
            int cellTop = this._panels[0].Height + fip.Height;
            int cellWidth = FilePanel.panelWidth * 2 / 6;
            int cellHeight = FileManager.HeightKeys;

            for (int i = 0; i < menu.Length; i++)
            {
                FileConsoleHelper.PrintBorderLine(cellLeft + i * cellWidth, cellTop, cellWidth, cellHeight, ConsoleColor.DarkYellow, ConsoleColor.Black);
                FileConsoleHelper.PrintString(menu[i], cellLeft + i * cellWidth + 1, cellTop + 1, ConsoleColor.White, ConsoleColor.Black);
            }
        }

        /// <summary>
        /// Представляет метод вывода сообщения
        /// </summary>
        /// <param name="message"></param>
        public void ShowMessage(string message)
        {
            FileConsoleHelper.PrintString(message, 0, Console.WindowHeight - BottomOffset, ConsoleColor.White, ConsoleColor.Black);
        }

        /// <summary>
        /// Представляет метод очистки сообщения
        /// </summary>
        private void ClearMessage()
        {
            FileConsoleHelper.PrintString(new String(' ', Console.WindowWidth), 0, Console.WindowHeight - BottomOffset, ConsoleColor.White, ConsoleColor.Black);
        }

        #endregion

    }
}
