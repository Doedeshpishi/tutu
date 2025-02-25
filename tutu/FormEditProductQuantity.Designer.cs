using System.Windows.Forms;

namespace tutu
{
    partial class FormEditProductQuantity
    {
        private System.ComponentModel.IContainer components = null;

        // Элементы управления
        private System.Windows.Forms.DataGridView dataGridViewSales;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.TextBox textBoxSearchSales;
        private System.Windows.Forms.Button buttonSearchSales;
        private System.Windows.Forms.ComboBox comboBoxPartners;
        private System.Windows.Forms.ComboBox comboBoxProductTypes;
        private System.Windows.Forms.DateTimePicker dateTimePickerStart;
        private System.Windows.Forms.DateTimePicker dateTimePickerEnd;
        private System.Windows.Forms.Button buttonApplyFilters;
        private System.Windows.Forms.Label labelPartners;
        private System.Windows.Forms.Label labelProductTypes;
        private System.Windows.Forms.Label labelStartDate;
        private System.Windows.Forms.Label labelEndDate;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dataGridViewSales = new System.Windows.Forms.DataGridView();
            this.buttonClose = new System.Windows.Forms.Button();
            this.textBoxSearchSales = new System.Windows.Forms.TextBox();
            this.buttonSearchSales = new System.Windows.Forms.Button();
            this.comboBoxPartners = new System.Windows.Forms.ComboBox();
            this.comboBoxProductTypes = new System.Windows.Forms.ComboBox();
            this.dateTimePickerStart = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerEnd = new System.Windows.Forms.DateTimePicker();
            this.buttonApplyFilters = new System.Windows.Forms.Button();
            this.labelPartners = new System.Windows.Forms.Label();
            this.labelProductTypes = new System.Windows.Forms.Label();
            this.labelStartDate = new System.Windows.Forms.Label();
            this.labelEndDate = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSales)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewSales
            // 
            this.dataGridViewSales.AllowUserToAddRows = false;
            this.dataGridViewSales.AllowUserToDeleteRows = false;
            this.dataGridViewSales.AllowUserToResizeColumns = false;
            this.dataGridViewSales.AllowUserToResizeRows = false;
            this.dataGridViewSales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSales.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridViewSales.Location = new System.Drawing.Point(0, 150);
            this.dataGridViewSales.Name = "dataGridViewSales";
            this.dataGridViewSales.ReadOnly = true;
            this.dataGridViewSales.RowHeadersWidth = 51;
            this.dataGridViewSales.RowTemplate.Height = 24;
            this.dataGridViewSales.Size = new System.Drawing.Size(800, 300);
            this.dataGridViewSales.TabIndex = 0;
            this.dataGridViewSales.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewSales_CellDoubleClick);
            // 
            // buttonClose
            // 
            this.buttonClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.buttonClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonClose.ForeColor = System.Drawing.Color.White;
            this.buttonClose.Location = new System.Drawing.Point(700, 10);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(75, 30);
            this.buttonClose.TabIndex = 1;
            this.buttonClose.Text = "Закрыть";
            this.buttonClose.UseVisualStyleBackColor = false;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // textBoxSearchSales
            // 
            this.textBoxSearchSales.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxSearchSales.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.textBoxSearchSales.Location = new System.Drawing.Point(10, 10);
            this.textBoxSearchSales.Name = "textBoxSearchSales";
            this.textBoxSearchSales.Size = new System.Drawing.Size(200, 25);
            this.textBoxSearchSales.TabIndex = 2;
            // 
            // buttonSearchSales
            // 
            this.buttonSearchSales.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.buttonSearchSales.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSearchSales.ForeColor = System.Drawing.Color.White;
            this.buttonSearchSales.Location = new System.Drawing.Point(220, 10);
            this.buttonSearchSales.Name = "buttonSearchSales";
            this.buttonSearchSales.Size = new System.Drawing.Size(75, 30);
            this.buttonSearchSales.TabIndex = 3;
            this.buttonSearchSales.Text = "Поиск";
            this.buttonSearchSales.UseVisualStyleBackColor = false;
            this.buttonSearchSales.Click += new System.EventHandler(this.ButtonSearchSales_Click);
            // 
            // comboBoxPartners
            // 
            this.comboBoxPartners.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPartners.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.comboBoxPartners.FormattingEnabled = true;
            this.comboBoxPartners.Location = new System.Drawing.Point(10, 60);
            this.comboBoxPartners.Name = "comboBoxPartners";
            this.comboBoxPartners.Size = new System.Drawing.Size(200, 25);
            this.comboBoxPartners.TabIndex = 4;
            // 
            // comboBoxProductTypes
            // 
            this.comboBoxProductTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxProductTypes.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.comboBoxProductTypes.FormattingEnabled = true;
            this.comboBoxProductTypes.Location = new System.Drawing.Point(220, 60);
            this.comboBoxProductTypes.Name = "comboBoxProductTypes";
            this.comboBoxProductTypes.Size = new System.Drawing.Size(200, 25);
            this.comboBoxProductTypes.TabIndex = 5;
            // 
            // dateTimePickerStart
            // 
            this.dateTimePickerStart.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dateTimePickerStart.Location = new System.Drawing.Point(10, 119);
            this.dateTimePickerStart.Name = "dateTimePickerStart";
            this.dateTimePickerStart.Size = new System.Drawing.Size(200, 25);
            this.dateTimePickerStart.TabIndex = 6;
            // 
            // dateTimePickerEnd
            // 
            this.dateTimePickerEnd.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dateTimePickerEnd.Location = new System.Drawing.Point(220, 119);
            this.dateTimePickerEnd.Name = "dateTimePickerEnd";
            this.dateTimePickerEnd.Size = new System.Drawing.Size(200, 25);
            this.dateTimePickerEnd.TabIndex = 7;
            // 
            // buttonApplyFilters
            // 
            this.buttonApplyFilters.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.buttonApplyFilters.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonApplyFilters.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.buttonApplyFilters.ForeColor = System.Drawing.Color.White;
            this.buttonApplyFilters.Location = new System.Drawing.Point(440, 60);
            this.buttonApplyFilters.Name = "buttonApplyFilters";
            this.buttonApplyFilters.Size = new System.Drawing.Size(150, 30);
            this.buttonApplyFilters.TabIndex = 8;
            this.buttonApplyFilters.Text = "Применить фильтр";
            this.buttonApplyFilters.UseVisualStyleBackColor = false;
            this.buttonApplyFilters.Click += new System.EventHandler(this.buttonApplyFilters_Click);
            // 
            // labelPartners
            // 
            this.labelPartners.AutoSize = true;
            this.labelPartners.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.labelPartners.Location = new System.Drawing.Point(10, 40);
            this.labelPartners.Name = "labelPartners";
            this.labelPartners.Size = new System.Drawing.Size(66, 19);
            this.labelPartners.TabIndex = 9;
            this.labelPartners.Text = "Партнер:";
            // 
            // labelProductTypes
            // 
            this.labelProductTypes.AutoSize = true;
            this.labelProductTypes.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.labelProductTypes.Location = new System.Drawing.Point(220, 40);
            this.labelProductTypes.Name = "labelProductTypes";
            this.labelProductTypes.Size = new System.Drawing.Size(109, 19);
            this.labelProductTypes.TabIndex = 10;
            this.labelProductTypes.Text = "Тип продукции:";
            // 
            // labelStartDate
            // 
            this.labelStartDate.AutoSize = true;
            this.labelStartDate.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.labelStartDate.Location = new System.Drawing.Point(10, 97);
            this.labelStartDate.Name = "labelStartDate";
            this.labelStartDate.Size = new System.Drawing.Size(112, 19);
            this.labelStartDate.TabIndex = 11;
            this.labelStartDate.Text = "Начальная дата:";
            // 
            // labelEndDate
            // 
            this.labelEndDate.AutoSize = true;
            this.labelEndDate.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.labelEndDate.Location = new System.Drawing.Point(220, 97);
            this.labelEndDate.Name = "labelEndDate";
            this.labelEndDate.Size = new System.Drawing.Size(105, 19);
            this.labelEndDate.TabIndex = 12;
            this.labelEndDate.Text = "Конечная дата:";
            // 
            // FormEditProductQuantity
            // 
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.labelEndDate);
            this.Controls.Add(this.labelStartDate);
            this.Controls.Add(this.labelProductTypes);
            this.Controls.Add(this.labelPartners);
            this.Controls.Add(this.buttonApplyFilters);
            this.Controls.Add(this.dateTimePickerEnd);
            this.Controls.Add(this.dateTimePickerStart);
            this.Controls.Add(this.comboBoxProductTypes);
            this.Controls.Add(this.comboBoxPartners);
            this.Controls.Add(this.buttonSearchSales);
            this.Controls.Add(this.textBoxSearchSales);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.dataGridViewSales);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FormEditProductQuantity";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Продажи";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSales)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}