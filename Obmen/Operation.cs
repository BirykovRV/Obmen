using System;
using System.IO;
using NUnrar.Archive;
using System.Windows.Forms;
using System.IO.Compression;

namespace Obmen
{
    class Operation
    {
        public static void Copy(string pathFrom, string pathTo)
        {
            DirectoryInfo dirFrom = new DirectoryInfo(pathFrom);
            DirectoryInfo dirTo = new DirectoryInfo(pathTo);

            try
            {
               FileInfo[] files = dirFrom.GetFiles();

               foreach (FileInfo fInfo in files)
                   fInfo.CopyTo(pathTo + fInfo.Name, true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Копирование коталогов с разных дисков и их содержимое
        public static void CopyDir(string pathFrom, string pathTo)
        {
            DirectoryInfo dirFrom = new DirectoryInfo(pathFrom);
            DirectoryInfo dirTo = new DirectoryInfo(pathTo);
            DirectoryInfo [] dir = dirFrom.GetDirectories();
            
            try
            {
                for (int i = 0; i < dir.Length; i++)
                {
                    string destPath = pathTo + dir[i].Name + @"\";
                    Directory.CreateDirectory(destPath);

                    FileInfo[] file = dir[i].GetFiles();
                    foreach (FileInfo fInfo in file)
                        fInfo.CopyTo(destPath + fInfo.Name, true);
                }
                FileInfo[] files = dirFrom.GetFiles();

                foreach (FileInfo fInfo in files)
                    fInfo.CopyTo(pathTo + fInfo.Name, true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Разархивация базы по комуналке с перемещением
        public static void CopyDB(string pathFrom, string pathTo)
        {
            DirectoryInfo dirFrom = new DirectoryInfo(pathFrom);
            FileInfo [] fileInfo = dirFrom.GetFiles();
            try
            {
                foreach (FileInfo file in fileInfo)
                RarArchive.WriteToDirectory(pathFrom + file.Name, pathTo); // Разархивация .rar
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void ExtractDistrib (string pathFrom, string pathTo)
        {
            try
            {
                DirectoryInfo dirInfo = new DirectoryInfo(pathTo);
                if (dirInfo.Exists) dirInfo.Delete(true);
                ZipFile.ExtractToDirectory(pathFrom, pathTo);
            }
            catch (IOException e)
            {
                MessageBox.Show(e.Message);
            }
        }

        // Получаем букву съемного диска
        public static string GetDisk()
            {
            DriveInfo[] allDrives = DriveInfo.GetDrives();
            string disk = "";
            
            foreach (DriveInfo d in allDrives)
            {
                try
                {
                    if (d.DriveType == DriveType.Removable)
                    {
                        disk = d.Name;
                        break;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                } 
            }
            return disk;
        }
    }
}
