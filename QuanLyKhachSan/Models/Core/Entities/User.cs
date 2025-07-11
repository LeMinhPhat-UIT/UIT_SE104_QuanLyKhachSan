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

        public int RoleID { get; set; }

        [Column(TypeName="smalldatetime")]
        public DateTime WorkingDate { get; set; }

        [StringLength(200)]
        [Column(TypeName="varchar")]
        public string EmailAddress { get; set; }

        [StringLength(10)]
        [Column(TypeName="char")]
        public string PhoneNumber { get; set; }
        public List<Invoice> Invoices { get; set; } = new List<Invoice>();
        public List<Reservation> Reservations { get; set; } = new List<Reservation>();
        public List<RevenueReport> RevenueReports { get; set; } = new List<RevenueReport>();

        [ForeignKey("RoleID")]
        public Role Role { get; set; }

        public User() { }
        public User(
            string userName, string password, string identityNumber, bool sex, 
            int role, DateTime workingDate, string emailAddress, string phoneNumber, string address)
        {
            UserName = userName;
            Password = password;
            IdentityNumber = identityNumber;
            RoleID = role;
            WorkingDate = workingDate;
            EmailAddress = emailAddress;
            PhoneNumber = phoneNumber;
        }
    }
}
