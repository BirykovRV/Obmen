using System.Windows.Forms;
using System.IO;
using System;
using System.Linq;

namespace Obmen
{
    class DelFilesDirs
    {    
        public void DeliteAll(string delFrom)  // delFrom - от куда удалить
        {
            DirectoryInfo dirInfo = new DirectoryInfo(delFrom);
            DirectoryInfo[] dirs = dirInfo.GetDirectories();
            FileInfo[] filesInfo = dirInfo.GetFiles();
            DateTime time = DateTime.Today;
            try
            {
                dirs = dirs.OrderBy(x => x.CreationTime).ToArray();
                filesInfo = filesInfo.OrderBy(x => x.CreationTime).ToArray();
                
                for (int i = 0; i < dirs.Length - 7; i++)
                {
                    FileInfo[] files = dirs[i].GetFiles();
                    foreach (FileInfo file in files)
                    {
                        file.Delete();
                    }
                    dirs[i].Delete();
                }

                for (int i = 0; i < filesInfo.Length - 7; i++)
                {
                    filesInfo[i].Delete();
                }

            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
