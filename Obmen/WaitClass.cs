
using System.Threading;

namespace Obmen
{
    class WaitClass
    {
        public Thread WaitFormThread = new Thread(new ThreadStart(WaitFormShow));

        private static void WaitFormShow()
        {
            System.Windows.Forms.Form f = new System.Windows.Forms.Form();
            f.ShowInTaskbar = false;
            f.Height = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Height / 50;
            f.Width = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Width / 3;
            f.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            f.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            System.Windows.Forms.ProgressBar pb = new System.Windows.Forms.ProgressBar();
            pb.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            f.Controls.Add(pb);
            pb.Dock = System.Windows.Forms.DockStyle.Fill;
            pb.Step = 5;
            f.ShowDialog();
        }
    }
}
