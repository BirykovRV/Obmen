﻿using System;
using System.IO;
using NUnrar.Archive;
using System.Windows.Forms;
using System.IO.Compression;

namespace Obmen
{
    class Operation : FormObmen
    {
        public static void Copy(string pathFrom, string pathTo)
        {
            try
            {
                DirectoryInfo dirFrom = new DirectoryInfo(pathFrom);
                DirectoryInfo dirTo = new DirectoryInfo(pathTo);

                if (dirTo.Exists & dirFrom.Exists)
                {
                    FileInfo[] files = dirFrom.GetFiles();

                    foreach (FileInfo fInfo in files)
                        fInfo.CopyTo(pathTo + fInfo.Name, true);
                }
                else
                {
                    dirFrom.Create();
                    dirTo.Create();

                    FileInfo[] files = dirFrom.GetFiles();

                    foreach (FileInfo fInfo in files)
                        fInfo.CopyTo(pathTo + fInfo.Name, true);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Копирование коталогов с разных дисков и их содержимое
        public static void CopyDir(string pathFrom, string pathTo)
        {
            try
            {
                DirectoryInfo dirFrom = new DirectoryInfo(pathFrom);
                DirectoryInfo dirTo = new DirectoryInfo(pathTo);

                if (dirFrom.Exists)
                {
                    DirectoryInfo[] dir = dirFrom.GetDirectories();

                    for (int i = 0; i < dir.Length; i++)
                    {
                        string destPath = pathTo + dir[i].Name + @"\";
                        Directory.CreateDirectory(destPath);

                        FileInfo[] file = dir[i].GetFiles();
                        foreach (FileInfo fInfo in file)
                            fInfo.CopyTo(destPath + fInfo.Name, true);
                    }
                }
                else
                {
                    dirFrom.Create();

                    DirectoryInfo[] dir = dirFrom.GetDirectories();
                    for (int i = 0; i < dir.Length; i++)
                    {
                        string destPath = pathTo + dir[i].Name + @"\";
                        Directory.CreateDirectory(destPath);

                        FileInfo[] file = dir[i].GetFiles();
                        foreach (FileInfo fInfo in file)
                            fInfo.CopyTo(destPath + fInfo.Name, true);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Разархивация базы по комуналке с перемещением
        public static void CopyDB(string pathFrom, string pathTo)
        {
            try
            {
                DirectoryInfo dirTo = new DirectoryInfo(pathTo);
                DirectoryInfo dirFrom = new DirectoryInfo(pathFrom);
                FileInfo[] files = dirFrom.GetFiles();
                if (dirTo.Exists)
                {
                    for (int i = 0; i < files.Length; i++)
                    {
                        string _pathFrom = dirFrom + files[i].Name;
                        RarArchive.WriteToDirectory(_pathFrom, pathTo); // Разархивация .rar
                    }
                }
                else
                {
                    dirTo.Create();
                    for (int i = 0; i < files.Length; i++)
                    {
                        string _pathFrom = dirFrom + files[i].Name;
                        RarArchive.WriteToDirectory(_pathFrom, pathTo); // Разархивация .rar
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Проверьте правильность путей и наличие rar архива на флешке.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void ExtractDistrib(string pathFrom, string pathTo)
        {
            try
            {
                DirectoryInfo dirFrom = new DirectoryInfo(pathFrom);
                DirectoryInfo dirTo = new DirectoryInfo(pathTo);
                FileInfo[] files = dirFrom.GetFiles();

                if (dirTo.Exists) dirTo.Delete(true);
                for (int i = 0; i < files.Length; i++)
                {
                    string _pathFrom = dirFrom + files[i].Name;
                    ZipFile.ExtractToDirectory(_pathFrom, pathTo); // Разархивация .zip
                }
            }
            catch (IOException)
            {
                MessageBox.Show("Убедитесь в наличии zip архива на флешке, а также к доступу к папке: " + pathTo, "Ошибка");
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

        // Обмен данными с ОПС
        public static void CopyForOps()
        {
            #region Присвоение путей
            string fromPostPay = Properties.Settings.Default.fromPostPay;
            string toPostPay = GetDisk() + @"Реестр коммунальных платежей\";

            string configF130From = GetDisk() + @"Config";
            string configF130To = Properties.Settings.Default.configF130To + @"\";
            string fromF130 = Properties.Settings.Default.fromF130;
            string toF130 = GetDisk() + @"F130\";
            string fromGibrid = GetDisk() + @"Гибридные переводы";
            string toGibrid = Properties.Settings.Default.toGibrid + @"\";
            string fromPostPayBD = GetDisk() + @"PostPay\DB\";
            string toPostPayBD = Properties.Settings.Default.toPostPayBD + @"\";
            string fromPension = Properties.Settings.Default.fromPension;
            string toPension = GetDisk() + @"Пенсия\";
            string fsgCashFrom = GetDisk() + @"FSG\Кэш";
            string fsgCashTo = Properties.Settings.Default.fsgCashTo + @"\";
            string regFSGFrom = Properties.Settings.Default.regFSGFrom;
            string regFSGTo = GetDisk() + @"FSG\Реестры платежей\";
            #endregion

            CopyDB(fromPostPayBD, toPostPayBD);     // База по комуналке
            Copy(regFSGFrom, regFSGTo);            // Реестры ФСГ
            Copy(fsgCashFrom, fsgCashTo);          // Архив для ФСГ
            Copy(regFSGFrom, regFSGTo);            // Реестр ФСГ
            Copy(fromPension, toPension);          // Файлы по пенсии
            CopyDir(configF130From, configF130To); // Ключ для 130
            Copy(fromGibrid, toGibrid);            // Файлы по гибридным
            CopyDir(fromPostPay, toPostPay);       // Реестр по комуналке
            Copy(fromF130, toF130);                // Файлы для АСКУ 

            DelFilesDirs Del = new DelFilesDirs();
            // Удаляем старые файлы
            Del.DeliteAll(fromPostPay);
            Del.DeliteAll(fromF130);
            Del.DeliteAll(fromPension);
            Del.DeliteAll(regFSGFrom);

        }

        // Метод для обновления Ppsplugin
        public static void UpdatePostPay()
        {
            string fromPostPayMod = GetDisk() + @"PostPay\Update\";
            string toPostPayMod = Properties.Settings.Default.toPostPayMod + @"\";

            try
            {
                ExtractDistrib(fromPostPayMod, toPostPayMod); //Обновление PostPay
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Обмен данными с FTP
        public static void CopyForIp(string ipAdress, string login, string pass)
        {
            #region Присвоение путей
            string pensiaFrom = @"Пенсия";
            string f130From = @"F130";
            string regPostPayFrom = @"Реестр коммунальных платежей";
            string regFSGFrom = @"FSG\Реестры платежей";

            string pensiaTo = "/Пенсия/";
            string f130To = "/F130/";
            string regPostPayTo = "/Реестр коммунальных платежей/";
            string regFSGTo = "/FSG/";
            #endregion

            CopyForFtp CopyFtp = new CopyForFtp();
            CopyFtp.IpAdress = ipAdress;
            CopyFtp.Login = login;
            CopyFtp.Password = pass;

            // Выгрузка на FTP
            CopyFtp.Copy(regPostPayFrom, regPostPayTo);
            CopyFtp.Copy(pensiaFrom, pensiaTo);
            CopyFtp.Copy(f130From, f130To);
            CopyFtp.Copy(regFSGFrom, regFSGTo);
        }

        public static void CopyFromFtp(string ipAdress, string login, string pass)
        {
            string configFrom = "/Config/";
            string esppFrom = "/ESPP/";
            string postPayDBFrom = "/PostPay/DB/";
            string postPayUpdate = "/PostPay/Update/";
            string cashFsgFrom = "/FSG/";

            string configTo = @"Config\";
            string esppTo = @"Гибридные переводы\";
            string postPayDBTo = @"PostPay\DB\";
            string postPayUpdateTo = @"PostPay\Update\";
            string cashFsgTo = @"FSG\Кэш\";

            CopyForFtp CopyFtp = new CopyForFtp();
            CopyFtp.IpAdress = ipAdress;
            CopyFtp.Login = login;
            CopyFtp.Password = pass;

            // Загрузка с FTP
            CopyFtp.CopyFromFtp(configFrom, configTo);
            CopyFtp.CopyFromFtp(esppFrom, esppTo);
            CopyFtp.CopyFromFtp(postPayDBFrom, postPayDBTo);
            CopyFtp.CopyFromFtp(postPayUpdate, postPayUpdateTo);
            CopyFtp.CopyFromFtpFSG(cashFsgFrom, cashFsgTo);
        }
    }
}
