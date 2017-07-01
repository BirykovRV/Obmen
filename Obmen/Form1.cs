using System;
using System.Windows.Forms;

namespace Obmen
{
    public partial class FormObmen : Form
    {
        Settings set = new Settings();

        public FormObmen()
        {
            InitializeComponent();
            настройкиToolStripMenuItem.Click += НастройкиToolStripMenuItem_Click;
            checkBoxPostPay.CheckedChanged += CheckBoxPostPay_CheckedChanged;
            выходToolStripMenuItem.Click += ВыходToolStripMenuItem_Click;
        }
        
        private void ВыходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void CheckBoxPostPay_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxPostPay.Checked)
                MessageBox.Show("Прежде чем обновлять модуль 'Коммунальные платяжи'\nнеобходимо выйти из программы ЕАС.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void НастройкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings settingsView = new Settings();
            settingsView.Show();
        }

        // Перетаскивание окна не по заголовку 
        //private void FormObmen_MouseDown(object sender, MouseEventArgs e)
        //{
        //    Capture = false;
        //    Message m = Message.Create(Handle, 0xa1, new IntPtr(2), IntPtr.Zero);
        //    WndProc(ref m);
        //}

        private void ButYes_Click(object sender, EventArgs e)
        {
            bool _radioButtonOps = Properties.Settings.Default.radioButtonOps;
            bool _radioButtonIP = Properties.Settings.Default.radioButtonIP;
            string ipAdress = Properties.Settings.Default.textBoxIP;
            string login = Properties.Settings.Default.textBoxLogin;
            string pass = Properties.Settings.Default.textBoxPass;

            if (_radioButtonOps == true)
            {
                if (checkBoxPostPay.Checked)
                {
                    Operation.UpdatePostPay();
                    Operation.CopyForOps();
                    MessageBox.Show("Копирование файлов завершено!\nЗакройте программу.");
                }
                else
                {
                    Operation.CopyForOps();
                    MessageBox.Show("Копирование файлов завершено!\nЗакройте программу.");
                }
            }
            else 
            {
                if (_radioButtonIP == true)
                {
                    Operation.CopyForIp(ipAdress, login, pass);
                    MessageBox.Show("Копирование файлов завершено!\nЗакройте программу.");
                }
            }
        }

        private void ButNo_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
