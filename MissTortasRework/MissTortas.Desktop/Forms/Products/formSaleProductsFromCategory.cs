using MissTortas.Desktop.Model;
using MissTortas.Desktop.Services.ProductService;
using MissTortas.Desktop.Services.Shared;
using System.ComponentModel;
using System.Net;

namespace MissTortas.Desktop.Forms.Products
{
    public partial class formSaleProductsFromCategory : Form
    {
        private readonly ProductCategory? productCategory;
        private readonly IProductService productService;
        private BindingList<SaleProduct> products = [];
        public formSaleProductsFromCategory(IProductService productService, ProductCategory? category)
        {
            InitializeComponent();
            this.productCategory = category;
            this.productService = productService;
        }
        public formSaleProductsFromCategory(IProductService productService) : this(productService, null)
        {
        }

        private async void LoadGrid()
        {
            try
            {
                if (productCategory != null)
                {
                    this.Text = $"Products from ({productCategory.ProductCategoryId}) - {productCategory.Name}";
                    var products = await productService.GetSaleProductsFromCategoryAsync(productCategory.ProductCategoryId);
                    this.products = [.. products];
                    dgvProducts.DataSource = this.products;
                }
                else
                {
                    this.Text = $"Products";
                    var products = await productService.GetAllSaleProductsAsync();
                    this.products = [.. products];
                    dgvProducts.DataSource = this.products;
                }
                if (products.Count > 0)
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
            var createProductForm = new formCreateSaleProduct(productService);

            createProductForm.OnSaleProductCreated += CreateProductForm_OnSaleProductCreated;
            createProductForm.ShowDialog();
        }

        private void CreateProductForm_OnSaleProductCreated(object? sender, Events.SaleProductCreatedArgs e)
        {
            products.Add(e.SaleProduct);
        }

        private void btnModifyProduct_Click(object sender, EventArgs e)
        {
            if (dgvProducts.SelectedRows.Count <= 0)
            {
                MessageBox.Show("Please, select a product", "Select a product");
                return;
            }
            if (dgvProducts.SelectedRows[0].DataBoundItem is not SaleProduct product)
                return;

            var modifyProductForm = new formCreateSaleProduct(productService, product);
            modifyProductForm.OnSaleProductModified += ModifyProductForm_OnSaleProductModified;
            modifyProductForm.ShowDialog();
        }

        private void ModifyProductForm_OnSaleProductModified(object? sender, Events.SaleProductModifiedArgs e)
        {
            var p = products.FirstOrDefault(p => p.Id == e.SaleProduct.Id);
            if (p is null)
            {
                return;
            }
            products[products.IndexOf(p)] = e.SaleProduct;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadGrid();
        }
    }
}
