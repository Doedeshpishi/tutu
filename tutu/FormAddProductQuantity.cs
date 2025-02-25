using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Npgsql;

namespace tutu
{
    public partial class FormAddProductQuantity : Form
    {
        private string connectionString = "Host=195.46.187.72;Username=postgres;Password=1337;Database=ConstructionMaterialsDB";

        public FormAddProductQuantity()
        {
            InitializeComponent();
            LoadProducts();
            LoadPartners();
        }

        private void LoadProducts()
        {
            try
            {
                using (var conn = new NpgsqlConnection(connectionString))
                {
                    conn.Open();
                    var query = @"SELECT ""Артикул"", ""Наименование продукции"" FROM ""Продукция"";";
                    var cmd = new NpgsqlCommand(query, conn);
                    var reader = cmd.ExecuteReader();

                    comboBoxProducts.Items.Clear();

                    while (reader.Read())
                    {
                        string productInfo = $"{reader["Артикул"]} - {reader["Наименование продукции"]}";
                        comboBoxProducts.Items.Add(productInfo);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке данных: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

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

                    while (reader.Read())
                    {
                        string partnerName = reader["Наименование партнера"].ToString();
                        comboBoxPartners.Items.Add(partnerName);
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
            if (comboBoxProducts.SelectedItem == null || comboBoxPartners.SelectedItem == null || string.IsNullOrEmpty(textBoxQuantity.Text))
            {
                MessageBox.Show("Выберите продукт, партнера и укажите количество.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int quantity = Convert.ToInt32(textBoxQuantity.Text);
                string selectedProduct = comboBoxProducts.SelectedItem.ToString();
                int article = int.Parse(selectedProduct.Split('-')[0].Trim());
                string partnerName = comboBoxPartners.SelectedItem.ToString();

                using (var conn = new NpgsqlConnection(connectionString))
                {
                    conn.Open();
                    var query = @"INSERT INTO ""Продажи"" (""Артикул"", ""Наименование партнера"", ""Количество продукции"", ""Дата продажи"") 
                                   VALUES (@article, @partnerName, @quantity, @date);";
                    var cmd = new NpgsqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("article", article);
                    cmd.Parameters.AddWithValue("partnerName", partnerName);
                    cmd.Parameters.AddWithValue("quantity", quantity);
                    cmd.Parameters.AddWithValue("date", DateTime.Now);

                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Количество продукции успешно добавлено.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при добавлении данных: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}