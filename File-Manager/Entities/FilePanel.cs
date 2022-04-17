using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using File_Manager.Helpers;

namespace File_Manager.Entities
{
    /// <summary>
    /// Представляет класс методов для работы с файловыми панелями
    /// </summary>
    class FilePanel
    {
        // ====================================== FIELDS ====================================== //

        #region FIELDS

        public static int panelHeight = 20;
        public static int panelWidth = 60;

        private int _top;
        private int _left;
        private int _height = FilePanel.panelHeight;
        private int _width = FilePanel.panelWidth;

        private string _path;
        private bool _isActive;
        private bool _isDisks;

        private int _activeElementIndex = 0;
        private int _firstElementIndex = 0;
        private readonly int _elementsToDisplay = Properties.Settings.Default.ElementsPerPage;

        private readonly List<FileSystemInfo> _objects = new List<FileSystemInfo>();

        #endregion

        // ====================================== PROPERTIES ====================================== //

        #region PROPERTIES

        /// <summary>
        /// Получает или задает верхнюю координату панели
        /// </summary>
        public int Top
        {
            get
            {
                return this._top;
            }

            set
            {
                if (0 <= value)
                {
                    this._top = value;
                }

                else
                {
                    ErrorLog.AddError(ErrorTypeName.InvalidTopCoordinate, Properties.Settings.Default.LogFilePath);
                    throw new Exception(ErrorTypeName.InvalidTopCoordinate);
                }
            }
        }

        /// <summary>
        /// Получает или задает левую координату панели
        /// </summary>
        public int Left
        {
            get
            {
                return this._left;
            }

            set
            {
                if (0 <= value && value <= Console.WindowWidth - FilePanel.panelHeight)
                {
                    this._left = value;
                }

                else
                {
                    ErrorLog.AddError(ErrorTypeName.InvalidLeftCoordinate, Properties.Settings.Default.LogFilePath);
                    throw new Exception(ErrorTypeName.InvalidLeftCoordinate);
                }
            }
        }

        /// <summary>
        /// Получает или задает высоту панели
        /// </summary>
        public int Height
        {
            get
            {
                return this._height;
            }

            set
            {
                if (0 < value && value <= Console.WindowHeight)
                {
                    this._height = value;
                }

                else
                {
                    ErrorLog.AddError(ErrorTypeName.InvalidTopCoordinate, Properties.Settings.Default.LogFilePath);
                    throw new Exception(ErrorTypeName.InvalidTopCoordinate);
                }
            }
        }

        /// <summary>
        /// Получает или задает ширину панели
        /// </summary>
        public int Width
        {
            get
            {
                return this._width;
            }

            set
            {
                if (0 < value && value <= Console.WindowWidth)
                {
                    this._width = value;
                }

                else
                {
                    ErrorLog.AddError(ErrorTypeName.InvalidWidth, Properties.Settings.Default.LogFilePath);
                    throw new Exception(ErrorTypeName.InvalidWidth);
                }
            }
        }

        /// <summary>
        /// Получает или задает путь
        /// </summary>
        public string Path
        {
            get
            {
                return this._path;
            }

            set
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(value);

                if (directoryInfo.Exists)
                {
                    this._path = value;
                }

                else
                {
                    ErrorLog.AddError(ErrorTypeName.InvalidPath, Properties.Settings.Default.LogFilePath);
                    throw new Exception(ErrorTypeName.InvalidPath);
                }
            }
        }

        /// <summary>
        /// Получает или задает признак активности панели
        /// </summary>
        public bool IsActive
        {
            get
            {
                return this._isActive;
            }

            set
            {
                this._isActive = value;
            }
        }

        /// <summary>
        /// Получает или задает признак проверки элемента на "Системный диск"
        /// </summary>
        public bool IsDisks
        {
            get
            {
                return this._isDisks;
            }
        }

        #endregion

        // ====================================== CONSTRUCTORS ====================================== //

