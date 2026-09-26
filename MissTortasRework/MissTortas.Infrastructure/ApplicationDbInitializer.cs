using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MissTortas.Domain.Products;
using MissTortas.Domain.Security.Users;
using MissTortas.Infrastructure.Context;
using MissTortas.Infrastructure.Entity;
using MissTortas.Infrastructure.Security.Identity;
using MissTortas.Infrastructure.Security.Permissions;
using MissTortas.Services;
using MissTortas.Services.DTO.Orders;
using MissTortas.Services.Interfaces;
using System.Security.Claims;


namespace MissTortas.Infrastructure
{
    public static class ApplicationDbInitializer
    {
        public static async Task SeedPermissionsAsync(IServiceProvider services)
        {
            var roleManager = services.GetRequiredService<RoleManager<ApplicationRole>>();

            var adminRole = await GetRoleOrThrowAsync(roleManager, UserConstants.AdminRoleName);
            await AddPermissionsToRoleAsync(roleManager, adminRole, Permission.All);

            var userRole = await GetRoleOrThrowAsync(roleManager, UserConstants.UserRoleName);
            await AddPermissionsToRoleAsync(roleManager, userRole, [Permission.ReadSelfUser]);
        }

        private static async Task<ApplicationRole> GetRoleOrThrowAsync(RoleManager<ApplicationRole> roleManager, string roleName)
        {
            return await roleManager.FindByNameAsync(roleName)
                ?? throw new InvalidOperationException($"{roleName} role not seeded.");
        }

        private static async Task AddPermissionsToRoleAsync(RoleManager<ApplicationRole> roleManager, ApplicationRole role, IEnumerable<Permission> permissions)
        {
            var existingPermissions = (await roleManager.GetClaimsAsync(role))
                .Where(c => c.Type == Permission.ClaimName)
                .Select(c => c.Value)
                .ToHashSet();

            foreach (var permission in permissions)
            {
                if (!existingPermissions.Contains(permission.Code))
                {
                    await roleManager.AddClaimAsync(role, new Claim(Permission.ClaimName, permission.Code));
                }
            }
        }

        public static async Task SeedDatabaseAsync(IServiceProvider services)
        {
            var dbContext = services.GetRequiredService<MissTortasContext>();
            await dbContext.Database.EnsureCreatedAsync();
            dbContext.Database.Migrate();
            await SeedRolesAsync(services);
            await SeedUsersAsync(services);
            await SeedPermissionsAsync(services);
            await SeedOrderTypes(services);
        }

        public static async Task SeedOrderTypes(IServiceProvider services)
        {
            var orderService = services.GetRequiredService<IOrderService>();
            List<CreateOrderTypeDTO> orderTypeList = [new CreateOrderTypeDTO { Name = "Default" }, new CreateOrderTypeDTO { Name = "Personalized" }];
            foreach (var ot in orderTypeList)
            {
                await orderService.CreateOrderTypeAsync(ot);
            }

        }
        public static async Task SeedUnitsAsync(IServiceProvider services)
        {
            using var scope = services.CreateScope();
            var productService = services.GetRequiredService<ProductService>();

            UnitDTO[] units = [
                new UnitDTO { Id = 1, Name = "unidad", TreatAsInteger = true},
                new UnitDTO { Id = 2, Name = "kilogramo", TreatAsInteger = false},
                new UnitDTO { Id = 3, Name = "litro", TreatAsInteger = false}
            ];

            foreach(var unit in units)
            {
                await productService.CreateUnitAsync(unit);
            }
            
        }

        public static async Task SeedRolesAsync(IServiceProvider services)
        {
            using var scope = services.CreateScope();

            var context = scope.ServiceProvider.GetRequiredService<MissTortasContext>();
            var roleManager = services.GetRequiredService<RoleManager<ApplicationRole>>();

            // Define required roles
            var requiredRoles = new[]
            {
                UserConstants.AdminRoleName,
                UserConstants.UserRoleName,
                UserConstants.GuestRoleName
            };

            foreach (var roleName in requiredRoles)
            {
                await EnsureRoleExistsAsync(roleName, context, roleManager);
            }
        }

        private static async Task EnsureRoleExistsAsync(string roleName, MissTortasContext context, RoleManager<ApplicationRole> roleManager)
        {
            var domainRole = await context.DomainRoles.FirstOrDefaultAsync(r => r.Name == roleName);
            if (domainRole is null)
            {
                domainRole = new Role { Name = roleName };
                await context.DomainRoles.AddAsync(domainRole);
                await context.SaveChangesAsync();
            }
            var appRole = await roleManager.FindByNameAsync(roleName);
            if (appRole is null)
            {
                appRole = new ApplicationRole { RoleId = domainRole.RoleId, Name = roleName };
                await roleManager.CreateAsync(appRole);
            }
        }

        public async static Task SeedUsersAsync(IServiceProvider services)
        {
            using var scope = services.CreateScope();

            var context = scope.ServiceProvider.GetRequiredService<MissTortasContext>();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            var domainUser = await context.DomainUsers.FirstOrDefaultAsync(u => u.FirstName == UserConstants.AdminUserName && u.LastName == UserConstants.AdminUserName);
            if (domainUser == null)
            {
                var role = await context.DomainRoles.Where(dr => dr.Name.ToUpper() == UserConstants.AdminRoleName.ToUpper()).SingleAsync();
                domainUser = new User
                {
                    FirstName = UserConstants.AdminUserName,
                    LastName = UserConstants.AdminUserName,
                    Birthday = new DateOnly(2000, 1, 1)
                };
                domainUser.Roles.Add(role);

                await context.DomainUsers.AddAsync(domainUser);
                await context.SaveChangesAsync();
            }

            var identityUser = await userManager.FindByNameAsync(UserConstants.AdminUserName);

            if (identityUser is null)
            {
                ApplicationUser newUser = new()
                {
                    UserId = domainUser.UserId,
                    UserName = UserConstants.AdminUserName,
                    Email = "admin@admin.com"
                };

                var createUserTask = await userManager.CreateAsync(newUser, "Admin+1234");
                if (createUserTask.Succeeded)
                {
                    await userManager.AddToRoleAsync(newUser, UserConstants.AdminRoleName);
                }
            }
        }

        public async static Task SeedUnitsAsync()
        {

        }
    }
}

