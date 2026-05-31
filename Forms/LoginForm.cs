using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace EverpineHotelManagement.Forms
{
    public partial class LoginForm : Form
    {
        private readonly Services.CaptchaService _captchaService = new Services.CaptchaService();

        private readonly Services.AuthService _authService = new Services.AuthService(new Data.UserRepository());
        public LoginForm()
        {
            InitializeComponent();

            txtLogin.Enter += RemovePlaceholder;
            txtLogin.Leave += SetPlaceholder;

            txtPassword.Enter += RemovePlaceholder;
            txtPassword.Leave += SetPlaceholder;

            txtCaptcha.Enter += RemovePlaceholder;
            txtCaptcha.Leave += SetPlaceholder;

            txtLogin.Text = "Введите логин";
            txtPassword.Text = "Введите пароль";
            txtCaptcha.Text = "Код";

            txtLogin.ForeColor = Color.Gray;
            txtPassword.ForeColor = Color.Gray;
            txtCaptcha.ForeColor = Color.Gray;

            this.BackColor = ColorTranslator.FromHtml("#F2EDE6");

            SetRoundRegion(loginback, 24);
            SetRoundRegion(btnLogin, 10);
            SetRoundRegion(btnRegister, 10);

            UpdateCaptcha();
        }

        private void UpdateCaptcha()
        {
            lblCaptcha.Text = _captchaService.Generate();
        }

        private void SetRoundRegion(Control control, int radius)
        {
            Rectangle bounds = new Rectangle(0, 0, control.Width, control.Height);
            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddArc(bounds.X, bounds.Y, radius, radius, 180, 90);
                path.AddArc(bounds.X + bounds.Width - radius, bounds.Y, radius, radius, 270, 90);
                path.AddArc(bounds.X + bounds.Width - radius, bounds.Y + bounds.Height - radius, radius, radius, 0, 90);
                path.AddArc(bounds.X, bounds.Y + bounds.Height - radius, radius, radius, 90, 90);
                path.CloseAllFigures();
                control.Region = new Region(path);
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtLogin.Text == "Введите логин" || string.IsNullOrWhiteSpace(txtLogin.Text) || txtPassword.Text == "Введите пароль" || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Пожалуйста, введите логин и пароль!");
                return;
            }

            if (txtCaptcha.Text == "Код" || string.IsNullOrWhiteSpace(txtCaptcha.Text))
            {
                MessageBox.Show("Пожалуйста, введите код с картинки!");
                return;
            }

            if (!_captchaService.Validate(txtCaptcha.Text))
            {
                MessageBox.Show("CAPTCHA введена неверно");
                UpdateCaptcha();
                return;
            }

            try
            {
                var user = _authService.Login(txtLogin.Text, txtPassword.Text);

                Session.CurrentUserId = user.Id;
                Session.CurrentUserName = user.FullName;
                Session.CurrentUserRole = user.RoleName;

                MessageBox.Show($"Добро пожаловать, {user.FullName}!");

                MainForm mainForm = new MainForm(user);
                mainForm.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

                UpdateCaptcha();
                txtCaptcha.Clear();
                txtCaptcha.Text = "Код";
                txtCaptcha.ForeColor = Color.Gray;
            }
        }

        private void btnRegister_MouseDown(object sender, MouseEventArgs e)
        {
            btnRegister.BackColor = Color.FromArgb(49, 71, 58);
            btnRegister.ForeColor = Color.FromArgb(253, 252, 250);
        }

        private void btnRegister_MouseUp(object sender, MouseEventArgs e)
        {
            btnRegister.BackColor = Color.FromArgb(253, 252, 250);
            btnRegister.ForeColor = Color.FromArgb(49, 71, 58);
        }

        private void RemovePlaceholder(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (tb.Text == "Введите логин" || tb.Text == "Введите пароль" || tb.Text == "Код")
            {
                tb.Text = "";
                tb.ForeColor = Color.Black;

                if (tb == txtPassword) tb.PasswordChar = '●';
            }
        }

        private void SetPlaceholder(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (string.IsNullOrWhiteSpace(tb.Text))
            {
                if (tb == txtLogin) tb.Text = "Введите логин";
                else if (tb == txtPassword)
                {
                    tb.PasswordChar = '\0';
                    tb.Text = "Введите пароль";
                }
                else if (tb == txtCaptcha) tb.Text = "Код";

                tb.ForeColor = Color.Gray;
            }
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            if (txtPassword.Text != "Введите пароль" && !string.IsNullOrEmpty(txtPassword.Text))
            {
                txtPassword.PasswordChar = '●';
            }
            else
            {
                txtPassword.PasswordChar = '\0';
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            RegisterForm regForm = new RegisterForm();

            regForm.ShowDialog();
        }

        private void btnUpdateCaptcha_Click(object sender, EventArgs e)
        {
            UpdateCaptcha();
        }

        private void lblClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        [System.Runtime.InteropServices.DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [System.Runtime.InteropServices.DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void panelTop_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}