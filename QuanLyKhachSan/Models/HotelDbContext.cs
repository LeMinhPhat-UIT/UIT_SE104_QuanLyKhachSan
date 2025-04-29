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

            modelBuilder.Entity<Rental>(entity =>
            {
                entity
                    .HasOne(x => x.Invoice)
                    .WithOne(y => y.Rental)
                    .OnDelete(DeleteBehavior.Cascade);
                entity
                    .HasOne(x => x.Room)
                    .WithMany(y => y.Rentals)
                    .OnDelete(DeleteBehavior.Restrict);
                entity
                    .HasMany(x => x.RentalDetails)
                    .WithOne(y => y.Rental)
                    .OnDelete(DeleteBehavior.Cascade);
                entity
                    .HasOne(x => x.User)
                    .WithMany(y => y.Rentals)
                    .OnDelete(DeleteBehavior.SetNull);
            });

            modelBuilder.Entity<RevenueReport>(entity =>
            {
                entity
                    .HasOne(x => x.RoomTier)
                    .WithMany(y => y.RevenueReports)
                    .OnDelete(DeleteBehavior.Restrict);
                entity
                    .HasMany(x => x.RevenueDetails)
                    .WithOne(y => y.Report)
                    .OnDelete(DeleteBehavior.Cascade);
                entity
                    .HasOne(x => x.User)
                    .WithMany(y => y.RevenueReports)
                    .OnDelete(DeleteBehavior.SetNull);
            });

            modelBuilder.Entity<Invoice>(entity => 
            {
                entity
                    .HasOne(x => x.User)
                    .WithMany(y => y.Invoices)
                    .OnDelete(DeleteBehavior.SetNull);
                entity
                    .HasMany(x => x.RevenueDetails)
                    .WithOne(y => y.Invoice)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Customer>(entity => 
            {
                entity
                    .HasOne(x => x.CustomerTier)
                    .WithMany(y => y.Customers)
                    .OnDelete(DeleteBehavior.SetNull);
                entity
                    .HasMany(x => x.RentalDetails)
                    .WithOne(y => y.Customer)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Room>(entity =>
            {
                entity
                    .HasOne(x => x.RoomTier)
                    .WithMany(y => y.Rooms)
                    .OnDelete(DeleteBehavior.SetNull);
            });

            //Constraints
            modelBuilder.Entity<Customer>().ToTable(x =>
            {
                x.HasCheckConstraint("CK_Customer_PhoneNumber", "LEN(PhoneNumber)=10");
                x.HasCheckConstraint("CK_Customer_IdentityNumber", "LEN(IdentityNumber)=12");
                x.HasCheckConstraint("CK_Customer_Sex", "Sex IN (1,0)");
            });

            modelBuilder.Entity<User>().ToTable(x =>
            {
                x.HasCheckConstraint("CK_User_PhoneNumber", "LEN(PhoneNumber)=10");
                x.HasCheckConstraint("CK_User_IdentityNumber", "LEN(IdentityNumber)=12");
                x.HasCheckConstraint("CK_User_Sex", "Sex IN (1,0)");
            });

            modelBuilder.Entity<RentalDetail>().ToTable(
                x => x.HasCheckConstraint("CK_RentalDetail_IsRepresentative", "IsRepresentative IN (1,0)")
            );

            modelBuilder.Entity<Room>().ToTable(
                x => x.HasCheckConstraint("CK_Room_RoomState", "RoomState IN ('available', 'occupied')")
            );

            modelBuilder.Entity<Rental>().ToTable(x => 
            {
                x.HasCheckConstraint("CK_Rental_Status", "Status IN ('Pending', 'CheckIn', 'CheckOut', 'Cancelled')");
                x.HasCheckConstraint("CK_Rental_CheckOutDate", "CheckOutDate > CheckInDate");
            });

            modelBuilder.Entity<Invoice>().ToTable(x =>
                x.HasCheckConstraint("CK_Invoice_TotalAmount", "TotalAmount = TotalDays*PricePerDay*(1+SurchargeRate/100)")
            );
        }

        public DbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }

        public static void CreateDatabase()
        {
            using var dbcontext = new HotelDbContext();
            string dbname = dbcontext.Database.GetDbConnection().Database;
            if (dbcontext.Database.EnsureCreated())
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