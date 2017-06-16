using System;
using System.Windows.Forms;

namespace Obmen
{
    public partial class Settings : Form
    {
        Button[] btns;
        TextBox[] txtbx;
        public Settings()
        {
            InitializeComponent();
            butCancel.Click += ButCancel_Click;
            Load += Settings_Load;
            
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            btns = new Button[]
            {
                button1,
                button2,
                button3,
                button4,
                button5,
                button6,
                button7,
                button8,
                button9,
                button10,
                button11,
                button12,
                button13,
                button14,
                button15,
                button16
            };
            txtbx = new TextBox[]
            {
                textBox1,
                textBox2,
                textBox3,
                textBox4,
                textBox5,
                textBox6,
                textBox7,
                textBox8,
                textBox9,
                textBox10,
                textBox11,
                textBox12,
                textBox13,
                textBox14,
                textBox15,
                textBox16
            };
            //for(int i = 1; i < btns.Length-1; i++)
            //{
            //    btns[i].Click += new EventHandler(BrowseDialog);
            //}
        }

        private void ButCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BrowseDialog(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                txtbx[Array.IndexOf(btns, (sender as Button))].Text = folderBrowserDialog.SelectedPath;
            }
        }
    }
}
