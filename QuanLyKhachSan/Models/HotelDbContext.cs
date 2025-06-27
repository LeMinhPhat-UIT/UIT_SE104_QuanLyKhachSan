using System.Windows;
using System.Windows.Media.Media3D;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using QuanLyKhachSan.Models.Core.Entities;

namespace EntityFramework
{
    public class HotelDbContext : DbContext
    {
        public DbSet<Amenity> Amenity { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<CustomerTier> CustomerTier { get; set; }
        public DbSet<Invoice> Invoice { get; set; }
        public DbSet<RevenueReport> RevenueReport {  get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<Reservation> Reservation { get; set; }
        public DbSet<Room> Room { get; set; }
        public DbSet<RoomTier> RoomTier { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Rule> Rule { get; set; }

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
            modelBuilder.Entity<Customer>().HasIndex(customer => customer.IdentityNumber).IsUnique();
            modelBuilder.Entity<User>().HasIndex(staff => staff.IdentityNumber).IsUnique();

            modelBuilder.Entity<Reservation>(entity =>
            {
                entity
                    .HasOne(x => x.Invoice)
                    .WithOne(y => y.Reservation)
                    .HasForeignKey<Invoice>(x => x.ReservationID)
                    .OnDelete(DeleteBehavior.Cascade);
                entity
                    .HasOne(x => x.Room)
                    .WithMany(y => y.Reservations)
                    .OnDelete(DeleteBehavior.Restrict);
                entity
                    .HasMany(x => x.Customers)
                    .WithMany(y => y.Reservations)
                    .UsingEntity(x => x.ToTable("Reservation_Customer"));
                entity
                    .HasOne(x => x.User)
                    .WithMany(y => y.Reservations)
                    .OnDelete(DeleteBehavior.SetNull);
            });

            modelBuilder.Entity<RevenueReport>(entity =>
            {
                entity
                    .HasOne(x => x.RoomTier)
                    .WithMany(y => y.RevenueReports)
                    .OnDelete(DeleteBehavior.Restrict);
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
            });

            modelBuilder.Entity<Customer>(entity => 
            {
                entity
                    .HasOne(x => x.CustomerTier)
                    .WithMany(y => y.Customers)
                    .OnDelete(DeleteBehavior.SetNull);
            });

            modelBuilder.Entity<Room>(entity =>
            {
                entity
                    .HasOne(x => x.RoomTier)
                    .WithMany(y => y.Rooms)
                    .OnDelete(DeleteBehavior.SetNull);
                entity
                    .HasMany(x => x.Amenities)
                    .WithMany(y => y.Rooms)
                    .UsingEntity(x => x.ToTable("Room_Amenity"));
            });
        }

        public DbSet<T> Set<T>() where T : class
            => base.Set<T>();

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