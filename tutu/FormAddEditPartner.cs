using System;
using System.Drawing;
using System.Windows.Forms;
using Npgsql;

namespace tutu
{
    public partial class FormAddEditPartner : Form
    {
        private string connectionString = "Host=195.46.187.72;Username=postgres;Password=1337;Database=ConstructionMaterialsDB";
        private string partnerName; // Для хранения имени партнера при редактировании

        public FormAddEditPartner(string partnerName = null)
        {
            InitializeComponent();
            this.partnerName = partnerName;

            // Устанавливаем подсказки
            SetPlaceholder(textBoxName, "Наименование партнера");
            SetPlaceholder(comboBoxType, "Тип партнера");
            SetPlaceholder(textBoxDirector, "ФИО директора");
            SetPlaceholder(textBoxPhone, "Телефон");
            SetPlaceholder(textBoxEmail, "Email");
            SetPlaceholder(textBoxAddress, "Юридический адрес");
            SetPlaceholder(textBoxINN, "ИНН");

            if (partnerName != null)
            {
                // Режим редактирования: загружаем данные партнера
                LoadPartnerData();
            }
        }

        private void LoadPartnerData()
        {
            try
            {
                using (var conn = new NpgsqlConnection(connectionString))
                {
                    conn.Open();
                    var query = @"SELECT * FROM public.""Партнеры"" WHERE ""Наименование партнера"" = @name;";
                    var cmd = new NpgsqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("name", partnerName);
                    var reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        textBoxName.Text = reader["Наименование партнера"].ToString();
                        comboBoxType.Text = reader["Тип партнера"].ToString();
                        textBoxDirector.Text = reader["Директор"].ToString();
                        textBoxPhone.Text = reader["Телефон партнера"].ToString();
                        textBoxEmail.Text = reader["Электронная почта партнера"].ToString();
                        textBoxAddress.Text = reader["Юридический адрес партнера"].ToString();
                        textBoxINN.Text = reader["ИНН"].ToString();
                        numericUpDownRating.Value = Convert.ToInt32(reader["Рейтинг"]);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке данных: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Проверка ввода данных
                if (string.IsNullOrEmpty(textBoxName.Text) || string.IsNullOrEmpty(comboBoxType.Text))
                {
                    Logger.Log("Попытка сохранения партнера с пустыми обязательными полями.");
                    MessageBox.Show("Поля 'Наименование' и 'Тип партнера' обязательны для заполнения.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (var conn = new NpgsqlConnection(connectionString))
                {
                    conn.Open();
                    var query = partnerName == null ?
                        @"INSERT INTO public.""Партнеры"" 
                (""Наименование партнера"", ""Тип партнера"", ""Директор"", ""Телефон партнера"", ""Электронная почта партнера"", ""Юридический адрес партнера"", ""ИНН"", ""Рейтинг"")
                VALUES (@name, @type, @director, @phone, @email, @address, @inn, @rating);" :
                        @"UPDATE public.""Партнеры"" 
                SET ""Наименование партнера"" = @newName, 
                    ""Тип партнера"" = @type, 
                    ""Директор"" = @director, 
                    ""Телефон партнера"" = @phone, 
                    ""Электронная почта партнера"" = @email, 
                    ""Юридический адрес партнера"" = @address, 
                    ""ИНН"" = @inn, 
                    ""Рейтинг"" = @rating
                WHERE ""Наименование партнера"" = @oldName;";

                    var cmd = new NpgsqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("newName", textBoxName.Text); // Новое наименование
                    cmd.Parameters.AddWithValue("type", comboBoxType.Text);
                    cmd.Parameters.AddWithValue("director", textBoxDirector.Text);
                    cmd.Parameters.AddWithValue("phone", textBoxPhone.Text);
                    cmd.Parameters.AddWithValue("email", textBoxEmail.Text);
                    cmd.Parameters.AddWithValue("address", textBoxAddress.Text);
                    cmd.Parameters.AddWithValue("inn", textBoxINN.Text);
                    cmd.Parameters.AddWithValue("rating", (int)numericUpDownRating.Value);

                    if (partnerName != null)
                    {
                        // Если редактируем существующего партнера, передаем старое наименование
                        cmd.Parameters.AddWithValue("oldName", partnerName);
                        Logger.Log($"Партнер {partnerName} отредактирован. Новые данные: {textBoxName.Text}, {comboBoxType.Text}, {textBoxDirector.Text}, и т.д.");
                    }
                    else
                    {
                        // Если добавляем нового партнера, передаем новое наименование
                        cmd.Parameters.AddWithValue("name", textBoxName.Text);
                        Logger.Log($"Добавлен новый партнер: {textBoxName.Text}, {comboBoxType.Text}, {textBoxDirector.Text}, и т.д.");
                    }

                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Данные успешно сохранены.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                Logger.Log($"Ошибка при сохранении данных партнера: {ex.Message}");
                MessageBox.Show("Ошибка при сохранении данных: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SetPlaceholder(TextBox textBox, string placeholder)
        {
            textBox.Text = placeholder;
            textBox.ForeColor = SystemColors.GrayText;

            textBox.GotFocus += (source, e) =>
            {
                if (textBox.Text == placeholder)
                {
                    textBox.Text = "";
                    textBox.ForeColor = SystemColors.WindowText;
                }
            };

            textBox.LostFocus += (source, e) =>
            {
                if (string.IsNullOrWhiteSpace(textBox.Text))
                {
                    textBox.Text = placeholder;
                    textBox.ForeColor = SystemColors.GrayText;
                }
            };
        }

        private void SetPlaceholder(ComboBox comboBox, string placeholder)
        {
            comboBox.Text = placeholder;
            comboBox.ForeColor = SystemColors.GrayText;

            comboBox.GotFocus += (source, e) =>
            {
                if (comboBox.Text == placeholder)
                {
                    comboBox.Text = "";
                    comboBox.ForeColor = SystemColors.WindowText;
                }
            };

            comboBox.LostFocus += (source, e) =>
            {
                if (string.IsNullOrWhiteSpace(comboBox.Text))
                {
                    comboBox.Text = placeholder;
                    comboBox.ForeColor = SystemColors.GrayText;
                }
            };
        }
    }
}