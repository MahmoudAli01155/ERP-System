using Domain.Common;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
             : base(options)
        {
        }


        #region HR Module

        public DbSet<Employee> Employees => Set<Employee>();
        public DbSet<Department> Departments => Set<Department>();
        public DbSet<Attendance> Attendances => Set<Attendance>();
        public DbSet<Leave> Leaves => Set<Leave>();
        public DbSet<Payroll> Payrolls => Set<Payroll>();

        #endregion

        #region Commerce Module

        public DbSet<Category> Categories => Set<Category>();
        public DbSet<Product> Products => Set<Product>();
        public DbSet<Cart> Carts => Set<Cart>();
        public DbSet<Order> Orders => Set<Order>();
        public DbSet<Payment> Payments => Set<Payment>();

        #endregion

        #region SupplyChain Module

        public DbSet<Warehouse> Warehouses => Set<Warehouse>();
        public DbSet<Inventory> Inventories => Set<Inventory>();
        public DbSet<StockMovement> StockMovements => Set<StockMovement>();
        public DbSet<Shipment> Shipments => Set<Shipment>();

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            ApplyHRConfigurations(modelBuilder);
            ApplyCommerceConfigurations(modelBuilder);
            ApplySupplyChainConfigurations(modelBuilder);

            ApplyGlobalFilters(modelBuilder);
        }

        // ================= HR =================
        #region HR ModelBuilder
        private void ApplyHRConfigurations(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Employee>().ToTable("Employees", "hr");
            modelBuilder.Entity<Department>().ToTable("Departments", "hr");
            modelBuilder.Entity<Attendance>().ToTable("Attendances", "hr");
            modelBuilder.Entity<Leave>().ToTable("Leaves", "hr");
            modelBuilder.Entity<Payroll>().ToTable("Payrolls", "hr");
            // Employee
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasIndex(e => e.Email).IsUnique();

                entity.Property(e => e.Salary)
                      .HasPrecision(18, 2);

                entity.HasOne(e => e.Department)
                      .WithMany(d => d.Employees)
                      .HasForeignKey(e => e.DepartmentId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // Attendance
            modelBuilder.Entity<Attendance>(entity =>
            {
                entity.HasOne(a => a.Employee)
                      .WithMany(e => e.Attendances)
                      .HasForeignKey(a => a.EmployeeId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            // Leave
            modelBuilder.Entity<Leave>(entity =>
            {
                entity.HasOne(l => l.Employee)
                      .WithMany(e => e.Leaves)
                      .HasForeignKey(l => l.EmployeeId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // Payroll
            modelBuilder.Entity<Payroll>(entity =>
            {
                entity.HasOne(p => p.Employee)
                      .WithMany(e => e.Payrolls)
                      .HasForeignKey(p => p.EmployeeId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.Property(p => p.BaseSalary).HasPrecision(18, 2);
                entity.Property(p => p.Bonuses).HasPrecision(18, 2);
                entity.Property(p => p.Deductions).HasPrecision(18, 2);
                entity.Property(p => p.NetSalary).HasPrecision(18, 2);
            });
        }
        #endregion
        // ================= E-Commerce =================
        #region E-Commerce ModelBuilder
        private void ApplyCommerceConfigurations(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Category>().ToTable("Categories", "commerce");
            modelBuilder.Entity<Product>().ToTable("Products", "commerce");
            modelBuilder.Entity<Cart>().ToTable("Carts", "commerce");
            modelBuilder.Entity<Order>().ToTable("Orders", "commerce");
            modelBuilder.Entity<Payment>().ToTable("Payments", "commerce");
            // Category
            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(c => c.ArName)
                      .IsRequired()
                      .HasMaxLength(200);

                entity.Property(c => c.EnName)
                      .IsRequired()
                      .HasMaxLength(200);
            });

            // Product
            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(c => c.ArName)
                      .IsRequired()
                      .HasMaxLength(200);

                entity.Property(c => c.EnName)
                      .IsRequired()
                      .HasMaxLength(200);

                entity.Property(p => p.Price)
                      .HasPrecision(18, 2);

                entity.HasOne(p => p.Category)
                      .WithMany(c => c.Products)
                      .HasForeignKey(p => p.CategoryId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasIndex(p => p.Price);
                entity.HasIndex(p => p.CategoryId);
            });

            // Cart
            //modelBuilder.Entity<Cart>(entity =>
            //{
            ////    entity.HasMany(c => c.Items)
            ////                    .WithOne()
            ////.OnDelete(DeleteBehavior.Cascade);
            //});

            // CartItem (Owned 🔥)
            modelBuilder.Entity<Cart>()
                .OwnsMany(c => c.Items, item =>
                {
                    item.WithOwner().HasForeignKey("CartId");

                    item.Property<Guid>("Id");
                    item.HasKey("Id");

                    item.Property(i => i.Quantity).IsRequired();
                });

            // Order
            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(o => o.TotalAmount)
                      .HasPrecision(18, 2);

                //entity.HasMany(o => o.Items)
                //      .WithOne()
                //      .OnDelete(DeleteBehavior.Cascade);
            });

            // OrderItem (Owned 🔥)
            modelBuilder.Entity<Order>()
                .OwnsMany(o => o.Items, item =>
                {
                    item.WithOwner().HasForeignKey("OrderId");

                    item.Property<Guid>("Id");
                    item.HasKey("Id");

                    item.Property(i => i.Price)
                        .HasPrecision(18, 2);
                });

            // Payment
            modelBuilder.Entity<Payment>(entity =>
            {
                entity.Property(p => p.Amount)
                      .HasPrecision(18, 2);

                entity.HasOne(p => p.Order)
                      .WithOne()
                      .HasForeignKey<Payment>(p => p.OrderId);
            });
        }
        #endregion
        // ================= SupplyChain =================
        #region SupplyChain ModelBuilder
        private void ApplySupplyChainConfigurations(ModelBuilder modelBuilder)
        {
            // ================= Warehouse =================
            modelBuilder.Entity<Warehouse>(entity =>
            {
                entity.ToTable("Warehouses", "supplychain");

                entity.Property(w => w.ArName)
                      .IsRequired()
                      .HasMaxLength(200);

                entity.Property(w => w.EnName)
                      .IsRequired()
                      .HasMaxLength(200);

                entity.Property(w => w.Location)
                      .IsRequired()
                      .HasMaxLength(300);

                entity.HasIndex(w => w.ArName).IsUnique();
            });

            // ================= Inventory =================
            modelBuilder.Entity<Inventory>(entity =>
            {
                entity.ToTable("Inventories", "supplychain");

                entity.HasKey(i => new { i.WarehouseId, i.ProductId });

                entity.Property(i => i.Quantity)
                      .IsRequired();

                entity.HasOne(i => i.Warehouse)
                      .WithMany(w => w.Inventories)
                      .HasForeignKey(i => i.WarehouseId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(i => i.Product)
                      .WithMany(p => p.Inventories)
                      .HasForeignKey(i => i.ProductId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // ================= Stock Movement =================
            modelBuilder.Entity<StockMovement>(entity =>
            {
                entity.ToTable("StockMovements", "supplychain");

                entity.Property(m => m.Quantity)
                      .IsRequired();

                entity.HasIndex(m => m.ProductId);
                entity.HasIndex(m => m.WarehouseId);
                entity.HasIndex(m => m.CreatedAt);

                entity.Property(m => m.Type)
                      .IsRequired();
            });

            // ================= Shipment =================
            modelBuilder.Entity<Shipment>(entity =>
            {
                entity.ToTable("Shipments", "supplychain");

                entity.Property(s => s.DeliveryAddress)
                      .IsRequired()
                      .HasMaxLength(500);

                entity.Property(s => s.Status)
                      .IsRequired();

                entity.HasOne<Order>()
                      .WithOne()
                      .HasForeignKey<Shipment>(s => s.OrderId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne<Warehouse>()
                      .WithMany()
                      .HasForeignKey(s => s.WarehouseId)
                      .OnDelete(DeleteBehavior.Restrict);
            });
        }
        #endregion



        private void ApplyGlobalFilters(ModelBuilder modelBuilder)
        {
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                if (typeof(BaseEntity).IsAssignableFrom(entityType.ClrType))
                {
                    var method = typeof(ApplicationDBContext)
                        .GetMethod(nameof(SetSoftDeleteFilter),
                            BindingFlags.NonPublic | BindingFlags.Static)
                        ?.MakeGenericMethod(entityType.ClrType);

                    method?.Invoke(null, new object[] { modelBuilder });
                }
            }
        }

        private static void SetSoftDeleteFilter<T>(ModelBuilder modelBuilder)
            where T : BaseEntity
        {
            modelBuilder.Entity<T>().HasQueryFilter(e => !e.IsDeleted);
        }

        // ================= Global Filters (Soft Delete 🔥) =================
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}
