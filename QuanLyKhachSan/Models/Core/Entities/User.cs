using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachSan.Models.Core.Entities
{
    public class User
    {
        [Key]
        public int UserID { get; set; }

        [StringLength(50)]
        [Column(TypeName="nvarchar")]
        public string UserName { get; set; }

        [StringLength(200)]
        [Column(TypeName="varchar")]
        public string Password { get; set; }

        [StringLength(12)]
        [Column(TypeName="char")]
        public string IdentityNumber {  get; set; }

        [Column(TypeName = "bit")]
        public bool Sex { get; set; }

        [StringLength(50)]
        [Column(TypeName="nvarchar")]
        public string Role { get; set; }

        [Column(TypeName="smalldatetime")]
        public DateTime WorkingDate { get; set; }

        [StringLength(20)]
        [Column(TypeName="char")]
        public string EmailAddress { get; set; }

        [StringLength(10)]
        [Column(TypeName="char")]
        public string PhoneNumber { get; set; }

        [StringLength(100)]
        [Column(TypeName="ntext")]
        public string Address { get; set; }
        public List<Invoice> Invoices { get; set; } = new List<Invoice>();
        public List<Reservation> Reservations { get; set; } = new List<Reservation>();
        public List<RevenueReport> RevenueReports { get; set; } = new List<RevenueReport>();

        public User() { }
        public User(
            string userName, string password, string identityNumber, bool sex, 
            string role, DateTime workingDate, string emailAddress, string phoneNumber, string address)
        {
            UserName = userName;
            Password = password;
            IdentityNumber = identityNumber;
            Role = role;
            WorkingDate = workingDate;
            EmailAddress = emailAddress;
            PhoneNumber = phoneNumber;
            Address = address;
        }
    }
}
