using System.IO;

namespace Obmen
{
    class CopyForFtp
    {
        private string ipAdress;
        private string login;
        private string password;
        private string postIndex;

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
        public string PostIndex
        {
            get { return postIndex; }
            set { postIndex = value; }
        }

        void CopyToFtp(string pathFrom, string uploadPath)
        {
            ftp ftpClient = new ftp(ipAdress, login, password);

            string[] files = Directory.GetFiles(pathFrom, "*.*");
            string[] subDir = Directory.GetDirectories(pathFrom);

            foreach (string file in files)
            {
                ftpClient.Upload(uploadPath + "/" + Path.GetFileName(file), file);
            }
        }

        public void Copy(string pathFrom, string uploadPath)
        {
            DriveInfo[] allDrives = DriveInfo.GetDrives();

            for (int i = 0; i < allDrives.Length; i++)
            {
                if (allDrives[i].DriveType == DriveType.Removable)
                {
                    string uploadPathIndex = "ftp://" + ipAdress + "/" + allDrives[i].VolumeLabel + "/";
                    CopyToFtp(allDrives[i].Name + pathFrom, uploadPathIndex + uploadPath);
                }
            }
        }
    }
}
