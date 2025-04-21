using System.Windows;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EntityFramework
{
    public class HotelDbContext : DbContext
    {
        public DbSet<Account> Account {  get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<CustomerTier> CustomerTier { get; set; }
        public DbSet<Invoice> Invoice { get; set; }
        public DbSet<InvoiceDetail> InvoiceDetail { get; set; }
        public DbSet<MonthlyRevenueDetail> MonthlyRevenueDetail { get; set; }
        public DbSet<MonthlyRevenueReport> MonthlyRevenueReport {  get; set; }
        public DbSet<RentalDetail> RentalDetail { get; set; }
        public DbSet<RentalForm> RentalForm { get; set; }
        public DbSet<Room> Room { get; set; }
        public DbSet<RoomTier> RoomTier { get; set; }
        public DbSet<Staff> Staff { get; set; }

        // chỉnh lại cho phù hợp tên server trên máy cá nhân
        private const string connectionString =
            @"
            Data Source=MSI\SQLEXPRESS;
            Initial Catalog=HotelData;
            Integrated Security=True;
            Trust Server Certificate=True";

        public static readonly ILoggerFactory loggerFactory = LoggerFactory.Create(builder =>
        {
            builder.AddFilter(DbLoggerCategory.Query.Name, LogLevel.Information);
            builder.AddConsole();
        });

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(connectionString);
            //optionsBuilder.UseLoggerFactory(loggerFactory);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<RentalDetail>()
                .HasKey(rentalDetail => new { rentalDetail.RentalFormID, rentalDetail.CustomerID });
            modelBuilder.Entity<InvoiceDetail>()
                .HasKey(invoiceDetail => new {invoiceDetail.InvoiceID, invoiceDetail.CustomerID });
            modelBuilder.Entity<MonthlyRevenueDetail>()
                .HasKey(revenueDetail => new { revenueDetail.ReportMonth, revenueDetail.RoomTierID });
            modelBuilder.Entity<Customer>().HasIndex(customer => customer.IdentityNumber).IsUnique();
            modelBuilder.Entity<Staff>().HasIndex(staff => staff.IdentityNumber).IsUnique();

            modelBuilder.Entity<Invoice>(entity => {
                entity
                    .HasOne(invoice => invoice.Staff)
                    .WithMany(staff => staff.Invoices)
                    .OnDelete(DeleteBehavior.SetNull);
                entity
                    .HasOne(invoice => invoice.RentalForm)
                    .WithOne(rentalForm => rentalForm.Invoice)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Customer>(entity => {
                entity
                    .HasMany(customer => customer.InvoiceDetails)
                    .WithOne(invoiceDetail => invoiceDetail.Customer)
                    .OnDelete(DeleteBehavior.Restrict);
                entity
                    .HasMany(customer => customer.RentalDetails)
                    .WithOne(rentalDetail => rentalDetail.Customer)
                    .OnDelete(DeleteBehavior.Restrict);
                entity
                    .HasOne(customer => customer.CustomerTier)
                    .WithMany(customerTier => customerTier.Customers)
                    .OnDelete(DeleteBehavior.SetNull);
            });
        }

        public static void CreateDatabase()
        {
            using var dbcontext = new HotelDbContext();
            string dbname = dbcontext.Database.GetDbConnection().Database;
            var result = dbcontext.Database.EnsureCreated();
            if (result)
                MessageBox.Show($"database '{dbname}' was created successfully");
            else
                MessageBox.Show($"failed to create database '{dbname}'");
        }
        public static void DropDatabase()
        {
            using var dbcontext = new HotelDbContext();
            string dbname = dbcontext.Database.GetDbConnection().Database;
            var result = dbcontext.Database.EnsureDeleted();
            if (result)
                MessageBox.Show($"database '{dbname}' was deleted successfully");
            else
                MessageBox.Show($"failed to delete database '{dbname}'");
        }
    }
}