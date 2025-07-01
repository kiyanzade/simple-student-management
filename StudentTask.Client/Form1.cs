using System.Net.Http.Json;

namespace StudentTask.Client
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async Task GetAllStudent()
        {
            try
            {
                var students = await _http.GetFromJsonAsync<List<StudentModel>>("api/student");
                dataGridView1.DataSource = students;
            }
            catch (Exception e)
            {
                MessageBox.Show("error loading data: " + e.Message);
            }
        }
        private async void btnLoad_Click(object sender, EventArgs e)
        {
            await GetAllStudent();
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            using var form = new StudentEditForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                var response = await _http.PostAsJsonAsync("api/student/add", form.Student);
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Student added!");
                    await GetAllStudent();
                }
                else
                {
                    MessageBox.Show("Error: " + await response.Content.ReadAsStringAsync());
                }
            }
        }

        private async void btnEdit_Click(object sender, EventArgs e)
        {

            var selected = dataGridView1.CurrentRow?.DataBoundItem as StudentModel;

            if (selected == null)
            {
                MessageBox.Show("Please select a student!", "Error!",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // preload data
            using var form = new StudentEditForm();
            form.txtFullName.Text = selected.FullName;
            form.txtNationalCode.Text = selected.NationalCode;
            form.dateTimePicker1.Value = selected.BirthDate.ToDateTime(TimeOnly.MinValue);

            if (form.ShowDialog() == DialogResult.OK && form.Student != null)
            {
                var response = await _http.PutAsJsonAsync(
$"api/Student/edit/{selected.Id}", form.Student);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Student updated!");
                    await GetAllStudent();
                }
                else
                {
                    MessageBox.Show("Error: " + await response.Content.ReadAsStringAsync());
                }
            }


        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            var selected = dataGridView1.CurrentRow?.DataBoundItem as StudentModel;

            if (selected == null)
            {
                MessageBox.Show("Please select a student!", "Error!",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var response = await _http.DeleteAsync($"api/Student/delete/{selected.Id}");
            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Student deleted!");
                await GetAllStudent();
            }
            else
            {
                MessageBox.Show("Error: " + await response.Content.ReadAsStringAsync());
            }
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
