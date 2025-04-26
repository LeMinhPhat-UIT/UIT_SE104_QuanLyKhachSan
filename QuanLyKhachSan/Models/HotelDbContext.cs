using System.Windows;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EntityFramework
{
    public class HotelDbContext : DbContext
    {
        public DbSet<Customer> Customer { get; set; }
        public DbSet<CustomerTier> CustomerTier { get; set; }
        public DbSet<Invoice> Invoice { get; set; }
        public DbSet<RevenueDetail> RevenueDetail { get; set; }
        public DbSet<RevenueReport> RevenueReport {  get; set; }
        public DbSet<RentalDetail> RentalDetail { get; set; }
        public DbSet<Rental> Rental { get; set; }
        public DbSet<Room> Room { get; set; }
        public DbSet<RoomTier> RoomTier { get; set; }
        public DbSet<User> User { get; set; }

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
                .HasKey(rentalDetail => new { rentalDetail.RentalID, rentalDetail.CustomerID });
            modelBuilder.Entity<RevenueDetail>()
                .HasKey(revenueDetail => new { revenueDetail.ReportID, revenueDetail.InvoiceID });
            modelBuilder.Entity<Customer>().HasIndex(customer => customer.IdentityNumber).IsUnique();
            modelBuilder.Entity<User>().HasIndex(staff => staff.IdentityNumber).IsUnique();

            modelBuilder.Entity<Invoice>(entity => {
                entity
                    .HasOne(invoice => invoice.User)
                    .WithMany(staff => staff.Invoices)
                    .OnDelete(DeleteBehavior.SetNull);
                entity
                    .HasOne(invoice => invoice.Rental)
                    .WithOne(rental => rental.Invoice)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Customer>(entity => {
                entity
                    .HasMany(customer => customer.RentalDetails)
                    .WithOne(rentalDetail => rentalDetail.Customer)
                    .OnDelete(DeleteBehavior.ClientNoAction);
                entity
                    .HasOne(customer => customer.CustomerTier)
                    .WithMany(customerTier => customerTier.Customers)
                    .OnDelete(DeleteBehavior.SetNull);
            });

            modelBuilder.Entity<User>()
                    .HasMany(user => user.Rentals)
                    .WithOne(rental => rental.User)
                    .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Room>()
                    .HasOne(room => room.RoomTier)
                    .WithMany(roomTier => roomTier.Rooms)
                    .OnDelete(DeleteBehavior.SetNull);
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