using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Obmen
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
            butCancel.Click += ButCancel_Click;
            
        }

        private void ButCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BrowseDialog(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = folderBrowserDialog.SelectedPath;
            }
        }
    }
}
