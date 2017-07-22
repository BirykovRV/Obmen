using System.Threading;

namespace Obmen
{
    class WaitClass
    {
        public Thread WaitFormThread = new Thread(new ThreadStart(WaitFormShow));

        private static void WaitFormShow()
        {
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
