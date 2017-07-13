using System;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Obmen
{
    public partial class FormObmen : Form
    {
        bool _radioButtonIP = Properties.Settings.Default.radioButtonIP;
        bool _radioButtonOps = Properties.Settings.Default.radioButtonOps;
        Button butUpdate = new Button();
        string ipAdress = Properties.Settings.Default.textBoxIP;
        string login = Properties.Settings.Default.textBoxLogin;
        string pass = Properties.Settings.Default.textBoxPass;

        public FormObmen()
        {
            InitializeComponent();
            настройкиToolStripMenuItem.Click += НастройкиToolStripMenuItem_Click;
            checkBoxPostPay.CheckedChanged += CheckBoxPostPay_CheckedChanged;
            выходToolStripMenuItem.Click += ВыходToolStripMenuItem_Click;

            if (_radioButtonIP == true)
            {
                butYes.Location = new Point(butYes.Location.X - 30, butYes.Location.Y);
                butYes.Text = "Выгрузить";
                butNo.Location = new Point(butNo.Location.X + 38, butNo.Location.Y);
                butNo.Text = "Выход";
                label1.Text = "Выбран режим работы для ИП";
                checkBoxPostPay.Visible = false;
                butUpdate.Location = new Point(butYes.Location.X + 99, butYes.Location.Y);
                butUpdate.FlatStyle = FlatStyle.Flat;
                butUpdate.Name = "butUpdate";
                butUpdate.Size = new Size(75, 23);
                butUpdate.TabIndex = 0;
                butUpdate.Text = "Скачать";
                butUpdate.UseVisualStyleBackColor = false;
                butUpdate.Click += ButUpdate_Click;
                groupBox1.Controls.Add(butUpdate);
            }
        }

        private void ВыходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void CheckBoxPostPay_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxPostPay.Checked)
                MessageBox.Show("Прежде чем обновлять модуль 'Коммунальные платежи'\nнеобходимо выйти из программы ЕАС.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void НастройкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings settingsView = new Settings();
            settingsView.Owner = this;
            settingsView.ShowDialog();
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
                    Task task = new Task(() =>
                    Operation.CopyForIp(ipAdress, login, pass));
                    task.Start();
                    ProgressView load = new ProgressView();
                    if (!task.IsCompleted)
                    {
                        load.Show();
                    }
                    load.Close();
                    MessageBox.Show("Копирование файлов завершено!\nЗакройте программу.");
                }
            }
        }

        private void ButUpdate_Click(object sender, EventArgs e)
        {
            if (_radioButtonIP == true)
            {
                WaitClass Wait = new WaitClass();
                Wait.WaitFormThread.Start();
                Operation.CopyFromFtp(ipAdress, login, pass);
                Wait.WaitFormThread.Abort();
                MessageBox.Show("Копирование файлов завершено!\nЗакройте программу.");
            }
        }

        private void ButNo_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
