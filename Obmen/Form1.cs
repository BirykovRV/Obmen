using System;
using System.Threading;
using System.Windows.Forms;

namespace Obmen
{
    public partial class FormObmen : Form
    {
        public FormObmen()
        {
            InitializeComponent();
            настройкиToolStripMenuItem.Click += НастройкиToolStripMenuItem_Click;
        }

        private void НастройкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings settingsView = new Settings();
            settingsView.Show(); 
        }

        // Перетаскивание окна не по заголовку 
        private void FormObmen_MouseDown(object sender, MouseEventArgs e)
        {
            Capture = false;
            Message m = Message.Create(Handle, 0xa1, new IntPtr(2), IntPtr.Zero);
            WndProc(ref m);
        }

        private void ButYes_Click(object sender, EventArgs e)
        {
            bool _radioButtonOps = Properties.Settings.Default.radioButtonOps;
            bool _radioButtonIP = Properties.Settings.Default.radioButtonIP;

            if (_radioButtonOps == true)
            {
                Operation.CopyForOps();
            }
            else if(_radioButtonIP == true)
            {
                Operation.CopyForIp();
            }

            MessageBox.Show("Копирование файлов завершено!\nЗакройте программу.");
        }

        private void ButNo_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                MessageBox.Show("Прежде чем обновлять модуль 'Коммунальные платяжи'\nнеобходимо выйти из программы ЕАС.","Внимание", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

       
    }
}
