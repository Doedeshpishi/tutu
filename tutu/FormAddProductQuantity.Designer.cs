namespace tutu
{
    partial class FormAddProductQuantity
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ComboBox comboBoxProducts;
        private System.Windows.Forms.ComboBox comboBoxPartners;
        private System.Windows.Forms.TextBox textBoxQuantity;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label labelProduct;
        private System.Windows.Forms.Label labelQuantity;
        private System.Windows.Forms.Label labelPartner;

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
            this.comboBoxProducts = new System.Windows.Forms.ComboBox();
            this.comboBoxPartners = new System.Windows.Forms.ComboBox();
            this.textBoxQuantity = new System.Windows.Forms.TextBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.labelProduct = new System.Windows.Forms.Label();
            this.labelQuantity = new System.Windows.Forms.Label();
            this.labelPartner = new System.Windows.Forms.Label();
            this.SuspendLayout();

            // comboBoxProducts
            this.comboBoxProducts.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.comboBoxProducts.FormattingEnabled = true;
            this.comboBoxProducts.Location = new System.Drawing.Point(20, 40);
            this.comboBoxProducts.Name = "comboBoxProducts";
            this.comboBoxProducts.Size = new System.Drawing.Size(560, 25);
            this.comboBoxProducts.TabIndex = 0;

            // comboBoxPartners
            this.comboBoxPartners.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.comboBoxPartners.FormattingEnabled = true;
            this.comboBoxPartners.Location = new System.Drawing.Point(20, 100);
            this.comboBoxPartners.Name = "comboBoxPartners";
            this.comboBoxPartners.Size = new System.Drawing.Size(560, 25);
            this.comboBoxPartners.TabIndex = 1;

            // textBoxQuantity
            this.textBoxQuantity.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.textBoxQuantity.Location = new System.Drawing.Point(20, 160);
            this.textBoxQuantity.Name = "textBoxQuantity";
            this.textBoxQuantity.Size = new System.Drawing.Size(560, 25);
            this.textBoxQuantity.TabIndex = 2;

            // buttonSave
            this.buttonSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.buttonSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSave.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSave.ForeColor = System.Drawing.Color.White;
            this.buttonSave.Location = new System.Drawing.Point(20, 210);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(260, 40);
            this.buttonSave.TabIndex = 3;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = false;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);

            // buttonCancel
            this.buttonCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.buttonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCancel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCancel.ForeColor = System.Drawing.Color.White;
            this.buttonCancel.Location = new System.Drawing.Point(320, 210);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(260, 40);
            this.buttonCancel.TabIndex = 4;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = false;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);

            // labelProduct
            this.labelProduct.AutoSize = true;
            this.labelProduct.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.labelProduct.Location = new System.Drawing.Point(20, 20);
            this.labelProduct.Name = "labelProduct";
            this.labelProduct.Size = new System.Drawing.Size(104, 19);
            this.labelProduct.TabIndex = 5;
            this.labelProduct.Text = "Выберите товар";

            // labelQuantity
            this.labelQuantity.AutoSize = true;
            this.labelQuantity.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.labelQuantity.Location = new System.Drawing.Point(20, 140);
            this.labelQuantity.Name = "labelQuantity";
            this.labelQuantity.Size = new System.Drawing.Size(141, 19);
            this.labelQuantity.TabIndex = 6;
            this.labelQuantity.Text = "Укажите количество";

            // labelPartner
            this.labelPartner.AutoSize = true;
            this.labelPartner.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.labelPartner.Location = new System.Drawing.Point(20, 80);
            this.labelPartner.Name = "labelPartner";
            this.labelPartner.Size = new System.Drawing.Size(119, 19);
            this.labelPartner.TabIndex = 7;
            this.labelPartner.Text = "Выберите партнера";

            // FormAddProductQuantity
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(600, 270);
            this.Controls.Add(this.labelPartner);
            this.Controls.Add(this.labelQuantity);
            this.Controls.Add(this.labelProduct);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.textBoxQuantity);
            this.Controls.Add(this.comboBoxPartners);
            this.Controls.Add(this.comboBoxProducts);
            this.Name = "FormAddProductQuantity";
            this.Text = "Добавление количества продукции";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}