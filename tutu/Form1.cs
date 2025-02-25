using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Npgsql;

namespace tutu
{
    public partial class Form1 : Form
    {
        private string connectionString = "Host=195.46.187.72;Username=postgres;Password=1337;Database=ConstructionMaterialsDB";

        public Form1()
        {
            InitializeComponent();
            LoadPartners();
            StyleForm();
        }

        private void LoadPartners()
        {
            try
            {
                using (var conn = new NpgsqlConnection(connectionString))
                {
                    conn.Open();
                    var query = @"
                SELECT 
                    p.""Наименование партнера"", 
                    p.""Тип партнера"", 
                    p.""Директор"", 
                    p.""Телефон партнера"", 
                    p.""Рейтинг"", 
                    COALESCE(SUM(s.""Количество продукции""), 0) AS TotalSales
                FROM ""Партнеры"" p
                LEFT JOIN ""Продажи"" s ON p.""Наименование партнера"" = s.""Наименование партнера""
                GROUP BY p.""Наименование партнера""
                ORDER BY p.""Наименование партнера""";

                    var cmd = new NpgsqlCommand(query, conn);
                    var reader = cmd.ExecuteReader();

                    flowLayoutPanelPartners.Controls.Clear();

                    while (reader.Read())
                    {
                        string partnerName = reader["Наименование партнера"].ToString();
                        string partnerType = reader["Тип партнера"].ToString();
                        string director = reader["Директор"].ToString();
                        string phone = reader["Телефон партнера"].ToString();
                        int rating = Convert.ToInt32(reader["Рейтинг"]);
                        int totalSales = Convert.ToInt32(reader["TotalSales"]);
                        string discount = CalculateDiscount(totalSales);

                        Panel partnerCard = CreatePartnerCard(partnerType, partnerName, discount, director, phone, rating, partnerName);
                        flowLayoutPanelPartners.Controls.Add(partnerCard);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке данных: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Panel CreatePartnerCard(string type, string name, string discount, string director, string phone, int rating, string partnerName)
        {
            // Создаем панель для карточки
            Panel card = new Panel
            {
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                Width = 700,
                Height = 120,
                Margin = new Padding(10),
                Padding = new Padding(10),
                Tag = partnerName // Сохраняем имя партнера для удаления
            };

            // Заголовок карточки (Тип | Наименование партнера Скидка)
            Label header = new Label
            {
                Text = $"{type} | {name} {discount}",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                ForeColor = Color.FromArgb(51, 51, 76),
                AutoSize = true,
                Location = new Point(10, 10)
            };

            // Директор
            Label directorLabel = new Label
            {
                Text = director,
                Font = new Font("Segoe UI", 10),
                ForeColor = Color.Black,
                AutoSize = true,
                Location = new Point(10, 40)
            };

            // Телефон
            Label phoneLabel = new Label
            {
                Text = phone,
                Font = new Font("Segoe UI", 10),
                ForeColor = Color.Black,
                AutoSize = true,
                Location = new Point(10, 60)
            };

            // Рейтинг
            Label ratingLabel = new Label
            {
                Text = $"Рейтинг: {rating}",
                Font = new Font("Segoe UI", 10),
                ForeColor = Color.Black,
                AutoSize = true,
                Location = new Point(10, 80)
            };

            // Кнопка удаления
            Button deleteButton = new Button
            {
                Text = "Удалить",
                BackColor = Color.FromArgb(51, 51, 76),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10),
                Width = 80,
                Height = 30,
                Location = new Point(600, 40),
                Tag = partnerName // Сохраняем имя партнера для удаления
            };
            deleteButton.Click += DeleteButton_Click;

            // Добавляем элементы на карточку
            card.Controls.Add(header);
            card.Controls.Add(directorLabel);
            card.Controls.Add(phoneLabel);
            card.Controls.Add(ratingLabel);
            card.Controls.Add(deleteButton);

            // Привязываем событие Click к карточке
            card.Click += PartnerCard_Click;

            return card;
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            Button deleteButton = (Button)sender;
            string partnerName = deleteButton.Tag.ToString();

            var confirmResult = MessageBox.Show("Вы уверены, что хотите удалить этого партнера?", "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirmResult == DialogResult.Yes)
            {
                try
                {
                    using (var conn = new NpgsqlConnection(connectionString))
                    {
                        conn.Open();
                        var checkQuery = @"SELECT COUNT(*) FROM ""Продажи"" WHERE ""Наименование партнера"" = @name";
                        var checkCmd = new NpgsqlCommand(checkQuery, conn);
                        checkCmd.Parameters.AddWithValue("name", partnerName);
                        int salesCount = Convert.ToInt32(checkCmd.ExecuteScalar());

                        if (salesCount > 0)
                        {
                            Logger.Log($"Попытка удаления партнера {partnerName} отклонена: есть связанные продажи.");
                            MessageBox.Show("Невозможно удалить партнера, так как у него есть связанные продажи.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        var deleteQuery = @"DELETE FROM ""Партнеры"" WHERE ""Наименование партнера"" = @name";
                        var deleteCmd = new NpgsqlCommand(deleteQuery, conn);
                        deleteCmd.Parameters.AddWithValue("name", partnerName);
                        deleteCmd.ExecuteNonQuery();
                    }

                    Logger.Log($"Партнер {partnerName} успешно удален.");
                    MessageBox.Show("Партнер успешно удален.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadPartners(); // Обновляем список после удаления
                }
                catch (Exception ex)
                {
                    Logger.Log($"Ошибка при удалении партнера {partnerName}: {ex.Message}");
                    MessageBox.Show("Ошибка при удалении партнера: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private string CalculateDiscount(int totalSales)
        {
            if (totalSales < 10000)
                return "0%";
            else if (totalSales >= 10000 && totalSales < 50000)
                return "5%";
            else if (totalSales >= 50000 && totalSales < 300000)
                return "10%";
            else
                return "15%";
        }

        private void StyleForm()
        {
            // Настройка стиля формы
            this.BackColor = Color.White;
            this.Text = "Учет партнеров и скидок";
            this.Size = new Size(800, 600);

            // Настройка FlowLayoutPanel
            flowLayoutPanelPartners.AutoScroll = true;
            flowLayoutPanelPartners.BackColor = Color.White;
            flowLayoutPanelPartners.Dock = DockStyle.Fill;
            flowLayoutPanelPartners.Padding = new Padding(20);
        }

        private void pictureBoxRefresh_Click(object sender, EventArgs e)
        {
            LoadPartners(); // Обновляем список партнеров
        }
        private void buttonAddPartner_Click(object sender, EventArgs e)
        {
            Logger.Log("Пользователь открыл форму добавления партнера.");
            FormAddEditPartner formAddEditPartner = new FormAddEditPartner();
            formAddEditPartner.ShowDialog();
            LoadPartners(); // Обновляем список после закрытия формы
        }
        private void PartnerCard_Click(object sender, EventArgs e)
        {
            Panel partnerCard = (Panel)sender;
            string partnerName = partnerCard.Tag.ToString();

            // Открываем форму редактирования и передаем имя партнера
            FormAddEditPartner formAddEditPartner = new FormAddEditPartner(partnerName);
            formAddEditPartner.ShowDialog();
            LoadPartners(); // Обновляем список после закрытия формы
        }
        private void buttonAddProductQuantity_Click(object sender, EventArgs e)
        {
            FormAddProductQuantity formAddProductQuantity = new FormAddProductQuantity();
            formAddProductQuantity.ShowDialog();
            LoadPartners(); // Обновляем список после добавления
        }
        private void buttonEditProductQuantity_Click(object sender, EventArgs e)
        {
            // Мы убираем использование GetFirstDataKey() и просто открываем форму для отображения всех продаж
            FormEditProductQuantity formEditProductQuantity = new FormEditProductQuantity();
            formEditProductQuantity.ShowDialog(); // Показываем форму
            LoadPartners(); // Обновляем список после редактирования или других изменений в форме
        }
        private void buttonGenerateReport_Click(object sender, EventArgs e)
        {
            FormGenerateReport formGenerateReport = new FormGenerateReport();
            formGenerateReport.ShowDialog(); // Открываем форму генерации отчетов
        }

        private void flowLayoutPanelPartners_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}