namespace FileSearcher
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
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
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.clbDrive = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbName = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.cbDate = new System.Windows.Forms.CheckBox();
            this.cbSize = new System.Windows.Forms.CheckBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.tbSize = new System.Windows.Forms.TextBox();
            this.tbSizeMax = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btDoIt = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.cbSizeType = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.cbName2 = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // clbDrive
            // 
            this.clbDrive.CheckOnClick = true;
            this.clbDrive.FormattingEnabled = true;
            this.clbDrive.Location = new System.Drawing.Point(16, 36);
            this.clbDrive.Margin = new System.Windows.Forms.Padding(4);
            this.clbDrive.Name = "clbDrive";
            this.clbDrive.Size = new System.Drawing.Size(471, 123);
            this.clbDrive.TabIndex = 0;
            this.clbDrive.SelectedIndexChanged += new System.EventHandler(this.clbDrive_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 16);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Где искать?";
            // 
            // cbName
            // 
            this.cbName.AutoSize = true;
            this.cbName.Location = new System.Drawing.Point(16, 201);
            this.cbName.Margin = new System.Windows.Forms.Padding(4);
            this.cbName.Name = "cbName";
            this.cbName.Size = new System.Drawing.Size(57, 21);
            this.cbName.TabIndex = 2;
            this.cbName.Text = "Имя";
            this.cbName.UseVisualStyleBackColor = true;
            this.cbName.CheckedChanged += new System.EventHandler(this.cbName_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 175);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Искать по:";
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(185, 198);
            this.tbName.Margin = new System.Windows.Forms.Padding(4);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(132, 22);
            this.tbName.TabIndex = 4;
            this.tbName.TextChanged += new System.EventHandler(this.tbName_TextChanged);
            // 
            // cbDate
            // 
            this.cbDate.AutoSize = true;
            this.cbDate.Location = new System.Drawing.Point(16, 231);
            this.cbDate.Margin = new System.Windows.Forms.Padding(4);
            this.cbDate.Name = "cbDate";
            this.cbDate.Size = new System.Drawing.Size(130, 21);
            this.cbDate.TabIndex = 5;
            this.cbDate.Text = "Дата создания";
            this.cbDate.UseVisualStyleBackColor = true;
            this.cbDate.CheckedChanged += new System.EventHandler(this.cbDate_CheckedChanged);
            // 
            // cbSize
            // 
            this.cbSize.AutoSize = true;
            this.cbSize.Location = new System.Drawing.Point(16, 262);
            this.cbSize.Margin = new System.Windows.Forms.Padding(4);
            this.cbSize.Name = "cbSize";
            this.cbSize.Size = new System.Drawing.Size(79, 21);
            this.cbSize.TabIndex = 7;
            this.cbSize.Text = "Размер";
            this.cbSize.UseVisualStyleBackColor = true;
            this.cbSize.CheckedChanged += new System.EventHandler(this.cbSize_CheckedChanged);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(185, 230);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(4);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(133, 22);
            this.dateTimePicker1.TabIndex = 8;
            this.dateTimePicker1.Value = new System.DateTime(2010, 1, 15, 20, 26, 31, 0);
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(329, 234);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(24, 17);
            this.label3.TabIndex = 9;
            this.label3.Text = "по";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker2.Location = new System.Drawing.Point(364, 230);
            this.dateTimePicker2.Margin = new System.Windows.Forms.Padding(4);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(124, 22);
            this.dateTimePicker2.TabIndex = 10;
            // 
            // tbSize
            // 
            this.tbSize.Location = new System.Drawing.Point(211, 262);
            this.tbSize.Margin = new System.Windows.Forms.Padding(4);
            this.tbSize.Name = "tbSize";
            this.tbSize.Size = new System.Drawing.Size(107, 22);
            this.tbSize.TabIndex = 11;
            this.tbSize.TextChanged += new System.EventHandler(this.tbSize_TextChanged);
            // 
            // tbSizeMax
            // 
            this.tbSizeMax.Location = new System.Drawing.Point(364, 262);
            this.tbSizeMax.Margin = new System.Windows.Forms.Padding(4);
            this.tbSizeMax.Name = "tbSizeMax";
            this.tbSizeMax.Size = new System.Drawing.Size(123, 22);
            this.tbSizeMax.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(329, 262);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(24, 17);
            this.label4.TabIndex = 9;
            this.label4.Text = "до";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(179, 263);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(23, 17);
            this.label5.TabIndex = 13;
            this.label5.Text = "от";
            // 
            // btDoIt
            // 
            this.btDoIt.ForeColor = System.Drawing.Color.Firebrick;
            this.btDoIt.Location = new System.Drawing.Point(16, 300);
            this.btDoIt.Margin = new System.Windows.Forms.Padding(4);
            this.btDoIt.Name = "btDoIt";
            this.btDoIt.Size = new System.Drawing.Size(471, 39);
            this.btDoIt.TabIndex = 14;
            this.btDoIt.Text = "Поиск";
            this.btDoIt.UseVisualStyleBackColor = true;
            this.btDoIt.Click += new System.EventHandler(this.btDoIt_Click);
            // 
            // cbSizeType
            // 
            this.cbSizeType.FormattingEnabled = true;
            this.cbSizeType.Location = new System.Drawing.Point(112, 262);
            this.cbSizeType.Margin = new System.Windows.Forms.Padding(4);
            this.cbSizeType.Name = "cbSizeType";
            this.cbSizeType.Size = new System.Drawing.Size(57, 24);
            this.cbSizeType.TabIndex = 16;
            this.cbSizeType.SelectedIndexChanged += new System.EventHandler(this.cbSizeType_SelectedIndexChanged);
            this.cbSizeType.Click += new System.EventHandler(this.cbSizeType_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 321);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(0, 17);
            this.label6.TabIndex = 17;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(16, 300);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(337, 37);
            this.progressBar1.TabIndex = 18;
            this.progressBar1.Click += new System.EventHandler(this.progressBar1_Click);
            // 
            // cbName2
            // 
            this.cbName2.FormattingEnabled = true;
            this.cbName2.Location = new System.Drawing.Point(364, 196);
            this.cbName2.Name = "cbName2";
            this.cbName2.Size = new System.Drawing.Size(123, 24);
            this.cbName2.TabIndex = 19;
            this.cbName2.SelectedIndexChanged += new System.EventHandler(this.cbName2_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Firebrick;
            this.ClientSize = new System.Drawing.Size(504, 352);
            this.Controls.Add(this.btDoIt);
            this.Controls.Add(this.cbName2);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cbSizeType);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbSizeMax);
            this.Controls.Add(this.tbSize);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.cbSize);
            this.Controls.Add(this.cbDate);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.clbDrive);
            this.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Поиск файлов";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox clbDrive;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox cbName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.CheckBox cbDate;
        private System.Windows.Forms.CheckBox cbSize;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.TextBox tbSize;
        private System.Windows.Forms.TextBox tbSizeMax;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btDoIt;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.ComboBox cbSizeType;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.ComboBox cbName2;
    }
}

