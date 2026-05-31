using System;
using System.Windows.Forms;

namespace EverpineHotelManagement.Forms
{
    public partial class EditBookingForm : Form
    {
        private Models.Booking _booking;

        public EditBookingForm(Models.Booking booking = null)
        {
            InitializeComponent();
            _booking = booking;

            cmbRoom.DataSource = new Data.RoomRepository().GetAvailableRooms();
            cmbRoom.DisplayMember = "RoomNumber";
            cmbRoom.ValueMember = "Id";

            cmbGuest.DataSource = new Data.GuestRepository().GetAllGuests();
            cmbGuest.DisplayMember = "FullName";
            cmbGuest.ValueMember = "Id";

            cmbStatus.Items.AddRange(new string[] { "Активно", "Завершено", "Отменено" });

            cmbRoom.SelectedIndexChanged += (s, e) => CalculatePrice();
            dtpCheckIn.ValueChanged += (s, e) => CalculatePrice();
            dtpCheckOut.ValueChanged += (s, e) => CalculatePrice();

            if (_booking != null)
            {
                cmbRoom.SelectedValue = _booking.RoomId;
                cmbGuest.SelectedValue = _booking.GuestId;
                dtpCheckIn.Value = DateTime.Parse(_booking.CheckInDate);
                dtpCheckOut.Value = DateTime.Parse(_booking.CheckOutDate);
                txtTotalPrice.Text = _booking.TotalPrice.ToString();
                cmbStatus.SelectedItem = _booking.Status;
            }
            else
            {
                cmbStatus.SelectedIndex = 0; 
                txtTotalPrice.ReadOnly = true; 
            }
        }

        private void CalculatePrice()
        {
            if (cmbRoom.SelectedItem is Models.Room selectedRoom)
            {
                int days = (dtpCheckOut.Value.Date - dtpCheckIn.Value.Date).Days;
                if (days < 1) days = 1; 
                double total = days * selectedRoom.Price;
                txtTotalPrice.Text = total.ToString("F2");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cmbRoom.SelectedValue == null) { MessageBox.Show("Выберите номер!"); return; }
            if (cmbGuest.SelectedValue == null) { MessageBox.Show("Выберите гостя!"); return; }
            if (dtpCheckOut.Value.Date <= dtpCheckIn.Value.Date) { MessageBox.Show("Дата выезда должна быть позже даты заезда."); return; }
            if (string.IsNullOrWhiteSpace(txtTotalPrice.Text)) { MessageBox.Show("Ошибка расчета цены!"); return; }

            try
            {
                var repo = new Data.BookingRepository();
                var roomRepo = new Data.RoomRepository();
                double price = double.Parse(txtTotalPrice.Text);

                if (_booking == null)
                {
                    repo.AddBooking(
                        (int)cmbRoom.SelectedValue,
                        (int)cmbGuest.SelectedValue,
                        Session.CurrentUserId, 
                        dtpCheckIn.Value.ToShortDateString(),
                        dtpCheckOut.Value.ToShortDateString(),
                        price,
                        cmbStatus.SelectedItem.ToString()
                    );

                    roomRepo.SetRoomAvailability((int)cmbRoom.SelectedValue, false);
                    MessageBox.Show("Бронирование успешно создано!");
                }
                else
                {
                    if (_booking.RoomId != (int)cmbRoom.SelectedValue)
                    {
                        roomRepo.SetRoomAvailability(_booking.RoomId, true);
                        roomRepo.SetRoomAvailability((int)cmbRoom.SelectedValue, false);
                    }

                    repo.UpdateBooking(
                        _booking.Id, (int)cmbRoom.SelectedValue, (int)cmbGuest.SelectedValue,
                        dtpCheckIn.Value.ToShortDateString(), dtpCheckOut.Value.ToShortDateString(),
                        price, cmbStatus.SelectedItem.ToString()
                    );
                    MessageBox.Show("Бронирование обновлено!");
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при сохранении: " + ex.Message);
            }
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