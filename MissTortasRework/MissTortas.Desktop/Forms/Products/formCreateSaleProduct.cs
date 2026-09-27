using MissTortas.Desktop.Events;
using MissTortas.Desktop.Model;
using MissTortas.Desktop.Services.ProductService;
using MissTortas.Desktop.Services.Shared;
using System.ComponentModel;
using System.Globalization;

namespace MissTortas.Desktop.Forms.Products
{
    public partial class formCreateSaleProduct : Form
    {
        private readonly IProductService productService;
        private readonly SaleProduct? productToModify;
        public event EventHandler<SaleProductCreatedArgs>? OnSaleProductCreated;
        public event EventHandler<SaleProductModifiedArgs>? OnSaleProductModified;
        private List<ProductCategory> categories = [];
        private List<ProductUnit> units = [];
        private readonly Dictionary<string, string> FilesUploaded;
        private readonly BindingList<string> FileNames;

        public formCreateSaleProduct(IProductService productService, SaleProduct? product)
        {
            InitializeComponent();
            this.productService = productService;
            FilesUploaded = [];
            FileNames = [];
            productToModify = product;
            if (productToModify != null)
            {
                lblHeader.Text = $"Modificando producto de venta '{productToModify.Name}' ({productToModify.Id}). Categoria {productToModify.CategoryId}.";
            }
            else
            {
                lblHeader.Text = $"Creando producto de venta.";
            }

        }
        public formCreateSaleProduct(IProductService productService) : this(productService, null) { }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private async void formCreateSaleProduct_Load(object sender, EventArgs e)
        {
            try
            {
                categories = await productService.GetCategoriesAsync(true, true);
                units = await productService.GetUnitsAsync();
                if(productToModify != null)
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
                openFilesList.DataSource = FileNames;
                if(categories.Count <= 0)
                {
                    btnConfirm.Enabled = false;
                }
                if (productToModify != null)
                {
                    Text = $"Modificando producto de venta: {productToModify.Id}";
                    chkEnabled.Visible = true;
                    chkEnabled.Checked = productToModify.Enabled;
                    SaleProductToForm(productToModify);
                }
                else
                {
                    Text = "Creando nuevo producto para la venta";
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

        private void RaiseOnSaleProductCreated(SaleProduct pc)
        {
            var handler = OnSaleProductCreated;
            if (handler == null)
            {
                return;
            }
            handler(this, new SaleProductCreatedArgs(pc));
        }

        private void RaiseOnSaleProductModified(SaleProduct pc)
        {
            var handler = OnSaleProductModified;
            if (handler == null)
            {
                return;
            }
            handler(this, new SaleProductModifiedArgs(pc));
        }

        private async void btnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                var product = FormToSaleProduct();
                if (productToModify == null)
                {
                    var retrieveProduct = await productService.CreateSaleProductAsync(product, FilesUploaded);
                    RaiseOnSaleProductCreated(retrieveProduct);
                    MessageBox.Show("Producto creado exitosamente", "Producto creado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    product.Id = productToModify.Id;
                    var retrieveProduct = await productService.ModifySaleProductAsync(product, FilesUploaded);
                    RaiseOnSaleProductModified(retrieveProduct);
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
            catch (FileNotFoundException ex)
            {
                MessageBox.Show($"Archivo no encontrado: {ex.Message}", "Error");
            }
            catch (UnauthorizedAccessException ex)
            {
                MessageBox.Show($"Acceso denegado al archivo {ex.Message}", "Error");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "Error");
            }
        }

        private SaleProduct FormToSaleProduct()
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
            var price = ParseQuantity(txtPrice.Text, false);
            var newProduct = new SaleProduct
            {
                Name = name,
                Description = description,
                Quantity = qty,
                CategoryId = selectedCategory.ProductCategoryId,
                UnitId = selectedUnit.Id,
                Enabled = chkEnabled.Checked,
                SalePrice = price
            };
            return newProduct;
        }

        private void SaleProductToForm(SaleProduct product)
        {
            txtProductName.Text = product.Name;
            txtDescription.Text = product.Description;
            txtQuantity.Text = product.Quantity.ToString();
            chkEnabled.Checked = product.Enabled;
            txtPrice.Text = product.SalePrice.ToString();
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

        private void btnUpload_Click(object sender, EventArgs e)
        {
            ofdFiles.Filter = "Image files (*.jpg;*.png;*.gif)|*.jpg;*.png;*.gif";
            ofdFiles.CheckFileExists = true;
            ofdFiles.Title = "Seleccionar archivos";
            ofdFiles.Multiselect = true;

            if (ofdFiles.ShowDialog() == DialogResult.OK)
            {
                var filePaths = ofdFiles.FileNames;
                foreach (var fp in filePaths)
                {
                    var filename = Path.GetFileName(fp);
                    FilesUploaded.Add(filename, fp);
                    FileNames.Add(filename);
                }
            }

        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (openFilesList.SelectedItem is string fileSelected)
            {
                FilesUploaded.Remove(fileSelected);
                FileNames.Remove(fileSelected);
            }
        }
    }
}