        #region CONSTRUCTORS

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="FilePanel"/>
        /// </summary>
        public FilePanel()
        {
            if (!Type.Equals(this.GetType(), typeof(FileInfoPanel)))
            {
                if (String.IsNullOrEmpty(Properties.Settings.Default.LastPath))
                {
                    this.GetDisks();
                }

                else
                {
                    this._path = Properties.Settings.Default.LastPath;
                    this.GetElements();
                }
                
                //this.GetDisks();
            }
        }

        #endregion

        // ====================================== EVENTS ====================================== //

        #region EVENTS

        /// <summary>
        /// Представляет метод обработки событий нажатий специальных клавиш
        /// </summary>
        /// <param name="key"></param>
        public void KeyboardEvents(ConsoleKeyInfo key)
        {
            try
            {
                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        this.MoveUp();
                        break;
                    case ConsoleKey.DownArrow:
                        this.MoveDown();
                        break;
                    case ConsoleKey.Home:
                        this.MoveHome();
                        break;
                    case ConsoleKey.End:
                        this.MoveEnd();
                        break;
                    case ConsoleKey.PageUp:
                        this.PageUp();
                        break;
                    case ConsoleKey.PageDown:
                        this.PageDown();
                        break;
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

        // ====================================== NAVIGATION METHODS ====================================== //

        #region NAVIGATION METHODS

        /// <summary>
        /// Представляет метод навигации вниз по списку
        /// </summary>
        private void MoveDown()
        {
            try
            {
                if (this._activeElementIndex >= this._firstElementIndex + this._elementsToDisplay - 1)
                {
                    this._firstElementIndex += 1;

                    if (this._firstElementIndex + this._elementsToDisplay >= this._objects.Count)
                    {
                        this._firstElementIndex = this._objects.Count - this._elementsToDisplay;
                    }

                    this._activeElementIndex = this._firstElementIndex + this._elementsToDisplay - 1;
                    this.UpdateContent(false);
                }

                else
                {
                    if (this._activeElementIndex >= this._objects.Count - 1)
                    {
                        return;
                    }

                    this.DeactivateObject(this._activeElementIndex);
                    this._activeElementIndex++;
                    this.ActivateObject(this._activeElementIndex);
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
        /// Представляет метод навигации вверх по списку
        /// </summary>
        private void MoveUp()
        {
            try
            {
                if (this._activeElementIndex <= this._firstElementIndex)
                {
                    this._firstElementIndex -= 1;

                    if (this._firstElementIndex < 0)
                    {
                        this._firstElementIndex = 0;
                    }

                    this._activeElementIndex = _firstElementIndex;
                    this.UpdateContent(false);
                }

                else
                {
                    this.DeactivateObject(this._activeElementIndex);
                    this._activeElementIndex--;
                    this.ActivateObject(this._activeElementIndex);
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
        /// Представляет метод навигации вниз к последнему элементу
        /// </summary>
        private void MoveEnd()
        {
            try
            {
                if (this._firstElementIndex + this._elementsToDisplay < this._objects.Count)
                {
                    this._firstElementIndex = this._objects.Count - this._elementsToDisplay;
                }

                this._activeElementIndex = this._objects.Count - 1;
                this.UpdateContent(false);
            }

            catch (Exception e)
            {
                ErrorLogHelper.PrintExceptionMessage("Exception:", 120 / 2 - e.Message.Length / 2, 22, ConsoleColor.White, ConsoleColor.Black);
                ErrorLogHelper.PrintExceptionMessage(e.Message, 120 / 2 - e.Message.Length / 2, 23, ConsoleColor.White, ConsoleColor.Black);
                ErrorLog.AddError(e.Message, Properties.Settings.Default.LogFilePath);
            }
        }

        /// <summary>
        /// Представляет метод навигации вверх к первому элементу
        /// </summary>
        private void MoveHome()
        {
            try
            {
                this._firstElementIndex = 0;
                this._activeElementIndex = 0;
                this.UpdateContent(false);
            }

            catch (Exception e)
            {
                ErrorLogHelper.PrintExceptionMessage("Exception:", 120 / 2 - e.Message.Length / 2, 22, ConsoleColor.White, ConsoleColor.Black);
                ErrorLogHelper.PrintExceptionMessage(e.Message, 120 / 2 - e.Message.Length / 2, 23, ConsoleColor.White, ConsoleColor.Black);
                ErrorLog.AddError(e.Message, Properties.Settings.Default.LogFilePath);
            }
        }

        /// <summary>
        /// Представляет метод навигации вниз на одну страницу
        /// </summary>
        private void PageDown()
        {
            try
            {
                if (this._activeElementIndex + this._elementsToDisplay < this._objects.Count)
                {
                    this._firstElementIndex += this._elementsToDisplay;
                    this._activeElementIndex += this._elementsToDisplay;
                }

                else
                {
                    this._activeElementIndex = this._objects.Count - 1;
                }

                this.UpdateContent(false);
            }

            catch (Exception e)
            {
                ErrorLogHelper.PrintExceptionMessage("Exception:", 120 / 2 - e.Message.Length / 2, 22, ConsoleColor.White, ConsoleColor.Black);
                ErrorLogHelper.PrintExceptionMessage(e.Message, 120 / 2 - e.Message.Length / 2, 23, ConsoleColor.White, ConsoleColor.Black);
                ErrorLog.AddError(e.Message, Properties.Settings.Default.LogFilePath);
            }
        }

        /// <summary>
        /// Представляет метод навигации вверх на одну страницу
        /// </summary>
        private void PageUp()
        {
            try
            {
                if (this._activeElementIndex > this._elementsToDisplay)
                {
                    this._firstElementIndex -= this._elementsToDisplay;
                    if (this._firstElementIndex < 0)
                    {
                        this._firstElementIndex = 0;
                    }

                    this._activeElementIndex -= this._elementsToDisplay;

                    if (this._activeElementIndex < 0)
                    {
                        this._activeElementIndex = 0;
                    }
                }

                else
                {
                    this._firstElementIndex = 0;
                    this._activeElementIndex = 0;
                }

                this.UpdateContent(false);
            }

            catch (Exception e)
            {
                ErrorLogHelper.PrintExceptionMessage("Exception:", 120 / 2 - e.Message.Length / 2, 22, ConsoleColor.White, ConsoleColor.Black);
                ErrorLogHelper.PrintExceptionMessage(e.Message, 120 / 2 - e.Message.Length / 2, 23, ConsoleColor.White, ConsoleColor.Black);
                ErrorLog.AddError(e.Message, Properties.Settings.Default.LogFilePath);
            }
        }

        #endregion

        // ====================================== GET METHODS ====================================== //

        #region GET METHODS

        /// <summary>
        /// Представляет метод получения активного (текущего) элемента
        /// </summary>
        /// <returns></returns>
        public FileSystemInfo GetActiveItem()
        {
            if (this._objects != null && this._objects.Count != 0)
            {
                return this._objects[this._activeElementIndex];
            }

            ErrorLog.AddError(ErrorTypeName.EmptyFilePanel, Properties.Settings.Default.LogFilePath);
            throw new Exception(ErrorTypeName.EmptyFilePanel);
        }

        /// <summary>
        /// Представляет метод получения файлов и директорий
        /// </summary>
        public void GetElements()
        {
            try
            {
                if (this._objects.Count != 0)
                {
                    this._objects.Clear();
                }

                this._isDisks = false;
                DirectoryInfo levelUpDirectory = null;
                this._objects.Add(levelUpDirectory);

                string[] directories = Directory.GetDirectories(this._path);

                foreach (string directory in directories)
                {
                    DirectoryInfo di = new DirectoryInfo(directory);
                    this._objects.Add(di);
                }

                string[] files = Directory.GetFiles(this._path);

                foreach (string file in files)
                {
                    FileInfo fi = new FileInfo(file);
                    this._objects.Add(fi);
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
        /// Представляет метод получения системных дисков
        /// </summary>
        public void GetDisks()
        {
            try
            {
                if (this._objects.Count != 0)
                {
                    this._objects.Clear();
                }

                this._isDisks = true;
                DriveInfo[] discs = DriveInfo.GetDrives();

                foreach (DriveInfo disc in discs)
                {
                    if (disc.IsReady)
                    {
                        DirectoryInfo di = new DirectoryInfo(disc.Name);
                        this._objects.Add(di);
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

        #endregion

        // ====================================== UI METHODS ====================================== //

        #region UI METHODS

        /// <summary>
        /// Представляет метод вывода панели с наполнением
        /// </summary>
        public void Show()
        {
            try
            {
                this.Clear();
                FileConsoleHelper.PrintBorderLineDouble(this._left, this._top, this._width, this._height, ConsoleColor.DarkYellow, ConsoleColor.Black);
                StringBuilder caption = new StringBuilder();

                if (Type.Equals(this.GetType(), typeof(FileInfoPanel)))
                {
                    caption.Append(' ').Append(this._path).Append(' ');
                }

                else
                {
                    if (this._isDisks && !Type.Equals(this.GetType(), typeof(FileInfoPanel)))
                    {
                        caption.Append(' ').Append("Диски:").Append(' ');
                    }

                    else
                    {
                        caption.Append(' ').Append(this._path).Append(' ');
                    }
                }

                FileConsoleHelper.PrintString(caption.ToString(), this._left + this._width / 2 - caption.ToString().Length / 2, this._top, ConsoleColor.White, ConsoleColor.Black);

                if (!Type.Equals(this.GetType(), typeof(FileInfoPanel)))
                {
                    this.PrintContent();
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
        /// Представляет метод вывода контента
        /// </summary>
        private void PrintContent()
        {
            try
            {
                if (this._objects.Count == 0)
                {
                    return;
                }

                int count = 0;
                int lastElement = this._firstElementIndex + this._elementsToDisplay;

                if (lastElement > this._objects.Count)
                {
                    lastElement = this._objects.Count;
                }

                if (this._activeElementIndex >= this._objects.Count)
                {
                    _activeElementIndex = 0;
                }

                for (int i = this._firstElementIndex; i < lastElement; i++)
                {
                    Console.SetCursorPosition(this._left + 1, this._top + count + 1);

                    if (i == this._activeElementIndex && this._isActive == true)
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.DarkYellow;
                    }

                    this.PrintItem(i);

                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;
                    count++;
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
        /// Представляет метод вывода элемента
        /// </summary>
        /// <param name="index"></param>
        private void PrintItem(int index)
        {
            try
            {
                int currentCursorTopPosition = Console.CursorTop;
                int currentCursorLeftPosition = Console.CursorLeft;

                if (!this._isDisks && index == 0)
                {
                    Console.Write("...");
                    return;
                }

                string fullName = _objects[index].Name;
                string shortName = fullName.Length > 30 ? fullName.Substring(0, 26) + ".." : fullName;

                Console.Write("{0}", shortName);
                Console.SetCursorPosition(currentCursorLeftPosition + this._width / 2, currentCursorTopPosition);

                if (_objects[index] is DirectoryInfo)
                {
                    Console.Write("{0}", "\t " + ((DirectoryInfo)_objects[index]).LastWriteTime);
                }

                else
                {
                    Console.Write("{0}", "\t " + ConvertBytes(((FileInfo)_objects[index]).Length));
                }
            }

            catch (Exception e)
            {
                ErrorLogHelper.PrintExceptionMessage("Exception:", 120 / 2 - e.Message.Length / 2, 22, ConsoleColor.White, ConsoleColor.Black);
                ErrorLogHelper.PrintExceptionMessage(e.Message, 120 / 2 - e.Message.Length / 2, 23, ConsoleColor.White, ConsoleColor.Black);
                ErrorLog.AddError(ErrorTypeName.InvalidElementIndex, Properties.Settings.Default.LogFilePath);
            }
        }

        /// <summary>
        /// Представляет метод очищения контента
        /// </summary>
        private void ClearContent()
        {
            try
            {
                for (int i = 1; i < this._height - 1; i++)
                {
                    string space = new String(' ', this._width - 2);
                    Console.SetCursorPosition(this._left + 1, this._top + i);
                    Console.Write(space);
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
        /// Представляет метод очищения панели
        /// </summary>
        public void Clear()
        {
            try
            {
                for (int i = 0; i < this._height; i++)
                {
                    string space = new String(' ', this._width);
                    Console.SetCursorPosition(this._left, this._top + i);
                    Console.Write(space);
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
        /// Представляет метод обновления панели
        /// </summary>
        public void UpdatePanel()
        {
            try
            {
                this._firstElementIndex = 0;
                this._activeElementIndex = 0;
                this.Show();
            }

            catch (Exception e)
            {
                ErrorLogHelper.PrintExceptionMessage("Exception:", 120 / 2 - e.Message.Length / 2, 22, ConsoleColor.White, ConsoleColor.Black);
                ErrorLogHelper.PrintExceptionMessage(e.Message, 120 / 2 - e.Message.Length / 2, 23, ConsoleColor.White, ConsoleColor.Black);
                ErrorLog.AddError(e.Message, Properties.Settings.Default.LogFilePath);
            }
        }

        /// <summary>
        /// Представляет метод обновления контента
        /// </summary>
        /// <param name="update"></param>
        public void UpdateContent(bool update)
        {
            try
            {
                if (update)
                {
                    this.GetElements();
                }

                this.ClearContent();

                if (!Type.Equals(this.GetType(), typeof(FileInfoPanel)))
                {
                    this.PrintContent();
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
        /// Представляет метод активации элемента
        /// </summary>
        /// <param name="index"></param>
        private void ActivateObject(int index)
        {
            try
            {
                int offsetY = this._activeElementIndex - this._firstElementIndex;
                Console.SetCursorPosition(this._left + 1, this._top + offsetY + 1);
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.DarkYellow;

                this.PrintItem(index);

                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.DarkYellow;
            }

            catch (Exception e)
            {
                ErrorLogHelper.PrintExceptionMessage("Exception:", 120 / 2 - e.Message.Length / 2, 22, ConsoleColor.White, ConsoleColor.Black);
                ErrorLogHelper.PrintExceptionMessage(e.Message, 120 / 2 - e.Message.Length / 2, 23, ConsoleColor.White, ConsoleColor.Black);
                ErrorLog.AddError(e.Message, Properties.Settings.Default.LogFilePath);
            }
        }

        /// <summary>
        /// Представляет метод деактивации элемента
        /// </summary>
        /// <param name="index"></param>
        private void DeactivateObject(int index)
        {
            try
            {
                int offsetY = this._activeElementIndex - this._firstElementIndex;
                Console.SetCursorPosition(this._left + 1, this._top + offsetY + 1);
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Black;

                this.PrintItem(index);
            }

            catch (Exception e)
            {
                ErrorLogHelper.PrintExceptionMessage("Exception:", 120 / 2 - e.Message.Length / 2, 22, ConsoleColor.White, ConsoleColor.Black);
                ErrorLogHelper.PrintExceptionMessage(e.Message, 120 / 2 - e.Message.Length / 2, 23, ConsoleColor.White, ConsoleColor.Black);
                ErrorLog.AddError(e.Message, Properties.Settings.Default.LogFilePath);
            }
        }

        #endregion

        // ====================================== ADDITIONAL METHODS ====================================== //

        #region ADDITIONAL METHODS

        /// <summary>
        /// Представляет метод конвертации байтов в доступные величины измерения
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public string ConvertBytes(long bytes)
        {
            try
            {
                string[] measure = { "B", "KB", "MB", "GB" };
                int i;
                double doubleBytes = bytes;

                for (i = 0; i < measure.Length && bytes >= 1024; i++, bytes /= 1024)
                {
                    doubleBytes = bytes / 1024.0;
                }

                string result = String.Format("{0:0.##} {1}", doubleBytes, measure[i]);

                return result.Replace(',', '.');
            }

            catch (Exception e)
            {
                ErrorLogHelper.PrintExceptionMessage("Exception:", 120 / 2 - e.Message.Length / 2, 22, ConsoleColor.White, ConsoleColor.Black);
                ErrorLogHelper.PrintExceptionMessage(e.Message, 120 / 2 - e.Message.Length / 2, 23, ConsoleColor.White, ConsoleColor.Black);
                ErrorLog.AddError(e.Message, Properties.Settings.Default.LogFilePath);
            }

            return String.Empty;

        }

        #endregion

    }
}
