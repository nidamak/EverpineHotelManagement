using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace EverpineHotelManagement.Forms
{
    public partial class RegisterForm : Form
    {
        private readonly Services.CaptchaService _captchaService = new Services.CaptchaService();

        public RegisterForm()
        {
            InitializeComponent();
                        
            SetRoundRegion(loginback, 24);

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

        private void RegisterForm_Load(object sender, EventArgs e)
        {
            SetupPlaceholders();
        }


        private void linklblLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form loginForm = Application.OpenForms["LoginForm"];

            if (loginForm != null)
            {
                loginForm.Show(); 
            }
            else
            {
                new LoginForm().Show(); 
            }

            this.Close();
        }

        private readonly Dictionary<TextBox, string> _placeholders = new Dictionary<TextBox, string>();

        private void SetupPlaceholders()
        {
            _placeholders[txtFullName] = "Введите ФИО";
            _placeholders[txtLogin] = "Введите логин";
            _placeholders[txtPassword] = "Придумайте пароль";
            _placeholders[txtRepeatPassword] = "Повторите пароль";
            _placeholders[txtCaptcha] = "Код";

            foreach (var item in _placeholders)
            {
                var tb = item.Key;

                if (tb == txtPassword || tb == txtRepeatPassword)
                {
                    tb.PasswordChar = '\0';
                }

                tb.Text = item.Value;
                tb.ForeColor = Color.Gray;

                tb.Enter += RemovePlaceholder;
                tb.Leave += SetPlaceholder;
            }
        }

        private void RemovePlaceholder(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (tb.Text == _placeholders[tb])
            {
                tb.Text = "";
                tb.ForeColor = Color.Black;

                if (tb == txtPassword || tb == txtRepeatPassword)
                    tb.PasswordChar = '●';
            }
        }

        private void SetPlaceholder(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (string.IsNullOrWhiteSpace(tb.Text))
            {
                if (tb == txtPassword || tb == txtRepeatPassword)
                    tb.PasswordChar = '\0';

                tb.Text = _placeholders[tb];
                tb.ForeColor = Color.Gray;
            }
        }

        private void btnUpdateCaptcha_Click(object sender, EventArgs e)
        {
            UpdateCaptcha();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtFullName.Text == "Введите ФИО" || txtLogin.Text == "Введите логин" ||
                txtPassword.Text == "Придумайте пароль" || txtRepeatPassword.Text == "Повторите пароль")
            {
                MessageBox.Show("Заполните все поля!");
                return;
            }

            if (txtCaptcha.Text == "Код" || string.IsNullOrWhiteSpace(txtCaptcha.Text))
            {
                MessageBox.Show("Пожалуйста, введите код с картинки!");
                return;
            }

            if (!_captchaService.Validate(txtCaptcha.Text))
            {
                MessageBox.Show("Неверный код капчи!");
                UpdateCaptcha(); 
                txtCaptcha.Clear(); 
                txtCaptcha.Text = "Код"; 
                txtCaptcha.ForeColor = Color.Gray;
                return;
            }

                if (!Regex.IsMatch(txtFullName.Text, @"^[а-яА-ЯёЁ\s]+$"))
            {
                MessageBox.Show("ФИО должно содержать только кириллицу.");
                return;
            }

            if (!Regex.IsMatch(txtLogin.Text, @"^[a-zA-Z0-9]{3,15}$"))
            {
                MessageBox.Show("Логин: только латиница и цифры (3-15 символов).");
                return;
            }

            if (!Regex.IsMatch(txtPassword.Text, @"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{6,}$"))
            {
                MessageBox.Show("Пароль: мин. 6 символов, должны быть буквы и цифры.");
                return;
            }

            if (txtPassword.Text != txtRepeatPassword.Text)
            {
                MessageBox.Show("Пароли не совпадают!");
                return;
            }

            try
            {
                var repo = new Data.UserRepository();

                if (repo.LoginExists(txtLogin.Text))
                {
                    MessageBox.Show("Пользователь с таким логином уже существует!");
                    return;
                }

                repo.CreateUser(txtLogin.Text, txtPassword.Text, txtFullName.Text, 3);

                MessageBox.Show("Регистрация успешна!");
                this.Close(); 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при регистрации: " + ex.Message);
            }
        }

        private void lblClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
