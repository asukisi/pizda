using Npgsql;
using System.Data;
using System;
using QRCoder;

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
            catch (Exception ex)
            {
                MessageBox.Show($"������ �����������: {ex.Message}");
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
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

            string connectionString = "Host=localhost;Port=5432;Database=test;Username=postgres;Password=3232;";
            string query = "UPDATE public.\"user\" SET name = @name, status = @status WHERE id = @id";

            try
            {
                using (var connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();

                    using (var command = new NpgsqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@name", newName);
                        command.Parameters.AddWithValue("@status", newStatus);
                        command.Parameters.AddWithValue("@id", id);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show($"������������ � ID {id} ������� ��������: ��� - {newName}, ������ - {newStatus}!");
                            textBox1.Clear();
                            textBox2.Clear();
                            comboBox1.SelectedIndex = -1;
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
            string query = "DELETE FROM public.\"user\"";

            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                using (var command = new NpgsqlCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            if (!int.TryParse(textBox2.Text, out int id))
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

            DateTime currentTime = DateTime.Now;
            string connectionString = "Host=localhost;Port=5432;Database=test;Username=postgres;Password=3232;";
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
            if (!int.TryParse(textBox2.Text, out int id))
            {
                MessageBox.Show("������� ���������� ID.");
                return;
            }

            string connectionString = "Host=localhost;Port=5432;Database=test;Username=postgres;Password=3232;";
            string query = "SELECT * FROM public.\"user\" WHERE id = @id";

            try
            {
                using (var connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();

                    using (var adapter = new NpgsqlDataAdapter(query, connection))
                    {
                        adapter.SelectCommand.Parameters.AddWithValue("@id", id);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        if (dataTable.Rows.Count > 0)
                        {
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
            string selectedStatus = comboBox1.SelectedItem?.ToString();

            if (string.IsNullOrWhiteSpace(selectedStatus))
            {
                MessageBox.Show("����������, �������� �������� �� ComboBox.");
                return;
            }

            string connectionString = "Host=localhost;Port=5432;Database=test;Username=postgres;Password=3232;";
            string query = "SELECT * FROM public.\"user\" WHERE status = @status";

            try
            {
                using (var connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();

                    using (var adapter = new NpgsqlDataAdapter(query, connection))
                    {
                        adapter.SelectCommand.Parameters.AddWithValue("@status", selectedStatus);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        if (dataTable.Rows.Count > 0)
                        {
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

        private void GetCompletedTasks_Click(object sender, EventArgs e)
        {
            string connectionString = "Host=localhost;Port=5432;Database=test;Username=postgres;Password=3232;";
            DateTime startDate = dateTimePickerStart.Value;
            DateTime endDate = dateTimePickerEnd.Value;

            string query = @"SELECT COUNT(*) AS completed_tasks
                             FROM public.task
                             WHERE completion_time BETWEEN @start_date AND @end_date 
                             AND status = 'completed'";

            try
            {
                using (var connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();

                    using (var command = new NpgsqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@start_date", startDate);
                        command.Parameters.AddWithValue("@end_date", endDate);

                        int completedTasks = Convert.ToInt32(command.ExecuteScalar());
                        MessageBox.Show($"���������� ����������� ����� �� ��������� ������: {completedTasks}");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"������: {ex.Message}");
            }
        }

        private void GetAverageCompletionTime_Click(object sender, EventArgs e)
        {
            string connectionString = "Host=localhost;Port=5432;Database=test;Username=postgres;Password=3232;";
            DateTime startDate = dateTimePickerStart.Value;
            DateTime endDate = dateTimePickerEnd.Value;

            string query = @"SELECT AVG(EXTRACT(EPOCH FROM (completion_time - start_time))) AS average_time_seconds
                             FROM public.task
                             WHERE completion_time BETWEEN @start_date AND @end_date
                             AND status = 'completed'";

            try
            {
                using (var connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();

                    using (var command = new NpgsqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@start_date", startDate);
                        command.Parameters.AddWithValue("@end_date", endDate);

                        object result = command.ExecuteScalar();
                        if (result != DBNull.Value)
                        {
                            double avgTimeSeconds = Convert.ToDouble(result);
                            TimeSpan averageTime = TimeSpan.FromSeconds(avgTimeSeconds);
                            MessageBox.Show($"������� ����� ���������� ������: {averageTime}");
                        }
                        else
                        {
                            MessageBox.Show("��� ������ ��� ������� �������� �������.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"������: {ex.Message}");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button4fd_Click(object sender, EventArgs e)
        {
            string url = "https://t.me/asukisi";


            using (QRCodeGenerator qrGenerator = new QRCodeGenerator())
            {
                QRCodeData qrCodeData = qrGenerator.CreateQrCode(url, QRCodeGenerator.ECCLevel.Q);
                QRCode qrCode = new QRCode(qrCodeData);


                Bitmap qrCodeImage = qrCode.GetGraphic(20);


                Bitmap resizedImage = new Bitmap(qrCodeImage, new Size(200, 200));


                pictureBox1.Image = resizedImage;
            }
        }

        private void buttonDownloadPdf_Click(object sender, EventArgs e)
        {

        }
    }
}
