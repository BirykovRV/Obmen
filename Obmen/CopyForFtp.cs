using System;
using System.IO;
using System.Net;

namespace Obmen
{
    class CopyForFtp
    {
        public string IpAdress { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string PostIndex { get; set; }

        void CopyToFtp(string pathFrom, string pathTo)
        {
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://" + IpAdress + "/Shared/" + PostIndex + "/TestObmen");
            request.Credentials = new NetworkCredential(Login, Password);
            request.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
            FtpWebResponse response = (FtpWebResponse)request.GetResponse();
            Console.WriteLine("Содержимое сервера:");
            Console.WriteLine();

            Stream responseStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(responseStream);
            Console.WriteLine(reader.ReadToEnd());

            reader.Close();
            responseStream.Close();
            response.Close();
            Console.Read();


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
