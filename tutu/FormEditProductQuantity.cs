using System;
using System.Data;
using System.Windows.Forms;
using Npgsql;

namespace tutu
{
    public partial class FormEditProductQuantity : Form
    {
        private string connectionString = "Host=195.46.187.72;Username=postgres;Password=1337;Database=ConstructionMaterialsDB";

        public FormEditProductQuantity()
        {
            InitializeComponent();
            LoadSalesData();  // Загружаем все продажи при старте
            LoadPartners();    // Загружаем список партнеров для фильтрации
            LoadProductTypes(); // Загружаем типы продукции для фильтрации
        }

        // Метод для загрузки данных о продажах с учетом фильтров
        private void LoadSalesData(string searchTerm = "", string partnerFilter = "", string productTypeFilter = "", DateTime? startDate = null, DateTime? endDate = null)
        {
            try
            {
                using (var conn = new NpgsqlConnection(connectionString))
                {
                    conn.Open();
                    var query = @"
                SELECT s.""ID"", s.""Артикул"", s.""Наименование партнера"", s.""Количество продукции"", s.""Дата продажи"", p.""Тип продукции""
                FROM ""Продажи"" s
                JOIN ""Продукция"" p ON s.""Артикул"" = p.""Артикул""
                WHERE (s.""Наименование партнера"" ILIKE @searchTerm OR s.""Артикул""::TEXT ILIKE @searchTerm)
                AND (s.""Наименование партнера"" ILIKE @partnerFilter)
                AND (p.""Тип продукции"" ILIKE @productTypeFilter)
                AND (s.""Дата продажи"" BETWEEN @startDate AND @endDate);";

                    var cmd = new NpgsqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("searchTerm", "%" + searchTerm + "%");
                    cmd.Parameters.AddWithValue("partnerFilter", "%" + partnerFilter + "%");
                    cmd.Parameters.AddWithValue("productTypeFilter", "%" + productTypeFilter + "%");
                    cmd.Parameters.AddWithValue("startDate", startDate ?? DateTime.MinValue);
                    cmd.Parameters.AddWithValue("endDate", endDate ?? DateTime.MaxValue);

                    var reader = cmd.ExecuteReader();
                    DataTable salesTable = new DataTable();
                    salesTable.Load(reader);

                    dataGridViewSales.DataSource = salesTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке данных: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Загрузка списка партнеров для фильтрации
        private void LoadPartners()
        {
            try
            {
                using (var conn = new NpgsqlConnection(connectionString))
                {
                    conn.Open();
                    var query = @"SELECT ""Наименование партнера"" FROM ""Партнеры"";";
                    var cmd = new NpgsqlCommand(query, conn);
                    var reader = cmd.ExecuteReader();

                    comboBoxPartners.Items.Clear();
                    comboBoxPartners.Items.Add("Все партнеры"); // Добавляем опцию "Все партнеры"

                    while (reader.Read())
                    {
                        string partnerName = reader["Наименование партнера"].ToString();
                        comboBoxPartners.Items.Add(partnerName);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке партнеров: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Загрузка типов продукции для фильтрации
        private void LoadProductTypes()
        {
            try
            {
                using (var conn = new NpgsqlConnection(connectionString))
                {
                    conn.Open();
                    var query = @"SELECT DISTINCT ""Тип продукции"" FROM ""Продукция"";";
                    var cmd = new NpgsqlCommand(query, conn);
                    var reader = cmd.ExecuteReader();

                    comboBoxProductTypes.Items.Clear();
                    comboBoxProductTypes.Items.Add("Все типы"); // Добавляем опцию "Все типы"

                    while (reader.Read())
                    {
                        string productType = reader["Тип продукции"].ToString();
                        comboBoxProductTypes.Items.Add(productType);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке типов продукции: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Обработчик для применения фильтров
        private void buttonApplyFilters_Click(object sender, EventArgs e)
        {
            string searchTerm = textBoxSearchSales.Text;
            string partnerFilter = comboBoxPartners.SelectedItem?.ToString() == "Все партнеры" ? "" : comboBoxPartners.SelectedItem?.ToString();
            string productTypeFilter = comboBoxProductTypes.SelectedItem?.ToString() == "Все типы" ? "" : comboBoxProductTypes.SelectedItem?.ToString();
            DateTime startDate = dateTimePickerStart.Value;
            DateTime endDate = dateTimePickerEnd.Value;

            LoadSalesData(searchTerm, partnerFilter, productTypeFilter, startDate, endDate);
        }

        // Обработчик для поиска
        private void ButtonSearchSales_Click(object sender, EventArgs e)
        {
            LoadSalesData(searchTerm: textBoxSearchSales.Text); // Запускаем поиск с учетом введенного текста
        }

        // Обработчик для закрытия формы
        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Обработчик для двойного клика на строку таблицы
        private void dataGridViewSales_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridViewSales.Rows[e.RowIndex];
                int saleId = Convert.ToInt32(row.Cells["ID"].Value); // Получаем ID из выбранной строки

                // Логика редактирования выбранной продажи
                MessageBox.Show("Вы выбрали продажу с ID: " + saleId);
            }
        }
    }
}