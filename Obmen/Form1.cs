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
            #region Присвоение путей для переменных
            string disk = Operation.GetDisk();

            // Пользователь не постоянен, как и название последней папки в пути
            // Определяем имя текущего пользователя
            string user = Environment.UserName;
            // Определяем текущую дату
            //string date = DateTime.Today.ToString("yyyy-MM-dd");
            string fromPostPay = @"C:\Users\" + user + @"\Documents\LttPpsPlugin\ExportFiles";
            string toPostPay = disk + @"Реестр коммунальных платежей\";

            string configF130From = disk + @"Config";
            string configF130To = @"C:\Program Files (x86)\ИПФ Сервер\Дневник Ф130\Config\";
            string fromF130 = @"C:\Program Files (x86)\ИПФ Сервер\Дневник Ф130\Archives\ASKUExport";
            string toF130 = disk + @"F130\";
            string fromGibrid = disk + @"Гибридные переводы";
            string toGibrid = @"C:\Гибридные переводы\";
            string fromPostPayBD = disk + @"База по коммунальным платежам\";
            string toPostPayBD = @"C:\База по коммунальным платежам\";
            string fromPension = @"C:\Users\" + user + @"\Desktop\Пенсия";
            string toPension = disk + @"Пенсия\";
            string fsgCashFrom = disk + @"FSG\Кэш";
            string fsgCashTo = @"C:\Users\" + user + @"\Documents\FSG\Кэш\";
            string regFSGFrom = @"C:\Users\" + user + @"\Documents\FSG\Реестры платежей";
            string regFSGTo = disk + @"FSG\Реестры платежей\";
            #endregion

            Thread th1 = new Thread(() => Operation.CopyDB(fromPostPayBD, toPostPayBD));    // База по комуналке
            th1.Start();
             
            Operation.Copy(regFSGFrom, regFSGTo);            // Реестры ФСГ
            Operation.Copy(fsgCashFrom, fsgCashTo);          // Архив для ФСГ
            Operation.Copy(fromPension, toPension);          // Файлы по пенсии
            Operation.CopyDir(configF130From, configF130To); // Ключ для 130
            Operation.Copy(fromGibrid, toGibrid);            // Файлы по гибридным
            Operation.CopyDir(fromPostPay, toPostPay);       // Реестр по комуналке
            Operation.Copy(fromF130, toF130);                // Файлы для АСКУ 

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
                string disk = Operation.GetDisk();
                string fromPostPayMod = disk + @"Обновление PostPay\Distribution.zip";
                string toPostPayMod = @"C:\ProgramData\PostPay\ExecutiveVersion\";

                MessageBox.Show("Прежде чем обновлять модуль 'Коммунальные платяжи'\nнеобходимо выйти из программы ЕАС.","Внимание", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                DialogResult result = MessageBox.Show("Обновить модуль 'Коммунальные платяжи'?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(result == DialogResult.Yes)
                {
                    Operation.ExtractDistrib(fromPostPayMod, toPostPayMod);  // Архив обновления PostPay
                    MessageBox.Show("Обновление завершено!", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
        }
    }
}
