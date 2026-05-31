namespace EverpineHotelManagement.Forms
{
    partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.loginback = new System.Windows.Forms.Panel();
            this.lblCaptcha = new System.Windows.Forms.Label();
            this.btnUpdateCaptcha = new System.Windows.Forms.Button();
            this.lblGreeting = new System.Windows.Forms.Label();
            this.lblAddition = new System.Windows.Forms.Label();
            this.lblEHM = new System.Windows.Forms.Label();
            this.picEverpine = new System.Windows.Forms.PictureBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblLogin = new System.Windows.Forms.Label();
            this.txtCaptcha = new System.Windows.Forms.TextBox();
            this.txtLogin = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnRegister = new System.Windows.Forms.Button();
            this.btnLogin = new System.Windows.Forms.Button();
            this.lblClose = new System.Windows.Forms.Label();
            this.loginback.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picEverpine)).BeginInit();
            this.SuspendLayout();
            // 
            // loginback
            // 
            resources.ApplyResources(this.loginback, "loginback");
            this.loginback.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(252)))), ((int)(((byte)(250)))));
            this.loginback.Controls.Add(this.lblCaptcha);
            this.loginback.Controls.Add(this.btnUpdateCaptcha);
            this.loginback.Controls.Add(this.lblGreeting);
            this.loginback.Controls.Add(this.lblAddition);
            this.loginback.Controls.Add(this.lblEHM);
            this.loginback.Controls.Add(this.picEverpine);
            this.loginback.Controls.Add(this.lblPassword);
            this.loginback.Controls.Add(this.lblLogin);
            this.loginback.Controls.Add(this.txtCaptcha);
            this.loginback.Controls.Add(this.txtLogin);
            this.loginback.Controls.Add(this.txtPassword);
            this.loginback.Controls.Add(this.btnRegister);
            this.loginback.Controls.Add(this.btnLogin);
            this.loginback.Name = "loginback";
            // 
            // lblCaptcha
            // 
            this.lblCaptcha.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            resources.ApplyResources(this.lblCaptcha, "lblCaptcha");
            this.lblCaptcha.Name = "lblCaptcha";
            // 
            // btnUpdateCaptcha
            // 
            this.btnUpdateCaptcha.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.btnUpdateCaptcha, "btnUpdateCaptcha");
            this.btnUpdateCaptcha.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(84)))), ((int)(((byte)(84)))));
            this.btnUpdateCaptcha.Name = "btnUpdateCaptcha";
            this.btnUpdateCaptcha.UseVisualStyleBackColor = false;
            this.btnUpdateCaptcha.Click += new System.EventHandler(this.btnUpdateCaptcha_Click);
            // 
            // lblGreeting
            // 
            resources.ApplyResources(this.lblGreeting, "lblGreeting");
            this.lblGreeting.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(61)))), ((int)(((byte)(61)))));
            this.lblGreeting.Name = "lblGreeting";
            // 
            // lblAddition
            // 
            resources.ApplyResources(this.lblAddition, "lblAddition");
            this.lblAddition.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(84)))), ((int)(((byte)(84)))));
            this.lblAddition.Name = "lblAddition";
            // 
            // lblEHM
            // 
            resources.ApplyResources(this.lblEHM, "lblEHM");
            this.lblEHM.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(126)))));
            this.lblEHM.Name = "lblEHM";
            // 
            // picEverpine
            // 
            this.picEverpine.Image = global::EverpineHotelManagement.Properties.Resources.everpine_logo;
            resources.ApplyResources(this.picEverpine, "picEverpine");
            this.picEverpine.Name = "picEverpine";
            this.picEverpine.TabStop = false;
            // 
            // lblPassword
            // 
            resources.ApplyResources(this.lblPassword, "lblPassword");
            this.lblPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(61)))), ((int)(((byte)(61)))));
            this.lblPassword.Name = "lblPassword";
            // 
            // lblLogin
            // 
            resources.ApplyResources(this.lblLogin, "lblLogin");
            this.lblLogin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(61)))), ((int)(((byte)(61)))));
            this.lblLogin.Name = "lblLogin";
            // 
            // txtCaptcha
            // 
            this.txtCaptcha.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(252)))), ((int)(((byte)(250)))));
            resources.ApplyResources(this.txtCaptcha, "txtCaptcha");
            this.txtCaptcha.Name = "txtCaptcha";
            // 
            // txtLogin
            // 
            this.txtLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(252)))), ((int)(((byte)(250)))));
            resources.ApplyResources(this.txtLogin, "txtLogin");
            this.txtLogin.Name = "txtLogin";
            this.txtLogin.Enter += new System.EventHandler(this.RemovePlaceholder);
            this.txtLogin.Leave += new System.EventHandler(this.SetPlaceholder);
            // 
            // txtPassword
            // 
            this.txtPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(252)))), ((int)(((byte)(250)))));
            resources.ApplyResources(this.txtPassword, "txtPassword");
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.TextChanged += new System.EventHandler(this.txtPassword_TextChanged);
            // 
            // btnRegister
            // 
            this.btnRegister.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(71)))), ((int)(((byte)(58)))));
            this.btnRegister.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(71)))), ((int)(((byte)(58)))));
            this.btnRegister.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(243)))), ((int)(((byte)(241)))));
            resources.ApplyResources(this.btnRegister, "btnRegister");
            this.btnRegister.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(71)))), ((int)(((byte)(58)))));
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.UseVisualStyleBackColor = true;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            this.btnRegister.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnRegister_MouseDown);
            this.btnRegister.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnRegister_MouseUp);
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(71)))), ((int)(((byte)(58)))));
            this.btnLogin.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnLogin.FlatAppearance.BorderSize = 0;
            this.btnLogin.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(118)))), ((int)(((byte)(77)))));
            this.btnLogin.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(139)))), ((int)(((byte)(90)))));
            resources.ApplyResources(this.btnLogin, "btnLogin");
            this.btnLogin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(252)))), ((int)(((byte)(250)))));
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // lblClose
            // 
            resources.ApplyResources(this.lblClose, "lblClose");
            this.lblClose.Name = "lblClose";
            this.lblClose.Click += new System.EventHandler(this.lblClose_Click);
            // 
            // LoginForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(237)))), ((int)(((byte)(230)))));
            this.Controls.Add(this.lblClose);
            this.Controls.Add(this.loginback);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LoginForm";
            this.ShowIcon = false;
            this.loginback.ResumeLayout(false);
            this.loginback.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picEverpine)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel loginback;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Label lblCaptcha;
        private System.Windows.Forms.TextBox txtCaptcha;
        private System.Windows.Forms.TextBox txtLogin;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblLogin;
        private System.Windows.Forms.Label lblGreeting;
        private System.Windows.Forms.PictureBox picEverpine;
        private System.Windows.Forms.Label lblAddition;
        private System.Windows.Forms.Label lblEHM;
        private System.Windows.Forms.Button btnUpdateCaptcha;
        private System.Windows.Forms.Label lblClose;
    }
}