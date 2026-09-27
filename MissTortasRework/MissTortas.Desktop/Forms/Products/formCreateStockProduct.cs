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
        private readonly Product? productToModify;
        private List<ProductCategory> categories = [];
        private List<ProductUnit> units = [];
        public event EventHandler<StockProductCreatedArgs>? OnStockProductCreated;
        public event EventHandler<StockProductModifiedArgs>? OnStockProductModified;

        public formCreateStockProduct(IProductService productService, Product? product)
        {
            InitializeComponent();
            this.productService = productService;
            productToModify = product;
            if (productToModify != null)
            {
                lblHeader.Text += $"";
                lblHeader.Text = $"Modificando producto {productToModify.Name} ({productToModify.Id}).Categoria {productToModify.CategoryId}.";
                chkEnabled.Checked = productToModify.Enabled;
            }
            else
            {
                lblHeader.Text = $"Creando producto.";
            }

        }
        public formCreateStockProduct(IProductService productService) : this(productService, null) { }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private async void formCreateStockProduct_Load(object sender, EventArgs e)
        {
            try
            {
                categories = await productService.GetCategoriesAsync(true, true);
                units = await productService.GetUnitsAsync();
                if (productToModify != null)
                {
                    categories = [.. categories.Where(c => c.ProductCategoryId == productToModify.CategoryId)];
                    units = [.. units.Where(c => c.Id == productToModify.UnitId)];
                }
                comboBoxCategory.DataSource = categories;
                comboBoxUnits.DataSource = units;
                comboBoxUnits.DisplayMember = nameof(ProductUnit.Name);
                comboBoxUnits.ValueMember = nameof(ProductUnit.Id);
                comboBoxCategory.DisplayMember = nameof(ProductCategory.Name);
                comboBoxCategory.ValueMember = nameof(ProductCategory.ProductCategoryId);

                if(categories.Count <= 0)
                {

                }

                if (productToModify != null)
                {
                    Text = $"Modificando producto: {productToModify.Id}";
                    txtProductName.ReadOnly = true ;
                    chkEnabled.Visible = true;
                    ProductToForm(productToModify);
                }
                else
                {
                    Text = "Creando producto.";
                    chkEnabled.Visible = false;
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
            var name = Validation.ValidateAndSanitize(txtProductName.Text, 3, 256, "Nombre");
            var description = Validation.ValidateAndSanitize(txtDescription.Text, 3, 256, "Descripcion");

            if (comboBoxCategory.SelectedItem is not ProductCategory selectedCategory)
            {
                throw new FormatException("La categoria seleccionada no es valida. Debe asegurarse que existen categorias cargadas y se selecciono una valida.");
            }
            if (comboBoxUnits.SelectedItem is not ProductUnit selectedUnit)
            {
                throw new FormatException("La unidad seleccionada no es valida. Debe asegurarse que existen unidades cargadas y se selecciono una valida.");
            }
            var qty = ParseQuantity(txtQuantity.Text, selectedUnit.TreatAsInteger);
            var newProduct = new Product
            {
                Name = name,
                Description = description,
                Quantity = qty,
                CategoryId = selectedCategory.ProductCategoryId,
                UnitId = selectedUnit.Id,
                Enabled = chkEnabled.Checked
            };
            return newProduct;
        }

        private void ProductToForm(Product product)
        {
            txtProductName.Text = product.Name;
            txtDescription.Text = product.Description;
            txtQuantity.Text = product.Quantity.ToString();
            chkEnabled.Checked = product.Enabled;
        }

        public static decimal ParseQuantity(string input, bool manageQuantityAsInteger)
        {
            if (!decimal.TryParse(input, NumberStyles.Number, CultureInfo.CurrentCulture, out decimal quantity))
                throw new FormatException($"Revise el campo de cantidad. '{input}' no es una cantidad valida.");
            var rounded = Math.Round(quantity, 0, MidpointRounding.AwayFromZero);
            if (manageQuantityAsInteger && rounded != quantity)
                throw new FormatException($"La cantidad esta configurada para ser tratada como unidad.");

            return manageQuantityAsInteger
                ? Math.Round(quantity, 0, MidpointRounding.AwayFromZero)
                : quantity;
        }
    }
}
