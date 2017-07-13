using System.Threading;
using System.Windows.Forms;

namespace Obmen
{
    class WaitClass
    {
        public Thread WaitFormThread = new Thread(new ThreadStart(WaitFormShow));

        private static void WaitFormShow()
        {
            //Form f = new Form();
            //f.ShowInTaskbar = false;
            //f.Height = 310;
            //f.Width = 100;
            //f.FormBorderStyle = FormBorderStyle.None;
            //f.StartPosition = FormStartPosition.CenterScreen;
            #region Прогрес бар ожидания
            //ProgressBar pb = new ProgressBar();
            //pb.Style = ProgressBarStyle.Marquee;
            //f.Controls.Add(pb);
            //pb.Dock = DockStyle.Fill;
            //pb.Step = 5;
            //f.ShowDialog();
            #endregion
            
            ProgressView Wait = new ProgressView();
            Wait.ShowDialog();
        }
    }
}
