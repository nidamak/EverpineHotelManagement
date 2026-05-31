using System;
using System.Windows.Forms;

namespace EverpineHotelManagement.Forms
{
    public partial class GuestForm : Form
    {
        public GuestForm()
        {
            InitializeComponent();
            ApplyPermissions();
            LoadGuests();
        }

        private void ApplyPermissions()
        {
            string role = Session.CurrentUserRole;
            bool canEditData = (role == "admin" || role == "operator");

            btnCreate.Enabled = canEditData;
            btnEdit.Enabled = canEditData;
            btnDelete.Enabled = canEditData;
        }

        private void LoadGuests()
        {
            var repo = new Data.GuestRepository();
            dgvGuests.DataSource = repo.GetAllGuests();

            if (dgvGuests.Columns["Id"] != null) dgvGuests.Columns["Id"].Visible = false;

            dgvGuests.Columns["FullName"].HeaderText = "ФИО";
            dgvGuests.Columns["Passport"].HeaderText = "Паспорт";
            dgvGuests.Columns["Phone"].HeaderText = "Телефон";
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            var editForm = new EditGuestForm();
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                LoadGuests();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvGuests.SelectedRows.Count > 0)
            {
                var guest = (Models.Guest)dgvGuests.SelectedRows[0].DataBoundItem;
                var editForm = new EditGuestForm(guest);
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    LoadGuests();
                }
            }
            else
            {
                MessageBox.Show("Выберите гостя для редактирования.");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvGuests.SelectedRows.Count > 0)
            {
                var confirm = MessageBox.Show("Удалить выбранного гостя?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirm == DialogResult.Yes)
                {
                    int id = Convert.ToInt32(dgvGuests.SelectedRows[0].Cells["Id"].Value);
                    var repo = new Data.GuestRepository();
                    repo.DeleteGuest(id);
                    LoadGuests();
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите строку для удаления.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}