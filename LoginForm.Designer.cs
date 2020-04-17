namespace KursachBD
{
    partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelreg = new System.Windows.Forms.Panel();
            this.NameLbl = new System.Windows.Forms.Label();
            this.PassTB = new System.Windows.Forms.TextBox();
            this.Back = new System.Windows.Forms.Label();
            this.LoginTB = new System.Windows.Forms.TextBox();
            this.NumPassTB = new System.Windows.Forms.TextBox();
            this.PhoneTB = new System.Windows.Forms.TextBox();
            this.Adress = new System.Windows.Forms.Label();
            this.RegistrGo = new System.Windows.Forms.Button();
            this.Series_pass = new System.Windows.Forms.Label();
            this.SeriesTB = new System.Windows.Forms.TextBox();
            this.Num_phone = new System.Windows.Forms.Label();
            this.AdressTB = new System.Windows.Forms.TextBox();
            this.InpLg = new System.Windows.Forms.Label();
            this.NameTB = new System.Windows.Forms.TextBox();
            this.Pass = new System.Windows.Forms.Label();
            this.Registr = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.panelreg.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.panelreg);
            this.panel1.Controls.Add(this.Registr);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.textBox2);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Location = new System.Drawing.Point(12, 87);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(654, 382);
            this.panel1.TabIndex = 0;
            // 
            // panelreg
            // 
            this.panelreg.Controls.Add(this.NameLbl);
            this.panelreg.Controls.Add(this.PassTB);
            this.panelreg.Controls.Add(this.Back);
            this.panelreg.Controls.Add(this.LoginTB);
            this.panelreg.Controls.Add(this.NumPassTB);
            this.panelreg.Controls.Add(this.PhoneTB);
            this.panelreg.Controls.Add(this.Adress);
            this.panelreg.Controls.Add(this.RegistrGo);
            this.panelreg.Controls.Add(this.Series_pass);
            this.panelreg.Controls.Add(this.SeriesTB);
            this.panelreg.Controls.Add(this.Num_phone);
            this.panelreg.Controls.Add(this.AdressTB);
            this.panelreg.Controls.Add(this.InpLg);
            this.panelreg.Controls.Add(this.NameTB);
            this.panelreg.Controls.Add(this.Pass);
            this.panelreg.Location = new System.Drawing.Point(255, 16);
            this.panelreg.Name = "panelreg";
            this.panelreg.Size = new System.Drawing.Size(396, 363);
            this.panelreg.TabIndex = 24;
            this.panelreg.Visible = false;
            // 
            // NameLbl
            // 
            this.NameLbl.AutoSize = true;
            this.NameLbl.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NameLbl.Location = new System.Drawing.Point(3, 40);
            this.NameLbl.Name = "NameLbl";
            this.NameLbl.Size = new System.Drawing.Size(53, 24);
            this.NameLbl.TabIndex = 8;
            this.NameLbl.Text = "Имя:";
            // 
            // PassTB
            // 
            this.PassTB.Location = new System.Drawing.Point(187, 242);
            this.PassTB.MaxLength = 50;
            this.PassTB.Name = "PassTB";
            this.PassTB.Size = new System.Drawing.Size(206, 32);
            this.PassTB.TabIndex = 21;
            this.PassTB.UseSystemPasswordChar = true;
            // 
            // Back
            // 
            this.Back.AutoSize = true;
            this.Back.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Back.Font = new System.Drawing.Font("Calibri", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Back.ForeColor = System.Drawing.Color.Blue;
            this.Back.Location = new System.Drawing.Point(332, 0);
            this.Back.Name = "Back";
            this.Back.Size = new System.Drawing.Size(61, 24);
            this.Back.TabIndex = 23;
            this.Back.Text = "Назад";
            this.Back.Click += new System.EventHandler(this.Back_Click);
            // 
            // LoginTB
            // 
            this.LoginTB.Location = new System.Drawing.Point(187, 198);
            this.LoginTB.MaxLength = 50;
            this.LoginTB.Name = "LoginTB";
            this.LoginTB.Size = new System.Drawing.Size(206, 32);
            this.LoginTB.TabIndex = 20;
            // 
            // NumPassTB
            // 
            this.NumPassTB.Location = new System.Drawing.Point(227, 116);
            this.NumPassTB.MaxLength = 9;
            this.NumPassTB.Name = "NumPassTB";
            this.NumPassTB.Size = new System.Drawing.Size(166, 32);
            this.NumPassTB.TabIndex = 18;
            // 
            // PhoneTB
            // 
            this.PhoneTB.Location = new System.Drawing.Point(187, 159);
            this.PhoneTB.MaxLength = 10;
            this.PhoneTB.Name = "PhoneTB";
            this.PhoneTB.Size = new System.Drawing.Size(206, 32);
            this.PhoneTB.TabIndex = 19;
            // 
            // Adress
            // 
            this.Adress.AutoSize = true;
            this.Adress.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Adress.Location = new System.Drawing.Point(3, 77);
            this.Adress.Name = "Adress";
            this.Adress.Size = new System.Drawing.Size(69, 24);
            this.Adress.TabIndex = 9;
            this.Adress.Text = "Адрес:";
            // 
            // RegistrGo
            // 
            this.RegistrGo.Font = new System.Drawing.Font("Calibri", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RegistrGo.Location = new System.Drawing.Point(78, 319);
            this.RegistrGo.Name = "RegistrGo";
            this.RegistrGo.Size = new System.Drawing.Size(217, 41);
            this.RegistrGo.TabIndex = 22;
            this.RegistrGo.Text = "Зарегистрироваться";
            this.RegistrGo.UseVisualStyleBackColor = true;
            this.RegistrGo.Click += new System.EventHandler(this.RegistrGo_Click);
            // 
            // Series_pass
            // 
            this.Series_pass.AutoSize = true;
            this.Series_pass.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Series_pass.Location = new System.Drawing.Point(3, 109);
            this.Series_pass.Name = "Series_pass";
            this.Series_pass.Size = new System.Drawing.Size(141, 48);
            this.Series_pass.TabIndex = 10;
            this.Series_pass.Text = "Серия и номер\r\nпаспорта:";
            // 
            // SeriesTB
            // 
            this.SeriesTB.Location = new System.Drawing.Point(187, 116);
            this.SeriesTB.MaxLength = 2;
            this.SeriesTB.Name = "SeriesTB";
            this.SeriesTB.Size = new System.Drawing.Size(34, 32);
            this.SeriesTB.TabIndex = 17;
            // 
            // Num_phone
            // 
            this.Num_phone.AutoSize = true;
            this.Num_phone.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Num_phone.Location = new System.Drawing.Point(3, 162);
            this.Num_phone.Name = "Num_phone";
            this.Num_phone.Size = new System.Drawing.Size(165, 24);
            this.Num_phone.TabIndex = 12;
            this.Num_phone.Text = "Номер телефона:";
            // 
            // AdressTB
            // 
            this.AdressTB.Location = new System.Drawing.Point(187, 74);
            this.AdressTB.MaxLength = 50;
            this.AdressTB.Name = "AdressTB";
            this.AdressTB.Size = new System.Drawing.Size(206, 32);
            this.AdressTB.TabIndex = 16;
            // 
            // InpLg
            // 
            this.InpLg.AutoSize = true;
            this.InpLg.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.InpLg.Location = new System.Drawing.Point(3, 201);
            this.InpLg.Name = "InpLg";
            this.InpLg.Size = new System.Drawing.Size(63, 24);
            this.InpLg.TabIndex = 13;
            this.InpLg.Text = "Логин";
            // 
            // NameTB
            // 
            this.NameTB.Font = new System.Drawing.Font("Calibri", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NameTB.Location = new System.Drawing.Point(187, 36);
            this.NameTB.MaxLength = 50;
            this.NameTB.Name = "NameTB";
            this.NameTB.Size = new System.Drawing.Size(206, 32);
            this.NameTB.TabIndex = 15;
            // 
            // Pass
            // 
            this.Pass.AutoSize = true;
            this.Pass.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Pass.Location = new System.Drawing.Point(3, 245);
            this.Pass.Name = "Pass";
            this.Pass.Size = new System.Drawing.Size(76, 24);
            this.Pass.TabIndex = 14;
            this.Pass.Text = "Пароль";
            // 
            // Registr
            // 
            this.Registr.Font = new System.Drawing.Font("Calibri", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Registr.Location = new System.Drawing.Point(446, 68);
            this.Registr.Name = "Registr";
            this.Registr.Size = new System.Drawing.Size(164, 42);
            this.Registr.TabIndex = 4;
            this.Registr.Text = "Регистрация";
            this.Registr.UseVisualStyleBackColor = true;
            this.Registr.Click += new System.EventHandler(this.Registr_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(229, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(253, 30);
            this.label3.TabIndex = 6;
            this.label3.Text = " Войдите в систему";
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox2.Location = new System.Drawing.Point(434, 231);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(164, 34);
            this.textBox2.TabIndex = 2;
            this.textBox2.UseSystemPasswordChar = true;
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox1.Location = new System.Drawing.Point(434, 152);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(164, 34);
            this.textBox1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(287, 231);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 29);
            this.label2.TabIndex = 3;
            this.label2.Text = "Пароль";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(287, 152);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 29);
            this.label1.TabIndex = 2;
            this.label1.Text = "Логин";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.button1.Location = new System.Drawing.Point(475, 301);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(123, 42);
            this.button1.TabIndex = 3;
            this.button1.Text = "Войти";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(3, 125);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(229, 181);
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // LoginForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(801, 531);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Calibri", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "LoginForm";
            this.Text = "Login form";
            this.Load += new System.EventHandler(this.Login_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelreg.ResumeLayout(false);
            this.panelreg.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button Registr;
        private System.Windows.Forms.Label Pass;
        private System.Windows.Forms.Label Num_phone;
        private System.Windows.Forms.Label Series_pass;
        private System.Windows.Forms.Label Adress;
        private System.Windows.Forms.Label NameLbl;
        private System.Windows.Forms.TextBox PassTB;
        private System.Windows.Forms.TextBox NumPassTB;
        private System.Windows.Forms.TextBox LoginTB;
        private System.Windows.Forms.TextBox PhoneTB;
        private System.Windows.Forms.TextBox SeriesTB;
        private System.Windows.Forms.TextBox AdressTB;
        private System.Windows.Forms.TextBox NameTB;
        private System.Windows.Forms.Label InpLg;
        private System.Windows.Forms.Button RegistrGo;
        private System.Windows.Forms.Label Back;
        private System.Windows.Forms.Panel panelreg;
    }
}

