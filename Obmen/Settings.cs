using System;
using System.Windows.Forms;

namespace Obmen
{
    public partial class Settings : Form
    {
        Button[] btns;
        TextBox[] txtbox;
        public Settings()
        {
            InitializeComponent();
            butCancel.Click += ButCancel_Click;
            Load += Settings_Load;
            butSave.Click += ButSave_Click;
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
                button16,
                button17,
                button18
            };
            txtbox = new TextBox[]
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
                regFSGTo,
                fromPostPayMod,
                toPostPayMod
            };

            #region Загрузка параметров
            configF130From.Text = Properties.Settings.Default.configF130From;
            configF130To.Text = Properties.Settings.Default.configF130To;
            fromPostPay.Text = Properties.Settings.Default.fromPostPay;
            toPostPay.Text = Properties.Settings.Default.toPostPay;
            fromF130.Text = Properties.Settings.Default.fromF130;
            toF130.Text = Properties.Settings.Default.toF130;
            fromGibrid.Text = Properties.Settings.Default.fromGibrid;
            toGibrid.Text = Properties.Settings.Default.toGibrid;
            fromPostPayBD.Text = Properties.Settings.Default.fromPostPayBD;
            toPostPayBD.Text = Properties.Settings.Default.toPostPayBD;
            fromPension.Text = Properties.Settings.Default.fromPension;
            toPension.Text = Properties.Settings.Default.toPension;
            fsgCashFrom.Text = Properties.Settings.Default.fsgCashFrom;
            fsgCashTo.Text = Properties.Settings.Default.fsgCashTo;
            regFSGFrom.Text = Properties.Settings.Default.regFSGFrom;
            regFSGTo.Text = Properties.Settings.Default.regFSGTo;
            radioButtonOps.Checked = Properties.Settings.Default.radioButtonOps;
            radioButtonIP.Checked = Properties.Settings.Default.radioButtonIP;
            fromPostPayMod.Text = Properties.Settings.Default.fromPostPayMod;
            toPostPayMod.Text = Properties.Settings.Default.toPostPayMod;
            #endregion

        }

        private void ButSave_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.configF130From = configF130From.Text;
            Properties.Settings.Default.configF130To = configF130To.Text;
            Properties.Settings.Default.fromPostPay = fromPostPay.Text;
            Properties.Settings.Default.toPostPay = toPostPay.Text;
            Properties.Settings.Default.fromF130 = fromF130.Text;
            Properties.Settings.Default.toF130 = toF130.Text;
            Properties.Settings.Default.fromGibrid = fromGibrid.Text;
            Properties.Settings.Default.toGibrid = toGibrid.Text;
            Properties.Settings.Default.fromPostPayBD = fromPostPayBD.Text;
            Properties.Settings.Default.toPostPayBD = toPostPayBD.Text;
            Properties.Settings.Default.fromPension = fromPension.Text;
            Properties.Settings.Default.toPension = toPension.Text;
            Properties.Settings.Default.fsgCashFrom = fsgCashFrom.Text;
            Properties.Settings.Default.fsgCashTo = fsgCashTo.Text;
            Properties.Settings.Default.regFSGFrom = regFSGFrom.Text;
            Properties.Settings.Default.regFSGTo = regFSGTo.Text;
            Properties.Settings.Default.radioButtonOps = radioButtonOps.Checked;
            Properties.Settings.Default.radioButtonIP = radioButtonIP.Checked;
            Properties.Settings.Default.fromPostPayMod = fromPostPayMod.Text;
            Properties.Settings.Default.toPostPayMod = toPostPayMod.Text;
            Properties.Settings.Default.Save();
        }

        private void ButCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BrowseDialog(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                txtbox[Array.IndexOf(btns, (sender as Button))].Text = folderBrowserDialog.SelectedPath;
            }
        }
    }
}
