namespace Obmen
{
    partial class FormObmen
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormObmen));
            this.butYes = new System.Windows.Forms.Button();
            this.butNo = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // butYes
            // 
            this.butYes.BackColor = System.Drawing.Color.LightCyan;
            this.butYes.FlatAppearance.BorderSize = 0;
            this.butYes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butYes.Location = new System.Drawing.Point(67, 63);
            this.butYes.Name = "butYes";
            this.butYes.Size = new System.Drawing.Size(75, 23);
            this.butYes.TabIndex = 0;
            this.butYes.Text = "Да";
            this.butYes.UseVisualStyleBackColor = false;
            this.butYes.Click += new System.EventHandler(this.ButYes_Click);
            // 
            // butNo
            // 
            this.butNo.BackColor = System.Drawing.Color.LightCyan;
            this.butNo.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.butNo.FlatAppearance.BorderSize = 0;
            this.butNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butNo.Location = new System.Drawing.Point(196, 63);
            this.butNo.Name = "butNo";
            this.butNo.Size = new System.Drawing.Size(75, 23);
            this.butNo.TabIndex = 1;
            this.butNo.Text = "Нет";
            this.butNo.UseVisualStyleBackColor = false;
            this.butNo.Click += new System.EventHandler(this.ButNo_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(89, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(165, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Запустить программу обмена?";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(53, 100);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(246, 17);
            this.checkBox1.TabIndex = 3;
            this.checkBox1.Text = "Обновить модуль \'Коммунальные платяжи\'";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // FormObmen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PaleTurquoise;
            this.ClientSize = new System.Drawing.Size(343, 129);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.butNo);
            this.Controls.Add(this.butYes);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormObmen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Обмен файлами";
            this.TransparencyKey = System.Drawing.Color.White;
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FormObmen_MouseDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button butYes;
        private System.Windows.Forms.Button butNo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}

