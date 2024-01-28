namespace kathy_s_crack
{
    partial class mainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainForm));
            this.textPath = new System.Windows.Forms.TextBox();
            this.comboBoxGame = new System.Windows.Forms.ComboBox();
            this.selectFolderPath = new System.Windows.Forms.FolderBrowserDialog();
            this.labelError = new System.Windows.Forms.Label();
            this.roundBtn1 = new kathy_s_crack.RoundBtn();
            this.btnCancel = new kathy_s_crack.RoundBtn();
            this.btnStart = new kathy_s_crack.RoundBtn();
            this.SuspendLayout();
            // 
            // textPath
            // 
            this.textPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textPath.ForeColor = System.Drawing.SystemColors.WindowText;
            this.textPath.Location = new System.Drawing.Point(79, 72);
            this.textPath.Name = "textPath";
            this.textPath.Size = new System.Drawing.Size(344, 26);
            this.textPath.TabIndex = 2;
            this.textPath.TextChanged += new System.EventHandler(this.textChanged_Check);
            // 
            // comboBoxGame
            // 
            this.comboBoxGame.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxGame.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxGame.FormattingEnabled = true;
            this.comboBoxGame.Items.AddRange(new object[] {
            "download + crack dlcs",
            "only crack dlcs"});
            this.comboBoxGame.Location = new System.Drawing.Point(236, 117);
            this.comboBoxGame.Name = "comboBoxGame";
            this.comboBoxGame.Size = new System.Drawing.Size(187, 26);
            this.comboBoxGame.TabIndex = 4;
            // 
            // selectFolderPath
            // 
            this.selectFolderPath.Description = "Выберите папку с игрой";
            // 
            // labelError
            // 
            this.labelError.AutoSize = true;
            this.labelError.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelError.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.labelError.Location = new System.Drawing.Point(123, 155);
            this.labelError.Name = "labelError";
            this.labelError.Size = new System.Drawing.Size(365, 18);
            this.labelError.TabIndex = 6;
            this.labelError.Text = "The executable file was not found in the selected folder";
            // 
            // roundBtn1
            // 
            this.roundBtn1.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.roundBtn1.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.roundBtn1.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.roundBtn1.BorderRadius = 25;
            this.roundBtn1.BorderSize = 0;
            this.roundBtn1.FlatAppearance.BorderSize = 0;
            this.roundBtn1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.roundBtn1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.roundBtn1.ForeColor = System.Drawing.Color.White;
            this.roundBtn1.Location = new System.Drawing.Point(440, 72);
            this.roundBtn1.Name = "roundBtn1";
            this.roundBtn1.Size = new System.Drawing.Size(109, 26);
            this.roundBtn1.TabIndex = 3;
            this.roundBtn1.Text = "select path";
            this.roundBtn1.TextColor = System.Drawing.Color.White;
            this.roundBtn1.UseVisualStyleBackColor = false;
            this.roundBtn1.Click += new System.EventHandler(this.btnSelectPath_click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Indigo;
            this.btnCancel.BackgroundColor = System.Drawing.Color.Indigo;
            this.btnCancel.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnCancel.BorderRadius = 40;
            this.btnCancel.BorderSize = 0;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Himalaya", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnCancel.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnCancel.Location = new System.Drawing.Point(519, 304);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(107, 37);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "cancel";
            this.btnCancel.TextColor = System.Drawing.Color.WhiteSmoke;
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.Color.Indigo;
            this.btnStart.BackgroundColor = System.Drawing.Color.Indigo;
            this.btnStart.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnStart.BorderRadius = 40;
            this.btnStart.BorderSize = 0;
            this.btnStart.FlatAppearance.BorderSize = 0;
            this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStart.Font = new System.Drawing.Font("Microsoft Himalaya", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnStart.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnStart.Location = new System.Drawing.Point(406, 304);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(107, 37);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "crack";
            this.btnStart.TextColor = System.Drawing.Color.WhiteSmoke;
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_click);
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Desktop;
            this.BackgroundImage = global::kathy_s_crack.Properties.Resources.back_space;
            this.ClientSize = new System.Drawing.Size(638, 353);
            this.Controls.Add(this.labelError);
            this.Controls.Add(this.comboBoxGame);
            this.Controls.Add(this.roundBtn1);
            this.Controls.Add(this.textPath);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnStart);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "mainForm";
            this.Text = "kathy\'s crack";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private RoundBtn btnStart;
        private RoundBtn btnCancel;
        private System.Windows.Forms.TextBox textPath;
        private RoundBtn roundBtn1;
        private System.Windows.Forms.ComboBox comboBoxGame;
        private System.Windows.Forms.FolderBrowserDialog selectFolderPath;
        private System.Windows.Forms.Label labelError;
    }
}

