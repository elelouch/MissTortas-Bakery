using MissTortas.Desktop.Model;
using MissTortas.Desktop.Services.ProductService;
using MissTortas.Desktop.Services.Shared;
using System.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace MissTortas.Desktop.Forms.Products
{
    public partial class formProductsFromCategory : Form
    {
        private readonly ProductCategory? productCategory;
        private readonly IProductService productService;
        private BindingList<Product> products = [];
        private List<Product> allProducts = [];
        public formProductsFromCategory(IProductService productService, ProductCategory? category)
        {
            InitializeComponent();
            this.productCategory = category;
            this.productService = productService;
        }
        public formProductsFromCategory(IProductService productService) : this(productService, null)
        {
        }
        private async void LoadGrid()
        {
            try
            {
                if (productCategory != null)
                {
                    this.Text = $"Productos de la categoria: '{productCategory.Name}'({productCategory.ProductCategoryId}) -";
                    var productsFromService = await productService.GetProductsFromCategoryAsync(productCategory.ProductCategoryId);
                    allProducts = [.. productsFromService];
                    this.products = new BindingList<Product>(allProducts);
                    dgvProducts.DataSource = this.products;
                }
                else
                {
                    this.Text = $"Productos";
                    var productsFromService = await productService.GetAllProductsAsync();
                    allProducts = productsFromService.ToList();
                    this.products = new BindingList<Product>(allProducts);
                    dgvProducts.DataSource = this.products;
                }
                if (this.products.Count > 0)
                {
                    var firstRow = dgvProducts.Rows[0];
                    firstRow.Selected = true;
                    dgvProducts.CurrentCell = firstRow.Cells[0];
                }
            }
            catch (ApiException exc)
            {
                ErrorDisplay.Show(this, exc);
                if (exc.StatusCode == HttpStatusCode.Forbidden || exc.StatusCode == HttpStatusCode.Unauthorized)
                {
                    this.Dispose();
                }
            }
        }
        private async void formProductsFromCategory_Load(object sender, EventArgs e)
        {
            LoadGrid();
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            var createProductForm = new formCreateStockProduct(productService);
            createProductForm.OnStockProductCreated += CreateProductForm_OnStockProductCreated;
            createProductForm.ShowDialog();
        }

        private void CreateProductForm_OnStockProductCreated(object? sender, Events.StockProductCreatedArgs e)
        {
            products.Add(e.Product);
        }

        private void btnModifyProduct_Click(object sender, EventArgs e)
        {
            if (dgvProducts.SelectedRows.Count <= 0)
            {
                MessageBox.Show("Por favor, seleccione un producto.", "Seleccione un producto.");
                return;
            }
            if (dgvProducts.SelectedRows[0].DataBoundItem is not Product product)
                return;

            var modifyProductForm = new formCreateStockProduct(productService, product);
            modifyProductForm.OnStockProductModified += ModifyProductForm_OnStockProductModified;
            modifyProductForm.ShowDialog();
        }

        private void ModifyProductForm_OnStockProductModified(object? sender, Events.StockProductModifiedArgs e)
        {
            var p = products.FirstOrDefault(p => p.Id == e.Product.Id);
            if (p is null)
            {
                return;
            }
            products[products.IndexOf(p)] = e.Product;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadGrid();
        }

        private void lblProductName_Click(object sender, EventArgs e)
        {

        }

        private void txtProductName_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Schedule filtering after the key press is processed so txtProductName.Text
            // already contains the new character.
            this.BeginInvoke(new Action(() => FilterProductsByName(txtProductName.Text)));
        }
        private void FilterProductsByName(string filter)
        {
            IEnumerable<Product> filtered;

            if (string.IsNullOrWhiteSpace(filter))
            {
                filtered = allProducts;
            }
            else
            {
                filtered = allProducts.Where(p => !string.IsNullOrEmpty(p.Name) && p.Name.IndexOf(filter, StringComparison.OrdinalIgnoreCase) >= 0);
            }

            var previousSelectedId = (dgvProducts.SelectedRows.Count > 0 && dgvProducts.SelectedRows[0].DataBoundItem is Product sel) ? sel.Id : (long?)null;

            products = new BindingList<Product>(filtered.ToList());
            dgvProducts.DataSource = products;

            if (previousSelectedId.HasValue)
            {
                var toSelect = products.FirstOrDefault(p => p.Id == previousSelectedId.Value);
                if (toSelect != null)
                {
                    var index = products.IndexOf(toSelect);
                    if (index >= 0 && index < dgvProducts.Rows.Count)
                    {
                        var row = dgvProducts.Rows[index];
                        row.Selected = true;
                        dgvProducts.CurrentCell = row.Cells[0];
                        return;
                    }
                }
            }

            if (products.Count > 0)
            {
                var firstRow = dgvProducts.Rows[0];
                firstRow.Selected = true;
                dgvProducts.CurrentCell = firstRow.Cells[0];
            }
            else
            {
                dgvProducts.CurrentCell = null;
            }
        }
    }
}
