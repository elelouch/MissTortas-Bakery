namespace MissTortas.Desktop.Forms.Products
{
    partial class formCreateStockProduct
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
            panel1 = new Panel();
            panel8 = new Panel();
            lblHeader = new Label();
            panel7 = new Panel();
            panel6 = new Panel();
            comboBoxUnits = new ComboBox();
            panel4 = new Panel();
            panel5 = new Panel();
            panel3 = new Panel();
            panel2 = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            panel1.SuspendLayout();
            panel8.SuspendLayout();
            panel7.SuspendLayout();
            panel6.SuspendLayout();
            panel4.SuspendLayout();
            panel5.SuspendLayout();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // lblProductName
            // 
            lblProductName.AutoSize = true;
            lblProductName.Dock = DockStyle.Top;
            lblProductName.Location = new Point(0, 0);
            lblProductName.Name = "lblProductName";
            lblProductName.Size = new Size(50, 14);
            lblProductName.TabIndex = 1;
            lblProductName.Text = "Nombre";
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
            comboBoxCategory.Location = new Point(0, 13);
            comboBoxCategory.Name = "comboBoxCategory";
            comboBoxCategory.Size = new Size(240, 22);
            comboBoxCategory.TabIndex = 2;
            // 
            // txtProductName
            // 
            txtProductName.Dock = DockStyle.Bottom;
            txtProductName.Location = new Point(0, 13);
            txtProductName.Name = "txtProductName";
            txtProductName.Size = new Size(240, 22);
            txtProductName.TabIndex = 0;
            // 
            // txtQuantity
            // 
            txtQuantity.Dock = DockStyle.Bottom;
            txtQuantity.Location = new Point(0, 15);
            txtQuantity.Name = "txtQuantity";
            txtQuantity.Size = new Size(240, 22);
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
            txtDescription.Location = new Point(0, 15);
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(240, 22);
            txtDescription.TabIndex = 1;
            // 
            // btnConfirm
            // 
            btnConfirm.BackColor = SystemColors.ControlLightLight;
            btnConfirm.FlatStyle = FlatStyle.Flat;
            btnConfirm.Location = new Point(0, 258);
            btnConfirm.Name = "btnConfirm";
            btnConfirm.Size = new Size(86, 26);
            btnConfirm.TabIndex = 7;
            btnConfirm.Text = "Confirmar";
            btnConfirm.UseVisualStyleBackColor = false;
            btnConfirm.Click += btnConfirm_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.Red;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Tahoma", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCancel.ForeColor = SystemColors.ControlLightLight;
            btnCancel.Location = new Point(159, 258);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(83, 26);
            btnCancel.TabIndex = 8;
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
            lblUnitName.Size = new Size(44, 14);
            lblUnitName.TabIndex = 13;
            lblUnitName.Text = "Unidad";
            // 
            // chkEnabled
            // 
            chkEnabled.AutoSize = true;
            chkEnabled.FlatStyle = FlatStyle.Flat;
            chkEnabled.Location = new Point(0, 226);
            chkEnabled.Name = "chkEnabled";
            chkEnabled.Size = new Size(65, 18);
            chkEnabled.TabIndex = 6;
            chkEnabled.Text = "Habilitar";
            chkEnabled.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.BackColor = Color.WhiteSmoke;
            panel1.Controls.Add(panel8);
            panel1.Controls.Add(panel7);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(163, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(474, 414);
            panel1.TabIndex = 1;
            // 
            // panel8
            // 
            panel8.Controls.Add(lblHeader);
            panel8.Location = new Point(125, 10);
            panel8.Name = "panel8";
            panel8.Size = new Size(241, 40);
            panel8.TabIndex = 1;
            // 
            // lblHeader
            // 
            lblHeader.AutoSize = true;
            lblHeader.Dock = DockStyle.Top;
            lblHeader.Font = new Font("Tahoma", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblHeader.Location = new Point(0, 0);
            lblHeader.Name = "lblHeader";
            lblHeader.Size = new Size(43, 14);
            lblHeader.TabIndex = 18;
            lblHeader.Text = "label1";
            // 
            // panel7
            // 
            panel7.Controls.Add(panel6);
            panel7.Controls.Add(btnCancel);
            panel7.Controls.Add(btnConfirm);
            panel7.Controls.Add(chkEnabled);
            panel7.Controls.Add(panel4);
            panel7.Controls.Add(panel5);
            panel7.Controls.Add(panel3);
            panel7.Controls.Add(panel2);
            panel7.Location = new Point(124, 56);
            panel7.Name = "panel7";
            panel7.Size = new Size(242, 284);
            panel7.TabIndex = 17;
            // 
            // panel6
            // 
            panel6.BorderStyle = BorderStyle.FixedSingle;
            panel6.Controls.Add(comboBoxUnits);
            panel6.Controls.Add(lblUnitName);
            panel6.Dock = DockStyle.Top;
            panel6.Location = new Point(0, 152);
            panel6.Name = "panel6";
            panel6.Size = new Size(242, 36);
            panel6.TabIndex = 4;
            // 
            // comboBoxUnits
            // 
            comboBoxUnits.Dock = DockStyle.Bottom;
            comboBoxUnits.FlatStyle = FlatStyle.Flat;
            comboBoxUnits.FormattingEnabled = true;
            comboBoxUnits.Location = new Point(0, 12);
            comboBoxUnits.Name = "comboBoxUnits";
            comboBoxUnits.Size = new Size(240, 22);
            comboBoxUnits.TabIndex = 14;
            // 
            // panel4
            // 
            panel4.BorderStyle = BorderStyle.FixedSingle;
            panel4.Controls.Add(comboBoxCategory);
            panel4.Controls.Add(lblCategory);
            panel4.Dock = DockStyle.Top;
            panel4.Location = new Point(0, 115);
            panel4.Name = "panel4";
            panel4.Size = new Size(242, 37);
            panel4.TabIndex = 3;
            // 
            // panel5
            // 
            panel5.BorderStyle = BorderStyle.FixedSingle;
            panel5.Controls.Add(txtQuantity);
            panel5.Controls.Add(label4);
            panel5.Dock = DockStyle.Top;
            panel5.Location = new Point(0, 76);
            panel5.Name = "panel5";
            panel5.Size = new Size(242, 39);
            panel5.TabIndex = 2;
            // 
            // panel3
            // 
            panel3.BorderStyle = BorderStyle.FixedSingle;
            panel3.Controls.Add(txtDescription);
            panel3.Controls.Add(lblDescription);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(0, 37);
            panel3.Name = "panel3";
            panel3.Size = new Size(242, 39);
            panel3.TabIndex = 1;
            // 
            // panel2
            // 
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(txtProductName);
            panel2.Controls.Add(lblProductName);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(242, 37);
            panel2.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = SystemColors.ControlLight;
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.Controls.Add(panel1, 1, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 420F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(800, 420);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // formCreateStockProduct
            // 
            AcceptButton = btnConfirm;
            AutoScaleDimensions = new SizeF(7F, 14F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new Size(800, 420);
            Controls.Add(tableLayoutPanel1);
            Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Name = "formCreateStockProduct";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Gestionar Producto";
            Load += formCreateStockProduct_Load;
            panel1.ResumeLayout(false);
            panel8.ResumeLayout(false);
            panel8.PerformLayout();
            panel7.ResumeLayout(false);
            panel7.PerformLayout();
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
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
        private Panel panel1;
        private Panel panel5;
        private Panel panel4;
        private Panel panel3;
        private Panel panel2;
        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel6;
        private Panel panel7;
        private Label lblHeader;
        private Panel panel8;
        private ComboBox comboBoxUnits;
    }
}