using System;
using System.IO;
using System.Windows.Forms;

namespace Obmen
{
    class CopyForFtp
    {
        private string ipAdress;
        private string login;
        private string password;

        public string IpAdress
        {
            get { return ipAdress; }
            set { ipAdress = value; }
        }
        public string Login
        {
            get { return login; }
            set { login = value; }
        }
        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        void CopyToFtp(string pathFrom, string uploadPath)
        {
            ftp ftpClient = new ftp(ipAdress, login, password);

            string[] files = Directory.GetFiles(pathFrom, "*.*");
            string[] subDirs = Directory.GetDirectories(pathFrom);

            foreach (string file in files)
            {
                ftpClient.Upload(uploadPath + Path.GetFileName(file), file);
            }

            foreach (string subDir in subDirs)
            {
                ftpClient.CreateDirectory(uploadPath + Path.GetFileName(subDir));
                CopyToFtp(subDir, uploadPath + Path.GetFileName(subDir) + "/");
            }
        }

        public void Copy(string pathFrom, string _uploadPath, string remoteFile, string localFile)
        {
            DriveInfo[] allDrives = DriveInfo.GetDrives();
            ftp ftpClient = new ftp(ipAdress, login, password);

            foreach (DriveInfo d in allDrives)
            {
                try
                {
                    if (d.DriveType == DriveType.Removable)
                    {
                        string uploadPathIndex = d.VolumeLabel;
                        CopyToFtp(d.Name + pathFrom, uploadPathIndex + _uploadPath);
                        ftpClient.DownloadFtpDirectory(remoteFile, d.Name + localFile);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}