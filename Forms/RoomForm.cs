using System;
using System.Windows.Forms;

namespace EverpineHotelManagement.Forms
{
    public partial class RoomForm : Form
    {
        public RoomForm() 
        {
            InitializeComponent();
            ApplyPermissions();
            LoadRooms();
        }

        private void ApplyPermissions()
        {
            string role = Session.CurrentUserRole; 
            bool canEditData = (role == "admin" || role == "operator");

            btnCreate.Enabled = canEditData;
            btnEdit.Enabled = canEditData;
            btnDelete.Enabled = canEditData;
            dgvData.ReadOnly = !canEditData;
        }

        private void LoadRooms()
        {
            var repo = new Data.RoomRepository();
            dgvData.DataSource = repo.GetAvailableRooms();

            dgvData.Columns["RoomNumber"].HeaderText = "Номер";
            dgvData.Columns["Type"].HeaderText = "Тип";
            dgvData.Columns["Price"].HeaderText = "Цена";
            dgvData.Columns["IsAvailable"].HeaderText = "Свободен";
            dgvData.Columns["Id"].Visible = false; 
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvData.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dgvData.SelectedRows[0].Cells["Id"].Value);
                var repo = new Data.RoomRepository();
                repo.DeleteRoom(id);
                LoadRooms(); 
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            var editForm = new EditRoomForm();
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                LoadRooms(); 
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvData.SelectedRows.Count > 0)
            {
                var room = (Models.Room)dgvData.SelectedRows[0].DataBoundItem;
                var editForm = new EditRoomForm(room);
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    LoadRooms(); 
                }
            }
        }
    }
}
