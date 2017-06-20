using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWindowForm
{
    class CopyFiles
    {
        private string pathTo;
        private string pathFrom;

        public string PathTo
        {
            get { return pathTo; }
            set { pathTo = value; }
        }
        public string PathFrom
        {
            get { return pathFrom; }
            set { pathFrom = value; }
        }

        public CopyFiles(string pathFrom, string pathTo)
        {

        }
    }
}
