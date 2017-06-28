using System.IO;
using System.Net;

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

        void CopyToFtp(string pathFrom, string pathTo)
        {
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://" + ipAdress + "/Shared/ZHUKOVKA/TestObmen/" + postIndex);
            request.Credentials = new NetworkCredential(Login, Password);
            request.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
            FtpWebResponse response = (FtpWebResponse)request.GetResponse();

            Stream responseStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(responseStream);
            System.Windows.Forms.MessageBox.Show(reader.ReadToEnd());

            reader.Close();
            response.Close();

            //DirectoryInfo dirFrom = new DirectoryInfo(pathFrom);
            //DirectoryInfo dirTo = new DirectoryInfo(pathTo);
            //FileInfo[] files = dirFrom.GetFiles();
            //foreach (FileInfo item in files)
            //{
            //    item.CopyTo(pathTo + item.Name, true);
            //}
        }

        public void Copy(string pathFrom, string pathTo)
        {
            DriveInfo[] allDrives = DriveInfo.GetDrives();

            for (int i = 0; i < allDrives.Length; i++)
            {
                if (allDrives[i].DriveType == DriveType.Removable)
                {
                    string pathIndex = @"D:\FTP\" + allDrives[i].VolumeLabel;
                    CopyToFtp(allDrives[i].Name + pathFrom, pathIndex + pathTo);
                }
            }
        }
    }
}
