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
            btnReset.Click += BtnReset_Click;
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Reset();
            #region Загрузка параметров
            configF130To.Text = Properties.Settings.Default.configF130To;
            fromPostPay.Text = Properties.Settings.Default.fromPostPay;
            fromF130.Text = Properties.Settings.Default.fromF130;
            toGibrid.Text = Properties.Settings.Default.toGibrid;
            toPostPayBD.Text = Properties.Settings.Default.toPostPayBD;
            fromPension.Text = Properties.Settings.Default.fromPension;
            fsgCashTo.Text = Properties.Settings.Default.fsgCashTo;
            regFSGFrom.Text = Properties.Settings.Default.regFSGFrom;
            radioButtonOps.Checked = Properties.Settings.Default.radioButtonOps;
            radioButtonIP.Checked = Properties.Settings.Default.radioButtonIP;
            toPostPayMod.Text = Properties.Settings.Default.toPostPayMod;
            comboBoxPost.Text = Properties.Settings.Default.comboBoxPost;
            textBoxIP.Text = Properties.Settings.Default.textBoxIP;
            textBoxLogin.Text = Properties.Settings.Default.textBoxLogin;
            textBoxPass.Text = Properties.Settings.Default.textBoxPass;
            #endregion
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            btns = new Button[]
            {
                button2,
                button3,
                button5,
                button8,
                button10,
                button11,
                button14,
                button15,
                button18
            };
            txtbox = new TextBox[]
            {
                configF130To,
                fromPostPay,
                fromF130,
                toGibrid,
                toPostPayBD,
                fromPension,
                fsgCashTo,
                regFSGFrom,
                toPostPayMod
            };

            #region Загрузка параметров
            configF130To.Text = Properties.Settings.Default.configF130To;
            fromPostPay.Text = Properties.Settings.Default.fromPostPay;
            fromF130.Text = Properties.Settings.Default.fromF130;
            toGibrid.Text = Properties.Settings.Default.toGibrid;
            toPostPayBD.Text = Properties.Settings.Default.toPostPayBD;
            fromPension.Text = Properties.Settings.Default.fromPension;
            fsgCashTo.Text = Properties.Settings.Default.fsgCashTo;
            regFSGFrom.Text = Properties.Settings.Default.regFSGFrom;
            radioButtonOps.Checked = Properties.Settings.Default.radioButtonOps;
            radioButtonIP.Checked = Properties.Settings.Default.radioButtonIP;
            toPostPayMod.Text = Properties.Settings.Default.toPostPayMod;
            comboBoxPost.Text = Properties.Settings.Default.comboBoxPost;
            textBoxIP.Text = Properties.Settings.Default.textBoxIP;
            textBoxLogin.Text = Properties.Settings.Default.textBoxLogin;
            textBoxPass.Text = Properties.Settings.Default.textBoxPass;
            #endregion
            
        }

        private void ButSave_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.configF130To = configF130To.Text;
            Properties.Settings.Default.fromPostPay = fromPostPay.Text;
            Properties.Settings.Default.fromF130 = fromF130.Text;
            Properties.Settings.Default.toGibrid = toGibrid.Text;
            Properties.Settings.Default.toPostPayBD = toPostPayBD.Text;
            Properties.Settings.Default.fromPension = fromPension.Text;
            Properties.Settings.Default.fsgCashTo = fsgCashTo.Text;
            Properties.Settings.Default.regFSGFrom = regFSGFrom.Text;
            Properties.Settings.Default.radioButtonOps = radioButtonOps.Checked;
            Properties.Settings.Default.radioButtonIP = radioButtonIP.Checked;
            Properties.Settings.Default.toPostPayMod = toPostPayMod.Text;
            Properties.Settings.Default.comboBoxPost = comboBoxPost.Text;
            Properties.Settings.Default.textBoxIP = textBoxIP.Text;
            Properties.Settings.Default.textBoxLogin = textBoxLogin.Text;
            Properties.Settings.Default.textBoxPass = textBoxPass.Text;
            Properties.Settings.Default.Save();
            Close();
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
