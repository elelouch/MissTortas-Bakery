using MissTortas.Desktop.Events;
using MissTortas.Desktop.Model;
using MissTortas.Desktop.Services.ProductService;
using MissTortas.Desktop.Services.Shared;

namespace MissTortas.Desktop.Forms.Products
{
    public partial class formCreateCategory : Form
    {
        private readonly IProductService productService;
        private readonly ProductCategory? parentCategory;
        public event EventHandler<CategoryCreatedArgs>? OnCategoryCreated;

        public formCreateCategory(ProductCategory? parentCategory, IProductService productService)
        {
            InitializeComponent();
            this.productService = productService;
            this.parentCategory = parentCategory;
            if (parentCategory != null)
            {
                this.Text = $"Creando categoría hija para la categoria ({parentCategory.ProductCategoryId}) - {parentCategory.Name}";
            }
            else
            {
                this.Text = $"Creando categoría raíz.";
            }
        }

        private async void btnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                var name = Validation.ValidateAndSanitize(txtCategoryName.Text, 3, 256, "Nombre");
                var newCategory = new ProductCategory
                {
                    Name = name,
                    IsFinal = chkFinalCategory.Checked,
                    ParentId = parentCategory?.ProductCategoryId
                };
                var resultCategory = await productService.CreateProductCategoryAsync(newCategory) ?? throw new InvalidOperationException("Result category is null.");
                RaiseOnCategoryCreated(resultCategory);
                MessageBox.Show(
                     $"La categoría '{newCategory.Name}' ha sido creada",
                     "Categoría creada exitosamente",
                     MessageBoxButtons.OK,
                     MessageBoxIcon.Information
                 );
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
                MessageBox.Show(
                    $"{exc.Message}",
                    "Nombre de categoría incorrecto",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }

        }
        private void RaiseOnCategoryCreated(ProductCategory cat)
        {
            var handler = OnCategoryCreated;
            if (handler == null)
            {
                return;
            }
            handler(this, new CategoryCreatedArgs(cat));
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}
