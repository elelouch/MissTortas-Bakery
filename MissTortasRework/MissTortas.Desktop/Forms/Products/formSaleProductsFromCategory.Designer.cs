namespace MissTortas.Desktop.Forms.Products
{
    partial class formSaleProductsFromCategory
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
            Id = new DataGridViewTextBoxColumn();
            SaleProductName = new DataGridViewTextBoxColumn();
            descriptionDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            quantityDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            salePriceDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            stockProductIdDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            saleProductBindingSource = new BindingSource(components);
            panel1 = new Panel();
            btnRefresh = new Button();
            btnModifyProduct = new Button();
            btnAddProduct = new Button();
            panel2 = new Panel();
            txtProductName = new TextBox();
            label1 = new Label();
            productBindingSource = new BindingSource(components);
            tlpProductsFromCategory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProducts).BeginInit();
            ((System.ComponentModel.ISupportInitialize)saleProductBindingSource).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)productBindingSource).BeginInit();
            SuspendLayout();
            // 
            // tlpProductsFromCategory
            // 
            tlpProductsFromCategory.ColumnCount = 2;
            tlpProductsFromCategory.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 80F));
            tlpProductsFromCategory.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tlpProductsFromCategory.Controls.Add(dgvProducts, 0, 1);
            tlpProductsFromCategory.Controls.Add(panel1, 1, 1);
            tlpProductsFromCategory.Controls.Add(panel2, 0, 0);
            tlpProductsFromCategory.Dock = DockStyle.Fill;
            tlpProductsFromCategory.Location = new Point(0, 0);
            tlpProductsFromCategory.Name = "tlpProductsFromCategory";
            tlpProductsFromCategory.RowCount = 2;
            tlpProductsFromCategory.RowStyles.Add(new RowStyle(SizeType.Percent, 15F));
            tlpProductsFromCategory.RowStyles.Add(new RowStyle(SizeType.Percent, 85F));
            tlpProductsFromCategory.Size = new Size(800, 420);
            tlpProductsFromCategory.TabIndex = 0;
            // 
            // dgvProducts
            // 
            dgvProducts.AllowUserToAddRows = false;
            dgvProducts.AllowUserToDeleteRows = false;
            dgvProducts.AutoGenerateColumns = false;
            dgvProducts.BackgroundColor = Color.WhiteSmoke;
            dgvProducts.BorderStyle = BorderStyle.None;
            dgvProducts.CellBorderStyle = DataGridViewCellBorderStyle.Raised;
            dgvProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProducts.Columns.AddRange(new DataGridViewColumn[] { Id, SaleProductName, descriptionDataGridViewTextBoxColumn, quantityDataGridViewTextBoxColumn, salePriceDataGridViewTextBoxColumn, stockProductIdDataGridViewTextBoxColumn });
            dgvProducts.DataSource = saleProductBindingSource;
            dgvProducts.Dock = DockStyle.Fill;
            dgvProducts.Location = new Point(3, 66);
            dgvProducts.Name = "dgvProducts";
            dgvProducts.ReadOnly = true;
            dgvProducts.Size = new Size(634, 351);
            dgvProducts.TabIndex = 0;
            // 
            // Id
            // 
            Id.DataPropertyName = "Id";
            Id.HeaderText = "Identificador";
            Id.Name = "Id";
            Id.ReadOnly = true;
            // 
            // SaleProductName
            // 
            SaleProductName.DataPropertyName = "Name";
            SaleProductName.HeaderText = "Nombre";
            SaleProductName.Name = "SaleProductName";
            SaleProductName.ReadOnly = true;
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
            // salePriceDataGridViewTextBoxColumn
            // 
            salePriceDataGridViewTextBoxColumn.DataPropertyName = "SalePrice";
            salePriceDataGridViewTextBoxColumn.HeaderText = "Precio de venta";
            salePriceDataGridViewTextBoxColumn.Name = "salePriceDataGridViewTextBoxColumn";
            salePriceDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // stockProductIdDataGridViewTextBoxColumn
            // 
            stockProductIdDataGridViewTextBoxColumn.DataPropertyName = "StockProductId";
            stockProductIdDataGridViewTextBoxColumn.HeaderText = "Identificador de Producto de Stock";
            stockProductIdDataGridViewTextBoxColumn.Name = "stockProductIdDataGridViewTextBoxColumn";
            stockProductIdDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // saleProductBindingSource
            // 
            saleProductBindingSource.DataSource = typeof(Model.SaleProduct);
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ControlLight;
            panel1.Controls.Add(btnRefresh);
            panel1.Controls.Add(btnModifyProduct);
            panel1.Controls.Add(btnAddProduct);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(643, 66);
            panel1.Name = "panel1";
            panel1.Size = new Size(154, 351);
            panel1.TabIndex = 2;
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
            // panel2
            // 
            panel2.Controls.Add(txtProductName);
            panel2.Controls.Add(label1);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(3, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(634, 57);
            panel2.TabIndex = 3;
            // 
            // txtProductName
            // 
            txtProductName.Dock = DockStyle.Bottom;
            txtProductName.Location = new Point(0, 35);
            txtProductName.Name = "txtProductName";
            txtProductName.Size = new Size(634, 22);
            txtProductName.TabIndex = 1;
            txtProductName.KeyPress += txtProductName_KeyPress;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Top;
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(122, 14);
            label1.TabIndex = 0;
            label1.Text = "Nombre de Producto";
            // 
            // productBindingSource
            // 
            productBindingSource.DataSource = typeof(Model.Product);
            // 
            // formSaleProductsFromCategory
            // 
            AutoScaleDimensions = new SizeF(7F, 14F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 420);
            Controls.Add(tlpProductsFromCategory);
            Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "formSaleProductsFromCategory";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Productos a la venta";
            Load += formProductsFromCategory_Load;
            tlpProductsFromCategory.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvProducts).EndInit();
            ((System.ComponentModel.ISupportInitialize)saleProductBindingSource).EndInit();
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)productBindingSource).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tlpProductsFromCategory;
        private DataGridView dgvProducts;
        private BindingSource productBindingSource;
        private Button btnAddProduct;
        private Button btnModifyProduct;
        private BindingSource saleProductBindingSource;
        private Button btnRefresh;
        private Panel panel1;
        private DataGridViewTextBoxColumn Id;
        private DataGridViewTextBoxColumn SaleProductName;
        private DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn quantityDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn salePriceDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn stockProductIdDataGridViewTextBoxColumn;
        private Panel panel2;
        private Label label1;
        private TextBox txtProductName;
    }
}