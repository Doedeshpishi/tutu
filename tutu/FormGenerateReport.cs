using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
using Npgsql;
using OfficeOpenXml; // Библиотека для работы с Excel
using iTextSharp.text;
using iTextSharp.text.pdf; // Библиотека для работы с PDF


namespace tutu
{
    public partial class FormGenerateReport : Form
    {
        private string connectionString = "Host=195.46.187.72;Username=postgres;Password=1337;Database=ConstructionMaterialsDB";

        public FormGenerateReport()
        {
            InitializeComponent();
        }

        // Метод для загрузки данных о продажах за выбранный период
        private DataTable LoadSalesData(DateTime startDate, DateTime endDate)
        {
            DataTable salesTable = new DataTable();
            try
            {
                using (var conn = new NpgsqlConnection(connectionString))
                {
                    conn.Open();
                    var query = @"
                        SELECT s.""ID"", s.""Артикул"", s.""Наименование партнера"", s.""Количество продукции"", s.""Дата продажи"", p.""Тип продукции""
                        FROM ""Продажи"" s
                        JOIN ""Продукция"" p ON s.""Артикул"" = p.""Артикул""
                        WHERE s.""Дата продажи"" BETWEEN @startDate AND @endDate;";

                    var cmd = new NpgsqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("startDate", startDate);
                    cmd.Parameters.AddWithValue("endDate", endDate);

                    var reader = cmd.ExecuteReader();
                    salesTable.Load(reader);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке данных: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return salesTable;
        }

        // Генерация отчета в Excel
        private void GenerateExcelReport(DataTable data, string filePath)
        {
            // Устанавливаем контекст лицензии
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            // Добавляем столбец с порядковым номером
            data.Columns.Add("№", typeof(int));
            for (int i = 0; i < data.Rows.Count; i++)
            {
                data.Rows[i]["№"] = i + 1; // Нумерация с 1
            }

            // Перемещаем столбец "№" на первое место
            data.Columns["№"].SetOrdinal(0);

            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Отчет по продажам");

                // Заголовки столбцов
                for (int i = 0; i < data.Columns.Count; i++)
                {
                    worksheet.Cells[1, i + 1].Value = data.Columns[i].ColumnName;
                    worksheet.Cells[1, i + 1].Style.Font.Bold = true; // Жирный шрифт для заголовков
                    worksheet.Cells[1, i + 1].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center; // Центрирование заголовков
                }

                // Данные
                for (int i = 0; i < data.Rows.Count; i++)
                {
                    for (int j = 0; j < data.Columns.Count; j++)
                    {
                        if (data.Columns[j].DataType == typeof(DateTime)) // Если столбец содержит дату
                        {
                            DateTime dateValue;
                            if (DateTime.TryParse(data.Rows[i][j].ToString(), out dateValue))
                            {
                                worksheet.Cells[i + 2, j + 1].Value = dateValue;
                                worksheet.Cells[i + 2, j + 1].Style.Numberformat.Format = "dd.MM.yyyy"; // Формат даты
                            }
                            
                        }
                        else
                        {
                            worksheet.Cells[i + 2, j + 1].Value = data.Rows[i][j];
                        }
                        worksheet.Cells[i + 2, j + 1].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center; // Центрирование данных
                    }
                }

                // Автоматическое выравнивание ширины столбцов
                worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();

                // Сохранение файла
                package.SaveAs(new FileInfo(filePath));
            }
        }

        // Генерация отчета в PDF
        private void GeneratePdfReport(DataTable data, string filePath)
        {
            // Указываем путь к шрифту Arial (замените на ваш путь)
            string fontPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "arial.ttf");
            BaseFont baseFont = BaseFont.CreateFont(fontPath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
            Font font = new Font(baseFont, 10);
            Font boldFont = new Font(baseFont, 10);

            // Добавляем столбец с порядковым номером
            data.Columns.Add("№", typeof(int));
            for (int i = 0; i < data.Rows.Count; i++)
            {
                data.Rows[i]["№"] = i + 1; // Нумерация с 1
            }

            // Перемещаем столбец "№" на первое место
            data.Columns["№"].SetOrdinal(0);

            // Создаем документ PDF
            Document document = new Document(PageSize.A4.Rotate(), 10, 10, 10, 10); // Повернутый формат A4 для большего места
            PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(filePath, FileMode.Create));
            document.Open();

            // Заголовок отчета
            Paragraph title = new Paragraph("Отчет по продажам за период", new Font(baseFont, 18));
            title.Alignment = Element.ALIGN_CENTER;
            document.Add(title);

            // Добавляем даты периода
            Paragraph period = new Paragraph($"С {dateTimePickerStart.Value.ToShortDateString()} по {dateTimePickerEnd.Value.ToShortDateString()}", new Font(baseFont, 12));
            period.Alignment = Element.ALIGN_CENTER;
            document.Add(period);

            document.Add(new Paragraph("\n")); // Пустая строка

            // Создаем таблицу
            PdfPTable table = new PdfPTable(data.Columns.Count);
            table.WidthPercentage = 100; // Таблица занимает 100% ширины страницы

            // Заголовки столбцов
            foreach (DataColumn column in data.Columns)
            {
                PdfPCell cell = new PdfPCell(new Phrase(column.ColumnName, boldFont));
                cell.BackgroundColor = new BaseColor(200, 200, 200); // Серый фон для заголовков
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                table.AddCell(cell);
            }

            // Данные
            foreach (DataRow row in data.Rows)
            {
                foreach (var item in row.ItemArray)
                {
                    PdfPCell cell = new PdfPCell(new Phrase(item.ToString(), font));
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    table.AddCell(cell);
                }
            }

            document.Add(table); // Добавляем таблицу в документ
            document.Close(); // Закрываем документ
        }

        // Обработчик для кнопки "Сгенерировать отчет"
        private void buttonGenerateReport_Click(object sender, EventArgs e)
        {
            DateTime startDate = dateTimePickerStart.Value;
            DateTime endDate = dateTimePickerEnd.Value;

            if (startDate > endDate)
            {
                MessageBox.Show("Начальная дата не может быть больше конечной.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Загрузка данных
            DataTable salesData = LoadSalesData(startDate, endDate);

            if (salesData.Rows.Count == 0)
            {
                MessageBox.Show("Нет данных для отчета за выбранный период.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Выбор формата отчета
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel Files|*.xlsx|PDF Files|*.pdf";
            saveFileDialog.Title = "Сохранить отчет";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;

                if (filePath.EndsWith(".xlsx"))
                {
                    GenerateExcelReport(salesData, filePath);
                }
                else if (filePath.EndsWith(".pdf"))
                {
                    GeneratePdfReport(salesData, filePath);
                }

                MessageBox.Show("Отчет успешно сгенерирован.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}