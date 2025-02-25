namespace tutu
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelPartners;
        private System.Windows.Forms.PictureBox pictureBoxRefresh;
        private System.Windows.Forms.Button buttonAddPartner;
        private System.Windows.Forms.Button buttonAddProductQuantity;
        private System.Windows.Forms.Button buttonEditProductQuantity;
        private System.Windows.Forms.Button buttonGenerateReport;


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
            this.buttonAddPartner = new System.Windows.Forms.Button();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.buttonGenerateReport = new System.Windows.Forms.Button();
            this.buttonEditProductQuantity = new System.Windows.Forms.Button();
            this.pictureBoxRefresh = new System.Windows.Forms.PictureBox();
            this.buttonAddProductQuantity = new System.Windows.Forms.Button();
            this.labelTitle = new System.Windows.Forms.Label();
            this.flowLayoutPanelPartners = new System.Windows.Forms.FlowLayoutPanel();
            this.panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRefresh)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonAddPartner
            // 
            this.buttonAddPartner.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.buttonAddPartner.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAddPartner.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAddPartner.ForeColor = System.Drawing.Color.White;
            this.buttonAddPartner.Location = new System.Drawing.Point(20, 45);
            this.buttonAddPartner.Name = "buttonAddPartner";
            this.buttonAddPartner.Size = new System.Drawing.Size(196, 32);
            this.buttonAddPartner.TabIndex = 2;
            this.buttonAddPartner.Text = "Добавить партнера";
            this.buttonAddPartner.UseVisualStyleBackColor = false;
            this.buttonAddPartner.Click += new System.EventHandler(this.buttonAddPartner_Click);
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.panelHeader.Controls.Add(this.buttonGenerateReport);
            this.panelHeader.Controls.Add(this.buttonAddPartner);
            this.panelHeader.Controls.Add(this.buttonEditProductQuantity);
            this.panelHeader.Controls.Add(this.pictureBoxRefresh);
            this.panelHeader.Controls.Add(this.buttonAddProductQuantity);
            this.panelHeader.Controls.Add(this.labelTitle);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(872, 115);
            this.panelHeader.TabIndex = 0;
            // 
            // buttonGenerateReport
            // 
            this.buttonGenerateReport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.buttonGenerateReport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.buttonGenerateReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonGenerateReport.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonGenerateReport.ForeColor = System.Drawing.Color.White;
            this.buttonGenerateReport.Location = new System.Drawing.Point(20, 80);
            this.buttonGenerateReport.Name = "buttonGenerateReport";
            this.buttonGenerateReport.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.buttonGenerateReport.Size = new System.Drawing.Size(600, 32);
            this.buttonGenerateReport.TabIndex = 5;
            this.buttonGenerateReport.Text = "Генерация отчетов";
            this.buttonGenerateReport.UseVisualStyleBackColor = false;
            this.buttonGenerateReport.Click += new System.EventHandler(this.buttonGenerateReport_Click);
            // 
            // buttonEditProductQuantity
            // 
            this.buttonEditProductQuantity.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.buttonEditProductQuantity.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonEditProductQuantity.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonEditProductQuantity.ForeColor = System.Drawing.Color.White;
            this.buttonEditProductQuantity.Location = new System.Drawing.Point(426, 45);
            this.buttonEditProductQuantity.Name = "buttonEditProductQuantity";
            this.buttonEditProductQuantity.Size = new System.Drawing.Size(196, 32);
            this.buttonEditProductQuantity.TabIndex = 4;
            this.buttonEditProductQuantity.Text = "Продажи\r\n";
            this.buttonEditProductQuantity.UseVisualStyleBackColor = false;
            this.buttonEditProductQuantity.Click += new System.EventHandler(this.buttonEditProductQuantity_Click);
            // 
            // pictureBoxRefresh
            // 
            this.pictureBoxRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxRefresh.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxRefresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBoxRefresh.Cursor = System.Windows.Forms.Cursors.Default;
            this.pictureBoxRefresh.Image = global::tutu.Properties.Resources.kisspng_computer_icons_multimedia_application_programming_multi_media_5ae175a590e129_2605477015247251575934;
            this.pictureBoxRefresh.Location = new System.Drawing.Point(788, 28);
            this.pictureBoxRefresh.Name = "pictureBoxRefresh";
            this.pictureBoxRefresh.Size = new System.Drawing.Size(72, 59);
            this.pictureBoxRefresh.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxRefresh.TabIndex = 1;
            this.pictureBoxRefresh.TabStop = false;
            this.pictureBoxRefresh.Click += new System.EventHandler(this.pictureBoxRefresh_Click);
            // 
            // buttonAddProductQuantity
            // 
            this.buttonAddProductQuantity.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.buttonAddProductQuantity.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAddProductQuantity.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAddProductQuantity.ForeColor = System.Drawing.Color.White;
            this.buttonAddProductQuantity.Location = new System.Drawing.Point(224, 45);
            this.buttonAddProductQuantity.Name = "buttonAddProductQuantity";
            this.buttonAddProductQuantity.Size = new System.Drawing.Size(196, 32);
            this.buttonAddProductQuantity.TabIndex = 3;
            this.buttonAddProductQuantity.Text = "Добавить количество";
            this.buttonAddProductQuantity.UseVisualStyleBackColor = false;
            this.buttonAddProductQuantity.Click += new System.EventHandler(this.buttonAddProductQuantity_Click);
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitle.ForeColor = System.Drawing.Color.White;
            this.labelTitle.Location = new System.Drawing.Point(14, 10);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(312, 32);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "Учет партнеров и скидок";
            // 
            // flowLayoutPanelPartners
            // 
            this.flowLayoutPanelPartners.AutoScroll = true;
            this.flowLayoutPanelPartners.BackColor = System.Drawing.Color.White;
            this.flowLayoutPanelPartners.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelPartners.Location = new System.Drawing.Point(0, 115);
            this.flowLayoutPanelPartners.Name = "flowLayoutPanelPartners";
            this.flowLayoutPanelPartners.Padding = new System.Windows.Forms.Padding(20);
            this.flowLayoutPanelPartners.Size = new System.Drawing.Size(872, 599);
            this.flowLayoutPanelPartners.TabIndex = 1;
            this.flowLayoutPanelPartners.Paint += new System.Windows.Forms.PaintEventHandler(this.flowLayoutPanelPartners_Paint);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(872, 714);
            this.Controls.Add(this.flowLayoutPanelPartners);
            this.Controls.Add(this.panelHeader);
            this.Name = "Form1";
            this.Text = "Учет партнеров";
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRefresh)).EndInit();
            this.ResumeLayout(false);

        }
    }
}