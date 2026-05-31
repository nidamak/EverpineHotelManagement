namespace EverpineHotelManagement.Forms
{
    partial class RegisterForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.loginback = new System.Windows.Forms.Panel();
            this.lblCaptcha = new System.Windows.Forms.Label();
            this.btnUpdateCaptcha = new System.Windows.Forms.Button();
            this.txtCaptcha = new System.Windows.Forms.TextBox();
            this.lblFullName = new System.Windows.Forms.Label();
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.linklblLogin = new System.Windows.Forms.LinkLabel();
            this.lblRepeatPassword = new System.Windows.Forms.Label();
            this.lblGreeting = new System.Windows.Forms.Label();
            this.lblAddition = new System.Windows.Forms.Label();
            this.lblEHM = new System.Windows.Forms.Label();
            this.picEverpine = new System.Windows.Forms.PictureBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblLogin = new System.Windows.Forms.Label();
            this.txtRepeatPassword = new System.Windows.Forms.TextBox();
            this.txtLogin = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.lblClose = new System.Windows.Forms.Label();
            this.loginback.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picEverpine)).BeginInit();
            this.SuspendLayout();
            // 
            // txtPassword
            // 
            this.txtPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(252)))), ((int)(((byte)(250)))));
            this.txtPassword.Font = new System.Drawing.Font("Segoe UI Variable Text Semibold", 7.8F, System.Drawing.FontStyle.Bold);
            this.txtPassword.Location = new System.Drawing.Point(40, 376);
            this.txtPassword.Multiline = true;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '●';
            this.txtPassword.Size = new System.Drawing.Size(371, 36);
            this.txtPassword.TabIndex = 2;
            // 
            // loginback
            // 
            this.loginback.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.loginback.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(252)))), ((int)(((byte)(250)))));
            this.loginback.Controls.Add(this.lblCaptcha);
            this.loginback.Controls.Add(this.btnUpdateCaptcha);
            this.loginback.Controls.Add(this.txtCaptcha);
            this.loginback.Controls.Add(this.lblFullName);
            this.loginback.Controls.Add(this.txtFullName);
            this.loginback.Controls.Add(this.linklblLogin);
            this.loginback.Controls.Add(this.lblRepeatPassword);
            this.loginback.Controls.Add(this.lblGreeting);
            this.loginback.Controls.Add(this.lblAddition);
            this.loginback.Controls.Add(this.lblEHM);
            this.loginback.Controls.Add(this.picEverpine);
            this.loginback.Controls.Add(this.lblPassword);
            this.loginback.Controls.Add(this.lblLogin);
            this.loginback.Controls.Add(this.txtRepeatPassword);
            this.loginback.Controls.Add(this.txtLogin);
            this.loginback.Controls.Add(this.txtPassword);
            this.loginback.Controls.Add(this.btnLogin);
            this.loginback.Location = new System.Drawing.Point(195, 33);
            this.loginback.Name = "loginback";
            this.loginback.Size = new System.Drawing.Size(448, 697);
            this.loginback.TabIndex = 1;
            // 
            // lblCaptcha
            // 
            this.lblCaptcha.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.lblCaptcha.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblCaptcha.Location = new System.Drawing.Point(40, 500);
            this.lblCaptcha.Name = "lblCaptcha";
            this.lblCaptcha.Size = new System.Drawing.Size(97, 36);
            this.lblCaptcha.TabIndex = 19;
            this.lblCaptcha.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnUpdateCaptcha
            // 
            this.btnUpdateCaptcha.FlatAppearance.BorderSize = 0;
            this.btnUpdateCaptcha.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdateCaptcha.Font = new System.Drawing.Font("Segoe UI Variable Display", 8F);
            this.btnUpdateCaptcha.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(84)))), ((int)(((byte)(84)))));
            this.btnUpdateCaptcha.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnUpdateCaptcha.Location = new System.Drawing.Point(40, 530);
            this.btnUpdateCaptcha.Name = "btnUpdateCaptcha";
            this.btnUpdateCaptcha.Size = new System.Drawing.Size(97, 28);
            this.btnUpdateCaptcha.TabIndex = 20;
            this.btnUpdateCaptcha.Text = "Обновить ";
            this.btnUpdateCaptcha.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnUpdateCaptcha.UseVisualStyleBackColor = false;
            this.btnUpdateCaptcha.Click += new System.EventHandler(this.btnUpdateCaptcha_Click);
            // 
            // txtCaptcha
            // 
            this.txtCaptcha.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(252)))), ((int)(((byte)(250)))));
            this.txtCaptcha.Font = new System.Drawing.Font("Segoe UI Variable Text Semibold", 7.8F, System.Drawing.FontStyle.Bold);
            this.txtCaptcha.Location = new System.Drawing.Point(166, 500);
            this.txtCaptcha.Multiline = true;
            this.txtCaptcha.Name = "txtCaptcha";
            this.txtCaptcha.Size = new System.Drawing.Size(245, 36);
            this.txtCaptcha.TabIndex = 18;
            // 
            // lblFullName
            // 
            this.lblFullName.AutoSize = true;
            this.lblFullName.Font = new System.Drawing.Font("Segoe UI Variable Text Semibold", 7.8F, System.Drawing.FontStyle.Bold);
            this.lblFullName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(61)))), ((int)(((byte)(61)))));
            this.lblFullName.Location = new System.Drawing.Point(52, 222);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new System.Drawing.Size(38, 17);
            this.lblFullName.TabIndex = 17;
            this.lblFullName.Text = "ФИО";
            // 
            // txtFullName
            // 
            this.txtFullName.Location = new System.Drawing.Point(40, 242);
            this.txtFullName.Multiline = true;
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Size = new System.Drawing.Size(371, 36);
            this.txtFullName.TabIndex = 16;
            // 
            // linklblLogin
            // 
            this.linklblLogin.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(118)))), ((int)(((byte)(77)))));
            this.linklblLogin.LinkArea = new System.Windows.Forms.LinkArea(24, 5);
            this.linklblLogin.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(139)))), ((int)(((byte)(90)))));
            this.linklblLogin.Location = new System.Drawing.Point(40, 619);
            this.linklblLogin.Name = "linklblLogin";
            this.linklblLogin.Size = new System.Drawing.Size(371, 30);
            this.linklblLogin.TabIndex = 15;
            this.linklblLogin.TabStop = true;
            this.linklblLogin.Text = "Аккаунт уже существует? Войти";
            this.linklblLogin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.linklblLogin.UseCompatibleTextRendering = true;
            this.linklblLogin.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linklblLogin_LinkClicked);
            // 
            // lblRepeatPassword
            // 
            this.lblRepeatPassword.AutoSize = true;
            this.lblRepeatPassword.Font = new System.Drawing.Font("Segoe UI Variable Text Semibold", 7.8F, System.Drawing.FontStyle.Bold);
            this.lblRepeatPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(61)))), ((int)(((byte)(61)))));
            this.lblRepeatPassword.Location = new System.Drawing.Point(52, 423);
            this.lblRepeatPassword.Name = "lblRepeatPassword";
            this.lblRepeatPassword.Size = new System.Drawing.Size(125, 17);
            this.lblRepeatPassword.TabIndex = 14;
            this.lblRepeatPassword.Text = "Повторите пароль";
            // 
            // lblGreeting
            // 
            this.lblGreeting.Font = new System.Drawing.Font("Segoe UI Variable Display", 13F);
            this.lblGreeting.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(61)))), ((int)(((byte)(61)))));
            this.lblGreeting.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblGreeting.Location = new System.Drawing.Point(7, 139);
            this.lblGreeting.Name = "lblGreeting";
            this.lblGreeting.Size = new System.Drawing.Size(432, 35);
            this.lblGreeting.TabIndex = 6;
            this.lblGreeting.Text = "Добро пожаловать в Everpine!";
            this.lblGreeting.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAddition
            // 
            this.lblAddition.Font = new System.Drawing.Font("Segoe UI Variable Display", 8F);
            this.lblAddition.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(84)))), ((int)(((byte)(84)))));
            this.lblAddition.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblAddition.Location = new System.Drawing.Point(12, 165);
            this.lblAddition.Name = "lblAddition";
            this.lblAddition.Size = new System.Drawing.Size(422, 30);
            this.lblAddition.TabIndex = 12;
            this.lblAddition.Text = "Введите свои данные для регистрации";
            this.lblAddition.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblEHM
            // 
            this.lblEHM.Font = new System.Drawing.Font("Segoe UI Variable Display", 6F);
            this.lblEHM.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(126)))));
            this.lblEHM.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblEHM.Location = new System.Drawing.Point(-3, 0);
            this.lblEHM.Name = "lblEHM";
            this.lblEHM.Size = new System.Drawing.Size(442, 36);
            this.lblEHM.TabIndex = 11;
            this.lblEHM.Text = "EVERPINE HOTEL MANAGEMENT";
            this.lblEHM.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // picEverpine
            // 
            this.picEverpine.Image = global::EverpineHotelManagement.Properties.Resources.everpine_logo;
            this.picEverpine.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.picEverpine.Location = new System.Drawing.Point(176, 39);
            this.picEverpine.Name = "picEverpine";
            this.picEverpine.Size = new System.Drawing.Size(85, 86);
            this.picEverpine.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picEverpine.TabIndex = 9;
            this.picEverpine.TabStop = false;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("Segoe UI Variable Text Semibold", 7.8F, System.Drawing.FontStyle.Bold);
            this.lblPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(61)))), ((int)(((byte)(61)))));
            this.lblPassword.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblPassword.Location = new System.Drawing.Point(52, 356);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(55, 17);
            this.lblPassword.TabIndex = 5;
            this.lblPassword.Text = "Пароль";
            // 
            // lblLogin
            // 
            this.lblLogin.AutoSize = true;
            this.lblLogin.Font = new System.Drawing.Font("Segoe UI Variable Text Semibold", 7.8F, System.Drawing.FontStyle.Bold);
            this.lblLogin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(61)))), ((int)(((byte)(61)))));
            this.lblLogin.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblLogin.Location = new System.Drawing.Point(52, 287);
            this.lblLogin.Name = "lblLogin";
            this.lblLogin.Size = new System.Drawing.Size(46, 17);
            this.lblLogin.TabIndex = 1;
            this.lblLogin.Text = "Логин";
            // 
            // txtRepeatPassword
            // 
            this.txtRepeatPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(252)))), ((int)(((byte)(250)))));
            this.txtRepeatPassword.Font = new System.Drawing.Font("Segoe UI Variable Text Semibold", 7.8F, System.Drawing.FontStyle.Bold);
            this.txtRepeatPassword.Location = new System.Drawing.Point(40, 443);
            this.txtRepeatPassword.Multiline = true;
            this.txtRepeatPassword.Name = "txtRepeatPassword";
            this.txtRepeatPassword.Size = new System.Drawing.Size(371, 36);
            this.txtRepeatPassword.TabIndex = 3;
            // 
            // txtLogin
            // 
            this.txtLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(252)))), ((int)(((byte)(250)))));
            this.txtLogin.Font = new System.Drawing.Font("Segoe UI Variable Text Semibold", 7.8F, System.Drawing.FontStyle.Bold);
            this.txtLogin.Location = new System.Drawing.Point(40, 307);
            this.txtLogin.Multiline = true;
            this.txtLogin.Name = "txtLogin";
            this.txtLogin.Size = new System.Drawing.Size(371, 36);
            this.txtLogin.TabIndex = 1;
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(71)))), ((int)(((byte)(58)))));
            this.btnLogin.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnLogin.FlatAppearance.BorderSize = 0;
            this.btnLogin.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(118)))), ((int)(((byte)(77)))));
            this.btnLogin.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(139)))), ((int)(((byte)(90)))));
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Font = new System.Drawing.Font("Segoe UI Variable Display", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnLogin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(252)))), ((int)(((byte)(250)))));
            this.btnLogin.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnLogin.Location = new System.Drawing.Point(40, 574);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(371, 42);
            this.btnLogin.TabIndex = 0;
            this.btnLogin.Text = "Зарегистрироваться";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // lblClose
            // 
            this.lblClose.AutoSize = true;
            this.lblClose.Font = new System.Drawing.Font("Segoe UI Variable Display Semib", 9F, System.Drawing.FontStyle.Bold);
            this.lblClose.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblClose.Location = new System.Drawing.Point(781, 9);
            this.lblClose.Name = "lblClose";
            this.lblClose.Size = new System.Drawing.Size(18, 20);
            this.lblClose.TabIndex = 2;
            this.lblClose.Text = "X";
            this.lblClose.Click += new System.EventHandler(this.lblClose_Click);
            // 
            // RegisterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(237)))), ((int)(((byte)(230)))));
            this.ClientSize = new System.Drawing.Size(811, 762);
            this.Controls.Add(this.lblClose);
            this.Controls.Add(this.loginback);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "RegisterForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RegisterForm";
            this.Load += new System.EventHandler(this.RegisterForm_Load);
            this.loginback.ResumeLayout(false);
            this.loginback.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picEverpine)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Panel loginback;
        private System.Windows.Forms.Label lblGreeting;
        private System.Windows.Forms.Label lblAddition;
        private System.Windows.Forms.Label lblEHM;
        private System.Windows.Forms.PictureBox picEverpine;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblLogin;
        private System.Windows.Forms.TextBox txtRepeatPassword;
        private System.Windows.Forms.TextBox txtLogin;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Label lblRepeatPassword;
        private System.Windows.Forms.LinkLabel linklblLogin;
        private System.Windows.Forms.Label lblFullName;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.Label lblCaptcha;
        private System.Windows.Forms.TextBox txtCaptcha;
        private System.Windows.Forms.Button btnUpdateCaptcha;
        private System.Windows.Forms.Label lblClose;
    }
}