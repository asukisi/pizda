using Npgsql;
using System.Data;
using System.Xml.Linq;

namespace Repair
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void ConnectButton_Click(object sender, EventArgs e)
        {

            string connectionString = "Host=localhost;Port=5432;Database=test;Username=postgres;Password=3232;";
            string query = "SELECT * FROM public.\"user\"";
            try
            {
                using (var connection = new NpgsqlConnection(connectionString))
                {
                    {
                        connection.Open();

                        // ���������� DataAdapter ��� ��������� ������
                        using (var adapter = new NpgsqlDataAdapter(query, connection))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable); // ��������� ������ � DataTable

                            // ����������� DataTable � DataGridView
                            dataGridView1.DataSource = dataTable;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"������ �����������: {ex.Message}");
            }
        }




        private void button3_Click_1(object sender, EventArgs e)
        {
            // ��������� ������ �� ��������� �����
            string newName = textBox1.Text;
            string newStatus = comboBox1.SelectedItem?.ToString();

            if (!int.TryParse(textBox2.Text, out int id))
            {
                MessageBox.Show("����������, ������� ���������� ID.");
                return;
            }

            if (string.IsNullOrWhiteSpace(newName))
            {
                MessageBox.Show("����������, ������� ����� ���.");
                return;
            }

            if (string.IsNullOrWhiteSpace(newStatus))
            {
                MessageBox.Show("����������, �������� ����� ������.");
                return;
            }

            // ������ �����������
            string connectionString = "Host=localhost;Port=5432;Database=test;Username=postgres;Password=3232;";

            // SQL-������ ��� ���������� ������
            string query = "UPDATE public.\"user\" SET name = @name, status = @status WHERE id = @id";

            try
            {
                using (var connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();

                    // ���������� NpgsqlCommand ��� ���������� �������
                    using (var command = new NpgsqlCommand(query, connection))
                    {
                        // ��������� ��������� ��� �������������� SQL-��������
                        command.Parameters.AddWithValue("@name", newName);
                        command.Parameters.AddWithValue("@status", newStatus);
                        command.Parameters.AddWithValue("@id", id);

                        // ��������� �������
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show($"������������ � ID {id} ������� ��������: ��� - {newName}, ������ - {newStatus}!");
                            textBox1.Clear();
                            textBox2.Clear();
                            comboBox1.SelectedIndex = -1; // ���������� ����� � ComboBox
                        }
                        else
                        {
                            MessageBox.Show($"������������ � ID {id} �� ������.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"������: {ex.Message}");
            }
        }


        private void button2_Click_1(object sender, EventArgs e)
        {
            string connectionString = "Host=localhost;Port=5432;Database=test;Username=postgres;Password=3232;";

            // SQL-������ ��� ��������
            string query = "DELETE FROM public.\"user\"";


            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();

                // ���������� NpgsqlCommand ��� ���������� �������
                using (var command = new NpgsqlCommand(query, connection))
                {
                    // ��������� ��������� ��� �������������� SQL-��������
                    command.ExecuteNonQuery();




                }
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            int id;
            if (!int.TryParse(textBox2.Text, out id))
            {
                MessageBox.Show("������� ���������� ID.");
                return;
            }

            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("����������, ������� ��� ������������.");
                return;
            }

            string status = comboBox1.SelectedItem?.ToString();
            if (string.IsNullOrWhiteSpace(status))
            {
                MessageBox.Show("����������, �������� ������.");
                return;
            }

            // �������� ������� �����
            DateTime currentTime = DateTime.Now;

            string connectionString = "Host=localhost;Port=5432;Database=test;Username=postgres;Password=3232;";

            // ����������� SQL-������
            string query = "INSERT INTO public.\"user\" (id, name, status, created_at) VALUES (@id, @name, @status, @created_at)";

            try
            {
                using (var connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();

                    using (var command = new NpgsqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);
                        command.Parameters.AddWithValue("@name", name);
                        command.Parameters.AddWithValue("@status", status);
                        command.Parameters.AddWithValue("@created_at", currentTime);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show($"������ ������� ���������! ID: {id}, ���: {name}, ������: {status}, �����: {currentTime}");
                            textBox1.Clear();
                            textBox2.Clear();
                            comboBox1.SelectedIndex = -1;
                        }
                        else
                        {
                            MessageBox.Show("�� ������� �������� ������.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"������: {ex.Message}");
            }
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            // ��������� ID �� ���������� ����
            if (!int.TryParse(textBox2.Text, out int id))
            {
                MessageBox.Show("������� ���������� ID.");
                return;
            }

            // ������ �����������
            string connectionString = "Host=localhost;Port=5432;Database=test;Username=postgres;Password=3232;";

            // SQL-������ ��� ������ ������������ �� ID
            string query = "SELECT * FROM public.\"user\" WHERE id = @id";

            try
            {
                using (var connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();

                    // ���������� DataAdapter ��� ��������� ������
                    using (var adapter = new NpgsqlDataAdapter(query, connection))
                    {
                        
                        adapter.SelectCommand.Parameters.AddWithValue("@id", id);

                        // ������� DataTable ��� �������� ����������
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        
                        if (dataTable.Rows.Count > 0)
                        {
                            // ����������� DataTable � DataGridView
                            dataGridView1.DataSource = dataTable;
                        }
                        else
                        {
                            MessageBox.Show("������������ � ����� ID �� ������.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"������: {ex.Message}");
            }
        }

        private void SearchByComboBox_Click(object sender, EventArgs e)
        {
            // ��������� ���������� �������� �� ComboBox
            string selectedStatus = comboBox1.SelectedItem?.ToString();

            if (string.IsNullOrWhiteSpace(selectedStatus))
            {
                MessageBox.Show("����������, �������� �������� �� ComboBox.");
                return;
            }

            // ������ �����������
            string connectionString = "Host=localhost;Port=5432;Database=test;Username=postgres;Password=3232;";

            // SQL-������ ��� ������ �� �������
            string query = "SELECT * FROM public.\"user\" WHERE status = @status";

            try
            {
                using (var connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();

                    // ���������� DataAdapter ��� ��������� ������
                    using (var adapter = new NpgsqlDataAdapter(query, connection))
                    {
                        // ��������� �������� status � ������
                        adapter.SelectCommand.Parameters.AddWithValue("@status", selectedStatus);

                        // ������� DataTable ��� �������� ����������
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        // ���������, ���� �� ���������
                        if (dataTable.Rows.Count > 0)
                        {
                            // ����������� DataTable � DataGridView
                            dataGridView1.DataSource = dataTable;
                        }
                        else
                        {
                            MessageBox.Show($"������������ �� �������� \"{selectedStatus}\" �� �������.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"������: {ex.Message}");
            }
        }

    }
}
