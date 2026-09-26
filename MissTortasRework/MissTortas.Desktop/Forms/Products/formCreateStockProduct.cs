using MissTortas.Desktop.Events;
using MissTortas.Desktop.Model;
using MissTortas.Desktop.Services.ProductService;
using MissTortas.Desktop.Services.Shared;
using System.Globalization;

namespace MissTortas.Desktop.Forms.Products
{
    public partial class formCreateStockProduct : Form
    {
        private readonly IProductService productService;
        private readonly ProductCategory? productCategory;
        private readonly Product? productToModify;
        private readonly long CategoryId;
        public event EventHandler<StockProductCreatedArgs>? OnStockProductCreated;
        public event EventHandler<StockProductModifiedArgs>? OnStockProductModified;

        public formCreateStockProduct(IProductService productService, ProductCategory? pc, Product? product)
        {
            InitializeComponent();
            this.productService = productService;
            this.productCategory = pc;
            this.productToModify = product;
            if (product != null)
            {
                this.lblHeader.Text = $"Modificando producto {product.Name} ({product.Id}).";
                this.chkEnabled.Checked = product.Enabled;
            }
            else
            {
                this.lblHeader.Text = $"Crear producto.";
            }
            if (pc != null)
            {
                this.lblHeader.Text += $"Categoria {pc.ProductCategoryId}.";
            }
        }
        public formCreateStockProduct(IProductService productService, ProductCategory pc) : this(productService, pc, null) { }
        public formCreateStockProduct(IProductService productService) : this(productService, null, null) { }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private async void formCreateStockProduct_Load(object sender, EventArgs e)
        {
            try
            {
                List<ProductCategory> cats = productCategory != null ? [productCategory] : await productService.GetCategoriesAsync(true, true);
                comboBoxCategory.DataSource = cats;
                comboBoxCategory.DisplayMember = nameof(ProductCategory.Name);
                comboBoxCategory.ValueMember = nameof(ProductCategory.ProductCategoryId);

                if (productToModify != null)
                {
                    this.Text = $"Modificando producto: {productToModify.Id}";
                    this.txtProductName.ReadOnly = true ;
                    this.chkEnabled.Visible = true;
                    this.chkManageQtyAsInteger.Visible = false;
                    ProductToForm(productToModify);
                }
                else
                {
                    this.Text = "Creando producto.";
                    this.chkEnabled.Visible = false;
                    this.chkManageQtyAsInteger.Visible = true;
                }
            }
            catch (ApiException exc)
            {
                ErrorDisplay.Show(this, exc);
                if (exc.StatusCode == System.Net.HttpStatusCode.Forbidden || exc.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    Dispose();
                }
            }
        }

        private void RaiseOnStockProductCreated(Product pc)
        {
            var handler = OnStockProductCreated;
            if (handler == null)
            {
                return;
            }
            handler(this, new StockProductCreatedArgs(pc));
        }

        private void RaiseOnStockProductModified(Product pc)
        {
            var handler = OnStockProductModified;
            if (handler == null)
            {
                return;
            }
            handler(this, new StockProductModifiedArgs(pc));
        }

        private async void btnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                var product = FormToProduct();
                if (productToModify == null)
                {
                    var retrieveProduct = await productService.CreateProductAsync(product);
                    RaiseOnStockProductCreated(retrieveProduct);
                    MessageBox.Show("Producto creado exitosamente", "Producto creado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    product.Id = productToModify.Id;
                    var retrieveProduct = await productService.ModifyProductAsync(product);
                    RaiseOnStockProductModified(retrieveProduct);
                    MessageBox.Show("Producto modificado exitosamente", "Producto modificado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                Dispose();
            }
            catch (ApiException exc)
            {
                ErrorDisplay.Show(this, exc);
                if (exc.StatusCode == System.Net.HttpStatusCode.Forbidden || exc.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    Dispose();
                }
            }
            catch (FormatException exc)
            {
                MessageBox.Show($"{exc.Message}", "No se pudo crear el producto, verifica los datos ingresados.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Product FormToProduct()
        {
            var manageQtyAsInteger = chkManageQtyAsInteger.Checked;
            var qty = ParseQuantity(txtQuantity.Text, manageQtyAsInteger);
            var name = Validation.ValidateAndSanitize(txtProductName.Text, 3, 256);
            var description = Validation.ValidateAndSanitize(txtDescription.Text, 3, 256);
            var unit = Validation.ValidateAndSanitize(txtUnitName.Text, 3, 256);

            if (comboBoxCategory.SelectedItem is not ProductCategory selected)
            {
                throw new InvalidOperationException("Not valid item.");
            }
            var newProduct = new Product
            {
                Name = name,
                Description = description,
                Quantity = qty,
                CategoryId = selected.ProductCategoryId,
                Unit = unit,
                Enabled = chkEnabled.Checked
            };
            return newProduct;
        }

        private void ProductToForm(Product product)
        {
            txtProductName.Text = product.Name;
            txtDescription.Text = product.Description;
            txtQuantity.Text = product.Quantity.ToString();
            txtUnitName.Text = product.Unit;
            chkEnabled.Checked = product.Enabled;
        }

        public static decimal ParseQuantity(string input, bool manageQuantityAsInteger)
        {
            if (!decimal.TryParse(input, NumberStyles.Number, CultureInfo.CurrentCulture, out decimal quantity))
                throw new FormatException($"'{input}' no es una cantidad valida.");

            return manageQuantityAsInteger
                ? Math.Round(quantity, 0, MidpointRounding.AwayFromZero)
                : quantity;
        }
    }
}
