using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MissTortas.Domain.Orders;
using MissTortas.Domain.Payments;
using MissTortas.Domain.Products;
using MissTortas.Domain.Security.Users;
using MissTortas.Infrastructure.Entity;
using MissTortas.Infrastructure.Entity.Orders;
using MissTortas.Infrastructure.Entity.Products;
using MissTortas.Infrastructure.Security.Identity;

namespace MissTortas.Infrastructure.Context
{
    public class MissTortasContext(DbContextOptions options) : IdentityDbContext<ApplicationUser, ApplicationRole, string>(options)
    {
        public DbSet<Unit> Units { get; set; } = default!;
        public DbSet<Product> Products { get; set; } = default!;
        public DbSet<ProductDetail> ProductDetails { get; set; } = default!;
        public DbSet<SaleProduct> SaleProducts { get; set; } = default!;
        public DbSet<ProductCategory> ProductCategories { get; set; } = default!;
        public DbSet<OrderSaleProduct> AskedProducts { get; set; } = default!;
        public DbSet<ProductFile> ProductFiles { get; set; } = default!;

        public DbSet<Order> Orders { get; set; } = default!;
        public DbSet<OrderType> OrderTypes { get; set; } = default!;
        public DbSet<Consultancy> Consultancies { get; set; } = default!;
        public DbSet<OrderPreparation> OrderPreparations { get; set; } = default!;
        public DbSet<ConsultancyFile> ConsultancyFiles { get; set; } = default!;

        public DbSet<Payment> Payments { get; set; } = default!;
        public DbSet<PaymentRequest> PaymentRequests { get; set; } = default!;

        public DbSet<User> DomainUsers { get; set; } = default!;
        public DbSet<Role> DomainRoles { get; set; } = default!;
        public DbSet<RefreshTokenEntity> RefreshTokens { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // non portable syntax
            modelBuilder.Entity<SaleProduct>(sp =>
            {
                sp.ToTable(t => t.HasCheckConstraint("CK_SaleProduct_NonNegativeQuantity", "\"SaleQuantity\" >= 0"));
            });

            modelBuilder.Entity<Unit>(unit =>
            {
                unit.Property(u => u.Name).IsRequired();
                unit.HasIndex(u => u.Name).IsUnique();
            });

            modelBuilder.Entity<RefreshTokenEntity>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Token).IsRequired().HasMaxLength(500);
                entity.Property(e => e.UserId).IsRequired();
                entity.Property(e => e.IsRevoked).HasDefaultValue(false);

                entity.HasIndex(e => e.Token).IsUnique();
                entity.HasIndex(e => e.UserId);
            });
            modelBuilder.Entity<User>(p =>
            {
                p.HasMany(u => u.Roles).WithMany(r => r.Users);
            });
            modelBuilder.Entity<Role>(p =>
            {
                p.HasIndex(r => r.Name).IsUnique();
            });

            modelBuilder.Entity<Consultancy>(c =>
            {
                c.HasOne(c => c.Assignee).WithMany().OnDelete(DeleteBehavior.NoAction);
                c.HasOne(c => c.Client).WithMany().OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<Product>(p =>
            {
                p.HasIndex(p => p.Name).IsUnique();
                p.ToTable(t => t.HasCheckConstraint("CK_Product_NonNegativeQuantity", "\"Quantity\" >= 0"));
                p.HasOne(p => p.SaleProduct)
                    .WithOne(sp => sp.Product)
                    .HasForeignKey<SaleProduct>(sp => sp.ProductId)
                    .IsRequired(false);
            });

            modelBuilder.Entity<ProductCategory>(pc =>
            {
                pc.HasMany(pc => pc.Products).WithOne(p => p.ProductCategory);
                pc.HasOne(p => p.Parent).WithMany(p => p.Children).OnDelete(DeleteBehavior.NoAction);
                pc.HasIndex(u => u.Name).IsUnique();
            });


            modelBuilder.Entity<Order>(o =>
            {
                o.HasMany(o => o.ProductsAsked).WithOne(ps => ps.Order);
                o.HasOne(o => o.Consultancy).WithMany(c => c.Orders).HasForeignKey(o => o.ConsultancyId).OnDelete(DeleteBehavior.Restrict);
                o.HasOne(o => o.PaymentRequest).WithOne(pr => pr.Order).HasForeignKey<PaymentRequest>(pr => pr.OrderId);
            });

            modelBuilder.Entity<OrderSaleProduct>(osp =>
            {
                osp.HasIndex(osp => new { osp.OrderId, osp.SaleProductId });
                osp.HasOne(orderSaleProduct => orderSaleProduct.SaleProduct).WithMany(sp => sp.OrderSaleProducts).OnDelete(DeleteBehavior.Restrict);
                osp.HasOne(orderSaleProduct => orderSaleProduct.Order).WithMany(o => o.ProductsAsked).OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<OrderPreparation>()
                .HasOne(op => op.Assignee)
                .WithMany(assignee => assignee.Preparations);

            modelBuilder.Entity<ConsultancyFile>()
                .HasOne(c => c.Consultancy)
                .WithMany();

            modelBuilder.Entity<PaymentRequest>()
                .HasOne(pr => pr.Payment)
                .WithOne(p => p.PaymentRequest)
                .HasForeignKey<Payment>(p => p.PaymentRequestId)
                .OnDelete(DeleteBehavior.Restrict);
        }

    }
}
