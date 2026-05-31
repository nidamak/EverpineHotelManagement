using System;
using System.Windows.Forms;

namespace EverpineHotelManagement.Forms
{
    public partial class EditRoomForm : Form
    {
        private Models.Room _room;

        public EditRoomForm(Models.Room room = null)
        {
            InitializeComponent();
            cmbType.Items.AddRange(new string[] { "Стандарт", "Люкс", "Семейный" });

            _room = room;
            if (_room != null)
            {
                txtNumber.Text = _room.RoomNumber;
                cmbType.SelectedItem = _room.Type;
                txtPrice.Text = _room.Price.ToString();
                chkAvailable.Checked = _room.IsAvailable;
            }
            else
            {
                cmbType.SelectedIndex = 0;
                UpdatePriceByType(cmbType.SelectedItem.ToString());
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNumber.Text) || string.IsNullOrWhiteSpace(txtPrice.Text))
            {
                MessageBox.Show("Пожалуйста, заполните номер и цену.");
                return;
            }

            if (!double.TryParse(txtPrice.Text, out double price))
            {
                MessageBox.Show("Цена должна быть числом.");
                return;
            }

            var repo = new Data.RoomRepository();

            if (_room == null)
                repo.AddRoom(txtNumber.Text, cmbType.Text, price, chkAvailable.Checked);
            else
                repo.UpdateRoom(_room.Id, txtNumber.Text, cmbType.Text, price, chkAvailable.Checked);

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void UpdatePriceByType(string type)
        {
            switch (type)
            {
                case "Стандарт": txtPrice.Text = "2000"; break;
                case "Люкс": txtPrice.Text = "5000"; break;
                case "Семейный": txtPrice.Text = "3500"; break;
                default: txtPrice.Text = "0"; break;
            }
        }

        private void cmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbType.SelectedItem != null)
            {
                UpdatePriceByType(cmbType.SelectedItem.ToString());
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