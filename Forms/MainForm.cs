using System;
using System.Drawing;
using System.Windows.Forms;

namespace EverpineHotelManagement.Forms
{
    public partial class MainForm : Form
    {
        private Models.User _currentUser;
        public MainForm(Models.User user)
        {
            InitializeComponent();

            _currentUser = user;

            Session.CurrentUserId = user.Id;
            Session.CurrentUserName = user.FullName;

            lblUserInfo.Text = $"{user.FullName}\n({user.RoleName})";

            lblUserInfo.Font = new Font("Segoe UI", 8, FontStyle.Regular);
            lblUserInfo.ForeColor = Color.Black;
        }

        private void MainForm_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show("Вы уверены, что хотите выйти из системы?", "Выход", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                Session.CurrentUserId = 0;
                Session.CurrentUserName = null;

                new LoginForm().Show();
                this.Dispose();
            }
        }

        private void btnRoom_Click(object sender, EventArgs e)
        {
            new RoomForm().ShowDialog();
        }

        private void btnGuest_Click(object sender, EventArgs e)
        {
            new GuestForm().Show();
        }

        private void btnBooking_Click(object sender, EventArgs e)
        {
            new BookingForm().Show();
        }
    }
}