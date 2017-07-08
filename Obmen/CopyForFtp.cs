using System;
using System.IO;
using System.Net;
using System.Threading;
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

        public void Copy(string pathFrom, string _uploadPath)
        {
            DriveInfo[] allDrives = DriveInfo.GetDrives();

            foreach (DriveInfo d in allDrives)
            {
                try
                {
                    if (d.DriveType == DriveType.Removable)
                    {
                        string uploadPathIndex = d.VolumeLabel;
                        Thread uploadThread = new Thread (() =>
                        CopyToFtp(d.Name + pathFrom, uploadPathIndex + _uploadPath));
                        uploadThread.Start();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void CopyFromFtp(string remoteFile, string localFile)
        {
            DriveInfo[] allDrives = DriveInfo.GetDrives();
            Session download = new Session();

            foreach (DriveInfo d in allDrives)
            {
                try
                {
                    if (d.DriveType == DriveType.Removable)
                    {
                        string url = "ftp://" + ipAdress + "/ToOPS";
                        NetworkCredential credentials = new NetworkCredential(login, password);
                        string uploadPathIndex = d.VolumeLabel;
                        Thread downloadThread = new Thread(() =>
                        download.DownloadFtpDirectory(url + remoteFile, credentials, d.Name + localFile));
                        downloadThread.Start();
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