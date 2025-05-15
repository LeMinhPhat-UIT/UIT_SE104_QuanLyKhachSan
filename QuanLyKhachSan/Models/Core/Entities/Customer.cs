using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachSan.Models.Core.Entities
{
    public class Customer
    {
        [Key]
        public int CustomerID {  get; set; }
        public int? CustomerTierID { get; set; }

        [StringLength(50)]
        [Column(TypeName="nvarchar")]
        public string CustomerName { get; set; }

        [StringLength(12)]
        [Column(TypeName="char")]
        public string IdentityNumber { get; set; }

        [Column(TypeName="bit")]
        public bool Sex { get; set; }

        [StringLength(100)]
        [Column(TypeName="ntext")]
        public string CustomerAddress { get; set; }

        [StringLength(10)]
        [Column(TypeName="char")]
        public string PhoneNumber { get; set; }


        [ForeignKey("CustomerTierID")]
        public CustomerTier? CustomerTier { get; set; }
        public List<Reservation> Reservations { get; set; } = new List<Reservation>();

        public Customer() { }
        public Customer(
            int customerTierID, string customerName, 
            string identityNumber, bool sex, string customerAddress,
            string phoneNumber)
        {
            CustomerTierID = customerTierID;
            CustomerName = customerName;
            IdentityNumber = identityNumber;
            Sex = sex;
            CustomerAddress = customerAddress;
            PhoneNumber = phoneNumber;
        }
    }
}
