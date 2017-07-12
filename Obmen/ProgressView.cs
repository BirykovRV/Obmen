using System.Windows.Forms;

namespace Obmen
{
    public partial class ProgressView : Form
    {
        public ProgressView()
        {
            InitializeComponent();

            timer1.Interval = 1000;
            timer1.Enabled = true;
            timer1.Tick += Timer1_Tick;
        }

        private void Timer1_Tick(object sender, System.EventArgs e)
        {
            progressBar1.PerformStep();
        }
    }
}
