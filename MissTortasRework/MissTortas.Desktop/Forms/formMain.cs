using MissTortas.Desktop.Forms.Orders;
using MissTortas.Desktop.Forms.Products;
using MissTortas.Desktop.Forms.Roles;
using MissTortas.Desktop.Forms.Users;
using MissTortas.Desktop.Services.AuthService;
using MissTortas.Desktop.Services.OrdersService;
using MissTortas.Desktop.Services.PermissionService;
using MissTortas.Desktop.Services.ProductService;
using MissTortas.Desktop.Services.RoleService;
using MissTortas.Desktop.Services.Shared;
using MissTortas.Desktop.Services.UserService;

namespace MissTortas.Desktop.Forms
{
    public partial class formMain : Form
    {
        private readonly IMissTortasHttpClient httpClient;
        private readonly IRoleService roleService;
        private readonly IUserService usersService;
        private readonly IAuthService authService;
        private readonly IPermissionService permissionService;
        private readonly IProductService productService;
        private readonly IOrderService orderService;

        private formUsers? formUsers;
        private formRoles? formRoles;
        private formCategories? formCategories;
        private formOrders? formOrders;
        private formProducts? formProducts;
        private formPreparations? formPreparations;

        public formMain(
            IMissTortasHttpClient httpClient,
            IUserService usersService,
            IAuthService authService,
            IRoleService roleService,
            IPermissionService permissionService,
            IProductService productService,
            IOrderService orderService
        )
        {
            InitializeComponent();
            this.httpClient = httpClient;
            this.usersService = usersService;
            this.authService = authService;
            this.roleService = roleService;
            this.permissionService = permissionService;
            this.productService = productService;
            this.orderService = orderService;
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void formMain_Shown(object sender, EventArgs e)
        {
            ShowLogin();
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (formUsers == null)
            {
                this.formUsers = new formUsers(usersService, authService, permissionService)
                {
                    MdiParent = this
                };
                this.formUsers.Show();
                this.formUsers.Disposed += FormUsers_Disposed;
            }
            else
            {
                this.formUsers.WindowState = FormWindowState.Normal;
                this.formUsers.BringToFront();
            }

        }

        private void FormUsers_Disposed(object? sender, EventArgs e)
        {
            this.formUsers = null;
        }

        private void rolesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (formRoles == null)
            {
                this.formRoles = new formRoles(roleService, permissionService)
                {
                    MdiParent = this
                };
                this.formRoles.Show();
                this.formRoles.Disposed += FormRoles_Disposed;
            }
            else
            {
                this.formRoles.WindowState = FormWindowState.Normal;
                this.formRoles.BringToFront();
            }
        }

        private void FormRoles_Disposed(object? sender, EventArgs e)
        {
            this.formRoles = null;
        }

        private void categoriesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (formCategories == null)
            {
                this.formCategories = new formCategories(productService)
                {
                    MdiParent = this
                };
                this.formCategories.Show();
                this.formCategories.Disposed += FormProducts_Disposed;
            }
            else
            {
                this.formCategories.WindowState = FormWindowState.Normal;
                this.formCategories.BringToFront();
            }
        }

        private void FormProducts_Disposed(object? sender, EventArgs e)
        {
            this.formCategories = null;
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (var child in this.MdiChildren)
            {
                child.Close();
            }
            ShowLogin();
        }

        private void ShowLogin()
        {
            formLogin appLogin = new(authService);
            mainMenuStrip.Visible = false;
            var dialogRes = appLogin.ShowDialog();
            if (dialogRes != DialogResult.OK)
            {
                this.Dispose();
            }
            mainMenuStrip.Visible = true;
        }

        private void productsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var productsForm = new formProducts(productService)
            {
                MdiParent = this
            };
            productsForm.Show();
            if (formProducts == null)
            {
                formProducts = new formProducts(productService)
                {
                    MdiParent = this
                };
                formProducts.Show();
                formProducts.Disposed += FormProducts_Disposed;
            }
            else
            {
                formProducts.WindowState = FormWindowState.Normal;
                formProducts.BringToFront();
            }
        }

        private void orderManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.formOrders == null)
            {
                this.formOrders = new formOrders(orderService, usersService)
                {
                    MdiParent = this
                };
                this.formOrders.Show();
                this.formOrders.Disposed += FormOrders_Disposed;
            }
            else
            {
                this.formOrders.WindowState = FormWindowState.Normal;
                this.formOrders.BringToFront();
            }

        }

        private void FormOrders_Disposed(object? sender, EventArgs e)
        {
            formOrders = null;
        }

        private void preparationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.formPreparations == null)
            {
                this.formPreparations = new formPreparations(orderService)
                {
                    MdiParent = this
                };
                this.formPreparations.Show();
                this.formPreparations.Disposed += FormPreparations_Disposed; ;
            }
            else
            {
                this.formPreparations.WindowState = FormWindowState.Normal;
                this.formPreparations.BringToFront();
            }
        }

        private void FormPreparations_Disposed(object? sender, EventArgs e)
        {
            formPreparations = null;
        }

        private void formMain_Load(object sender, EventArgs e)
        {
        }
    }
}
