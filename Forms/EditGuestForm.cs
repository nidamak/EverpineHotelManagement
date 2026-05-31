using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace EverpineHotelManagement.Forms
{
    public partial class EditGuestForm : Form
    {
        private Models.Guest _guest;

        public EditGuestForm(Models.Guest guest = null)
        {
            InitializeComponent();

            _guest = guest;
            if (_guest != null)
            {
                txtFullName.Text = _guest.FullName;
                txtPassport.Text = _guest.Passport;
                txtPhone.Text = _guest.Phone;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFullName.Text) ||
                string.IsNullOrWhiteSpace(txtPassport.Text) ||
                string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                MessageBox.Show("Заполните все поля!");
                return;
            }

            if (!Regex.IsMatch(txtFullName.Text, @"^[а-яА-ЯёЁa-zA-Z\s]+$"))
            {
                MessageBox.Show("ФИО может содержать только буквы.");
                return;
            }

            if (!Regex.IsMatch(txtPassport.Text, @"^\d{10}$"))
            {
                MessageBox.Show("Паспорт должен состоять ровно из 10 цифр.");
                return;
            }

            string rawPhone = txtPhone.Text.Trim();
            string normalizedPhone = "";

            if (Regex.IsMatch(rawPhone, @"^8\d{10}$"))
            {
                normalizedPhone = "+7" + rawPhone.Substring(1);
            }
            else if (Regex.IsMatch(rawPhone, @"^\+7\d{10}$"))
            {
                normalizedPhone = rawPhone;
            }
            else if (Regex.IsMatch(rawPhone, @"^\d{10}$"))
            {
                normalizedPhone = "+7" + rawPhone;
            }
            else
            {
                MessageBox.Show("Некорректный формат телефона. Введите номер, начиная с 8, +7 или 10 цифр.");
                return;
            }

            var repo = new Data.GuestRepository();
            if (_guest == null)
                repo.AddGuest(txtFullName.Text, txtPassport.Text, normalizedPhone);
            else
                repo.UpdateGuest(_guest.Id, txtFullName.Text, txtPassport.Text, normalizedPhone);

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void lblClose_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Вы уверены, что хотите отменить изменения?",
                                   "Отмена", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }

    }
}