namespace MissTortas.Desktop.Forms.Products
{
    partial class formCreateSaleProduct
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblProductName = new Label();
            lblCategory = new Label();
            label4 = new Label();
            comboBoxCategory = new ComboBox();
            txtProductName = new TextBox();
            txtQuantity = new TextBox();
            lblDescription = new Label();
            txtDescription = new TextBox();
            btnConfirm = new Button();
            btnCancel = new Button();
            lblUnitName = new Label();
            chkEnabled = new CheckBox();
            ofdFiles = new OpenFileDialog();
            openFilesList = new ListBox();
            btnUpload = new Button();
            btnRemove = new Button();
            txtPrice = new TextBox();
            lblPrice = new Label();
            panel6 = new Panel();
            panel1 = new Panel();
            panel2 = new Panel();
            panel3 = new Panel();
            panel4 = new Panel();
            panel5 = new Panel();
            comboBoxUnits = new ComboBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            panel7 = new Panel();
            panel9 = new Panel();
            panel8 = new Panel();
            label1 = new Label();
            panel10 = new Panel();
            lblHeader = new Label();
            panel11 = new Panel();
            panel6.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            panel5.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            panel7.SuspendLayout();
            panel9.SuspendLayout();
            panel8.SuspendLayout();
            panel10.SuspendLayout();
            SuspendLayout();
            // 
            // lblProductName
            // 
            lblProductName.AutoSize = true;
            lblProductName.Dock = DockStyle.Top;
            lblProductName.Location = new Point(0, 0);
            lblProductName.Name = "lblProductName";
            lblProductName.Size = new Size(124, 14);
            lblProductName.TabIndex = 0;
            lblProductName.Text = "Nombre del Producto";
            // 
            // lblCategory
            // 
            lblCategory.AutoSize = true;
            lblCategory.Dock = DockStyle.Top;
            lblCategory.Location = new Point(0, 0);
            lblCategory.Name = "lblCategory";
            lblCategory.Size = new Size(58, 14);
            lblCategory.TabIndex = 1;
            lblCategory.Text = "Categoria";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Dock = DockStyle.Top;
            label4.Location = new Point(0, 0);
            label4.Name = "label4";
            label4.Size = new Size(54, 14);
            label4.TabIndex = 3;
            label4.Text = "Cantidad";
            // 
            // comboBoxCategory
            // 
            comboBoxCategory.Dock = DockStyle.Bottom;
            comboBoxCategory.FlatStyle = FlatStyle.Flat;
            comboBoxCategory.FormattingEnabled = true;
            comboBoxCategory.Location = new Point(0, 14);
            comboBoxCategory.Name = "comboBoxCategory";
            comboBoxCategory.Size = new Size(272, 22);
            comboBoxCategory.TabIndex = 0;
            // 
            // txtProductName
            // 
            txtProductName.BorderStyle = BorderStyle.None;
            txtProductName.Dock = DockStyle.Bottom;
            txtProductName.Location = new Point(0, 20);
            txtProductName.Name = "txtProductName";
            txtProductName.Size = new Size(272, 15);
            txtProductName.TabIndex = 0;
            // 
            // txtQuantity
            // 
            txtQuantity.BorderStyle = BorderStyle.None;
            txtQuantity.Dock = DockStyle.Bottom;
            txtQuantity.Location = new Point(0, 14);
            txtQuantity.Name = "txtQuantity";
            txtQuantity.Size = new Size(272, 15);
            txtQuantity.TabIndex = 3;
            // 
            // lblDescription
            // 
            lblDescription.AutoSize = true;
            lblDescription.Dock = DockStyle.Top;
            lblDescription.Location = new Point(0, 0);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(68, 14);
            lblDescription.TabIndex = 8;
            lblDescription.Text = "Descripcion";
            // 
            // txtDescription
            // 
            txtDescription.Dock = DockStyle.Bottom;
            txtDescription.Location = new Point(0, 14);
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(272, 22);
            txtDescription.TabIndex = 0;
            // 
            // btnConfirm
            // 
            btnConfirm.BackColor = SystemColors.ControlLightLight;
            btnConfirm.FlatStyle = FlatStyle.Flat;
            btnConfirm.Location = new Point(193, 2);
            btnConfirm.Name = "btnConfirm";
            btnConfirm.Size = new Size(81, 25);
            btnConfirm.TabIndex = 0;
            btnConfirm.Text = "Confirmar";
            btnConfirm.UseVisualStyleBackColor = false;
            btnConfirm.Click += btnConfirm_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.Red;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCancel.ForeColor = SystemColors.ControlLightLight;
            btnCancel.Location = new Point(360, 2);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(81, 25);
            btnCancel.TabIndex = 1;
            btnCancel.Text = "Cancelar";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // lblUnitName
            // 
            lblUnitName.AutoSize = true;
            lblUnitName.Dock = DockStyle.Top;
            lblUnitName.Location = new Point(0, 0);
            lblUnitName.Name = "lblUnitName";
            lblUnitName.Size = new Size(118, 14);
            lblUnitName.TabIndex = 13;
            lblUnitName.Text = "Unidad del producto";
            // 
            // chkEnabled
            // 
            chkEnabled.AutoSize = true;
            chkEnabled.Dock = DockStyle.Bottom;
            chkEnabled.FlatStyle = FlatStyle.Flat;
            chkEnabled.Location = new Point(0, 312);
            chkEnabled.Name = "chkEnabled";
            chkEnabled.Size = new Size(274, 18);
            chkEnabled.TabIndex = 7;
            chkEnabled.Text = "Habilitar";
            chkEnabled.UseVisualStyleBackColor = true;
            // 
            // ofdFiles
            // 
            ofdFiles.FileName = "saleFiles";
            // 
            // openFilesList
            // 
            openFilesList.FormattingEnabled = true;
            openFilesList.Location = new Point(42, 34);
            openFilesList.Name = "openFilesList";
            openFilesList.Size = new Size(189, 242);
            openFilesList.TabIndex = 14;
            // 
            // btnUpload
            // 
            btnUpload.BackColor = SystemColors.ControlLightLight;
            btnUpload.FlatStyle = FlatStyle.Flat;
            btnUpload.Location = new Point(43, 281);
            btnUpload.Name = "btnUpload";
            btnUpload.Size = new Size(89, 32);
            btnUpload.TabIndex = 0;
            btnUpload.Text = "Cargar";
            btnUpload.UseVisualStyleBackColor = false;
            btnUpload.Click += btnUpload_Click;
            // 
            // btnRemove
            // 
            btnRemove.BackColor = SystemColors.ControlLightLight;
            btnRemove.FlatStyle = FlatStyle.Flat;
            btnRemove.Location = new Point(138, 281);
            btnRemove.Name = "btnRemove";
            btnRemove.Size = new Size(93, 32);
            btnRemove.TabIndex = 1;
            btnRemove.Text = "Quitar";
            btnRemove.UseVisualStyleBackColor = false;
            btnRemove.Click += btnRemove_Click;
            // 
            // txtPrice
            // 
            txtPrice.BorderStyle = BorderStyle.None;
            txtPrice.Dock = DockStyle.Bottom;
            txtPrice.Location = new Point(0, 17);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(272, 15);
            txtPrice.TabIndex = 0;
            // 
            // lblPrice
            // 
            lblPrice.AutoSize = true;
            lblPrice.Dock = DockStyle.Top;
            lblPrice.Location = new Point(0, 0);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(40, 14);
            lblPrice.TabIndex = 18;
            lblPrice.Text = "Precio";
            // 
            // panel6
            // 
            panel6.BorderStyle = BorderStyle.FixedSingle;
            panel6.Controls.Add(txtPrice);
            panel6.Controls.Add(lblPrice);
            panel6.Dock = DockStyle.Top;
            panel6.Location = new Point(0, 184);
            panel6.Name = "panel6";
            panel6.Size = new Size(274, 34);
            panel6.TabIndex = 1;
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(txtProductName);
            panel1.Controls.Add(lblProductName);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(274, 37);
            panel1.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(txtDescription);
            panel2.Controls.Add(lblDescription);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 37);
            panel2.Name = "panel2";
            panel2.Size = new Size(274, 38);
            panel2.TabIndex = 1;
            // 
            // panel3
            // 
            panel3.BorderStyle = BorderStyle.FixedSingle;
            panel3.Controls.Add(comboBoxCategory);
            panel3.Controls.Add(lblCategory);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(0, 146);
            panel3.Name = "panel3";
            panel3.Size = new Size(274, 38);
            panel3.TabIndex = 2;
            // 
            // panel4
            // 
            panel4.BorderStyle = BorderStyle.FixedSingle;
            panel4.Controls.Add(txtQuantity);
            panel4.Controls.Add(label4);
            panel4.Dock = DockStyle.Top;
            panel4.Location = new Point(0, 75);
            panel4.Name = "panel4";
            panel4.Size = new Size(274, 31);
            panel4.TabIndex = 3;
            // 
            // panel5
            // 
            panel5.BorderStyle = BorderStyle.FixedSingle;
            panel5.Controls.Add(comboBoxUnits);
            panel5.Controls.Add(lblUnitName);
            panel5.Dock = DockStyle.Top;
            panel5.Location = new Point(0, 106);
            panel5.Name = "panel5";
            panel5.Size = new Size(274, 40);
            panel5.TabIndex = 4;
            // 
            // comboBoxUnits
            // 
            comboBoxUnits.Dock = DockStyle.Bottom;
            comboBoxUnits.FlatStyle = FlatStyle.Flat;
            comboBoxUnits.FormattingEnabled = true;
            comboBoxUnits.Location = new Point(0, 16);
            comboBoxUnits.Name = "comboBoxUnits";
            comboBoxUnits.Size = new Size(272, 22);
            comboBoxUnits.TabIndex = 14;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = SystemColors.ControlLight;
            tableLayoutPanel1.ColumnCount = 5;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.Controls.Add(panel7, 1, 2);
            tableLayoutPanel1.Controls.Add(panel9, 1, 1);
            tableLayoutPanel1.Controls.Add(panel8, 3, 1);
            tableLayoutPanel1.Controls.Add(panel10, 1, 0);
            tableLayoutPanel1.Controls.Add(panel11, 2, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 80F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.Size = new Size(800, 420);
            tableLayoutPanel1.TabIndex = 20;
            // 
            // panel7
            // 
            panel7.BackColor = Color.WhiteSmoke;
            tableLayoutPanel1.SetColumnSpan(panel7, 3);
            panel7.Controls.Add(btnConfirm);
            panel7.Controls.Add(btnCancel);
            panel7.Dock = DockStyle.Fill;
            panel7.Location = new Point(83, 381);
            panel7.Name = "panel7";
            panel7.Size = new Size(634, 36);
            panel7.TabIndex = 21;
            // 
            // panel9
            // 
            panel9.BackColor = Color.WhiteSmoke;
            panel9.Controls.Add(panel6);
            panel9.Controls.Add(chkEnabled);
            panel9.Controls.Add(panel3);
            panel9.Controls.Add(panel5);
            panel9.Controls.Add(panel4);
            panel9.Controls.Add(panel2);
            panel9.Controls.Add(panel1);
            panel9.Dock = DockStyle.Fill;
            panel9.Location = new Point(83, 45);
            panel9.Name = "panel9";
            panel9.Size = new Size(274, 330);
            panel9.TabIndex = 22;
            // 
            // panel8
            // 
            panel8.BackColor = Color.WhiteSmoke;
            panel8.Controls.Add(label1);
            panel8.Controls.Add(openFilesList);
            panel8.Controls.Add(btnUpload);
            panel8.Controls.Add(btnRemove);
            panel8.Location = new Point(443, 45);
            panel8.Name = "panel8";
            panel8.Size = new Size(274, 330);
            panel8.TabIndex = 21;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(42, 17);
            label1.Name = "label1";
            label1.Size = new Size(129, 14);
            label1.TabIndex = 15;
            label1.Text = "Archivos de productos";
            // 
            // panel10
            // 
            panel10.BackColor = Color.WhiteSmoke;
            tableLayoutPanel1.SetColumnSpan(panel10, 3);
            panel10.Controls.Add(lblHeader);
            panel10.Dock = DockStyle.Fill;
            panel10.Location = new Point(83, 3);
            panel10.Name = "panel10";
            panel10.Size = new Size(634, 36);
            panel10.TabIndex = 23;
            // 
            // lblHeader
            // 
            lblHeader.Dock = DockStyle.Fill;
            lblHeader.Font = new Font("Tahoma", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblHeader.Location = new Point(0, 0);
            lblHeader.Name = "lblHeader";
            lblHeader.Size = new Size(634, 36);
            lblHeader.TabIndex = 0;
            lblHeader.Text = "label2";
            // 
            // panel11
            // 
            panel11.BackColor = Color.WhiteSmoke;
            panel11.Dock = DockStyle.Fill;
            panel11.Location = new Point(363, 45);
            panel11.Name = "panel11";
            panel11.Size = new Size(74, 330);
            panel11.TabIndex = 24;
            // 
            // formCreateSaleProduct
            // 
            AcceptButton = btnConfirm;
            AutoScaleDimensions = new SizeF(7F, 14F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new Size(800, 420);
            Controls.Add(tableLayoutPanel1);
            Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "formCreateSaleProduct";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Gestionar Producto";
            Load += formCreateSaleProduct_Load;
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            panel7.ResumeLayout(false);
            panel9.ResumeLayout(false);
            panel9.PerformLayout();
            panel8.ResumeLayout(false);
            panel8.PerformLayout();
            panel10.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Label lblProductName;
        private Label lblCategory;
        private Label label4;
        private ComboBox comboBoxCategory;
        private TextBox txtProductName;
        private TextBox txtQuantity;
        private Label lblDescription;
        private TextBox txtDescription;
        private Button btnConfirm;
        private Button btnCancel;
        private Label lblUnitName;
        private CheckBox chkEnabled;
        private OpenFileDialog ofdFiles;
        private ListBox openFilesList;
        private Button btnUpload;
        private Button btnRemove;
        private TextBox txtPrice;
        private Label lblPrice;
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Panel panel4;
        private Panel panel5;
        private Panel panel6;
        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel7;
        private Panel panel8;
        private Panel panel9;
        private Label label1;
        private Panel panel10;
        private Panel panel11;
        private Label lblHeader;
        private ComboBox comboBoxUnits;
    }
}