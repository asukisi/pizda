namespace Repair
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dataGridView1 = new DataGridView();
            ConnectButton = new Button();
            npgsqlDataAdapter1 = new Npgsql.NpgsqlDataAdapter();
            button1 = new Button();
            textBox1 = new TextBox();
            label1 = new Label();
            textBox2 = new TextBox();
            label2 = new Label();
            button2 = new Button();
            button3 = new Button();
            comboBox1 = new ComboBox();
            label3 = new Label();
            textBox3 = new TextBox();
            label4 = new Label();
            SearchButton = new Button();
            SearchByComboBox = new Button();
            label5 = new Label();
            dateTimePickerStart = new DateTimePicker();
            dateTimePickerEnd = new DateTimePicker();
            pictureBox1 = new PictureBox();
            button4fd = new Button();
            buttonDownloadPdf = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 12);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(450, 150);
            dataGridView1.TabIndex = 0;
            // 
            // ConnectButton
            // 
            ConnectButton.Location = new Point(12, 168);
            ConnectButton.Name = "ConnectButton";
            ConnectButton.Size = new Size(104, 23);
            ConnectButton.TabIndex = 1;
            ConnectButton.Text = "Отобразить";
            ConnectButton.UseVisualStyleBackColor = true;
            ConnectButton.Click += ConnectButton_Click;
            // 
            // npgsqlDataAdapter1
            // 
            npgsqlDataAdapter1.DeleteCommand = null;
            npgsqlDataAdapter1.InsertCommand = null;
            npgsqlDataAdapter1.SelectCommand = null;
            npgsqlDataAdapter1.UpdateCommand = null;
            // 
            // button1
            // 
            button1.Location = new Point(611, 150);
            button1.Name = "button1";
            button1.Size = new Size(104, 23);
            button1.TabIndex = 2;
            button1.Text = "Добавить";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click_1;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(611, 13);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(121, 23);
            textBox1.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(545, 12);
            label1.Name = "label1";
            label1.Size = new Size(29, 15);
            label1.TabIndex = 4;
            label1.Text = "имя";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(611, 43);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(121, 23);
            textBox2.TabIndex = 5;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(545, 46);
            label2.Name = "label2";
            label2.Size = new Size(17, 15);
            label2.TabIndex = 6;
            label2.Text = "id";
            // 
            // button2
            // 
            button2.Location = new Point(611, 208);
            button2.Name = "button2";
            button2.Size = new Size(104, 23);
            button2.TabIndex = 7;
            button2.Text = "Удалить все";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click_1;
            // 
            // button3
            // 
            button3.Location = new Point(611, 179);
            button3.Name = "button3";
            button3.Size = new Size(104, 23);
            button3.TabIndex = 8;
            button3.Text = "Заменить";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click_1;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "в ожидании", "в работе ", "выполнено" });
            comboBox1.Location = new Point(611, 82);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(121, 23);
            comboBox1.TabIndex = 9;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(545, 82);
            label3.Name = "label3";
            label3.Size = new Size(41, 15);
            label3.TabIndex = 10;
            label3.Text = "статус";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(611, 121);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(121, 23);
            textBox3.TabIndex = 11;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(545, 121);
            label4.Name = "label4";
            label4.Size = new Size(60, 15);
            label4.TabIndex = 12;
            label4.Text = "описание";
            // 
            // SearchButton
            // 
            SearchButton.Location = new Point(12, 197);
            SearchButton.Name = "SearchButton";
            SearchButton.Size = new Size(104, 23);
            SearchButton.TabIndex = 13;
            SearchButton.Text = "Поиск по айди";
            SearchButton.UseVisualStyleBackColor = true;
            SearchButton.Click += button4_Click;
            // 
            // SearchByComboBox
            // 
            SearchByComboBox.Location = new Point(12, 226);
            SearchByComboBox.Name = "SearchByComboBox";
            SearchByComboBox.Size = new Size(104, 39);
            SearchByComboBox.TabIndex = 14;
            SearchByComboBox.Text = "Поиск по комбобокс";
            SearchByComboBox.UseVisualStyleBackColor = true;
            SearchByComboBox.Click += SearchByComboBox_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 550);
            label5.Name = "label5";
            label5.Size = new Size(128, 15);
            label5.TabIndex = 15;
            label5.Text = "ООО \"Проект сервис\"";
            // 
            // dateTimePickerStart
            // 
            dateTimePickerStart.Location = new Point(253, 537);
            dateTimePickerStart.Name = "dateTimePickerStart";
            dateTimePickerStart.Size = new Size(200, 23);
            dateTimePickerStart.TabIndex = 16;
            // 
            // dateTimePickerEnd
            // 
            dateTimePickerEnd.Location = new Point(481, 537);
            dateTimePickerEnd.Name = "dateTimePickerEnd";
            dateTimePickerEnd.Size = new Size(200, 23);
            dateTimePickerEnd.TabIndex = 17;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(520, 288);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(268, 200);
            pictureBox1.TabIndex = 18;
            pictureBox1.TabStop = false;
            // 
            // button4fd
            // 
            button4fd.Location = new Point(12, 271);
            button4fd.Name = "button4fd";
            button4fd.Size = new Size(104, 23);
            button4fd.TabIndex = 19;
            button4fd.Text = "показать qr code";
            button4fd.UseVisualStyleBackColor = true;
            button4fd.Click += button4fd_Click;
            // 
            // buttonDownloadPdf
            // 
            buttonDownloadPdf.Location = new Point(12, 329);
            buttonDownloadPdf.Name = "buttonDownloadPdf";
            buttonDownloadPdf.Size = new Size(104, 23);
            buttonDownloadPdf.TabIndex = 20;
            buttonDownloadPdf.Text = "скачать pdf";
            buttonDownloadPdf.UseVisualStyleBackColor = true;
            buttonDownloadPdf.Click += buttonDownloadPdf_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 572);
            Controls.Add(buttonDownloadPdf);
            Controls.Add(button4fd);
            Controls.Add(pictureBox1);
            Controls.Add(dateTimePickerEnd);
            Controls.Add(dateTimePickerStart);
            Controls.Add(label5);
            Controls.Add(SearchByComboBox);
            Controls.Add(SearchButton);
            Controls.Add(label4);
            Controls.Add(textBox3);
            Controls.Add(label3);
            Controls.Add(comboBox1);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(label2);
            Controls.Add(textBox2);
            Controls.Add(label1);
            Controls.Add(textBox1);
            Controls.Add(button1);
            Controls.Add(ConnectButton);
            Controls.Add(dataGridView1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Button ConnectButton;
        private Npgsql.NpgsqlDataAdapter npgsqlDataAdapter1;
        private Button button1;
        private TextBox textBox1;
        private Label label1;
        private TextBox textBox2;
        private Label label2;
        private Button button2;
        private Button button3;
        private ComboBox comboBox1;
        private Label label3;
        private TextBox textBox3;
        private Label label4;
        private Button SearchButton;
        private Button SearchByComboBox;
        private Label label5;
        private DateTimePicker dateTimePickerStart;
        private DateTimePicker dateTimePickerEnd;
        private PictureBox pictureBox1;
        private Button button4fd;
        private Button buttonDownloadPdf;
    }
}
