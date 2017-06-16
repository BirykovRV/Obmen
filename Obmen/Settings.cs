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
                configF130From,
                configF130To,
                fromPostPay,
                toPostPay,
                fromF130,
                toF130,
                fromGibrid,
                toGibrid,
                fromPostPayBD,
                toPostPayBD,
                fromPension,
                toPension,
                fsgCashFrom,
                fsgCashTo,
                regFSGFrom,
                regFSGTo
            };
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
