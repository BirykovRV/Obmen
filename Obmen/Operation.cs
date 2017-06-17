using System;
using System.IO;
using NUnrar.Archive;
using System.Windows.Forms;
using System.IO.Compression;
using System.Threading;

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
        //public static string GetDisk()
        //    {
        //    DriveInfo[] allDrives = DriveInfo.GetDrives();
        //    string disk = "";
            
        //    foreach (DriveInfo d in allDrives)
        //    {
        //        try
        //        {
        //            if (d.DriveType == DriveType.Removable)
        //            {
        //                disk = d.Name;
        //                break;
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        } 
        //    }
        //    return disk;
        //}

        // Обмен данными с ОПС
        public static void CopyForOps()
        {
            #region Присвоение путей
            string fromPostPay = Properties.Settings.Default.fromPostPay;
            string toPostPay = Properties.Settings.Default.toPostPay + @"\";

            string configF130From = Properties.Settings.Default.configF130From;
            string configF130To = Properties.Settings.Default.configF130To + @"\";
            string fromF130 = Properties.Settings.Default.fromF130;
            string toF130 = Properties.Settings.Default.toF130 + @"\";
            string fromGibrid = Properties.Settings.Default.fromGibrid;
            string toGibrid = Properties.Settings.Default.toGibrid + @"\";
            string fromPostPayBD = Properties.Settings.Default.fromPostPayBD + @"\";
            string toPostPayBD = Properties.Settings.Default.toPostPayBD + @"\";
            string fromPension = Properties.Settings.Default.fromPension;
            string toPension = Properties.Settings.Default.toPension + @"\";
            string fsgCashFrom = Properties.Settings.Default.fsgCashFrom;
            string fsgCashTo = Properties.Settings.Default.fsgCashTo + @"\";
            string regFSGFrom = Properties.Settings.Default.regFSGFrom;
            string regFSGTo = Properties.Settings.Default.regFSGTo + @"\";
            string fromPostPayMod = Properties.Settings.Default.fromPostPayMod + @"\";
            string toPostPayMod = Properties.Settings.Default.toPostPayMod + @"\";
            #endregion

            Thread th1 = new Thread(() => CopyDB(fromPostPayBD, toPostPayBD));    // База по комуналке
            th1.Start();

            Copy(regFSGFrom, regFSGTo);            // Реестры ФСГ
            Copy(fsgCashFrom, fsgCashTo);          // Архив для ФСГ
            Copy(fromPension, toPension);          // Файлы по пенсии
            CopyDir(configF130From, configF130To); // Ключ для 130
            Copy(fromGibrid, toGibrid);            // Файлы по гибридным
            CopyDir(fromPostPay, toPostPay);       // Реестр по комуналке
            Copy(fromF130, toF130);                // Файлы для АСКУ 
            ExtractDistrib(fromPostPayMod, toPostPayMod); //Обновление PostPay
        }

        // Обмен данными с FTP
        public static void CopyForIp()
        {

        }
    }
}
