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

                        // Используем DataAdapter для получения данных
                        using (var adapter = new NpgsqlDataAdapter(query, connection))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable); // Загружаем данные в DataTable

                            // Привязываем DataTable к DataGridView
                            dataGridView1.DataSource = dataTable;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка подключения: {ex.Message}");
            }
        }




        private void button3_Click_1(object sender, EventArgs e)
        {
            // Получение данных из текстовых полей
            string newName = textBox1.Text;
            string newStatus = comboBox1.SelectedItem?.ToString();

            if (!int.TryParse(textBox2.Text, out int id))
            {
                MessageBox.Show("Пожалуйста, введите корректный ID.");
                return;
            }

            if (string.IsNullOrWhiteSpace(newName))
            {
                MessageBox.Show("Пожалуйста, введите новое имя.");
                return;
            }

            if (string.IsNullOrWhiteSpace(newStatus))
            {
                MessageBox.Show("Пожалуйста, выберите новый статус.");
                return;
            }

            // Строка подключения
            string connectionString = "Host=localhost;Port=5432;Database=test;Username=postgres;Password=3232;";

            // SQL-запрос для обновления данных
            string query = "UPDATE public.\"user\" SET name = @name, status = @status WHERE id = @id";

            try
            {
                using (var connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();

                    // Используем NpgsqlCommand для выполнения запроса
                    using (var command = new NpgsqlCommand(query, connection))
                    {
                        // Добавляем параметры для предотвращения SQL-инъекций
                        command.Parameters.AddWithValue("@name", newName);
                        command.Parameters.AddWithValue("@status", newStatus);
                        command.Parameters.AddWithValue("@id", id);

                        // Выполняем команду
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show($"Пользователь с ID {id} успешно обновлен: Имя - {newName}, Статус - {newStatus}!");
                            textBox1.Clear();
                            textBox2.Clear();
                            comboBox1.SelectedIndex = -1; // Сбрасываем выбор в ComboBox
                        }
                        else
                        {
                            MessageBox.Show($"Пользователь с ID {id} не найден.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }


        private void button2_Click_1(object sender, EventArgs e)
        {
            string connectionString = "Host=localhost;Port=5432;Database=test;Username=postgres;Password=3232;";

            // SQL-запрос для удаления
            string query = "DELETE FROM public.\"user\"";


            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();

                // Используем NpgsqlCommand для выполнения запроса
                using (var command = new NpgsqlCommand(query, connection))
                {
                    // Добавляем параметры для предотвращения SQL-инъекций
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
                MessageBox.Show("Введите корректный ID.");
                return;
            }

            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Пожалуйста, введите имя пользователя.");
                return;
            }

            string status = comboBox1.SelectedItem?.ToString();
            if (string.IsNullOrWhiteSpace(status))
            {
                MessageBox.Show("Пожалуйста, выберите статус.");
                return;
            }

            // Получаем текущее время
            DateTime currentTime = DateTime.Now;

            string connectionString = "Host=localhost;Port=5432;Database=test;Username=postgres;Password=3232;";

            // Обновленный SQL-запрос
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
                            MessageBox.Show($"Данные успешно добавлены! ID: {id}, Имя: {name}, Статус: {status}, Время: {currentTime}");
                            textBox1.Clear();
                            textBox2.Clear();
                            comboBox1.SelectedIndex = -1;
                        }
                        else
                        {
                            MessageBox.Show("Не удалось добавить данные.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Получение ID из текстового поля
            if (!int.TryParse(textBox2.Text, out int id))
            {
                MessageBox.Show("Введите корректный ID.");
                return;
            }

            // Строка подключения
            string connectionString = "Host=localhost;Port=5432;Database=test;Username=postgres;Password=3232;";

            // SQL-запрос для поиска пользователя по ID
            string query = "SELECT * FROM public.\"user\" WHERE id = @id";

            try
            {
                using (var connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();

                    // Используем DataAdapter для получения данных
                    using (var adapter = new NpgsqlDataAdapter(query, connection))
                    {
                        
                        adapter.SelectCommand.Parameters.AddWithValue("@id", id);

                        // Создаем DataTable для хранения результата
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        
                        if (dataTable.Rows.Count > 0)
                        {
                            // Привязываем DataTable к DataGridView
                            dataGridView1.DataSource = dataTable;
                        }
                        else
                        {
                            MessageBox.Show("Пользователь с таким ID не найден.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }

        private void SearchByComboBox_Click(object sender, EventArgs e)
        {
            // Получение выбранного значения из ComboBox
            string selectedStatus = comboBox1.SelectedItem?.ToString();

            if (string.IsNullOrWhiteSpace(selectedStatus))
            {
                MessageBox.Show("Пожалуйста, выберите значение из ComboBox.");
                return;
            }

            // Строка подключения
            string connectionString = "Host=localhost;Port=5432;Database=test;Username=postgres;Password=3232;";

            // SQL-запрос для поиска по статусу
            string query = "SELECT * FROM public.\"user\" WHERE status = @status";

            try
            {
                using (var connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();

                    // Используем DataAdapter для получения данных
                    using (var adapter = new NpgsqlDataAdapter(query, connection))
                    {
                        // Добавляем параметр status в запрос
                        adapter.SelectCommand.Parameters.AddWithValue("@status", selectedStatus);

                        // Создаем DataTable для хранения результата
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        // Проверяем, есть ли результат
                        if (dataTable.Rows.Count > 0)
                        {
                            // Привязываем DataTable к DataGridView
                            dataGridView1.DataSource = dataTable;
                        }
                        else
                        {
                            MessageBox.Show($"Пользователи со статусом \"{selectedStatus}\" не найдены.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }

    }
}
