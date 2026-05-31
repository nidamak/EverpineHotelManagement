using System;
using System.Windows.Forms;

namespace EverpineHotelManagement.Forms
{
    public partial class BookingForm : Form
    {
        public BookingForm()
        {
            InitializeComponent();
            ApplyPermissions();
            LoadBookings();
        }

        private void ApplyPermissions()
        {
            string role = Session.CurrentUserRole;
            bool canEditData = (role == "admin" || role == "operator");

            btnCreate.Enabled = canEditData;
            btnEdit.Enabled = canEditData;
            btnDelete.Enabled = canEditData;
        }

        private void LoadBookings()
        {
            var repo = new Data.BookingRepository();
            dgvBookings.DataSource = repo.GetAllBookings();

            if (dgvBookings.Columns["Id"] != null) dgvBookings.Columns["Id"].Visible = false;
            if (dgvBookings.Columns["RoomId"] != null) dgvBookings.Columns["RoomId"].Visible = false;
            if (dgvBookings.Columns["GuestId"] != null) dgvBookings.Columns["GuestId"].Visible = false;
            if (dgvBookings.Columns["UserId"] != null) dgvBookings.Columns["UserId"].Visible = false;

            dgvBookings.Columns["RoomNumber"].HeaderText = "Номер";
            dgvBookings.Columns["GuestFullName"].HeaderText = "Гость";
            dgvBookings.Columns["UserFullName"].HeaderText = "Сотрудник";
            dgvBookings.Columns["CheckInDate"].HeaderText = "Заезд";
            dgvBookings.Columns["CheckOutDate"].HeaderText = "Выезд";
            dgvBookings.Columns["TotalPrice"].HeaderText = "Итого";
            dgvBookings.Columns["Status"].HeaderText = "Статус";
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            var editForm = new EditBookingForm();
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                LoadBookings();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvBookings.SelectedRows.Count > 0)
            {
                var booking = (Models.Booking)dgvBookings.SelectedRows[0].DataBoundItem;
                var editForm = new EditBookingForm(booking);
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    LoadBookings();
                }
            }
            else
            {
                MessageBox.Show("Выберите бронирование для редактирования.");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvBookings.SelectedRows.Count > 0)
            {
                var confirm = MessageBox.Show("Удалить выбранное бронирование?", "Удаление", MessageBoxButtons.YesNo);
                if (confirm == DialogResult.Yes)
                {
                    var booking = (Models.Booking)dgvBookings.SelectedRows[0].DataBoundItem;

                    var repo = new Data.BookingRepository();
                    var roomRepo = new Data.RoomRepository();

                    repo.DeleteBooking(booking.Id);

                    roomRepo.SetRoomAvailability(booking.RoomId, true);

                    LoadBookings();
                }
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}