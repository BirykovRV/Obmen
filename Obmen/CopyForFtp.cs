using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obmen
{
    class CopyForFtp
    {
        void CopyToFtp(string pathFrom, string pathTo)
        {
            //FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://10.86.1.201/Shared/Zhukovka/TestObmen");
            //request.Credentials = new NetworkCredential("support", "trd19afo");
            //request.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
            //FtpWebResponse response = (FtpWebResponse)request.GetResponse();
            //Console.WriteLine("Содержимое сервера:");
            //Console.WriteLine();

            //Stream responseStream = response.GetResponseStream();
            //StreamReader reader = new StreamReader(responseStream);
            //Console.WriteLine(reader.ReadToEnd());

            //reader.Close();
            //responseStream.Close();
            //response.Close();
            //Console.Read();
            DirectoryInfo dirFrom = new DirectoryInfo(pathFrom);
            DirectoryInfo dirTo = new DirectoryInfo(pathTo);
            FileInfo[] files = dirFrom.GetFiles();
            foreach (FileInfo item in files)
            {
                item.CopyTo(pathTo + item.Name, true);
            }
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
                    //CopyToFtp(d.Name + f130From, pathIndex + @"/F130/");
                    //CopyToFtp(d.Name + regPostPayFrom, pathIndex + @"/Реестр коммунальных платежей/");
                    //CopyToFtp(d.Name + regFSGFrom, pathIndex + @"/FSG/Реестры платежей/");
                }
            }
        }
    }
}
