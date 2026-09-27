namespace MissTortas.Desktop.Forms.Products
{
    partial class formProductsFromCategory
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
            components = new System.ComponentModel.Container();
            tlpProductsFromCategory = new TableLayoutPanel();
            dgvProducts = new DataGridView();
            idDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            nameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            descriptionDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            quantityDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            categoryIdDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            manageQuantityAsIntegerDataGridViewCheckBoxColumn = new DataGridViewCheckBoxColumn();
            unitDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            Enabled = new DataGridViewCheckBoxColumn();
            productBindingSource = new BindingSource(components);
            panel2 = new Panel();
            btnRefresh = new Button();
            btnModifyProduct = new Button();
            btnAddProduct = new Button();
            tlpProductsFromCategory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProducts).BeginInit();
            ((System.ComponentModel.ISupportInitialize)productBindingSource).BeginInit();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // tlpProductsFromCategory
            // 
            tlpProductsFromCategory.ColumnCount = 2;
            tlpProductsFromCategory.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 80F));
            tlpProductsFromCategory.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tlpProductsFromCategory.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tlpProductsFromCategory.Controls.Add(dgvProducts, 0, 0);
            tlpProductsFromCategory.Controls.Add(panel2, 1, 0);
            tlpProductsFromCategory.Dock = DockStyle.Fill;
            tlpProductsFromCategory.Location = new Point(0, 0);
            tlpProductsFromCategory.Name = "tlpProductsFromCategory";
            tlpProductsFromCategory.RowCount = 1;
            tlpProductsFromCategory.RowStyles.Add(new RowStyle(SizeType.Percent, 61.77778F));
            tlpProductsFromCategory.Size = new Size(800, 420);
            tlpProductsFromCategory.TabIndex = 0;
            // 
            // dgvProducts
            // 
            dgvProducts.AllowUserToAddRows = false;
            dgvProducts.AllowUserToDeleteRows = false;
            dgvProducts.AllowUserToOrderColumns = true;
            dgvProducts.AutoGenerateColumns = false;
            dgvProducts.BackgroundColor = Color.WhiteSmoke;
            dgvProducts.BorderStyle = BorderStyle.None;
            dgvProducts.CellBorderStyle = DataGridViewCellBorderStyle.Raised;
            dgvProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProducts.Columns.AddRange(new DataGridViewColumn[] { idDataGridViewTextBoxColumn, nameDataGridViewTextBoxColumn, descriptionDataGridViewTextBoxColumn, quantityDataGridViewTextBoxColumn, categoryIdDataGridViewTextBoxColumn, Enabled });
            dgvProducts.DataSource = productBindingSource;
            dgvProducts.Dock = DockStyle.Fill;
            dgvProducts.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgvProducts.GridColor = SystemColors.Window;
            dgvProducts.ImeMode = ImeMode.Disable;
            dgvProducts.Location = new Point(3, 3);
            dgvProducts.MultiSelect = false;
            dgvProducts.Name = "dgvProducts";
            dgvProducts.ReadOnly = true;
            dgvProducts.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Sunken;
            dgvProducts.Size = new Size(634, 414);
            dgvProducts.TabIndex = 0;
            // 
            // idDataGridViewTextBoxColumn
            // 
            idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            idDataGridViewTextBoxColumn.HeaderText = "Identificador";
            idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            idDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            nameDataGridViewTextBoxColumn.HeaderText = "Nombre";
            nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            nameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // descriptionDataGridViewTextBoxColumn
            // 
            descriptionDataGridViewTextBoxColumn.DataPropertyName = "Description";
            descriptionDataGridViewTextBoxColumn.HeaderText = "Descripcion";
            descriptionDataGridViewTextBoxColumn.Name = "descriptionDataGridViewTextBoxColumn";
            descriptionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // quantityDataGridViewTextBoxColumn
            // 
            quantityDataGridViewTextBoxColumn.DataPropertyName = "Quantity";
            quantityDataGridViewTextBoxColumn.HeaderText = "Cantidad Disponible";
            quantityDataGridViewTextBoxColumn.Name = "quantityDataGridViewTextBoxColumn";
            quantityDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // categoryIdDataGridViewTextBoxColumn
            // 
            categoryIdDataGridViewTextBoxColumn.DataPropertyName = "CategoryId";
            categoryIdDataGridViewTextBoxColumn.HeaderText = "Identificador de Categoria";
            categoryIdDataGridViewTextBoxColumn.Name = "categoryIdDataGridViewTextBoxColumn";
            categoryIdDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // Enabled
            // 
            Enabled.DataPropertyName = "Enabled";
            Enabled.HeaderText = "Habilitado";
            Enabled.Name = "Enabled";
            Enabled.ReadOnly = true;
            // 
            // productBindingSource
            // 
            productBindingSource.DataSource = typeof(Model.Product);
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.ControlLight;
            panel2.Controls.Add(btnRefresh);
            panel2.Controls.Add(btnModifyProduct);
            panel2.Controls.Add(btnAddProduct);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(643, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(154, 414);
            panel2.TabIndex = 3;
            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = SystemColors.ControlLightLight;
            btnRefresh.Dock = DockStyle.Top;
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.Location = new Point(0, 60);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(154, 30);
            btnRefresh.TabIndex = 2;
            btnRefresh.Text = "Refrescar";
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // btnModifyProduct
            // 
            btnModifyProduct.BackColor = SystemColors.ControlLightLight;
            btnModifyProduct.Dock = DockStyle.Top;
            btnModifyProduct.FlatStyle = FlatStyle.Flat;
            btnModifyProduct.Location = new Point(0, 30);
            btnModifyProduct.Name = "btnModifyProduct";
            btnModifyProduct.Size = new Size(154, 30);
            btnModifyProduct.TabIndex = 1;
            btnModifyProduct.Text = "Modificar Producto";
            btnModifyProduct.UseVisualStyleBackColor = false;
            btnModifyProduct.Click += btnModifyProduct_Click;
            // 
            // btnAddProduct
            // 
            btnAddProduct.BackColor = SystemColors.ControlLightLight;
            btnAddProduct.Dock = DockStyle.Top;
            btnAddProduct.FlatStyle = FlatStyle.Flat;
            btnAddProduct.Location = new Point(0, 0);
            btnAddProduct.Name = "btnAddProduct";
            btnAddProduct.Size = new Size(154, 30);
            btnAddProduct.TabIndex = 0;
            btnAddProduct.Text = "Agregar Producto";
            btnAddProduct.UseVisualStyleBackColor = false;
            btnAddProduct.Click += btnAddProduct_Click;
            // 
            // formProductsFromCategory
            // 
            AutoScaleDimensions = new SizeF(7F, 14F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 420);
            Controls.Add(tlpProductsFromCategory);
            Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "formProductsFromCategory";
            Text = "Productos";
            Load += formProductsFromCategory_Load;
            tlpProductsFromCategory.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvProducts).EndInit();
            ((System.ComponentModel.ISupportInitialize)productBindingSource).EndInit();
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tlpProductsFromCategory;
        private DataGridView dgvProducts;
        private BindingSource productBindingSource;
        private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn quantityDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn categoryIdDataGridViewTextBoxColumn;
        private DataGridViewCheckBoxColumn manageQuantityAsIntegerDataGridViewCheckBoxColumn;
        private DataGridViewTextBoxColumn unitDataGridViewTextBoxColumn;
        private DataGridViewCheckBoxColumn Enabled;
        private Panel panel2;
        private Button btnRefresh;
        private Button btnAddProduct;
        private Button btnModifyProduct;
    }
}