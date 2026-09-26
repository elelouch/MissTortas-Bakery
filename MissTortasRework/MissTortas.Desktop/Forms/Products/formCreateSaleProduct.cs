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
        private readonly ProductCategory? productCategory;
        private readonly SaleProduct? productToModify;
        private readonly long CategoryId;
        public event EventHandler<SaleProductCreatedArgs>? OnSaleProductCreated;
        public event EventHandler<SaleProductModifiedArgs>? OnSaleProductModified;
        private readonly Dictionary<string, string> FilesUploaded;
        private readonly BindingList<string> FileNames;

        public formCreateSaleProduct(IProductService productService, ProductCategory? pc, SaleProduct? product)
        {
            InitializeComponent();
            this.productService = productService;
            this.productCategory = pc;
            this.productToModify = product;
            this.FilesUploaded = [];
            this.FileNames = [];
            if (product != null)
            {
                this.lblHeader.Text = $"Modificando producto de venta '{product.Name}' ({product.Id}).";
            }
            else
            {
                this.lblHeader.Text = $"Crear producto de venta.";
            }
            if (pc != null)
            {
                this.lblHeader.Text += $"Categoria {pc.ProductCategoryId}.";
            }
        }
        public formCreateSaleProduct(IProductService productService, ProductCategory pc) : this(productService, pc, null) { }
        public formCreateSaleProduct(IProductService productService) : this(productService, null, null) { }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private async void formCreateSaleProduct_Load(object sender, EventArgs e)
        {
            try
            {
                List<ProductCategory> cats = productCategory != null ? [productCategory] : await productService.GetCategoriesAsync(true, true);
                comboBoxCategory.DataSource = cats;
                comboBoxCategory.DisplayMember = nameof(ProductCategory.Name);
                comboBoxCategory.ValueMember = nameof(ProductCategory.ProductCategoryId);
                openFilesList.DataSource = FileNames;

                if (productToModify != null)
                {
                    this.Text = $"Modificando producto de venta: {productToModify.Id}";
                    this.chkEnabled.Visible = true;
                    this.chkEnabled.Checked = productToModify.Enabled;
                    this.chkManageQtyAsInteger.Visible = false;
                    SaleProductToForm(productToModify);
                }
                else
                {
                    this.Text = "Creando nuevo producto para la venta";
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
            var manageQtyAsInteger = chkManageQtyAsInteger.Checked;
            var qty = ParseQuantity(txtQuantity.Text, manageQtyAsInteger);
            var name = Validation.ValidateAndSanitize(txtProductName.Text, 3, 256);
            var description = Validation.ValidateAndSanitize(txtDescription.Text, 3, 256);
            var unit = Validation.ValidateAndSanitize(txtUnitName.Text, 0, 256);
            var price = ParseQuantity(txtPrice.Text, null);
            if (comboBoxCategory.SelectedItem is not ProductCategory selected)
            {
                throw new InvalidOperationException("La categoria seleccionada no es valida.");
            }
            var newProduct = new SaleProduct
            {
                Name = name,
                Description = description,
                Quantity = qty,
                CategoryId = selected.ProductCategoryId,
                Unit = unit,
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
            txtUnitName.Text = product.Unit;
            chkEnabled.Checked = product.Enabled;
            txtPrice.Text = product.SalePrice.ToString();
        }

        public static decimal ParseQuantity(string input, bool? manageQuantityAsInteger)
        {
            if (!decimal.TryParse(input, NumberStyles.Number, CultureInfo.CurrentCulture, out decimal quantity))
                throw new FormatException($"'{input}' no es una cantidad valida.");

            if (manageQuantityAsInteger is bool manageqty)
            {
                return manageqty
                        ? Math.Round(quantity, 0, MidpointRounding.AwayFromZero)
                        : quantity;
            }
            return Math.Round(quantity, 0, MidpointRounding.AwayFromZero);
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
